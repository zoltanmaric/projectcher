using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    public class CArtist
    {
        // ID u bazi
        private int artistID;
        // indeks u listi artista u ovom modelu
        private int artistIndex;
        private string artistName;

        public CArtist(int artistID, int artistIndex, string artistName)
        {
            this.artistID = artistID;
            this.artistIndex = artistIndex;
            this.artistName = artistName;
        }

        public int ArtistID
        {
            get { return artistID; }
        }

        public int ArtistIndex
        {
            get { return artistIndex; }
        }

        public override string ToString()
        {
            return artistName;
        }

        public string ArtistName
        {
            get { return artistName; }
        }
    }
}
