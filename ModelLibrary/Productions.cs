using System;

namespace ModelLibrary
{
    public class Productions
    {
        public Productions()
        {
            
        }

        public Productions(int production_ID, int palletPutInStock0001, int tapmachine, int totalKegsPrPallet, int counter, int palletCounter, DateTime batchDate)
        {
            Production_ID = production_ID;
            PalletPutInStock0001 = palletPutInStock0001;
            Tapmachine = tapmachine;
            TotalKegsPrPallet = totalKegsPrPallet;
            Counter = counter;
            PalletCounter = palletCounter;
            BatchDate = batchDate;
        }

        public int Production_ID { get; set; }

        public int PalletPutInStock0001 { get; set; }

        public int Tapmachine { get; set; }

        public int TotalKegsPrPallet { get; set; }

        public int Counter { get; set; }

        public int PalletCounter { get; set; }

        public DateTime BatchDate { get; set; }
    }
}
