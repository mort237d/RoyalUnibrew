using System;

namespace UniBase.Model.K2
{
    public class ShiftRegistrations
    {
        public ShiftRegistrations()
        {
            
        }

        public ShiftRegistrations(int shiftRegistration_ID, DateTime start_Time, DateTime end_Date, int breaks, int totalHours, int staff, string initials, int processOrder_No, Frontpages frontpage)
        {
            ShiftRegistration_ID = shiftRegistration_ID;
            Start_Time = start_Time;
            End_Date = end_Date;
            Breaks = breaks;
            TotalHours = totalHours;
            Staff = staff;
            Initials = initials;
            ProcessOrder_No = processOrder_No;
            Frontpage = frontpage;
        }

        public int ShiftRegistration_ID { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime End_Date { get; set; }

        public int Breaks { get; set; }

        public int TotalHours { get; set; }

        public int Staff { get; set; }

        public string Initials { get; set; }

        public int ProcessOrder_No { get; set; }

        public virtual Frontpages Frontpage { get; set; }
    }
}
