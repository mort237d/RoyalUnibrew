namespace UniBase.Model.K2.ButtonMethods
{
    class CalculateTUTotal
    {
        public int CalculateTUDayTotal(int dayStart, int dayEnd)
        {
            int result = (dayEnd / 10) - (dayStart / 10) + 1;
            return result;
        }

        public int CalculatePalletCounter(int firstDayTotal, int secoundDayTotal, int thirdDayTotal, int palletsOn0001)
        {
            int result = firstDayTotal + secoundDayTotal + thirdDayTotal + palletsOn0001;
            return result;
        }

        public int CalculateTotalKegs(int totalKegsPrPallet, int palletCounter, int pallets)
        {
            int result = (totalKegsPrPallet * palletCounter) + pallets;
            return result;
        }


    }
}
