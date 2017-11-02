﻿using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotify_Local_Tagger
{
    public partial class GUI : Form
    {

        User theUser;

        /**
         * Constructor
         * 
         **/
        public GUI()
        {
            InitializeComponent();
            //At the begining, login panel is visible
            loginPanel.Visible = true;
            mainPanel.Visible = false;
            initLocalSongsListView();
            
        }

        private void initLocalSongsListView()
        {
            ImageList imageListSmall = new ImageList();
            imageListSmall.Images.Add(Bitmap.FromFile("C:/Users/Utilisateur/Pictures/musicFile.bmp"));
            localListView.LargeImageList = imageListSmall;
        }

        /**
         * loginCredsButton_Click : Triggered when login button with credentials is pressed
         * 
         * sender: the object sending the signal
         * e: arguments sended
         * 
         **/
        private void loginCredsButton_Click(object sender, EventArgs e)
        {

        }

        /**
         * loginWebButton_Click : Triggered when login button on web page is pressed
         * 
         * sender: the object sending the signal
         * e: arguments sended
         **/
        private void loginWebButton_Click(object sender, EventArgs e)
        {

            theUser = new User(this);

            if(theUser.isConnexionOK())
            {
                MessageBox.Show("Retrieving informations failed");
            }else
            {
                Console.WriteLine("Successfull connexion");
                loginPanel.Visible = false;
                mainPanel.Visible = true;
                mainPanelInit();
            }

        }

        public void showMessageBox(String theText)
        {
            MessageBox.Show(theText);
        }

        /**
         * mainPanelInit: Initializes the graphical components of the main menu
         * 
         **/
        private void mainPanelInit()
        {
            theUser.setProfilePic(profilePictureBox);
            nameLabel.Text = theUser.getName();
            countryLabel.Text = theUser.getCountry();
            followersLabel.Text = theUser.getFollowers();
            playlistsGroupBox.Text = "Playlists - " + theUser.getNbPlaylists();
            setPlaylistsInBox();
            setSongsInBox();
        }

        /**
         * setPlaylistsInBox: Fill the playlist list box
         * 
         **/
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

        /**
         * setSongsInBox: Fill the songs list box (at initialization)
         * 
         **/
        private void setSongsInBox()
        {
            if(theUser.getNbPlaylists() > 0)
            {
                spotifyMusicsListView.Items.Clear();
                playlistNotUserLabel.Text = "";

                ImageList imageListSmall = new ImageList();
                imageListSmall.Images.Add(Bitmap.FromFile("C:/Users/Utilisateur/Pictures/spotFileIco.bmp"));

                List<ListViewItem> theItems = theUser.getSongsOfPlaylistAsStrings(0);

                if (theItems.Count == 0)
                    playlistNotUserLabel.Text = "This playlist can't be read as it is not yours";

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
            playlistNotUserLabel.Text = "";
            List<ListViewItem> newItems = theUser.getSongsOfPlaylistAsStrings(playlistsListBox.SelectedIndex);

            if (newItems.Count == 0)
                playlistNotUserLabel.Text = "This playlist can't be read as it is not yours";

            foreach (ListViewItem item in newItems)
            {
                spotifyMusicsListView.Items.Add(item);
            }

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            String selectedPath = "";
            bool hasCancelled = false;
            localListView.Items.Clear();

            var t = new Thread((ThreadStart)(() => {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = System.Environment.SpecialFolder.MyComputer;
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                {
                    hasCancelled = true;
                    return;
                }

                selectedPath = fbd.SelectedPath;
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            if (!hasCancelled)
            {
                folderTextBox.Text = selectedPath;



                List<ListViewItem> newItems = theUser.getLocalSongsAsStrings(folderTextBox.Text);
                foreach (ListViewItem item in newItems)
                {
                    localListView.Items.Add(item);
                }
            }

        }

        private void synchronizeButton_Click(object sender, EventArgs e)
        {
            // Step 1: Retrieve all informations from Spotify
            theUser.fillSpotifySongs();
            theUser.fillLocalSongs();

            // Step 2: Matching and tagging
            theUser.matchSongs();

            // Step 3: Open the form for manual matching

        }
    }
}
