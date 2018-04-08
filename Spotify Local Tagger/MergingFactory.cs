using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Local_Tagger
{
    /// <summary>
    /// Operations made on song lists while merging.
    /// </summary>
    class MergingFactory
    {

        /// <summary>
        /// Do the matchs between the corresponding songs in the two lists and delete the matched songs.
        /// </summary>
        /// <param name="localSongs">The list of local songs.</param>
        /// <param name="spotifySongs">The list of Spotify songs.</param>
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
                        int resultCompareElements = compareByElements(spotifySongs.ElementAt(j), localSongs.ElementAt(i));
                        if (resultCompareElements == 1)
                        {
                            mergeTags(spotifySongs.ElementAt(j), localSongs.ElementAt(i));
                            spotifySongs.RemoveAt(j);
                            localToRemove.Add(i);
                            break;

                        }else if (resultCompareElements == 2)
                        {
                            Console.WriteLine(localSongs.ElementAt(i).getTrack().Name + " could be matched by suggestion");
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

        /// <summary>
        /// Levenshtein distance between two strings.
        /// </summary>
        /// <param name="s1">The first string.</param>
        /// <param name="s2">The second string.</param>
        /// <returns>The Levenshtein distance between <c>s1</c> and <c>s2</c>.</returns>
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

        /// <summary>
        /// Compare the two songs by their elements.
        /// </summary>
        /// <param name="spotifySong">The Spotify song.</param>
        /// <param name="localSong">The local song.</param>
        /// <returns>0 if does not match, 1 if it matches, 2 if the localSong has only the valid title.</returns>
        private static int compareByElements(SpotifySong spotifySong, LocalSong localSong)
        {

            //We have a score and we evaluate if this is sufficiently good to merge the two songs
            string localMatchString = localSong.getMatchingString();
            string spotifyMatchString = spotifySong.getMatchingString();

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

            localSong.initMatchingString(localMatchString);

            //2. Look for the title
            bool hasGoodTitle = false;
            /*spotifySong.initMatchingString(spotifySong.getTitle());
            spotifySong.processMatchingString();*/
            spotifySong.processMatchingStringWithTitle();
            if (localMatchString.Contains(spotifySong.getMatchingString()))
            {
                hasGoodTitle = true;
            }

            //3. Reinit matching strings
            /**spotifySong.initMatchingString();
            spotifySong.processMatchingString();**/
            spotifySong.initMatchingString(spotifyMatchString);
            localSong.initMatchingString(localMatchString);

            if (nbOK > 0 && hasGoodTitle)
            {
                //Console.WriteLine(spotifySong.getMatchingString() + " -- " + localSong.getMatchingString());
                return 1;
            }

            if (hasGoodTitle)
                return 2;

            return 0;
        }

        /// <summary>
        /// Put the tags of the Spotify song in the local songs.
        /// </summary>
        /// <param name="spotifySong">The song from Spotify.</param>
        /// <param name="localSong">The local song.</param>
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
