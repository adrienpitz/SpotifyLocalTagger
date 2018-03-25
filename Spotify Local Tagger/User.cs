using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Local_Tagger
{
    public class User
    {
        private SpotifyWebAPI spotifyAPI;
        GUI theGui;
        PrivateProfile profile;
        List<SimplePlaylist> playlists;
        List<PlaylistTrack> spotifyTrackSet;
        List<TagLib.File> mp3TrackSet;

        List<LocalSong> localSongs;
        List<SpotifySong> spotifySongs;


        public User(GUI gui)
        {
            theGui = gui;
            connect();
            mp3TrackSet = new List<TagLib.File>();
            spotifyTrackSet = new List<PlaylistTrack>();
            localSongs = new List<LocalSong>();
            spotifySongs = new List<SpotifySong>();
            while(spotifyAPI == null) { }
            initComponents();

        }

        private async void connect()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory("http://localhost", 8888, "6ac9eb8c694441748f29683de12b50b7", SpotifyAPI.Web.Enums.Scope.UserReadPrivate, TimeSpan.FromSeconds(20));

            try
            {
                spotifyAPI = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                theGui.showMessageBox(ex.Message);
            }
        }

        private void initComponents()
        {
            profile = spotifyAPI.GetPrivateProfile();
            playlists = getPlaylists();
        }

        public bool isConnexionOK()
        {
            return spotifyAPI == null;
        }

        private List<SimplePlaylist> getPlaylists()
        {
            Paging<SimplePlaylist> playlists = spotifyAPI.GetUserPlaylists(profile.Id);
            List<SimplePlaylist> list = playlists.Items.ToList();

            while(playlists.Next != null)
            {
                playlists = spotifyAPI.GetUserPlaylists(profile.Id, 20, playlists.Offset + playlists.Limit);
                list.AddRange(playlists.Items);
            }

            return list;
        }

        public async void setProfilePic(PictureBox profilePicBox)
        {

            if(profile.Images != null && profile.Images.Count > 0)
            {
                using (WebClient wc = new WebClient())
                {
                    byte[] imageBytes = await wc.DownloadDataTaskAsync(new Uri(profile.Images[0].Url));
                    using (MemoryStream stream = new MemoryStream(imageBytes))
                        profilePicBox.Image = System.Drawing.Image.FromStream(stream);
                }
            }
        }

        public String getName()
        {
            return profile.DisplayName;
        }

        public String getCountry()
        {
            return profile.Country;
        }

        public String getFollowers()
        {
            return profile.Followers.Total.ToString();
        }

        public int getNbPlaylists()
        {
            return playlists.Count;
        }

        public List<String> getPlaylistsAsStrings()
        {
            List<String> thePlaylists = new List<string>();

            foreach(SimplePlaylist playlist in playlists)
            {
                thePlaylists.Add(playlist.Name);
            }
            
            return thePlaylists;
        }


        private void ProcessDirectory(string targetDirectory, List<String> toComplete)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.mp3");
            foreach (string fileName in fileEntries)
                toComplete.Add(fileName);

            string[] subDirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subDirectory in subDirectoryEntries)
                ProcessDirectory(subDirectory, toComplete);
        }


        public List<ListViewItem> getLocalSongsAsStrings(String pathToFolder)
        {
            List<ListViewItem> theSongsItems = new List<ListViewItem>();

            mp3TrackSet.Clear();

            List<String> pathsList = new List<string>();

            ProcessDirectory(pathToFolder, pathsList);

            //Now that we have the paths, we will complete the list with taglib instances
            foreach(string path in pathsList)
            {
                TagLib.File file = TagLib.File.Create(path);
                if(file != null)
                {
                    mp3TrackSet.Add(file);
                }
            }

            foreach(TagLib.File file in mp3TrackSet)
            {
                ListViewItem theItem = new ListViewItem(new string[] { Path.GetFileName(file.Name) });
                theItem.ImageIndex = 0;
                theSongsItems.Add(theItem);
            }

            return theSongsItems;
        }

        public List<ListViewItem> getSongsOfPlaylistAsStrings(int playlistId)
        {
            List<ListViewItem> theSongs = new List<ListViewItem>();

            SimplePlaylist thePlaylist = playlists.ElementAt(playlistId);

            spotifyTrackSet = new List<PlaylistTrack>();

            Paging<PlaylistTrack> tracks = spotifyAPI.GetPlaylistTracks(profile.Id, thePlaylist.Id);

            //tracks.Items.ForEach(track => trackSet.Add(track));

            if (tracks.Items != null)
            {
                int i = 100;

                while (true)
                {
                    Paging<PlaylistTrack> temp = spotifyAPI.GetPlaylistTracks(profile.Id, thePlaylist.Id, "", 100, i);
                    if (temp != null && temp.Items != null && temp.Items.Count > 0)
                    {
                        foreach (PlaylistTrack playTrack in temp.Items)
                            tracks.Items.Add(playTrack);
                        i += 100;
                    }
                    else
                        break;
                }

                foreach (PlaylistTrack track in tracks.Items)
                {
                    if (track != null)
                        spotifyTrackSet.Add(track);
                }
            }

            foreach(PlaylistTrack track in spotifyTrackSet)
            {
                ListViewItem theItem = new ListViewItem(new string[] { track.Track.Name, track.Track.Artists[0].Name, track.Track.Album.Name });
                theItem.ImageIndex = 0;
                theSongs.Add(theItem);
            }

            return theSongs;
        }

        public void fillLocalSongs()
        {

            localSongs.Clear();

            foreach(TagLib.File file in mp3TrackSet)
            {
                LocalSong song = new LocalSong(file);
                if(song != null)
                {
                    localSongs.Add(song);
                }
            }
        }

        public void fillSpotifySongs()
        {

            spotifySongs.Clear();

            //TODO : Perform the operation in // ?
            foreach(PlaylistTrack spotifyTrack in spotifyTrackSet)
            {
                SpotifySong song = new SpotifySong(spotifyTrack, spotifyAPI);
                if (song != null)
                {
                    spotifySongs.Add(song);
                }
            }
        }

        public void matchSongs()
        {
            MergingFactory.process(localSongs, spotifySongs);
        }

        public int getNbLocalSongs()
        {
            return localSongs.Count;
        }
    }
}
