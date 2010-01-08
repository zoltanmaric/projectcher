using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    class CArtistScore
    {
        public CArtistScore(decimal score)
        {
            Score = score;
            NumOfFans = 1;
        }

        public decimal Score
        {
            get;
            set;
        }
        public int NumOfFans
        {
            get;
            set;
        }

    }
}
