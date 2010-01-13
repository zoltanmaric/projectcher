using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cher.Main
{
    public class Results
    {
        private double macroPrecision;
        public double MacroPrecision
        {
            get { return macroPrecision; }
        }

        private double macroRecall;
        public double MacroRecall
        {
            get { return macroRecall; }
        }

        private double macroF1;
        public double MacroF1
        {
            get { return macroF1; }
        }

        private double microPrecision;
        public double MicroPrecision
        {
            get { return microPrecision; }
        }

        private double microRecall;
        public double MicroRecall
        {
            get { return microRecall; }
        }

        private double microF1;
        public double MicroF1
        {
            get { return microF1; }
        }

        public Results(double paramMacroPrecision, double paramMacroRecall, double paramMacroF1,
                       double paramMicroPrecision, double paramMicroRecall, double paramMicroF1)
        {
            macroPrecision = paramMacroPrecision;
            macroRecall = paramMacroRecall;
            macroF1 = paramMacroF1;

            microPrecision = paramMicroPrecision;
            microRecall = paramMicroRecall;
            microF1 = paramMicroF1;
        }
    }
}
