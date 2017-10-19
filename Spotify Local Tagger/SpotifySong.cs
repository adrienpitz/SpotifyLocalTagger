using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Local_Tagger
{
    class SpotifySong
    {

        private byte[] imageBytes;
        PlaylistTrack track;
        bool hasBeenPaired;
        bool isInvalid;

        public SpotifySong(PlaylistTrack _track)
        {
            track = _track;
            hasBeenPaired = false;
            if (track == null)
                isInvalid = true;
            else
            {
                downloadImage();
            }
        }

        private void downloadImage()
        {
            WebClient webclient = new WebClient();
            var images = track.Track.Album.Images;
            if (images != null) {
                try
                {
                    imageBytes = webclient.DownloadData(images.ElementAt(0).Url);

                    if(imageBytes == null || imageBytes.Count() == 0)
                    {
                        //TODO : Set default album cover
                    }

                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }else
            {
                //TODO : Set default album cover
            }
        }

        public string[] getPerformers()
        {
            List<string> performers = new List<string>();

            foreach (SimpleArtist performer in track.Track.Artists)
            {
                performers.Add(performer.Name);
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

    }
}
