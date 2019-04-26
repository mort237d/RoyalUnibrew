using System;

namespace ModelLibrary
{
    public class Frontpages
    {
        public Frontpages()
        {
            
        }

        public Frontpages(int processOrder_No, int finishedProduct_No, int contro_ID, int labelContro_ID, int shiftReg_ID, int production_ID, int tU_ID, DateTime date, string note, int column, int week_No, Products product)
        {
            ProcessOrder_No = processOrder_No;
            FinishedProduct_No = finishedProduct_No;
            Contro_ID = contro_ID;
            LabelContro_ID = labelContro_ID;
            ShiftReg_ID = shiftReg_ID;
            Production_ID = production_ID;
            TU_ID = tU_ID;
            Date = date;
            Note = note;
            Column = column;
            Week_No = week_No;
            Product = product;
        }

        public int ProcessOrder_No { get; set; } //PK
        public int FinishedProduct_No { get; set; } //FK
        public int Contro_ID { get; set; } //FK
        public int LabelContro_ID { get; set; } //FK           
        public int ShiftReg_ID { get; set; } //FK
        public int Production_ID { get; set; } //FK
        public int TU_ID { get; set; } //FK
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public int Column { get; set; }
        public int Week_No { get; set; }
        public virtual Products Product { get; set; }

    }
}
