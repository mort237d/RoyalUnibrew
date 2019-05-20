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
        public ObservableCollection<Productions> ProductionsList { get; set; }

        public ObservableCollection<TUs> TUsList { get; set; }

        public CalculateProductions()
        {
            ProductionsList = ModelGenerics.GetAll(new Productions());
            TUsList = ModelGenerics.GetAll(new TUs());
            
        }

        public int CalculatePalletCounter(int processOrderNr)
        {
            int palletCounterResult = 0;


            var result = from l1 in ProductionsList
                join l2 in TUsList
                    on l1.ProcessOrder_No equals processOrderNr
                select new { l1.ProcessOrder_No, Value1 = l1.PalletPutInStock0001, Value2 = l2.FirstDay_Total, Value3 = l2.SecoundDay_Total, value4 = l2.ThirdDay_Total};

            foreach (var item in result)
            {
                palletCounterResult += item.Value1 + item.Value2 + item.Value3 + item.value4;
            }
            return palletCounterResult;
        }
    }
}
