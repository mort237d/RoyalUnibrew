namespace ModelLibrary
{
    public class Products
    {
        public Products(int finishedProduct_No, string productName, int bedstBeforeDateLength)
        {
            FinishedProduct_No = finishedProduct_No;
            ProductName = productName;
            BedstBeforeDateLength = bedstBeforeDateLength;
        }

        public Products()
        {
            
        }

        public int FinishedProduct_No { get; set; }
        public string ProductName { get; set; }
        public int BedstBeforeDateLength { get; set; }
    }
}
