using System;

namespace ModelLibrary
{
    public class ControlSchedules
    {
        public ControlSchedules()
        {
            
        }

        public ControlSchedules(int controlSchedule_ID, DateTime time, double weight, string kegTest, double ludKoncentration, double mipMA, string signature, string note, int processOrder_No, Frontpages frontpage)
        {
            ControlSchedule_ID = controlSchedule_ID;
            Time = time;
            Weight = weight;
            KegTest = kegTest;
            LudKoncentration = ludKoncentration;
            MipMA = mipMA;
            Signature = signature;
            Note = note;
            ProcessOrder_No = processOrder_No;
            Frontpage = frontpage;
        }

        public int ControlSchedule_ID { get; set; }

        public DateTime Time { get; set; }

        public double Weight { get; set; }
        
        public string KegTest { get; set; }

        public double LudKoncentration { get; set; }

        public double MipMA { get; set; }
        
        public string Signature { get; set; }

        public string Note { get; set; }

        public int ProcessOrder_No { get; set; }

        public virtual Frontpages Frontpage { get; set; }
    }
}
