using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Local_Tagger
{
    /// <summary>
    /// Specifies a Spotify song.
    /// </summary>
    public class SpotifySong : Song
    {
        /// <summary>
        /// The album image.
        /// </summary>
        private byte[] _imageBytes;
        /// <summary>
        /// Instance of PlaylistTrack, holds all the Spotify informations
        /// about the song.
        /// </summary>
        PlaylistTrack _track;
        /// <summary>
        /// Whether <c>_track</c> has been initialized or not.
        /// </summary>
        bool _isInvalid;
        /// <summary>
        /// Instance of FullAlbum, holds all the informations about
        /// the album holding the song.
        /// </summary>
        FullAlbum _fullAlbum;

        /// <summary>
        /// Downloads the FullAlbum and the image related to it.
        /// Initializes and process the matching string.
        /// </summary>
        /// <param name="track">The track instance.</param>
        /// <param name="api">The API instance.</param>
        public SpotifySong(PlaylistTrack track, SpotifyWebAPI api)
        {
            
            this._track = track;
            if (this._track == null)
                _isInvalid = true;
            else
            {
                downloadImage();
                downloadFullAlbum(api);
                initMatchingString();
                processMatchingString();
            }

        }

        /// <summary>
        /// Initializes the FullAlbum related to the song using the API.
        /// </summary>
        /// <param name="api">The API instance.</param>
        private void downloadFullAlbum(SpotifyWebAPI api)
        {
            
            _fullAlbum = api.GetAlbum(_track.Track.Album.Id);

        }

        /// <summary>
        /// Download the album image and sets it to the byte vector.
        /// </summary>
        /// <remarks>
        /// First, will try to get it from Spotify, then from Google Images
        /// and if not working, sets a default album cover to the song.
        /// </remarks>
        private void downloadImage()
        {
            WebClient webclient = new WebClient();
            var images = _track.Track.Album.Images;
            if (images != null) {
                try
                {
                    if(images.Count > 0)
                       _imageBytes = webclient.DownloadData(images.ElementAt(0).Url);

                    if(_imageBytes == null || _imageBytes.Count() == 0)
                    {

                        // Get the image through a request to Google image
                        Stream albumPicStream = new GoogleImageAlbum().getAlbumImage(_track.Track.Album.Name, null); // TODO : Remove empty string

                        // If it fails -> Default album cover
                        if (albumPicStream == null)
                        {
                            Assembly _assembly = Assembly.GetExecutingAssembly();
                            albumPicStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.localTaggerDefaultAlbum.bmp");
                        }

                        // Putting the image on the byte vector
                        System.Drawing.Image thepic = new Bitmap(albumPicStream);
                        var ms = new MemoryStream();
                        thepic.Save(ms, thepic.RawFormat);
                        _imageBytes = ms.ToArray();

                    }

                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }else
            {

                Stream albumPicStream = new GoogleImageAlbum().getAlbumImage(_track.Track.Album.Name, null); // TODO : Remove empty string

                if (albumPicStream == null)
                {
                    Assembly _assembly = Assembly.GetExecutingAssembly();
                    albumPicStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.localTaggerDefaultAlbum.bmp");
                }

                System.Drawing.Image thepic = new Bitmap(albumPicStream);
                var ms = new MemoryStream();
                thepic.Save(ms, thepic.RawFormat);
                _imageBytes = ms.ToArray();

            }
        }

        /// <summary>
        /// Get the performers of the song as a string array.
        /// </summary>
        /// <returns>The performers of the song as string array.</returns>
        public string[] getPerformers()
        {
            List<string> performers = new List<string>();

            foreach (SimpleArtist performer in _track.Track.Artists)
            {
                performers.Add(performer.Name);
            }

            return performers.ToArray();
        }

        /// <summary>
        /// Get the album cover as Taglib.Picture instance.
        /// </summary>
        /// <returns>The album cover as Taglib.Picture instance.</returns>
        public TagLib.Picture getAlbumCover()
        {
            return new TagLib.Picture(new TagLib.ByteVector(_imageBytes.ToArray()));
        }

        /// <summary>
        /// Get the title of the song.
        /// </summary>
        /// <returns>The title of the song.</returns>
        public string getTitle()
        {
            return _track.Track.Name;
        }

        /// <summary>
        /// Get the number of the song inside the album.
        /// </summary>
        /// <returns>The number of the song inside the album.</returns>
        public uint getTrackNumber()
        {
            return (uint)_track.Track.TrackNumber;
        }

        /// <summary>
        /// Get the number of the disk of the song inside the album (1+).
        /// </summary>
        /// <returns>The number of the disk of the song inside the album.</returns>
        public uint getDiskNumber()
        {
            return (uint)_track.Track.DiscNumber;
        }

        /// <summary>
        /// Get the year of the album release of the song.
        /// </summary>
        /// <returns>The year of the album release of the song.</returns>
        public uint getYearAlbum()
        {
            if(_fullAlbum.ReleaseDate != null)
            {
                return (uint)Int32.Parse(_fullAlbum.ReleaseDate.Substring(0, 4));
            }
            return 0;
        }

        /// <summary>
        /// Get the name of the album.
        /// </summary>
        /// <returns>The name of the album.</returns>
        public string getNameAlbum()
        {
            return _track.Track.Album.Name;
        }

        /// <summary>
        /// Get all the artists that contributed to the album in which 
        /// the song appears as string array.
        /// </summary>
        /// <returns></returns>
        public string[] getArtistsAlbum()
        {
            List<string> albumArtists = new List<string>();

            if (_fullAlbum.Artists != null)
            {
                if (_fullAlbum.Artists.Count() != 0) {
                    foreach (SimpleArtist artist in _fullAlbum.Artists)
                    {
                        albumArtists.Add(artist.Name);
                    }
                }
                else
                {
                    if (_track.Track.Artists.Count() > 1)
                        albumArtists.Add("Various Artists");
                    else
                        albumArtists.Add(_track.Track.Artists.ElementAt(0).Name);
                }
            }
            else
            {
                if (_track.Track.Artists.Count() > 1)
                    albumArtists.Add("Various Artists");
                else
                    albumArtists.Add(_track.Track.Artists.ElementAt(0).Name);
            }

            return albumArtists.ToArray();
            
        }

        /// <summary>
        /// Initializes the matching string of the Spotify song.
        /// </summary>
        public override void initMatchingString()
        {
            matchingString = "";

            string[] performers = getPerformers();

            //TODO: See if setting all artists is better than just put the princpal one
            foreach(string performer in performers)
            {
                matchingString = matchingString + performer + " ";
            }

            matchingString += "- ";

            matchingString += getTitle();
        }

        /// <summary>
        /// Initializes the matching string to a defined value.
        /// </summary>
        /// <param name="toPut">The value used to initialize the matching string.</param>
        public void initMatchingString(string toPut)
        {
            if(toPut != null)
                matchingString = toPut;
        }

        /// <summary>
        /// Gets the number of tracks in the album of the song.
        /// </summary>
        /// <returns>The number of tracks in the album of the song if all is ok, 
        /// 0 otherwise</returns>
        public uint getNbAlbumTracks()
        {
            if(_fullAlbum.Tracks != null)
                return (uint)_fullAlbum.Tracks.Items.Count();

            return 0;
    
        }

        /// <summary>
        /// Get the album cover as Taglib instance.
        /// </summary>
        /// <returns>The album cover as Taglib instance.</returns>
        public TagLib.Id3v2.AttachedPictureFrame getAlbumImage()
        {
            TagLib.Picture picture = new TagLib.Picture(new TagLib.ByteVector(_imageBytes.ToArray()));
            TagLib.Id3v2.AttachedPictureFrame albumCoverPictFrame = new TagLib.Id3v2.AttachedPictureFrame(picture);
            albumCoverPictFrame.Type = TagLib.PictureType.FrontCover;
            albumCoverPictFrame.TextEncoding = TagLib.StringType.Latin1;

            return albumCoverPictFrame;
        }

        /// <summary>
        /// Process the matching string with the special case where it 
        /// corresponds to the title, and title only.
        /// </summary>
        public void processMatchingStringWithTitle()
        {
            initMatchingString(getTitle());
            processMatchingStringTitle();
        }

        /// <summary>
        /// Communication with Google Image to retrieve the album cover.
        /// </summary>
        private class GoogleImageAlbum
        {

            /// <summary>
            /// Constructor of the instance.
            /// </summary>
            public GoogleImageAlbum()
            {

            }

            /// <summary>
            /// Gets the album image through Google Images.
            /// </summary>
            /// <param name="nameOfAlbum">The name of the album.</param>
            /// <param name="mainPerformer">The main performer of the album.</param>
            /// <returns>The album image as a stream.</returns>
            public Stream getAlbumImage(string nameOfAlbum, string mainPerformer)
            {
                Stream albumImageStream = null;

                string html = getHTML(nameOfAlbum, mainPerformer);
                List<string> urls = getUrls(html);

                byte[] cover = getImage(urls.ElementAt(0));

                albumImageStream = new MemoryStream(cover);

                return albumImageStream;
            }

            /// <summary>
            /// Get the HTML of the Google Image web page corresponding to the request.
            /// </summary>
            /// <param name="nameOfAlbum">The name of the album.</param>
            /// <param name="mainPerformer">The main performer of the album.</param>
            /// <returns>The HTML of the Google Image web page corresponding to the request</returns>
            private static string getHTML(string nameOfAlbum, string mainPerformer)
            {

                string[] nameOfAlbumSplitted;
                string[] mainPerformerSplitted;

                var delimiter = ' ';  // Cut on spaces

                // First, let's make the query
                if (nameOfAlbum != null)
                    nameOfAlbumSplitted = nameOfAlbum.Split(delimiter);
                else
                    nameOfAlbumSplitted = new string[] { };

                if (mainPerformer != null)
                    mainPerformerSplitted = mainPerformer.Split(delimiter);
                else
                    mainPerformerSplitted = new string[] { };

                string query = "https://www.google.be/search?q=";

                for (var i=0; i < nameOfAlbumSplitted.Length - 1; ++i)
                {
                    query += (nameOfAlbumSplitted[i] + "+");
                }

                if(nameOfAlbumSplitted.Length > 0 && mainPerformerSplitted.Length == 0)
                {
                    query += nameOfAlbumSplitted[nameOfAlbumSplitted.Length - 1]; // Query terminated
                }
                else if(nameOfAlbumSplitted.Length > 0)
                {
                    query += (nameOfAlbumSplitted[nameOfAlbumSplitted.Length - 1] + "+"); //Query continues for the artist
                }

                for (var i=0; i < mainPerformerSplitted.Length - 1; ++i)
                {
                    query += (mainPerformerSplitted[i] + "+");
                }

                if(mainPerformerSplitted.Length > 0)
                {
                    query += mainPerformerSplitted[mainPerformerSplitted.Length - 1];
                }

                query += "&tbm=isch"; // Specify that we want the google image page

                var htmlData = "";

                var request = (HttpWebRequest)WebRequest.Create(query);
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";

                var response = (HttpWebResponse)request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                        return "";
                    using (var sr = new StreamReader(dataStream))
                    {
                        htmlData = sr.ReadToEnd();
                    }
                }

                return htmlData;

            }

            /// <summary>
            /// Extract the links of images on the HTML of the Google Image web page
            /// corresponding to the request.
            /// </summary>
            /// <param name="html">The HTML page.</param>
            /// <returns>A list of URLs to images.</returns>
            private static List<string> getUrls(string html)
            {
                var urls = new List<string>();

                int i = html.IndexOf("\"ou\"", StringComparison.Ordinal);

                while (i >= 0)
                {
                    i = html.IndexOf("\"", i + 4, StringComparison.Ordinal);
                    i++;
                    int ndx2 = html.IndexOf("\"", i, StringComparison.Ordinal);
                    string url = html.Substring(i, ndx2 - i);
                    urls.Add(url);
                    i = html.IndexOf("\"ou\"", ndx2, StringComparison.Ordinal);
                    break; // TODO : Remove if we want more thant one pic
                }

                return urls;
            }

            /// <summary>
            /// Returns the image specified by the URL as a Byte vector.
            /// </summary>
            /// <param name="url">The URL of the image.</param>
            /// <returns>The image specified by the URL as byte array.</returns>
            private static Byte[] getImage(string url)
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                        return null;
                    using (var sr = new BinaryReader(dataStream))
                    {
                        byte[] bytes = sr.ReadBytes(100000000);

                        return bytes;
                    }
                }
            }

        }

    }

}
