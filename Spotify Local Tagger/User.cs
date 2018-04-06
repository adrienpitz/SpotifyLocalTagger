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
        private SpotifyWebAPI _spotifyAPI;
        GUI _theGui;
        PrivateProfile _profile;
        List<SimplePlaylist> _playlists;
        List<PlaylistTrack> _spotifyTrackSet;
        List<TagLib.File> _mp3TrackSet;

        List<LocalSong> _localSongs;
        List<SpotifySong> _spotifySongs;


        public User(GUI gui)
        {
            _theGui = gui;
            connect();
            _mp3TrackSet = new List<TagLib.File>();
            _spotifyTrackSet = new List<PlaylistTrack>();
            _localSongs = new List<LocalSong>();
            _spotifySongs = new List<SpotifySong>();
            while(_spotifyAPI == null) { }
            initComponents();

        }

        private async void connect()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory("http://localhost", 8888, "6ac9eb8c694441748f29683de12b50b7", SpotifyAPI.Web.Enums.Scope.UserReadPrivate, TimeSpan.FromSeconds(20));

            try
            {
                _spotifyAPI = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                _theGui.showMessageBox(ex.Message);
            }
        }

        private void initComponents()
        {
            _profile = _spotifyAPI.GetPrivateProfile();
            _playlists = getPlaylists();
        }

        public bool isConnexionOK()
        {
            return _spotifyAPI != null;
        }

        private List<SimplePlaylist> getPlaylists()
        {
            Paging<SimplePlaylist> playlists = _spotifyAPI.GetUserPlaylists(_profile.Id);
            List<SimplePlaylist> list = playlists.Items.ToList();

            while(playlists.Next != null)
            {
                playlists = _spotifyAPI.GetUserPlaylists(_profile.Id, 20, playlists.Offset + playlists.Limit);
                list.AddRange(playlists.Items);
            }

            return list;
        }

        public async void setProfilePic(PictureBox profilePicBox)
        {

            if(_profile.Images != null && _profile.Images.Count > 0)
            {
                using (WebClient wc = new WebClient())
                {
                    byte[] imageBytes = await wc.DownloadDataTaskAsync(new Uri(_profile.Images[0].Url));
                    using (MemoryStream stream = new MemoryStream(imageBytes))
                        profilePicBox.Image = System.Drawing.Image.FromStream(stream);
                }
            }
        }

        public String getName()
        {
            return _profile.DisplayName;
        }

        public String getCountry()
        {
            return _profile.Country;
        }

        public String getFollowers()
        {
            return _profile.Followers.Total.ToString();
        }

        public int getNbPlaylists()
        {
            return _playlists.Count;
        }

        public List<String> getPlaylistsAsStrings()
        {
            List<String> thePlaylists = new List<string>();

            foreach(SimplePlaylist playlist in _playlists)
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

        public List<string> getLocalSongsAsStrings()
        {
            List<string> theSongsItems = new List<string>();

            foreach(LocalSong song in _localSongs)
            {
                theSongsItems.Add(Path.GetFileName(song.getTrack().Name));
            }

            return theSongsItems;
        }

        public List<ListViewItem> getLocalSongsAsStrings(String pathToFolder)
        {
            List<ListViewItem> theSongsItems = new List<ListViewItem>();

            _mp3TrackSet.Clear();

            List<String> pathsList = new List<string>();

            ProcessDirectory(pathToFolder, pathsList);

            //Now that we have the paths, we will complete the list with taglib instances
            foreach(string path in pathsList)
            {
                TagLib.File file = TagLib.File.Create(path);
                if(file != null)
                {
                    _mp3TrackSet.Add(file);
                }
            }

            foreach(TagLib.File file in _mp3TrackSet)
            {
                ListViewItem theItem = new ListViewItem(new string[] { Path.GetFileName(file.Name) });
                theItem.ImageIndex = 0;
                theSongsItems.Add(theItem);
            }

            return theSongsItems;
        }

        public List<string> getSongsOfPlaylistAsStrings()
        {
            List<string> theSongs = new List<string>();

            foreach(SpotifySong song in _spotifySongs)
            {
                theSongs.Add(song.getPerformers()[0] + " - " + song.getTitle());
            }

            return theSongs;
        }

        public List<ListViewItem> getSongsOfPlaylistAsStrings(int playlistId)
        {
            List<ListViewItem> theSongs = new List<ListViewItem>();

            SimplePlaylist thePlaylist = _playlists.ElementAt(playlistId);

            _spotifyTrackSet = new List<PlaylistTrack>();

            Paging<PlaylistTrack> tracks = _spotifyAPI.GetPlaylistTracks(_profile.Id, thePlaylist.Id);

            //tracks.Items.ForEach(track => trackSet.Add(track));

            if (tracks.Items != null)
            {
                int i = 100;

                while (true)
                {
                    Paging<PlaylistTrack> temp = _spotifyAPI.GetPlaylistTracks(_profile.Id, thePlaylist.Id, "", 100, i);
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
                        _spotifyTrackSet.Add(track);
                }
            }

            foreach(PlaylistTrack track in _spotifyTrackSet)
            {
                ListViewItem theItem = new ListViewItem(new string[] { track.Track.Name, track.Track.Artists[0].Name, track.Track.Album.Name });
                theItem.ImageIndex = 0;
                theSongs.Add(theItem);
            }

            return theSongs;
        }

        public void fillLocalSongs()
        {

            _localSongs.Clear();

            foreach(TagLib.File file in _mp3TrackSet)
            {
                LocalSong song = new LocalSong(file);
                if(song != null)
                {
                    _localSongs.Add(song);
                }
            }
        }

        public void fillSpotifySongs()
        {

            _spotifySongs.Clear();

            //TODO : Perform the operation in // ?
            foreach(PlaylistTrack spotifyTrack in _spotifyTrackSet)
            {
                SpotifySong song = new SpotifySong(spotifyTrack, _spotifyAPI);
                if (song != null)
                {
                    _spotifySongs.Add(song);
                }
            }
        }

        public void matchSongs()
        {
            MergingFactory.process(_localSongs, _spotifySongs);
        }

        public void matchSongs(int idLocal, int idSpotify)
        {
            MergingFactory.mergeTags(_spotifySongs.ElementAt(idSpotify), _localSongs.ElementAt(idLocal));
            _spotifySongs.RemoveAt(idSpotify);
            _localSongs.RemoveAt(idLocal);
        }

        public int getNbLocalSongs()
        {
            return _localSongs.Count;
        }
    }
}
