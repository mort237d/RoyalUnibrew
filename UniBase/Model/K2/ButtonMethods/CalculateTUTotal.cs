using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model.K2.ButtonMethods
{
    class CalculateTuTotal
    {
        public int CalculateTuDayTotal(int dayStart, int dayEnd)
        {
            int result = (dayEnd / 10) - (dayStart / 10) + 1;
            return result;
        }
    }
}
