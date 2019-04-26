using System;

namespace ModelLibrary
{
    public class ShiftRegistrations
    {
        public int Shift_Reg { get; set; } //PK
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public DateTime Break { get; set; }
        public int Staff { get; set; }
        public double TotalHours { get; set; }
        public string Initials { get; set; }
    }
}
