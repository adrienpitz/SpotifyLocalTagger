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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Spotify_Local_Tagger
{
    /// <summary>
    /// Interaction between the user and the main Form,
    /// diplaying the playlists and the songs from both Spotify and local source.
    /// </summary>
    public partial class GUI : Form
    {

        /// <summary>
        /// Informations about the user
        /// </summary>
        User _theUser;

        Assembly _assembly;
        Stream _spotIcoStream;
        Stream _localIcoStream;

        /// <summary>
        /// Initializes the Form and the resources used as icons.
        /// </summary>
        public GUI()
        {
            InitializeComponent();
            //At the begining, login panel is visible
            loginPanel.Visible = true;
            mainPanel.Visible = false;

            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                _spotIcoStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.spotFileIco.bmp");
                _localIcoStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.musicFile.bmp");
            }
            catch
            {
                MessageBox.Show("Error accessing ressources !");
            }


            initLocalSongsListView();
            
        }

        /// <summary>
        /// Set the icon of local songs to be desplayed before each local song
        /// </summary>
        private void initLocalSongsListView()
        {
            ImageList imageListSmall = new ImageList();
            imageListSmall.Images.Add(new Bitmap(_localIcoStream));
            localListView.LargeImageList = imageListSmall;
        }

        /// <summary>
        /// Triggers the connection by login/password
        /// </summary>
        /// <param name="sender">The button instance</param>
        /// <param name="e">The event</param>
        /// <remarks> API doesn't provide this functionality yet </remarks>
        private void loginCredsButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Triggers the connection with the web page
        /// </summary>
        /// <param name="sender">The button instance</param>
        /// <param name="e">The event</param>
        private void loginWebButton_Click(object sender, EventArgs e)
        {

            _theUser = new User();

            if(!_theUser.isConnexionOK())
            {
                MessageBox.Show("Retrieving informations failed.");
            }else
            {
                Console.WriteLine("Successfull connexion");
                loginPanel.Visible = false;
                mainPanel.Visible = true;
                mainPanelInit();
            }

        }

        /// <summary>
        /// Opens a box showing <c>theText</c>.
        /// </summary>
        /// <param name="theText">The text to display</param>
        public void showMessageBox(String theText)
        {
            MessageBox.Show(theText);
        }

        /// <summary>
        /// Initializes the graphical components of the main menu.
        /// </summary>
        private void mainPanelInit()
        {
            _theUser.setProfilePic(profilePictureBox);
            nameLabel.Text = _theUser.getName();
            countryLabel.Text = _theUser.getCountry();
            followersLabel.Text = _theUser.getFollowers();
            playlistsGroupBox.Text = "Playlists - " + _theUser.getNbPlaylists();
            setPlaylistsInBox();
            setSongsInBox();
        }

        /// <summary>
        /// Fills the playlist list box
        /// </summary>
        private void setPlaylistsInBox()
        {
            List<String> thePlaylists = _theUser.getPlaylistsAsStrings();

            playlistsListBox.Items.Clear();

            foreach(String playlistName in thePlaylists)
            {
                playlistsListBox.Items.Add(playlistName);
            }

            if (thePlaylists.Count > 0)
                playlistsListBox.SetSelected(0, true);
        }

        /// <summary>
        /// Initializes the Spotify songs list with the first playlist in the list
        /// </summary>
        /// <remarks>Used at initialization only</remarks>
        private void setSongsInBox()
        {
            if(_theUser.getNbPlaylists() > 0)
            {
                spotifyMusicsListView.Items.Clear();
                playlistNotUserLabel.Text = "";

                ImageList imageListSmall = new ImageList();
                imageListSmall.Images.Add(new Bitmap(_spotIcoStream));

                List<ListViewItem> theItems = _theUser.getSongsOfPlaylistAsStrings(0);

                if (theItems.Count == 0)
                    playlistNotUserLabel.Text = "This playlist can't be read as it is not yours";

                foreach(ListViewItem item in theItems)
                {
                    spotifyMusicsListView.Items.Add(item);
                }

                spotifyMusicsListView.LargeImageList = imageListSmall;
            }
        }

        /// <summary>
        /// Updates the list of Spotify songs in the box when a playlist is selected
        /// </summary>
        /// <param name="sender">The button instance</param>
        /// <param name="e">The event</param>
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
            List<ListViewItem> newItems = _theUser.getSongsOfPlaylistAsStrings(playlistsListBox.SelectedIndex);

            if (newItems.Count == 0)
                playlistNotUserLabel.Text = "This playlist can't be read as it is not yours";

            foreach (ListViewItem item in newItems)
            {
                spotifyMusicsListView.Items.Add(item);
            }

        }

        /// <summary>
        /// Opens a file navigator in which the user will specify the file in
        /// which his/her local songs are
        /// </summary>
        /// <param name="sender">The button instance </param>
        /// <param name="e">The event</param>
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

                groupBox1.Text = "Local musics in " + new DirectoryInfo(selectedPath).Name;

                List<ListViewItem> newItems = _theUser.getLocalSongsAsStrings(folderTextBox.Text);
                foreach (ListViewItem item in newItems)
                {
                    localListView.Items.Add(item);
                }
            }

        }

        /// <summary>
        /// Triggers the synchronisation between the Spotify songs and the Local songs
        /// in background of the UI thread
        /// </summary>
        /// <param name="sender">The button instance</param>
        /// <param name="e">The event</param>
        /// <remarks>
        /// If all local songs did not have a match, a manual merging operation will
        /// be triggered when the background thread will finish well.
        /// </remarks>
        private void synchronizeButton_ClickAlternative(object sender, EventArgs e)
        {
            playlistsListBox.Enabled = false;
            spotifyMusicsListView.Enabled = false;
            localListView.Enabled = false;
            browseButton.Enabled = false;
            folderTextBox.Enabled = false;

            backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Triggers the synchronisation between the Spotify songs and the Local songs
        /// </summary>
        /// <param name="sender">The button instance</param>
        /// <param name="e">The event</param>
        /// <remarks>
        /// If all local songs did not have a match, a manual merging operation will
        /// be triggered
        /// </remarks>
        private void synchronizeButton_Click(object sender, EventArgs e)
        {

            playlistsListBox.Enabled = false;
            spotifyMusicsListView.Enabled = false;
            localListView.Enabled = false;
            browseButton.Enabled = false;
            folderTextBox.Enabled = false;

            progressBar.Value = 0;

            // Step 1: Retrieve all informations from Spotify

            progressBar.PerformStep();

            _theUser.fillSpotifySongs();

            progressBar.PerformStep();

            _theUser.fillLocalSongs();

            progressBar.PerformStep();

            // Step 2: Matching and tagging
            _theUser.matchSongs();
            progressBar.PerformStep();

            // Step 3: Open the form for manual matching
            Form manualMergingForm = new ManualMergingGUI(_theUser);
            manualMergingForm.Show();

            playlistsListBox.Enabled = true;
            spotifyMusicsListView.Enabled = true;
            localListView.Enabled = true;
            browseButton.Enabled = true;
            folderTextBox.Enabled = true;

        }

        /// <summary>
        /// Automatic merging operation done by the background thread.
        /// </summary>
        /// <param name="sender">The object sending the signal.</param>
        /// <param name="e">The event.</param>
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

            backgroundWorker.ReportProgress(10);

            // Step 1: Retrieve all informations from Spotify
            _theUser.fillSpotifySongs();
            backgroundWorker.ReportProgress(20); //20% of the job has been made

            _theUser.fillLocalSongs();
            backgroundWorker.ReportProgress(30); //30% of the job has been made

            // Step 2 : Matching and tagging
            _theUser.matchSongs();
            backgroundWorker.ReportProgress(100); //100% of the job has been made

        }

        /// <summary>
        /// Updates the progress bar status when the worker finished one task.
        /// </summary>
        /// <param name="sender">The object sending the signal.</param>
        /// <param name="e">The event.</param>
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// Triggers the manual matching when the background thread completed his job and reactivate elements
        /// of the GUI
        /// </summary>
        /// <param name="sender">The object sending the signal.</param>
        /// <param name="e">The event.</param>
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                this.showMessageBox("An error occured during the merging operation.");
            }
            else
            {
                // Open manual merging only if it both lists contains elements
                if (_theUser.getNbLocalSongs() != 0 && _theUser.getNbSpotifySongs() != 0)
                {
                    Form manualMergingForm = new ManualMergingGUI(_theUser);
                    manualMergingForm.Show();
                }

                playlistsListBox.Enabled = true;
                spotifyMusicsListView.Enabled = true;
                localListView.Enabled = true;
                browseButton.Enabled = true;
                folderTextBox.Enabled = true;
            }
        }
    }
}
