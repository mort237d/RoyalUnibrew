using System;

namespace ModelLibrary
{
    public class ControlSchedules
    {
        public ControlSchedules()
        {
            
        }

        public ControlSchedules(int controlSchedule_ID, DateTime time, double weight, string kegTest, double ludKoncentration, double mipMA, string signature, string note)
        {
            ControlSchedule_ID = controlSchedule_ID;
            Time = time;
            Weight = weight;
            KegTest = kegTest;
            LudKoncentration = ludKoncentration;
            MipMA = mipMA;
            Signature = signature;
            Note = note;
        }

        public int ControlSchedule_ID { get; set; }

        public DateTime Time { get; set; }

        public double Weight { get; set; }
        
        public string KegTest { get; set; }

        public double LudKoncentration { get; set; }

        public double MipMA { get; set; }
        
        public string Signature { get; set; }

        public string Note { get; set; }
    }
}
