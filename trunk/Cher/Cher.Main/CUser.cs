using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    class CUser
    {
        private int userID;
        private int userIndex;
        private string userName;
        private string url;
        private List<CArtist> artists;
        // broj slušanja pojedinog artista - indeks
        // i-tom artistu u listi artists odgovara
        // i-ta ocjena u listi artistScores
        private List<long> artistNumListens;
        private long totalNumListens;
        private List<CTrack> tracks;

        public CUser(int userID, int userIndex, string userName, string url)
        {
            this.userID = userID;
            this.userIndex = userIndex;
            this.userName = userName;
            this.url = url;

            artists = new List<CArtist>();
            artistNumListens = new List<long>();
            totalNumListens = 0;
            tracks = new List<CTrack>();
        }

        public void AddArtist(CArtist newArtist, int numListens)
        {
            artists.Add(newArtist);
            artistNumListens.Add(numListens);
            totalNumListens += numListens;
        }

        public void AddTrack(CTrack newTrack)
        {
            tracks.Add(newTrack);
        }

        public decimal GetArtistScore(int artistIndex)
        {
            return (decimal)artistNumListens[artistIndex] / totalNumListens;
        }

        public int UserID
        {
            get { return userID; }
        }

        public string UserName
        {
            get { return userName; }
        }

        public List<CArtist> Artists
        {
            get { return artists; }
        }

        public List<long> ArtistNumListens
        {
            get { return artistNumListens; }
        }

        public override string ToString()
        {
            return userName;
        }
    }
}
