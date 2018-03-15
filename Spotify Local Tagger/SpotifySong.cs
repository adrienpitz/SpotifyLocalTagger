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
                        Assembly _assembly = Assembly.GetExecutingAssembly();
                        Stream albumPicStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.localTaggerDefaultAlbum.bmp");
                        System.Drawing.Image thepic = new Bitmap(albumPicStream);
                        var ms = new MemoryStream();
                        thepic.Save(ms, thepic.RawFormat);
                        imageBytes = ms.ToArray();
                    }

                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }else
            {
                //TODO : Set default album cover
                Assembly _assembly = Assembly.GetExecutingAssembly();
                Stream albumPicStream = _assembly.GetManifestResourceStream("Spotify_Local_Tagger.Resources.localTaggerDefaultAlbum.bmp");
                System.Drawing.Image thepic = new Bitmap(albumPicStream);
                var ms = new MemoryStream();
                thepic.Save(ms, thepic.RawFormat);
                imageBytes = ms.ToArray();
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

    }
}
