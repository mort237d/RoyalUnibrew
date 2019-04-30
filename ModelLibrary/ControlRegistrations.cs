using System;

namespace ModelLibrary
{
    public class ControlRegistrations
    {
        public ControlRegistrations()
        {
            
        }

        public ControlRegistrations(int controlRegistration_ID, TimeSpan time, DateTime production_Date,
            string commentsOnChangedDate, bool controlAlcoholSpearDispenser, int capNo, int etiquetteNo, double kegSize,
            string signature, DateTime firstPalletDepalletizing, DateTime lastPalletDepalletizing, DateTime expiry_Date)
        {
            ControlRegistration_ID = controlRegistration_ID;
            Time = time;
            Production_Date = production_Date;
            CommentsOnChangedDate = commentsOnChangedDate;
            ControlAlcoholSpearDispenser = controlAlcoholSpearDispenser;
            CapNo = capNo;
            EtiquetteNo = etiquetteNo;
            KegSize = kegSize;
            Signature = signature;
            FirstPalletDepalletizing = firstPalletDepalletizing;
            LastPalletDepalletizing = lastPalletDepalletizing;
            Expiry_Date = expiry_Date;
        }

        public int ControlRegistration_ID { get; set; }

        public TimeSpan Time { get; set; }

        public DateTime Production_Date { get; set; }

        public DateTime Expiry_Date { get; set; }


        public string CommentsOnChangedDate { get; set; }

        public bool ControlAlcoholSpearDispenser { get; set; }

        public int CapNo { get; set; }

        public int EtiquetteNo { get; set; }

        public double KegSize { get; set; }

        public string Signature { get; set; }

        public DateTime FirstPalletDepalletizing { get; set; }

        public DateTime LastPalletDepalletizing { get; set; }
    }
}
