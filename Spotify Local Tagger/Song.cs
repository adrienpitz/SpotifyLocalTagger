using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.WriteLine(matchingString);
        }

    }
}
