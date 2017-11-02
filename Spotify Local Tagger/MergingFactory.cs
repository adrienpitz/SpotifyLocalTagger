using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Local_Tagger
{
    class MergingFactory
    {

        public static void process(List<LocalSong> localSongs, List<SpotifySong> spotifySongs)
        {
            if(localSongs != null && spotifySongs != null)
            {

                List<int> localToRemove = new List<int>();

                //Iterate through the local songs
                for(int i=0; i < localSongs.Count; ++i)
                {
                    int minLevDistance = 6000;
                    int minId = -1;
                    //Iterate through the spotify songs
                    for(int j=0; j < spotifySongs.Count; ++j)
                    {
                        int dist = levenshteinDistance(localSongs.ElementAt(i).getMatchingString(), spotifySongs.ElementAt(j).getMatchingString());
                        if(dist < minLevDistance)
                        {
                            minLevDistance = dist;
                            minId = j;
                        }

                    }


                   // Console.WriteLine(minLevDistance + " " + localSongs.ElementAt(i).getMatchingString() + " - " + spotifySongs.ElementAt(minId).getMatchingString());
                    if(minLevDistance <= 10 && minId != -1)
                    {
                        mergeTags(spotifySongs.ElementAt(minId), localSongs.ElementAt(i));
                        spotifySongs.RemoveAt(minId);
                    }
                }
            }
        }

        private static int levenshteinDistance(string s1, string s2)
        {
            //Console.WriteLine(s1 + " " + s2);
            int n = s1.Length;
            int m = s2.Length;
            int[,] d = new int[n + 1, m + 1];

            if (n == 0)
                return m;
            if (m == 0)
                return n;

            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 0; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (s2[j - 1] == s1[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[n, m];
        }

        private static void mergeTags(SpotifySong spotifySong, LocalSong localSong)
        {
            //Retrieve taglib ref
            TagLib.File localFile = localSong.getTrack();

            //Perform merge
            localFile.Tag.Clear();
            localFile.Tag.Artists = spotifySong.getPerformers();
            localFile.Tag.Album = spotifySong.getNameAlbum();
            localFile.Tag.AlbumArtists = spotifySong.getArtistsAlbum();
            localFile.Tag.BeatsPerMinute = 320;
            localFile.Tag.Comment = "Spotify Local Tagger by Adrien P.";
            localFile.Tag.Disc = spotifySong.getDiskNumber();
            localFile.Tag.Performers = spotifySong.getPerformers();
            localFile.Tag.Title = spotifySong.getTitle();
            localFile.Tag.Track = spotifySong.getTrackNumber();
            localFile.Tag.TrackCount = spotifySong.getTrackNumber();
            localFile.Tag.Year = spotifySong.getYearAlbum();

            //Pic
            TagLib.IPicture[] pictFrames = { spotifySong.getAlbumImage() };
            localFile.Tag.Pictures = pictFrames;

            //Save
            localFile.Save();
        }

    }
}
