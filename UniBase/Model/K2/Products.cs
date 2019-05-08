namespace UniBase.Model.K2
{
    public class Products
    {
        public Products(int finishedProduct_No, string productName, int bestBeforeDateLength)
        {
            FinishedProduct_No = finishedProduct_No;
            ProductName = productName;
            BestBeforeDateLength = bestBeforeDateLength;
        }

        public Products()
        {
            
        }

        public int FinishedProduct_No { get; set; }

        public string ProductName { get; set; }

        public int BestBeforeDateLength { get; set; }
    }
}
