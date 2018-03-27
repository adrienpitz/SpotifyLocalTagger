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
        Assembly _assembly;
        Stream _spotIcoStream;
        Stream _localIcoStream;

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

            populateLocalSongsListView();
            populateSpotifySongsListView();
        }

        private void populateLocalSongsListView()
        {
            localListBox.Items.Clear();

            ImageList imageListSmall = new ImageList();
            imageListSmall.Images.Add(new Bitmap(_localIcoStream));

            List<string> theItems = theUser.getLocalSongsAsStrings();

            foreach(string item in theItems)
            {
                localListBox.Items.Add(item);
            }

        }

        private void populateSpotifySongsListView()
        {
            spotifyListBox.Items.Clear();

            ImageList imageListSmall = new ImageList();
            imageListSmall.Images.Add(new Bitmap(_spotIcoStream));

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
            Console.WriteLine(localListBox.SelectedIndex + "-" + spotifyListBox.SelectedIndex);
        }
    }
}
