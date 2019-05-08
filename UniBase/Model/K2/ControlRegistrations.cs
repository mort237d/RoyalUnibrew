using System;

namespace UniBase.Model.K2
{
    public class ControlRegistrations
    {
        public ControlRegistrations()
        {
            
        }

        public ControlRegistrations(int controlRegistration_ID, TimeSpan time, DateTime production_Date, DateTime expiry_Date, string commentsOnChangedDate, bool controlAlcoholSpearDispenser, int capNo, int etiquetteNo, double kegSize, string signature, DateTime firstPalletDepalletizing, DateTime lastPalletDepalletizing, int processOrder_No, Frontpages frontpage)
        {
            ControlRegistration_ID = controlRegistration_ID;
            Time = time;
            Production_Date = production_Date;
            Expiry_Date = expiry_Date;
            CommentsOnChangedDate = commentsOnChangedDate;
            ControlAlcoholSpearDispenser = controlAlcoholSpearDispenser;
            CapNo = capNo;
            EtiquetteNo = etiquetteNo;
            KegSize = kegSize;
            Signature = signature;
            FirstPalletDepalletizing = firstPalletDepalletizing;
            LastPalletDepalletizing = lastPalletDepalletizing;
            ProcessOrder_No = processOrder_No;
            Frontpage = frontpage;
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

        public int ProcessOrder_No { get; set; }

        public virtual Frontpages Frontpage { get; set; }
    }
}
