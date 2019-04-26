using System;

namespace ModelLibrary
{
    public class ShiftRegistrations
    {
        public ShiftRegistrations()
        {
            
        }

        public ShiftRegistrations(int shift_Reg, DateTime start_Time, DateTime end_Time, DateTime @break, int staff, double totalHours, string initials)
        {
            Shift_Reg = shift_Reg;
            Start_Time = start_Time;
            End_Time = end_Time;
            Break = @break;
            Staff = staff;
            TotalHours = totalHours;
            Initials = initials;
        }

        public int Shift_Reg { get; set; } //PK
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public DateTime Break { get; set; }
        public int Staff { get; set; }
        public double TotalHours { get; set; }
        public string Initials { get; set; }
    }
}
