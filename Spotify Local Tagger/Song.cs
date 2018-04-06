using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spotify_Local_Tagger
{
    /// <summary>
    /// A general song for the local analyzer
    /// </summary>
    abstract class Song
    {

        /// <summary>
        /// String used as the basis of comparison for matching songs.
        /// </summary>
        protected String matchingString;

        /// <summary>
        /// Set the matching string to empty.
        /// </summary>
        public Song()
        {
            matchingString = String.Empty;
        }

        /// <summary>
        /// Initializes the matching string.
        /// </summary>
        public abstract void initMatchingString();

        /// <summary>
        /// Getter for the matching string.
        /// </summary>
        /// <returns>The matching string</returns>
        public String getMatchingString()
        {
            return matchingString;
        }

        /// <summary>
        /// Performs the epuration of the matching string.
        /// </summary>
        public void processMatchingString()
        {
            deleteSpaces();
            deleteUnderScores();
            deleteApostrophe();
            deleteBetweenParenthesis();
            deleteBetweenBrackets();

            setToUpperCase();
            replaceAccents();
            deleteFeaturings();
            removeDigitBeforeSong();
            deletePonctuation();
            replaceAnd();
            deleteSlash();
            removeLastSentence(false);
            deleteDash();
            deleteLyrics();
        }

        /// <summary>
        /// Performs the epuration of the matching string
        /// which corresponds to only the title of the song.
        /// </summary>
        public void processMatchingStringTitle()
        {
            deleteSpaces();
            deleteUnderScores();
            deleteApostrophe();
            deleteBetweenParenthesis();
            deleteBetweenBrackets();

            setToUpperCase();
            replaceAccents();
            deleteFeaturings();
            removeDigitBeforeSong();
            deletePonctuation();
            replaceAnd();
            deleteSlash();
            removeLastSentence(true);
            deleteDash();
            deleteLyrics();
        }

        /// <summary>
        /// Delete all instance of ' ' in the matching string.
        /// </summary>
        private void deleteSpaces()
        {
            matchingString = matchingString.Replace(" ", string.Empty);
        }

        /// <summary>
        /// Delete all instance of '_' in the matching string.
        /// </summary>
        private void deleteUnderScores()
        {
            matchingString = matchingString.Replace("_", string.Empty);
        }

        /// <summary>
        /// Delete all instance of ''' in the matching string.
        /// </summary>
        private void deleteApostrophe()
        {
            matchingString = matchingString.Replace("'", string.Empty);
        }

        /// <summary>
        /// Sets the matching string to uppercase.
        /// </summary>
        private void setToUpperCase()
        {
            matchingString = matchingString.ToUpper();
        }

        /// <summary>
        /// Replace letters with accents by their corresponding alphabet letter.
        /// </summary>
        private void replaceAccents()
        {
            matchingString = matchingString.Replace("É", "E");
            matchingString = matchingString.Replace("È", "E");
            matchingString = matchingString.Replace("Ê", "E");
            matchingString = matchingString.Replace("Ë", "E");
            matchingString = matchingString.Replace("Ñ", "N");
            matchingString = matchingString.Replace("Í", "I");
            matchingString = matchingString.Replace("Ç", "C");
            matchingString = matchingString.Replace("Ä", "A");
            matchingString = matchingString.Replace("Å", "A");
            matchingString = matchingString.Replace("À", "A");
            matchingString = matchingString.Replace("Ö", "O");
            matchingString = matchingString.Replace("Ü", "U");
            matchingString = matchingString.Replace("Ú", "U");
            matchingString = matchingString.Replace("Û", "U");
            matchingString = matchingString.Replace("Ù", "U");
            matchingString = matchingString.Replace("Ã", "A");
            matchingString = matchingString.Replace("Õ", "O");
            matchingString = matchingString.Replace("Â", "A");
            matchingString = matchingString.Replace("Á", "A");
            matchingString = matchingString.Replace("Î", "I");
            matchingString = matchingString.Replace("Ï", "I");
            matchingString = matchingString.Replace("Ì", "I");
            matchingString = matchingString.Replace("Ó", "O");
            matchingString = matchingString.Replace("Ô", "O");
            matchingString = matchingString.Replace("Ò", "O");
        }

        /// <summary>
        /// Delete each sentence between parenthesis in the matching string.
        /// </summary>
        private void deleteBetweenParenthesis()
        {
            while (deleteParenthesis()) { }
        }

        /// <summary>
        /// Delete a sentence between parenthesis in the matching string if any.
        /// </summary>
        /// <returns>true if a phrase between parenthesis is present, false otherwise.</returns>
        private bool deleteParenthesis()
        {
            int indexOfFirst = matchingString.IndexOf('(');
            if (indexOfFirst == -1)
                return false;

            int indexOfSecond = matchingString.IndexOf(')');
            if (indexOfSecond == -1) {
                matchingString = matchingString.Remove(indexOfFirst);
                return true;
            }

            matchingString = matchingString.Remove(indexOfFirst, indexOfSecond - indexOfFirst + 1);

            return true;
        }

        /// <summary>
        /// Delete each sentence between brackets in the matching string.
        /// </summary>
        private void deleteBetweenBrackets()
        {
            while (deleteBrackets()) { }
        }

        /// <summary>
        /// Delete a sentence between brackets in the matching string if any.
        /// </summary>
        /// <returns>true if a phrase between brackets is present, false otherwise</returns>
        private bool deleteBrackets()
        {
            int indexOfFirst = matchingString.IndexOf('[');
            if (indexOfFirst == -1)
                return false;

            int indexOfSecond = matchingString.IndexOf(']');
            if(indexOfSecond == -1)
            {
                matchingString = matchingString.Remove(indexOfFirst);
                return true;
            }

            matchingString = matchingString.Remove(indexOfFirst, indexOfSecond - indexOfFirst + 1);

            return true;
        }

        /// <summary>
        /// Delete each occurences of '/' in the matching string.
        /// </summary>
        private void deleteSlash()
        {
            //TODO: See if it is better than MP3ModifierFactory
            matchingString = matchingString.Replace("/", string.Empty);
        }

        /// <summary>
        /// Delete 'ft' and 'featuring' terms in the matching string.
        /// </summary>
        private void deleteFeaturings()
        {
            matchingString = matchingString.Replace("FEAT.", string.Empty);
            matchingString = matchingString.Replace("FT.", string.Empty);
            matchingString = matchingString.Replace("FEATURING.", string.Empty);
            matchingString = matchingString.Replace("FEAT", string.Empty);
            matchingString = matchingString.Replace("FT", string.Empty);
            matchingString = matchingString.Replace("FEATURING", string.Empty);
        }

        /// <summary>
        /// Remove the digit before a song, separated from the rest of 
        /// the string with a '.' or a '-'.
        /// </summary>
        private void removeDigitBeforeSong()
        {
            Regex myRegex = new Regex(@"^[0-9]+$");

            int indexOfDash = matchingString.IndexOf("-");

            // Si il y a une - dans la string
            if (indexOfDash > 0)
            {

                // On check bien si ce qu'il y a entre le début de la phrase et le '-' est un chiffre
                string substr = matchingString.Substring(0, indexOfDash);

                if (myRegex.IsMatch(substr))
                {
                     matchingString = matchingString.Remove(0, indexOfDash + 1);
                }

            }

            int indexOfPoint = matchingString.IndexOf(".");

            // Si il y a un . dans la string
            if (indexOfPoint > 0)
            {

                // On check bien si ce qu'il y a entre le début de la phrase et le '.' est un chiffre
                string substr = matchingString.Substring(0, indexOfPoint);

                if (myRegex.IsMatch(substr))
                {
                     matchingString = matchingString.Remove(0, indexOfPoint + 1);
                }
            }

        }

        /// <summary>
        /// Delete each form of ponctuation in matching string.
        /// </summary>
        private void deletePonctuation()
        {
            matchingString = matchingString.Replace(".", string.Empty);
            matchingString = matchingString.Replace("?", string.Empty);
            matchingString = matchingString.Replace("!", string.Empty);
            matchingString = matchingString.Replace("’", string.Empty);
            matchingString = matchingString.Replace("'", string.Empty);
            matchingString = matchingString.Replace(",", string.Empty);
            matchingString = matchingString.Replace("\"", string.Empty);
            matchingString = matchingString.Replace("*", string.Empty);
            matchingString = matchingString.Replace("~", string.Empty);
        }

        /// <summary>
        /// Replaces occurences of '&' by 'and' in the matching string.
        /// </summary>
        private void replaceAnd()
        {
            matchingString = matchingString.Replace("&", "AND");
        }

        /// <summary>
        /// Removes last sentence of the matching string (designed by a '-')
        /// if it contains a special term.
        /// </summary>
        /// <param name="isOnlyTitle">If the matching string only corresponds to title.</param>
        /// <remarks>
        /// If the matching string is the title, we don't testify if there is more than two '-'.
        /// </remarks>
        private void removeLastSentence(bool isOnlyTitle)
        {
            int lastIndex = matchingString.LastIndexOf("-");
            int firstIndex = -1;

            if (!isOnlyTitle)
            {
                firstIndex = matchingString.IndexOf("-");
                if (firstIndex == lastIndex)
                    return;
            }

            if (lastIndex != -1)
            {

                string toAnalyze = matchingString.Substring(lastIndex);


                if (toAnalyze.Contains("REMASTER"))
                {
                    matchingString = matchingString.Remove(lastIndex);
                    return;
                }

                if (toAnalyze.Contains("VERSION"))
                {
                    matchingString = matchingString.Remove(lastIndex);
                    return;
                }

                if (toAnalyze.Contains("MONO"))
                {
                    matchingString = matchingString.Remove(lastIndex);
                    return;
                }

                if (toAnalyze.Contains("STEREO"))
                {
                    matchingString = matchingString.Remove(lastIndex);
                    return;
                }

                if (toAnalyze.Contains("ORIGINAL"))
                {
                    matchingString = matchingString.Remove(lastIndex);
                    return;
                }

                if (toAnalyze.Contains("EDIT"))
                {
                    matchingString = matchingString.Remove(lastIndex);
                    return;
                }

                if (toAnalyze.Contains("RADIO"))
                {
                    matchingString = matchingString.Remove(lastIndex);
                    return;
                }

                if (toAnalyze.Contains("REMIX"))
                {
                    matchingString = matchingString.Remove(lastIndex);
                    return;
                }

                if (toAnalyze.Contains("FROM"))
                {
                    matchingString = matchingString.Remove(lastIndex);
                }
            }
        }

        /// <summary>
        /// Delete all instance of '-' in the matching string.
        /// </summary>
        private void deleteDash()
        {
            matchingString = matchingString.Replace("-", string.Empty);
        }

        /// <summary>
        /// Delete the word "lyrics" from the matching string if present.
        /// </summary>
        private void deleteLyrics()
        {
            matchingString = matchingString.Replace("LYRICS", string.Empty);
        }

    }
}
