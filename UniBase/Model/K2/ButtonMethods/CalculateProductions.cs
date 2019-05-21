using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int CalculatePalletCounter(int processOrderNr)
        {
            int palletCounterResult = 0;

            //
            //            var result = from l1 in ProductionMethod.Instance.CompleteProductionsList
            //                join l2 in TuMethod.Instance.CompleteTUsList
            //                    on l1.ProcessOrder_No equals l2.ProcessOrder_No
            //                select new { l1.ProcessOrder_No, Value1 = l1.PalletPutInStock0001, Value2 = l2.FirstDay_Total, Value3 = l2.SecoundDay_Total, value4 = l2.ThirdDay_Total};

            //            foreach (var item in result)
            //            {
            //                palletCounterResult += item.Value1 + item.Value2 + item.Value3 + item.value4;
            //            }


            foreach (var tUItem in _tUlist)
            {
                foreach (var productItem in _productionList)
                {
                    if (productItem.ProcessOrder_No == tUItem.ProcessOrder_No)
                    {
                        palletCounterResult += productItem.PalletPutInStock0001 + tUItem.FirstDay_Total +
                                               tUItem.SecoundDay_Total + tUItem.ThirdDay_Total;
                    }
                }
            }

            return palletCounterResult;
        }
    }
}
