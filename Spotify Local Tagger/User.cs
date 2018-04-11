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
    /// <summary>
    /// All useful informations about the user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The Spotify API.
        /// </summary>
        private SpotifyWebAPI _spotifyAPI;
        /// <summary>
        /// Instance of the GUI.
        /// </summary>
        GUI _theGui;
        /// <summary>
        /// All infos of the profile of the user.
        /// </summary>
        PrivateProfile _profile;
        /// <summary>
        /// All playlists of the user.
        /// </summary>
        List<SimplePlaylist> _playlists;
        /// <summary>
        /// Tracks of the Spotify playlist under supervision.
        /// </summary>
        List<PlaylistTrack> _spotifyTrackSet;
        /// <summary>
        /// Tracks of the Local folder under supervision.
        /// </summary>
        List<TagLib.File> _mp3TrackSet;
        /// <summary>
        /// List of instances of LocalSong.
        /// </summary>
        List<LocalSong> _localSongs;
        /// <summary>
        /// List of instances of SpotifySong.
        /// </summary>
        List<SpotifySong> _spotifySongs;

        /// <summary>
        /// Initialize all the lists and connects to Spotify
        /// through the web.
        /// </summary>
        /// <param name="gui">Instance of the GUI</param>
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

        /// <summary>
        /// Initialize all the lists and connects to Spotify
        /// through the web.
        /// </summary>
        public User()
        {
            connect();
            _mp3TrackSet = new List<TagLib.File>();
            _spotifyTrackSet = new List<PlaylistTrack>();
            _localSongs = new List<LocalSong>();
            _spotifySongs = new List<SpotifySong>();
            while (_spotifyAPI == null) { }
            initComponents();
        }

        /// <summary>
        /// Connects to the API.
        /// </summary>
        /// <remarks>
        /// If the connexion fails, a message box will open to inform the user.
        /// </remarks>
        private async void connect()
        {
            WebAPIFactory webApiFactory = new WebAPIFactory("http://localhost", 8888, "6ac9eb8c694441748f29683de12b50b7", SpotifyAPI.Web.Enums.Scope.UserReadPrivate, TimeSpan.FromSeconds(25));

            try
            {
                _spotifyAPI = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                _theGui.showMessageBox(ex.Message);
            }
        }

        /// <summary>
        /// Get the private profile of the user and get his/her playlists.
        /// </summary>
        private void initComponents()
        {
            _profile = _spotifyAPI.GetPrivateProfile();
            _playlists = getPlaylists();
        }

        /// <summary>
        /// Check if the instance of the API is well initialized.
        /// </summary>
        /// <returns>true if the connexion was ok, false otherwise.</returns>
        public bool isConnexionOK()
        {
            return _spotifyAPI != null;
        }

        /// <summary>
        /// Get the playlists created and followed by the user.
        /// </summary>
        /// <returns>The list of playlists created and followed by the user.</returns>
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

        /// <summary>
        /// Set the profile picture of the user in the picturebox on the main Form.
        /// </summary>
        /// <param name="profilePicBox">The instance of the picturebox.</param>
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

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <returns>The name of the user.</returns>
        public String getName()
        {
            return _profile.DisplayName;
        }

        /// <summary>
        /// Getter for the 2 letters ID of the country of the user.
        /// </summary>
        /// <returns>The 2 letters ID of the country.</returns>
        public String getCountry()
        {
            return _profile.Country;
        }

        /// <summary>
        /// Get the number of followers of the user.
        /// </summary>
        /// <returns>The number of followers of the user as string object.</returns>
        public String getFollowers()
        {
            return _profile.Followers.Total.ToString();
        }

        /// <summary>
        /// Get the number of playlists created and followed by the user.
        /// </summary>
        /// <returns>The number of playlists created and followed by the user.</returns>
        public int getNbPlaylists()
        {
            return _playlists.Count;
        }

        /// <summary>
        /// Get the playlist names of the user.
        /// </summary>
        /// <returns>List of the name of the playlists as string.</returns>
        public List<String> getPlaylistsAsStrings()
        {
            List<String> thePlaylists = new List<string>();

            foreach(SimplePlaylist playlist in _playlists)
            {
                thePlaylists.Add(playlist.Name);
            }
            
            return thePlaylists;
        }

        /// <summary>
        /// Set all paths to mp3 files into <c>toComplete</c>.
        /// </summary>
        /// <param name="targetDirectory">The directory to complete.</param>
        /// <param name="toComplete"></param>
        private void ProcessDirectory(string targetDirectory, List<String> toComplete)
        {
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.mp3");
            foreach (string fileName in fileEntries)
                toComplete.Add(fileName);

            string[] subDirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subDirectory in subDirectoryEntries)
                ProcessDirectory(subDirectory, toComplete);
        }

        /// <summary>
        /// Get the names of songs in the folder under supervision.
        /// </summary>
        /// <returns>List of the name of the local songs as string.</returns>
        public List<string> getLocalSongsAsStrings()
        {
            List<string> theSongsItems = new List<string>();

            foreach(LocalSong song in _localSongs)
            {
                theSongsItems.Add(Path.GetFileName(song.getTrack().Name));
            }

            return theSongsItems;
        }

        /// <summary>
        /// Get the songs of <c>pathToFolder</c> as ListView items.
        /// </summary>
        /// <param name="pathToFolder">The path to the local songs folder.</param>
        /// <returns>The songs of the folder under supervision as ListView items.</returns>
        public List<ListViewItem> getLocalSongsAsStrings(String pathToFolder)
        {
            List<ListViewItem> theSongsItems = new List<ListViewItem>();

            _mp3TrackSet.Clear();

            List<String> pathsList = new List<string>();

            ProcessDirectory(pathToFolder, pathsList);

            // Complete the list with taglib instances
            foreach(string path in pathsList)
            {
                TagLib.File file = TagLib.File.Create(path);
                if(file != null)
                {
                    _mp3TrackSet.Add(file);
                }
            }

            // Creating the listview items
            foreach(TagLib.File file in _mp3TrackSet)
            {
                ListViewItem theItem = new ListViewItem(new string[] { Path.GetFileName(file.Name) });
                theItem.ImageIndex = 0;
                theSongsItems.Add(theItem);
            }

            return theSongsItems;
        }

        /// <summary>
        /// Get the names of songs in the playlist under supervision.
        /// </summary>
        /// <returns>List of names of the Spotify songs as string.</returns>
        public List<string> getSongsOfPlaylistAsStrings()
        {
            List<string> theSongs = new List<string>();

            foreach(SpotifySong song in _spotifySongs)
            {
                theSongs.Add(song.getPerformers()[0] + " - " + song.getTitle());
            }

            return theSongs;
        }

        /// <summary>
        /// Get the songs of the playlist under supervision as ListView items.
        /// </summary>
        /// <param name="playlistId">The ID of the playlist under supervision.</param>
        /// <returns>The songs of the playlist under supervision as ListView items.</returns>
        public List<ListViewItem> getSongsOfPlaylistAsStrings(int playlistId)
        {
            List<ListViewItem> theSongs = new List<ListViewItem>();

            SimplePlaylist thePlaylist = _playlists.ElementAt(playlistId);

            _spotifyTrackSet = new List<PlaylistTrack>();

            Paging<PlaylistTrack> tracks = _spotifyAPI.GetPlaylistTracks(_profile.Id, thePlaylist.Id);

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

        /// <summary>
        /// Fill the local songs list by transforming TagLib instances in LocalSong instances.
        /// </summary>
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

        /// <summary>
        /// Fills the Spotify song list from the playlist under supervision.
        /// </summary>
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

        /// <summary>
        /// Triggers the matching operation between the songs of the two lists.
        /// </summary>
        public void matchSongs()
        {
            MergingFactory.process(_localSongs, _spotifySongs);
        }

        /// <summary>
        /// Matches a song in both lists.
        /// </summary>
        /// <param name="idLocal">The id in the list of the local song to merge.</param>
        /// <param name="idSpotify">The id in the list of the Spotify song to merge.</param>
        public void matchSongs(int idLocal, int idSpotify)
        {
            MergingFactory.mergeTags(_spotifySongs.ElementAt(idSpotify), _localSongs.ElementAt(idLocal));
            _spotifySongs.RemoveAt(idSpotify);
            _localSongs.RemoveAt(idLocal);
        }

        /// <summary>
        /// The number of local songs in the list.
        /// </summary>
        /// <returns>The number of local songs in the list.</returns>
        public int getNbLocalSongs()
        {
            return _localSongs.Count;
        }

        /// <summary>
        /// The number of Spotify songs in the list.
        /// </summary>
        /// <returns>The number of Spotify songs in the list.</returns>
        public int getNbSpotifySongs()
        {
            return _spotifySongs.Count;
        }
    }
}
