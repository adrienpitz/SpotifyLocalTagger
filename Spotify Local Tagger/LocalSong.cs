using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Local_Tagger
{
    class LocalSong : Song
    {
        TagLib.File track;

        public LocalSong(TagLib.File theTrack)
        {
            track = theTrack;
            initMatchingString();
            processMatchingString();
        }

        public override void initMatchingString()
        {
            matchingString = Path.GetFileNameWithoutExtension(track.Name);
        }
    }
}
