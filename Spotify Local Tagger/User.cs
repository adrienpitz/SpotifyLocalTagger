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
    class User
    {
        private SpotifyWebAPI spotifyAPI;
        GUI theGui;
        PrivateProfile profile;
        List<SimplePlaylist> playlists;
        bool areComponentsInitialized;


        public User(GUI gui)
        {
            theGui = gui;
            connect();
            areComponentsInitialized = false;
            while(spotifyAPI == null) { }

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
            if (!areComponentsInitialized)
                initComponents();

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
    }
}
