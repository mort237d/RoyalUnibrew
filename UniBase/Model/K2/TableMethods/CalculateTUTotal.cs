using System;

namespace UniBase.Model.K2.TableMethods
{
    public class CalculateTUTotal
    {
        public int CalculateTUDayTotal(int dayStart, int dayEnd)
        {
            int result;
            //if % 1 = 0 then the integer can be divided
            if (Math.Abs(((double)dayEnd / 10 - ((double)dayStart / 10)) % 1) < 0.49)
            {
                result = dayEnd / 10 - dayStart / 10 + 1;
            }
            else //else we added 1 more to round up
            {
                result = dayEnd / 10 - dayStart / 10 + 1 + 1;
            }
            return result;
        }

        //Calculates TotalKegs when a textbox is changed that is used to calculate it. Not in use
        public int CalculateTotalKegs(int totalKegsPrPallet, int palletCounter)
        {
            //Gets the TotalKegsPrPallet times PalletCounter and returns it to TotalKegs.
            int result = (totalKegsPrPallet * palletCounter);
            return result;
        }


    }
}
