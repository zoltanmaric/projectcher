using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    class CArtist
    {
        // ID u bazi
        private int artistID;
        // indeks u listi artista u ovom modelu
        private int artistIndex;
        private string artistName;
        private string bio;
        private string url;
        private List<CUser> users;

        public CArtist(int artistID, int artistIndex, string artistName, string bio, string url)
        {
            this.artistID = artistID;
            this.artistIndex = artistIndex;
            this.artistName = artistName;
            this.bio = bio;
            this.url = url;

            users = new List<CUser>();
        }

        public void AddUser(CUser newUser)
        {
            users.Add(newUser);
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
