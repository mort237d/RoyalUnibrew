using System;

namespace ModelLibrary
{
    public class ShiftRegistration
    {
        public int ShiftReg_ID { get; set; } //PK
        public int ProccessOrdre_No { get; set; } //FK
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Staff { get; set; }
        public double TotalHours { get; set; }
        public double Brakes { get; set; }
        public string Initials { get; set; }
    }
}
