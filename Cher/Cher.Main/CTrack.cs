using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    public class CTrack
    {
        private int trackID;
        private string title;
        private string artistName;
        private string url;

        public CTrack(int trackID, string title, string artistName, string url)
        {
            this.trackID = trackID;
            this.title = title;
            this.artistName = artistName;
            this.url = url;
        }
    }
}
