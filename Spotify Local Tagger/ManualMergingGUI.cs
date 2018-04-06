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
    /// <summary>
    /// Interaction between the user and the manual merging GUI Form
    /// </summary>
    public partial class ManualMergingGUI : Form
    {

        /// <summary>
        /// Informations about the user.
        /// </summary>
        User _theUser;

        /// <summary>
        /// Initializes the basic components.
        /// </summary>
        public ManualMergingGUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the basic components and populate the list views
        /// with unmatched songs.
        /// </summary>
        /// <param name="_theUser"></param>
        public ManualMergingGUI(User theUser)
        {
            InitializeComponent();
            _theUser = theUser;

            // Shows the "oops" panel, hide the list views
            mainPanel.Visible = true;
            mergePanel.Visible = false;

            int nLocalSongs = _theUser.getNbLocalSongs();
            numberUnmatchedLabel.Text = nLocalSongs + "";

            populateLocalSongsListView();
            populateSpotifySongsListView();
        }

        /// <summary>
        /// Add the local song list in the list view.
        /// </summary>
        private void populateLocalSongsListView()
        {
            localListBox.Items.Clear();

            List<string> theItems = _theUser.getLocalSongsAsStrings();

            foreach(string item in theItems)
            {
                localListBox.Items.Add(item);
            }

        }

        /// <summary>
        /// Add the spotify song list in the list view.
        /// </summary>
        private void populateSpotifySongsListView()
        {
            spotifyListBox.Items.Clear();

            List<string> theItems = _theUser.getSongsOfPlaylistAsStrings();

            foreach(string item in theItems)
            {
                spotifyListBox.Items.Add(item);
            }

        }

        /// <summary>
        /// Shows the merge panel when user clicks on the button to merge by hand.
        /// </summary>
        /// <param name="sender">The button instance.</param>
        /// <param name="e">The event.</param>
        private void proceedButton1_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            mergePanel.Visible = true;
        }

        /// <summary>
        /// Closes the form when cancel is pressed.
        /// </summary>
        /// <param name="sender">The button instance.</param>
        /// <param name="e">The event.</param>
        private void cancelButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Closes the form when quit button is pressed.
        /// </summary>
        /// <param name="sender">The button instance.</param>
        /// <param name="e">The event.</param>
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Triggers the matching procedure when a song in both lists is selected.
        /// </summary>
        /// <param name="sender">The button instance.</param>
        /// <param name="e">The event.</param>
        /// <remarks>
        /// If no songs is selected in one of the list, the merging operation won't happen.
        /// If all the songs in one lists have found a match, the form closes itself.
        /// </remarks>
        private void matchButton_Click(object sender, EventArgs e)
        {
            if(!(localListBox.SelectedIndex == -1 || spotifyListBox.SelectedIndex == -1))
            {
                _theUser.matchSongs(localListBox.SelectedIndex, spotifyListBox.SelectedIndex);
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
