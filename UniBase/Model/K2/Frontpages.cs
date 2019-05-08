using System;

namespace UniBase.Model.K2
{
    public class Frontpages
    {
        public Frontpages()
        {
            
        }

        public Frontpages(int processOrder_No, DateTime date, int finishedProduct_No, int colunm, string note, int week_No)
        {
            ProcessOrder_No = processOrder_No;
            Date = date;
            FinishedProduct_No = finishedProduct_No;
            Colunm = colunm;
            Note = note;
            Week_No = week_No;
        }

        public int ProcessOrder_No { get; set; }

        public DateTime Date { get; set; }

        public string DateHelper { get; set; }

        public int FinishedProduct_No { get; set; }

        public int Colunm { get; set; }

        public string Note { get; set; }

        public int Week_No { get; set; }
    }
}
