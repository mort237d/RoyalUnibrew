using System;

namespace ModelLibrary
{
    public class ControlRegistrations
    {
        public ControlRegistrations()
        {
            
        }

        public ControlRegistrations(int labelContro_ID, DateTime time, DateTime productionDate, string commentsOnChangedDate, bool controlAlacholSpearDispenser, int capNo, int etiquetteNo, int kegSize, string signature, DateTime firstPalletDepalletizing, DateTime lastPalletDepalletizing)
        {
            LabelContro_ID = labelContro_ID;
            Time = time;
            ProductionDate = productionDate;
            CommentsOnChangedDate = commentsOnChangedDate;
            ControlAlacholSpearDispenser = controlAlacholSpearDispenser;
            CapNo = capNo;
            EtiquetteNo = etiquetteNo;
            KegSize = kegSize;
            Signature = signature;
            FirstPalletDepalletizing = firstPalletDepalletizing;
            LastPalletDepalletizing = lastPalletDepalletizing;
        }

        public int LabelContro_ID { get; set; } //PK
        public DateTime Time { get; set; }
        public DateTime ProductionDate { get; set; }
        public string CommentsOnChangedDate { get; set; }
        public bool ControlAlacholSpearDispenser { get; set; }
        public int CapNo { get; set; }
        public int EtiquetteNo { get; set; }
        public int KegSize { get; set; }
        public string Signature { get; set; }
        public DateTime FirstPalletDepalletizing { get; set; }
        public DateTime LastPalletDepalletizing { get; set; }

    }
}
