using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model
{
    class XamlBindings
    {

        public List<FrontPageHeader> FrontPageHeaderList { get; set; }

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
