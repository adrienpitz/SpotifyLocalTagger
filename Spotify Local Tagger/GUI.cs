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

        private void loginWebButton_Click(object sender, EventArgs e)
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
            nameLabel.Text = theUser.getName();
            countryLabel.Text = theUser.getCountry();
            followersLabel.Text = theUser.getFollowers();
            playlistsGroupBox.Text = "Playlists - " + theUser.getNbPlaylists();
            setPlaylistsInBox();
            setSongsInBox();
        }

        private void setPlaylistsInBox()
        {
            List<String> thePlaylists = theUser.getPlaylistsAsStrings();

            playlistsListBox.Items.Clear();

            foreach(String playlistName in thePlaylists)
            {
                playlistsListBox.Items.Add(playlistName);
            }

            if (thePlaylists.Count > 0)
                playlistsListBox.SetSelected(0, true);
        }

        private void setSongsInBox()
        {
            if(theUser.getNbPlaylists() > 0)
            {
                spotifyMusicsListView.Items.Clear();

                ImageList imageListSmall = new ImageList();
                imageListSmall.Images.Add(Bitmap.FromFile("C:/Users/Utilisateur/Pictures/spotFileIco.bmp"));

                List<ListViewItem> theItems = theUser.getSongsOfPlaylistAsStrings(0);

                foreach(ListViewItem item in theItems)
                {
                    spotifyMusicsListView.Items.Add(item);
                }

                spotifyMusicsListView.LargeImageList = imageListSmall;
            }
        }

        private void playlistsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            spotifyMusicGroupBox.Text = "Spotify musics in " + playlistsListBox.SelectedItem.ToString();
            if(spotifyMusicGroupBox.Text.Length > 46)
            {
                spotifyMusicGroupBox.Text = spotifyMusicGroupBox.Text.Remove(46);
                spotifyMusicGroupBox.Text = spotifyMusicGroupBox.Text + "...";
            }

            spotifyMusicsListView.Items.Clear();
            List<ListViewItem> newItems = theUser.getSongsOfPlaylistAsStrings(playlistsListBox.SelectedIndex);

            foreach (ListViewItem item in newItems)
            {
                spotifyMusicsListView.Items.Add(item);
            }

        }
    }
}
