using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    public static class CalculateProductions
    {
        private static TUs _tUs = new TUs();
        private static Productions _productions = new Productions();

        public static int CalculatePalletCounter()
        {
            int result = _tUs.FirstDay_Total + _tUs.SecoundDay_Total + _tUs.ThirdDay_Total + _productions.PalletPutInStock0001;
            return result;
        }
    }
}
