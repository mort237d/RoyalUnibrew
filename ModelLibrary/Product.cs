namespace ModelLibrary
{
    public class Product
    {
        public Product(int finishedProduct_No, string productName, int bedstBeforeDateLength)
        {
            FinishedProduct_No = finishedProduct_No;
            ProductName = productName;
            BedstBeforeDateLength = bedstBeforeDateLength;
        }

        public Product()
        {
            
        }

        public int FinishedProduct_No { get; set; }
        public string ProductName { get; set; }
        public int BedstBeforeDateLength { get; set; }
    }
}
