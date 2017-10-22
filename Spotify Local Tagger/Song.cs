using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spotify_Local_Tagger
{
    abstract class Song
    {

        protected String matchingString;

        public Song()
        {
            matchingString = String.Empty;
        }

        public abstract void initMatchingString();

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
            //TODO : Remove
            Console.WriteLine(matchingString);
        }

        private void deleteSpaces()
        {
            matchingString = matchingString.Replace(" ", string.Empty);
        }

        private void deleteUnderScores()
        {
            matchingString = matchingString.Replace("_", string.Empty);
        }

        private void deleteApostrophe()
        {
            matchingString = matchingString.Replace("'", string.Empty);
        }

        private void setToUpperCase()
        {
            matchingString = matchingString.ToUpper();
        }

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
            matchingString = matchingString.Replace("Ö", "O");
            matchingString = matchingString.Replace("Ü", "U");
            matchingString = matchingString.Replace("Ã", "A");
            matchingString = matchingString.Replace("Õ", "O");
            matchingString = matchingString.Replace("Â", "A");
            matchingString = matchingString.Replace("Á", "A");
            matchingString = matchingString.Replace("Î", "I");
            matchingString = matchingString.Replace("Ï", "I");
            matchingString = matchingString.Replace("Ì", "I");
            matchingString = matchingString.Replace("Ó", "O");
            matchingString = matchingString.Replace("Ô", "O");
        }

        private void deleteBetweenParenthesis()
        {
            while (deleteParenthesis()) { }
        }

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

        private void deleteBetweenBrackets()
        {
            while (deleteBrackets()) { }
        }

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

        private void deleteSlash()
        {
            matchingString = matchingString.Replace("/", string.Empty);
        }

        private void deleteFeaturings()
        {
            matchingString = matchingString.Replace("FEAT.", string.Empty);
            matchingString = matchingString.Replace("FT.", string.Empty);
            matchingString = matchingString.Replace("FEATURING.", string.Empty);
            matchingString = matchingString.Replace("FEAT", string.Empty);
            matchingString = matchingString.Replace("FT", string.Empty);
            matchingString = matchingString.Replace("FEATURING", string.Empty);
        }

        private void removeDigitBeforeSong()
        {
            Regex myRegex = new Regex(@"^[0-9]+");

            int indexOfDash = matchingString.IndexOf("-");

            if(indexOfDash > 0)
            {

                string substr = matchingString.Substring(0, indexOfDash);

                if (myRegex.IsMatch(substr))
                    matchingString = matchingString.Remove(0, indexOfDash+1);

            }
        }

        private void deletePonctuation()
        {
            matchingString = matchingString.Replace(".", string.Empty);
            matchingString = matchingString.Replace("?", string.Empty);
            matchingString = matchingString.Replace("!", string.Empty);
            matchingString = matchingString.Replace("’", string.Empty);
            matchingString = matchingString.Replace("'", string.Empty);
            matchingString = matchingString.Replace(",", string.Empty);
            matchingString = matchingString.Replace("\"", string.Empty);
        }

        private void replaceAnd()
        {
            matchingString = matchingString.Replace("&", "AND");
        }

    }
}
