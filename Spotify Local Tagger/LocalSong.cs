using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Local_Tagger
{
    /// <summary>
    /// Specifies a local song.
    /// </summary>
    public class LocalSong : Song
    {
        /// <summary>
        /// The instance of the track.
        /// </summary>
        TagLib.File _track;

        /// <summary>
        /// Initializes a local song and its matching string.
        /// </summary>
        /// <param name="theTrack"></param>
        public LocalSong(TagLib.File theTrack)
        {
            _track = theTrack;
            initMatchingString();
            processMatchingString();
        }

        /// <summary>
        /// Initializes the matching string with the track name.
        /// </summary>
        public override void initMatchingString()
        {
            matchingString = Path.GetFileNameWithoutExtension(_track.Name);
        }

        /// <summary>
        /// Initializes the string to <c>toPut</c>.
        /// </summary>
        /// <param name="toPut">The string value in which the track 
        /// will be initialized.</param>
        public void initMatchingString(string toPut)
        {
            if(toPut != null)
            {
                matchingString = toPut;
            }
        }

        /// <summary>
        /// Get the instance of the track.
        /// </summary>
        /// <returns>The instance of the track.</returns>
        public TagLib.File getTrack()
        {
            return _track;
        }
    }
}
