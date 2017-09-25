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
    public partial class GUI : Form
    {

        User theUser;

        public GUI()
        {
            InitializeComponent();
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void loginCredsButton_Click(object sender, EventArgs e)
        {

        }

        private async void loginWebButton_Click(object sender, EventArgs e)
        {


            theUser = new User(this);

            if(theUser.isConnexionOK())
            {
                MessageBox.Show("Retrieving informations failed");
            }else
            {
                Console.WriteLine("Successfull connexion");
                panel1.Visible = false;
                panel2.Visible = true;
                panel2Init();
            }

        }

        public void showMessageBox(String theText)
        {
            MessageBox.Show(theText);
        }

        private void panel2Init()
        {
            theUser.setProfilePic(profilePictureBox);
        }

    }
}
