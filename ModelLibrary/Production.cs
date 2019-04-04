using System;

namespace ModelLibrary
{
    public class Production
    {
        public int Production_ID { get; set; } //PK
        public int PalletPutInStock0001 { get; set; }
        public int TapMachine { get; set; }
        public int TotalKegsPrPallet { get; set; }
        public int Counter { get; set; }
        public int Pallet_Counter { get; set; }
        public DateTime BatchDate { get; set; }

    }
}
