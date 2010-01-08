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
        private List<CUser> neighbours;

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

        public List<CArtist> Suggestions(int numOfSuggestions)
        {
            const decimal w1 = 0.25M;   // utjecaj broja susjeda koji slušaju danog artista
            const decimal w2 = 0.75M;   // utjecaj ocjena pojedinog susjeda za danog artista

            List<CArtist> ngbArtists = new List<CArtist>();
            Dictionary<CArtist, CArtistScore> artistScores = new Dictionary<CArtist,CArtistScore>();

            foreach (CUser neighbour in neighbours)
            {
                foreach (CArtist artist in neighbour.Artists)
                {
                    if (artistScores.ContainsKey(artist))
                    {
                        artistScores[artist].Score += neighbour.GetArtistScore(artist.ArtistName);
                        artistScores[artist].NumOfFans++;
                    }
                    // ako još nije zapisana ocjena za trenutnog artista
                    // dodaj artista u dictionary s ocjenom trenutnog susjeda
                    else
                    {
                        artistScores.Add(artist, new CArtistScore(neighbour.GetArtistScore(artist.ArtistName)));
                    }
                }
                
            }
            Dictionary<CArtist, decimal> suggestionIntensities = new Dictionary<CArtist, decimal>();
            foreach (KeyValuePair<CArtist, CArtistScore> item in artistScores)
            {
                item.Value.Score = item.Value.Score / item.Value.NumOfFans;
                decimal suggestionIntensity = w1 * item.Value.NumOfFans + w2 * item.Value.Score;
                suggestionIntensities.Add(item.Key, suggestionIntensity);
            }

            if (numOfSuggestions > suggestionIntensities.Count)
            {
                return (from si in suggestionIntensities
                        orderby si.Value
                        select si.Key).Take(numOfSuggestions) as List<CArtist>;
            }
            else
            {
                return (from si in suggestionIntensities
                        orderby si.Value
                        select si.Key) as List<CArtist>;
            }

        }
    }
}
