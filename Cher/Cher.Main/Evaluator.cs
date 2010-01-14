using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    public class Evaluator
    {
        List<CUser> users;
        List<List<CArtist>> recommendedArtistsCher;
        List<List<string>> recommendedArtistsLastFM;

        /// <summary>
        /// Za ovu varijantu racunanja rezultata treba dati jednak broj
        /// preporuka dobivenih od Cher i od Last.fm-a.
        /// </summary>
        /// <returns></returns>
        public Results CalculateResultsA()
        {
            // Ovo ćemo koristiti za mikro-usrednjavanje na kraju.
            int sumTruePositives = 0;
            int sumFalsePositives = 0;
            int sumFalseNegatives = 0;

            // Sume koje se koriste za makro-usrednjavanje
            double sumPrecision = 0.0;
            double sumRecall = 0.0;
            double sumF1 = 0.0;

            for (int i = 0; i < users.Count; ++i)
            {
                
                List<CArtist> cherovePreporuke = recommendedArtistsCher[i];
                List<string> lastFMovePreporuke = recommendedArtistsLastFM[i];
                
                if (cherovePreporuke.Count != lastFMovePreporuke.Count)
                    return null;

                // Za jednog korisnika
                int thisTruePositives = 0;
                int thisFalsePositives = 0;
                int thisFalseNegatives = 0;

                for (int j = 0; j < lastFMovePreporuke.Count; ++j)
                {
                    CArtist artist = new CArtist(0, 0, lastFMovePreporuke[j]);
                    if (cherovePreporuke.Contains(artist))
                    {
                        ++thisTruePositives;
                    }
                    else
                    {
                        ++thisFalseNegatives;
                    }
                    thisFalsePositives = cherovePreporuke.Count - thisTruePositives;
                }
                // Sad imamo sve TP, FP i FN za jednog korisnika.

                double thisPrecision = (double)thisTruePositives /(thisTruePositives+thisFalsePositives); // jel ovo dobro casta sve u double?
                double thisRecall = (double)thisTruePositives / (thisTruePositives + thisFalseNegatives);
                double thisF1 = 2 * thisPrecision * thisRecall / (thisPrecision + thisRecall);

                // Ovo ćemo koristiti za makro-usrednjavanje na kraju.
                sumPrecision += thisPrecision;
                sumRecall += thisRecall;
                sumF1 += thisF1;

                // Ovo ćemo koristiti za mikro-usrednjavanje na kraju.
                sumTruePositives += thisTruePositives;
                sumFalsePositives += thisFalsePositives;
                sumFalseNegatives += thisFalseNegatives;
            }

            // Gotove makro-usrednjene vrijednosti
            double macroAveragedPrecision = sumPrecision / users.Count;
            double macroAveragedRecall = sumRecall / users.Count;
            double macroAveragedF1 = sumF1 / users.Count;

            // Prosječne vrijednosti TP, FP i FN koje se koriste za mikro-usrednjavanje
            double sumTruePositivesD = (double)sumTruePositives / (double) users.Count;
            double sumFalsePositivesD = (double)sumFalsePositives / (double) users.Count;
            double sumFalseNegativesD = (double)sumFalseNegatives / (double)users.Count;

            // Gotove mikro-usrednjene vrijednosti
            double microAveragedPrecision = sumTruePositivesD / (sumTruePositivesD + sumFalsePositivesD); // jel ovo dobro casta sve u double?
            double microAveragedRecall = sumTruePositivesD / (sumTruePositivesD + sumFalseNegativesD);
            double microAveragedF1 = 2 * microAveragedPrecision * microAveragedRecall / (microAveragedPrecision + microAveragedRecall);

            Results r = new Results(macroAveragedPrecision, macroAveragedRecall, macroAveragedF1,
                                    microAveragedPrecision, microAveragedRecall, microAveragedF1);

            return r;
        }

        /// <summary>
        /// Za ovu varijantu racunanja rezultata treba dati manji broj
        /// preporuka dobivenih od Cher i sve preporuke od Last.fm-a.
        /// </summary>
        /// <returns></returns>
        public Results CalculateResultsB()
        {
            return null; ////////!!!!!
        }

        public void AddUserWithRecommendations(CUser paramUser, List<CArtist> paramRecsCher, List<string> paramRecsLastFM)
        {
            users.Add(paramUser);
            recommendedArtistsCher.Add(paramRecsCher);
            recommendedArtistsLastFM.Add(paramRecsLastFM);
        }

        public Evaluator()
        {
            users = new List<CUser>();
            recommendedArtistsCher = new List<List<CArtist>>();
            recommendedArtistsLastFM = new List<List<string>>();
        }
    }
}
