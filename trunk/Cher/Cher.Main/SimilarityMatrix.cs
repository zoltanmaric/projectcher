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

            decimal score = 0;
            decimal sumSquares1 = 0, sumSquares2 = 0;
            foreach (CArtist artist in intersection)
            {
                decimal userScore1 = cUser1.GetArtistScore(artist.ArtistName);
                decimal userScore2 = cUser2.GetArtistScore(artist.ArtistName);
                sumSquares1 = userScore1 * userScore1;
                sumSquares2 = userScore2 * userScore2;
                score += userScore1 * userScore2;
            }

            if ((sumSquares1 != 0) && (sumSquares2 != 0))
                score /= (decimal)(Math.Sqrt((double)sumSquares1) * Math.Sqrt((double)sumSquares2));

            return score;
        }
        
    }
}
