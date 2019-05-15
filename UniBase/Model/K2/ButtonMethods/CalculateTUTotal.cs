using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    class CalculateTUTotal
    {
        public int CalculateTUDayTotal(int dayStart, int dayEnd)
        {
            int result = (dayEnd / 10) - (dayStart / 10) + 1;
            return result;
        }
    }
}
