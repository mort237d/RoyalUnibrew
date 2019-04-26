using System;

namespace ModelLibrary
{
    public class ControlSchedules
    {
        public int Control_ID { get; set; } //PK
        public DateTime Time { get; set; }
        public DateTime WeightControlTime { get; set; } //Tidspunktet hvor vægten blev kontroleret
        public double Weight { get; set; }
        public string ReceiptForTest { get; set; }
        public string KegTest { get; set; }
        public double LudKoncentration { get; set; }
        public double MipMA { get; set; }
        public string Signature { get; set; }
        public string Note { get; set; }
    }
}
