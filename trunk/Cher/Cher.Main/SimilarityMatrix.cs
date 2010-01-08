using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    public class SimilarityMatrix
    {
        private decimal[][] matrix;

        public const decimal ownSimilarity = 0.0m;

        public decimal[] GetSimilaritiesRow(int paramUserIndex)
        {
            return matrix[paramUserIndex];
        }

        public SimilarityMatrix(List<CUser> paramUsers)
        {
            int numUsers = paramUsers.Count;
            matrix = new decimal[numUsers][];
            for (int x = 0; x < numUsers; ++x) matrix[x] = new decimal[numUsers];
            
            matrix[0][0] = ownSimilarity;
            for (int i = 0; i < (numUsers - 1); ++i)
            {
                for (int j = i + 1; j < numUsers; ++j)
                {
                    
                    matrix[j][j] = ownSimilarity;
                    matrix[j][i] = matrix[i][j] = Similarity(paramUsers[i], paramUsers[j]);
                }
            }
        }

        private decimal Similarity(CUser cUser1, CUser cUser2)
        {
            List<CArtist> intersection = new List<CArtist>();
            foreach (CArtist artist in cUser1.Artists)
            {
                if (cUser2.Artists.Contains(artist))
                {
                    intersection.Add(artist);
                }
            }

            int numSimilar = 0;
            decimal score = 0;
            foreach (CArtist artist in intersection)
            {
                score += cUser1.GetArtistScore(artist.ArtistName) * cUser2.GetArtistScore(artist.ArtistName);
            }

            return score;
        }
        
    }
}
