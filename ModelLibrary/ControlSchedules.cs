using System;

namespace ModelLibrary
{
    public class ControlSchedules
    {
        public ControlSchedules()
        {
            
        }

        public ControlSchedules(int control_ID, DateTime time, DateTime weightControlTime, int weight, string receiptForTest, string kegTest, double ludKoncentration, double mipMA, string signature, string note)
        {
            Control_ID = control_ID;
            Time = time;
            WeightControlTime = weightControlTime;
            Weight = weight;
            ReceiptForTest = receiptForTest;
            KegTest = kegTest;
            LudKoncentration = ludKoncentration;
            MipMA = mipMA;
            Signature = signature;
            Note = note;
        }

        public int Control_ID { get; set; } //PK
        public DateTime Time { get; set; }
        public DateTime WeightControlTime { get; set; } //Tidspunktet hvor vægten blev kontroleret
        public int Weight { get; set; }
        public string ReceiptForTest { get; set; }
        public string KegTest { get; set; }
        public double LudKoncentration { get; set; }
        public double MipMA { get; set; }
        public string Signature { get; set; }
        public string Note { get; set; }
    }
}
