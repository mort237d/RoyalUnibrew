using System;

namespace ModelLibrary
{
    public class ShiftRegistrations
    {
        public ShiftRegistrations()
        {
            
        }

        public ShiftRegistrations(int shiftRegistration_ID, DateTime start_Time, DateTime end_Date, int breaks, int totalHours, int staff, string initials)
        {
            ShiftRegistration_ID = shiftRegistration_ID;
            Start_Time = start_Time;
            End_Date = end_Date;
            Breaks = breaks;
            TotalHours = totalHours;
            Staff = staff;
            Initials = initials;
        }

        public int ShiftRegistration_ID { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime End_Date { get; set; }

        public int Breaks { get; set; }

        public int TotalHours { get; set; }

        public int Staff { get; set; }

        public string Initials { get; set; }
    }
}
