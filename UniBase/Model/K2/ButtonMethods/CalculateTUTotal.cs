namespace UniBase.Model.K2.ButtonMethods
{
    public class CalculateTUTotal
    {
        

        public int CalculateTUDayTotal(int dayStart, int dayEnd)
        {
            int result = (dayEnd / 10) - (dayStart / 10) + 1;
            return result;
        }

        public int CalculateTotalKegs(int totalKegsPrPallet, int palletCounter)
        {
            int result = (totalKegsPrPallet * palletCounter);
            return result;
        }


    }
}
