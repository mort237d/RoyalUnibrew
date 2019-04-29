using System;

namespace ModelLibrary
{
    public class Frontpages
    {
        public Frontpages()
        {
            
        }

        public Frontpages(int processOrder_No, int finishedProduct_No, int control_ID, int labelControl_ID, int shiftReg_Reg, int production_ID, int tU_ID, DateTime date, string note, int column, int week_No, Products product)
        {
            ProcessOrder_No = processOrder_No;
            FinishedProduct_No = finishedProduct_No;
            Control_ID = control_ID;
            LabelControl_ID = labelControl_ID;
            Shift_Reg = shiftReg_Reg;
            Production_ID = production_ID;
            TU_ID = tU_ID;
            Date = date;
            Note = note;
            Column = column;
            Week_No = week_No;
            Product = product;
        }

        public int ProcessOrder_No { get; set; } //PK
        public DateTime Date { get; set; }
        public int FinishedProduct_No { get; set; } //FK
        public int Column { get; set; }
        public string Note { get; set; }
        public int Week_No { get; set; }
        public int Control_ID { get; set; }
        public int LabelControl_ID { get; set; }
        public int Shift_Reg { get; set; }
        public int Production_ID { get; set; }
        public int TU_ID { get; set; }
        public virtual ControlRegistrations ControlRegistration { get; set; }
        public virtual ControlSchedules ControlSchedule { get; set; }
        public virtual Products Product { get; set; }
        public virtual Productions Production { get; set; }
        public virtual ShiftRegistrations ShiftRegistration { get; set; }
        public virtual TUs TU { get; set; }
    }
}
