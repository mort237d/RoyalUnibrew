using System;

namespace ModelLibrary
{
    public class Productions
    {
        public int Production_ID { get; set; } //PK

        public int PalletPutInStock0001 { get; set; }

        public int Tapmachine { get; set; }

        public int TotalKegsPrPallet { get; set; }

        public int Counter { get; set; }

        public int PalletCounter { get; set; }

        public DateTime BatchDate { get; set; }
    }
}
