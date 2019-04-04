using System;

namespace ModelLibrary
{
    public class ControlRegistration
    {
        public int LabelContro_ID { get; set; } //PK
        public DateTime Time { get; set; }
        public DateTime ProductionDate { get; set; }
        public string CommentsOnChangedDate { get; set; }
        public bool ControlAlacholSpearDispenser { get; set; }
        public int Cap_No { get; set; }
        public int Etiquette_No { get; set; }
        public int KegSize { get; set; }
        public string Signature { get; set; }
        public DateTime FirstPalletDepalletizing { get; set; }
        public DateTime LastPalletDepalletizing { get; set; }

    }
}
