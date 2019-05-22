using System.Collections.ObjectModel;

namespace UniBase.Model.K2.ButtonMethods
{
    public class CalculateProductions
    {
        private ObservableCollection<TUs> _tUlist;
        private ObservableCollection<Productions> _productionList;
        public CalculateProductions()
        {
            Load();
        }

        private async void Load()
        {
            _tUlist = await ModelGenerics.GetAll(new TUs());
            _productionList = await ModelGenerics.GetAll(new Productions());
        }

        //Calculates the PalletCounter when a textbox is changed that is used to calculate it. Not in use
        public int CalculatePalletCounter(int processOrderNr)
        {
            int palletCounterResult = 0;
            //Compares each item in the two list with each other ProcessOrder_No
            foreach (var tUItem in _tUlist)
            {
                foreach (var productItem in _productionList)
                {
                    if (productItem.ProcessOrder_No == tUItem.ProcessOrder_No)
                    {
                        //if the processOrder_No is the same, it adds the data together
                        palletCounterResult += productItem.PalletPutInStock0001 + tUItem.FirstDay_Total +
                                               tUItem.SecoundDay_Total + tUItem.ThirdDay_Total;
                    }
                }
            }

            return palletCounterResult;
        }
    }
}
