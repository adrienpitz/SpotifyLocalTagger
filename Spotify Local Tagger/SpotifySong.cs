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
    class SpotifySong : Song
    {

        private byte[] imageBytes;
        PlaylistTrack track;
        bool hasBeenPaired;
        bool isInvalid;
        FullAlbum fullAlbum;

        public SpotifySong(PlaylistTrack _track, SpotifyWebAPI api)
        {
            
            track = _track;
            hasBeenPaired = false;
            if (track == null)
                isInvalid = true;
            else
            {
                downloadImage();
                downloadFullAlbum(api);
                initMatchingString();
                processMatchingString();
            }

        }

        private void downloadFullAlbum(SpotifyWebAPI api)
        {
            
            fullAlbum = api.GetAlbum(track.Track.Album.Id);

        }

        private void downloadImage()
        {
            WebClient webclient = new WebClient();
            var images = track.Track.Album.Images;
            if (images != null) {
                try
                {
                    if(images.Count > 0)
                       imageBytes = webclient.DownloadData(images.ElementAt(0).Url);

                    if(imageBytes == null || imageBytes.Count() == 0)
                    {
                        //TODO : Set default album cover

                        Stream albumPicStream = new GoogleImageAlbum().getAlbumImage(track.Track.Album.Name, null); // TODO : Remove empty string

                        if (albumPicStream == null)
                        {
                            Console.WriteLine("Coucou !");
                            Assembly _assembly = Assembly.GetExecutingAssembly();
                            albumPicStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.localTaggerDefaultAlbum.bmp");
                        }

                        System.Drawing.Image thepic = new Bitmap(albumPicStream);
                        var ms = new MemoryStream();
                        thepic.Save(ms, thepic.RawFormat);
                        imageBytes = ms.ToArray();

                        /**
                        Assembly _assembly = Assembly.GetExecutingAssembly();
                        Stream albumPicStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.localTaggerDefaultAlbum.bmp");
                        System.Drawing.Image thepic = new Bitmap(albumPicStream);
                        var ms = new MemoryStream();
                        thepic.Save(ms, thepic.RawFormat);
                        imageBytes = ms.ToArray();
                        **/
                    }

                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }else
            {
                //TODO : Set default album cover

                Stream albumPicStream = new GoogleImageAlbum().getAlbumImage(track.Track.Album.Name, null); // TODO : Remove empty string

                if (albumPicStream == null)
                {
                    Console.WriteLine("Coucou !");
                    Assembly _assembly = Assembly.GetExecutingAssembly();
                    albumPicStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.localTaggerDefaultAlbum.bmp");
                }

                System.Drawing.Image thepic = new Bitmap(albumPicStream);
                var ms = new MemoryStream();
                thepic.Save(ms, thepic.RawFormat);
                imageBytes = ms.ToArray();

                /**
                Assembly _assembly = Assembly.GetExecutingAssembly();
                Stream albumPicStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.localTaggerDefaultAlbum.bmp");
                System.Drawing.Image thepic = new Bitmap(albumPicStream);
                var ms = new MemoryStream();
                thepic.Save(ms, thepic.RawFormat);
                imageBytes = ms.ToArray();
                **/
            }
        }

        public string[] getPerformers()
        {
            List<string> performers = new List<string>();

            foreach (SimpleArtist performer in track.Track.Artists)
            {
                performers.Add(performer.Name);
                //Console.WriteLine(performer.Name);
            }

            return performers.ToArray();
        }

        public TagLib.Picture getAlbumCover()
        {
            return new TagLib.Picture(new TagLib.ByteVector(imageBytes.ToArray()));
        }

        public string getTitle()
        {
            return track.Track.Name;
        }

        public uint getTrackNumber()
        {
            return (uint)track.Track.TrackNumber;
        }

        public uint getDiskNumber()
        {
            return (uint)track.Track.DiscNumber;
        }

        public uint getYearAlbum()
        {
            if(fullAlbum.ReleaseDate != null)
            {
                return (uint)Int32.Parse(fullAlbum.ReleaseDate.Substring(0, 4));
            }
            return 0;
        }

        public string getNameAlbum()
        {
            return track.Track.Album.Name;
        }

        public string[] getArtistsAlbum()
        {
            List<string> albumArtists = new List<string>();

            if (fullAlbum.Artists != null)
            {
                if (fullAlbum.Artists.Count() != 0) {
                    foreach (SimpleArtist artist in fullAlbum.Artists)
                    {
                        albumArtists.Add(artist.Name);
                    }
                }
                else
                {
                    if (track.Track.Artists.Count() > 1)
                        albumArtists.Add("Various Artists");
                    else
                        albumArtists.Add(track.Track.Artists.ElementAt(0).Name);
                }
            }
            else
            {
                if (track.Track.Artists.Count() > 1)
                    albumArtists.Add("Various Artists");
                else
                    albumArtists.Add(track.Track.Artists.ElementAt(0).Name);
            }

            return albumArtists.ToArray();
            
        }

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

        public void initMatchingString(string toPut)
        {
            if(toPut != null)
                matchingString = toPut;
        }

        public uint getNbAlbumTracks()
        {
            if(fullAlbum.Tracks != null)
                return (uint)fullAlbum.Tracks.Items.Count();

            return 0;
    
        }

        public TagLib.Id3v2.AttachedPictureFrame getAlbumImage()
        {
            TagLib.Picture picture = new TagLib.Picture(new TagLib.ByteVector(imageBytes.ToArray()));
            TagLib.Id3v2.AttachedPictureFrame albumCoverPictFrame = new TagLib.Id3v2.AttachedPictureFrame(picture);
            albumCoverPictFrame.Type = TagLib.PictureType.FrontCover;
            albumCoverPictFrame.TextEncoding = TagLib.StringType.Latin1;

            return albumCoverPictFrame;
        }

        private class GoogleImageAlbum
        {

            public GoogleImageAlbum()
            {

            }

            public Stream getAlbumImage(string nameOfAlbum, string mainPerformer)
            {
                Stream albumImageStream = null;

                string html = getHTML(nameOfAlbum, mainPerformer);
                List<string> urls = getUrls(html);

                byte[] cover = getImage(urls.ElementAt(0));

                albumImageStream = new MemoryStream(cover);

                if(albumImageStream == null)
                {
                    Console.WriteLine("Nique ta mère");
                }

                return albumImageStream;
            }

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
