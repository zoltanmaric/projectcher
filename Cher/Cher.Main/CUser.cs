using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    public class CUser
    {
        private int userID;
        private int userIndex;
        private string userName;
        private string url;
        private List<CArtist> artists;
        private Dictionary<string, long> artistNumListens;
        private long totalNumListens;
        private List<CTrack> tracks;

        private double Similarity(CUser cUser, CUser cUser_2)
        {
            throw new NotImplementedException();
        }

        public CUser(int userID, int userIndex, string userName, string url)
        {
            this.userID = userID;
            this.userIndex = userIndex;
            this.userName = userName;
            this.url = url;

            artists = new List<CArtist>();
            artistNumListens = new Dictionary<string, long>();
            totalNumListens = 0;
            tracks = new List<CTrack>();
        }

        public void AddArtist(CArtist newArtist, int numListens)
        {
            artists.Add(newArtist);
            artistNumListens.Add(newArtist.ArtistName, numListens);
            totalNumListens += numListens;
        }

        public void AddTrack(CTrack newTrack)
        {
            tracks.Add(newTrack);
        }

        public decimal GetArtistScore(string artist)
        {
            return (decimal)artistNumListens[artist] / totalNumListens;
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

        public override string ToString()
        {
            return userName;
        }
    }
}
