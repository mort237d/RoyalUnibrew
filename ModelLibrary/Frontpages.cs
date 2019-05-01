using System;

namespace ModelLibrary
{
    public class Frontpages
    {
        public Frontpages()
        {
            
        }

        public Frontpages(int processOrder_No, DateTime date, int finishedProduct_No, int colunm, string note, int controlSchedule_ID, int controlRegistration_ID, int shiftRegistration_ID, int production_ID, int tU_ID, int week_No)
        {
            ProcessOrder_No = processOrder_No;
            Date = date;
            FinishedProduct_No = finishedProduct_No;
            Colunm = colunm;
            Note = note;
            ControlSchedule_ID = controlSchedule_ID;
            ControlRegistration_ID = controlRegistration_ID;
            ShiftRegistration_ID = shiftRegistration_ID;
            Production_ID = production_ID;
            TU_ID = tU_ID;
            Week_No = week_No;
        }

        public Frontpages(int processOrder_No, DateTime date, int finishedProduct_No, int colunm, string note, int controlSchedule_ID, int controlRegistration_ID, int shiftRegistration_ID, int production_ID, int tU_ID, int week_No, ControlRegistrations controlRegistration, ControlSchedules controlSchedule, Products product, Productions production, ShiftRegistrations shiftRegistration, TUs tU)
        {
            ProcessOrder_No = processOrder_No;
            Date = date;
            FinishedProduct_No = finishedProduct_No;
            Colunm = colunm;
            Note = note;
            ControlSchedule_ID = controlSchedule_ID;
            ControlRegistration_ID = controlRegistration_ID;
            ShiftRegistration_ID = shiftRegistration_ID;
            Production_ID = production_ID;
            TU_ID = tU_ID;
            Week_No = week_No;
            ControlRegistration = controlRegistration;
            ControlSchedule = controlSchedule;
            Product = product;
            Production = production;
            ShiftRegistration = shiftRegistration;
            TU = tU;
        }

        public int ProcessOrder_No { get; set; }

        public DateTime Date { get; set; }

        public int FinishedProduct_No { get; set; }

        public int Colunm { get; set; }

        public string Note { get; set; }

        public int ControlSchedule_ID { get; set; }

        public int ControlRegistration_ID { get; set; }

        public int ShiftRegistration_ID { get; set; }

        public int Production_ID { get; set; }

        public int TU_ID { get; set; }

        public int Week_No { get; set; }

        public virtual ControlRegistrations ControlRegistration { get; set; }

        public virtual ControlSchedules ControlSchedule { get; set; }

        public virtual Products Product { get; set; }

        public virtual Productions Production { get; set; }

        public virtual ShiftRegistrations ShiftRegistration { get; set; }

        public virtual TUs TU { get; set; }
    }
}
