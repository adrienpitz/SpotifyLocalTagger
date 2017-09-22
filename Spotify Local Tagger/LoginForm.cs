using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Local_Tagger
{
    public partial class LoginForm : Form
    {

        private SpotifyWebAPI spotifyAPI;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginCredsButton_Click(object sender, EventArgs e)
        {

        }

        private async void loginWebButton_Click(object sender, EventArgs e)
        {

            WebAPIFactory webApiFactory = new WebAPIFactory("http://localhost", 8888, "6ac9eb8c694441748f29683de12b50b7",SpotifyAPI.Web.Enums.Scope.UserReadPrivate, TimeSpan.FromSeconds(20));

            try
            {
                spotifyAPI = await webApiFactory.GetWebApi();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if(spotifyAPI == null)
            {
                MessageBox.Show("Retrieving informations failed");
            }else
            {
                Console.WriteLine("Successfull connexion");
                //Console.WriteLine(spotifyAPI.GetUserPlaylists().Size);
            }

        }

    }
}
