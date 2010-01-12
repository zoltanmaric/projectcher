using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cher.Main;

namespace Cher.Main
{
    public static class Neighbourhood
    {
        private static SimilarityMatrix similarityMatrix;

        public static SimilarityMatrix SimilarityMatrix
        {
            get { return Neighbourhood.similarityMatrix; }
            set { Neighbourhood.similarityMatrix = value; }
        }

        public static List<CUser> GetNeighbourhood(CUser paramUser, List<CUser> paramAllUsers, int paramSize)
        {
            int index = paramAllUsers.IndexOf(paramUser);
            decimal[] similarities = similarityMatrix.GetSimilaritiesRow(index);

            Dictionary<CUser, decimal> similarityDict = new Dictionary<CUser,decimal>();
            
            for (int i = 0; i < paramAllUsers.Count; i++)
            {
                similarityDict.Add(paramAllUsers[i], similarities[i]);
            }

            List<CUser> neighbourhood = (from simi in similarityDict
                                        orderby simi.Value descending
                                        select simi.Key).Take(paramSize).ToList();
            
            return neighbourhood;
        }
    }
}
