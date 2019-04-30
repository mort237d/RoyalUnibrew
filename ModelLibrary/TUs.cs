namespace ModelLibrary
{
    public class TUs
    {
        public TUs()
        {
            
        }

        public TUs(int tU_ID, int firstDayStart_TU, int firstDayEnd_TU, int firstDay_Total, int secoundDayStart_TU, int secoundDayEnd_TU, int secoundDay_Total, int thirdDayStart_TU, int thirdDayEnd_TU, int thirdDay_Total)
        {
            TU_ID = tU_ID;
            FirstDayStart_TU = firstDayStart_TU;
            FirstDayEnd_TU = firstDayEnd_TU;
            FirstDay_Total = firstDay_Total;
            SecoundDayStart_TU = secoundDayStart_TU;
            SecoundDayEnd_TU = secoundDayEnd_TU;
            SecoundDay_Total = secoundDay_Total;
            ThirdDayStart_TU = thirdDayStart_TU;
            ThirdDayEnd_TU = thirdDayEnd_TU;
            ThirdDay_Total = thirdDay_Total;
        }

        public int TU_ID { get; set; }

        public int FirstDayStart_TU { get; set; }

        public int FirstDayEnd_TU { get; set; }

        public int FirstDay_Total { get; set; }

        public int SecoundDayStart_TU { get; set; }

        public int SecoundDayEnd_TU { get; set; }

        public int SecoundDay_Total { get; set; }

        public int ThirdDayStart_TU { get; set; }

        public int ThirdDayEnd_TU { get; set; }

        public int ThirdDay_Total { get; set; }
    }
}
