using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    class CUser
    {
        private int userID;
        private string userName;
        private string url;
        private List<CArtist> artists;
        // broj slušanja pojedinog artista - indeks
        // i-tom artistu u listi artists odgovara
        // i-ta ocjena u listi artistScores
        private List<int> artistScores;
        private List<CTrack> tracks;

        public CUser(int userID, string userName, string url)
        {
            this.userID = userID;
            this.userName = userName;
            this.url = url;

            artists = new List<CArtist>();
            artistScores = new List<int>();
            tracks = new List<CTrack>();
        }

        public void AddArtist(CArtist newArtist)
        {
            artists.Add(newArtist);
        }

        /// <summary>
        /// Dodaje vrijednost score na posljednje mjesto
        /// u listi ocjena. i-ta ocjena u listi ocjena
        /// odgovara i-tom artistu u listi artista.
        /// </summary>
        /// <param name="score">Ocjena (broj slušanja).</param>
        public void AddArtistScore(int score)
        {
            artistScores.Add(score);
        }

        public void AddTrack(CTrack newTrack)
        {
            tracks.Add(newTrack);
        }

        public int UserID
        {
            get { return userID; }
        }
    }
}
