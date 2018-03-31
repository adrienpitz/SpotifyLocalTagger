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
                    if(minLevDistance <= 5 && minId != -1)
                    {
                        mergeTags(spotifySongs.ElementAt(minId), localSongs.ElementAt(i));
                        spotifySongs.RemoveAt(minId);
                        localToRemove.Add(i);
                    }
                }

                //Delete local songs already processed
                Console.Write(localSongs.Count + " - ");
                for(int i = localToRemove.Count-1; i >= 0; i--)
                {
                    localSongs.RemoveAt(localToRemove.ElementAt(i));
                }
                Console.Write(localSongs.Count + "\n");


                //Merge remaining songs if we can
                localToRemove.Clear();

                for(int i=0; i < localSongs.Count; ++i)
                {
                    for(int j=0; j < spotifySongs.Count; ++j)
                    {
                        if(compareByElements(spotifySongs.ElementAt(j), localSongs.ElementAt(i)) == 1)
                        {
                            mergeTags(spotifySongs.ElementAt(j), localSongs.ElementAt(i));
                            spotifySongs.RemoveAt(j);
                            localToRemove.Add(i);
                            break;
                        }
                    }
                }

                //Delete remaining local songs that have been processed
                Console.Write(localSongs.Count + " - ");
                for (int i = localToRemove.Count - 1; i >= 0; i--)
                {
                    localSongs.RemoveAt(localToRemove.ElementAt(i));
                }
                Console.Write(localSongs.Count + "\n");

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

        /**
         * returns:
         *  - 0: spotify song does not match the local song
         *  - 1: spotify song does match the local song
         *  - 2: spotify song has the same title than the local song
         **/
        private static int compareByElements(SpotifySong spotifySong, LocalSong localSong)
        {

            //We have a score and we evaluate if this is sufficiently good to merge the two songs
            string localMatchString = localSong.getMatchingString();
            //1. Look for the artists
            string[] performers = spotifySong.getPerformers();
            int nbOK = 0;

            if(localSong.getTrack().Tag.Performers != null && localSong.getTrack().Tag.Performers.Count() != 0)
            {
                foreach(string performer in performers)
                {
                    spotifySong.initMatchingString(performer);
                    spotifySong.processMatchingString();
                    
                    foreach(string performerLocal in localSong.getTrack().Tag.Performers)
                    {
                        localSong.initMatchingString(performerLocal);
                        localSong.processMatchingString();

                        if (localSong.getMatchingString().Contains(spotifySong.getMatchingString())){
                            nbOK++;
                            break;
                        }

                    }

                    if (nbOK > 0)
                        break;
                }
            }

            if(localSong.getTrack().Tag.Performers == null || localSong.getTrack().Tag.Performers.Count() == 0 || nbOK == 0)
            {
                foreach (string performer in performers)
                {
                    spotifySong.initMatchingString(performer);
                    spotifySong.processMatchingString();
                    if (localMatchString.Contains(spotifySong.getMatchingString()))
                    {
                        nbOK++;
                        break;
                    }
                }
            }

            //2. Look for the title
            bool hasGoodTitle = false;
            spotifySong.initMatchingString(spotifySong.getTitle());
            spotifySong.processMatchingString();
            if (localMatchString.Contains(spotifySong.getMatchingString()))
            {
                Console.WriteLine("Coucou vous ! " + localMatchString);
                hasGoodTitle = true;
            }

            //3. Reinit matching strings
            spotifySong.initMatchingString();
            spotifySong.processMatchingString();
            localSong.initMatchingString(localMatchString);

            if (nbOK > 0 && hasGoodTitle)
            {
                //Console.WriteLine(spotifySong.getMatchingString() + " -- " + localSong.getMatchingString());
                return 1;
            }

            return 0;
        }

        public static void mergeTags(SpotifySong spotifySong, LocalSong localSong)
        {
            //Retrieve taglib ref
            TagLib.File localFile = localSong.getTrack();

            //Perform merge
            localFile.Tag.Clear();
            localFile.Tag.Performers = spotifySong.getPerformers();
            localFile.Tag.Album = spotifySong.getNameAlbum();
            localFile.Tag.AlbumArtists = spotifySong.getArtistsAlbum();
            localFile.Tag.BeatsPerMinute = 320;
            localFile.Tag.Comment = "Spotify Local Tagger by Adrien P.";
            localFile.Tag.Disc = spotifySong.getDiskNumber();
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
