using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Spotify_Local_Tagger
{
    public partial class ManualMergingGUI : Form
    {

        User theUser;

        public ManualMergingGUI()
        {
            InitializeComponent();
        }

        public ManualMergingGUI(User _theUser)
        {
            InitializeComponent();
            theUser = _theUser;
            mainPanel.Visible = true;
            mergePanel.Visible = false;

            // Get number of unmatched songs 
            int nLocalSongs = theUser.getNbLocalSongs();
            numberUnmatchedLabel.Text = nLocalSongs + "";

            populateLocalSongsListView();
            populateSpotifySongsListView();
        }

        private void populateLocalSongsListView()
        {
            localListBox.Items.Clear();

            List<string> theItems = theUser.getLocalSongsAsStrings();

            foreach(string item in theItems)
            {
                localListBox.Items.Add(item);
            }

        }

        private void populateSpotifySongsListView()
        {
            spotifyListBox.Items.Clear();

            List<string> theItems = theUser.getSongsOfPlaylistAsStrings();

            foreach(string item in theItems)
            {
                spotifyListBox.Items.Add(item);
            }

        }

        private void proceedButton1_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            mergePanel.Visible = true;
        }

        private void cancelButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void matchButton_Click(object sender, EventArgs e)
        {
            if(!(localListBox.SelectedIndex == -1 || spotifyListBox.SelectedIndex == -1))
            {
                theUser.matchSongs(localListBox.SelectedIndex, spotifyListBox.SelectedIndex);
                populateLocalSongsListView();
                populateSpotifySongsListView();

                if(localListBox.Items.Count == 0 || spotifyListBox.Items.Count == 0)
                {
                    this.Close();
                    this.Dispose();
                }

            }
        }
    }
}
