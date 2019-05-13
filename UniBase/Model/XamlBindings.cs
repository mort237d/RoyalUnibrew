using System.Collections.Generic;

namespace UniBase.Model
{
    class XamlBindings
    {
        #region Properties
        public string PlaceHolderDate { get; set; } = "2000/01/01";
        public string PlaceHolderTimeSpan { get; set; } = "00:00:00";
        public string PlaceholderString { get; set; } = "Tekst";
        public int PlaceHolderInt { get; set; } = 0;
        public double PlaceHolderDouble { get; set; } = 0.00;
        #endregion

        #region PropertyLists
        public List<FrontPageHeader> FrontPageHeaderList { get; set; }

        

        #endregion

        public XamlBindings()
        {
            FrontPageHeaderList = new List<FrontPageHeader>
            {
                new FrontPageHeader("ProcessOrdre Nr", "Sorter efter ProcessOdre Nr"),
                new FrontPageHeader("Dato", "Sorter efter Dato"),
                new FrontPageHeader("Færdigt Produkt Nr", "Sorter efter Færdigt Produkt Nr"),
                new FrontPageHeader("Kolonne", "Sorter efter Kolonne"),
                new FrontPageHeader("Note", "Sorter efter Note"),
                new FrontPageHeader("Uge Nr", "Sorter efter Uge Nr")
            };
        }

       

    }
}
