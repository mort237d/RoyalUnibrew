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
        public List<ControlRegistrationsHeader> ControlRegistrationsHeaderList { get; set; }
        


        #endregion

        public XamlBindings()
        {
            CreateFrontpageHeader();
            CreateControlRegistrationHeader();
        }

        public void CreateFrontpageHeader()
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

        public void CreateControlRegistrationHeader()
        {
            ControlRegistrationsHeaderList = new List<ControlRegistrationsHeader>
            {
                new ControlRegistrationsHeader("Kontrol Registrering ID", "Sorter efter Kontrol Registrering ID"),
                new ControlRegistrationsHeader("ProcessOrdre Nr", "Sorter efter ProcessOrdre Nr"),
                new ControlRegistrationsHeader("Tid","Sorter efter Tid"),
                new ControlRegistrationsHeader("Produktionsdato","Sorter efter Produktionsdato"),
                new ControlRegistrationsHeader("Kommentar vedr. ændret dato","Sorter efter Kommentar vedr. ændret dato"),
                new ControlRegistrationsHeader("Kontrol af sprit på anstikker","Sorter efter Kontrol af sprit på anstikker"),
                new ControlRegistrationsHeader("Hætte Nr","Sorter efter Hætte Nr"),
                new ControlRegistrationsHeader("Etikette Nr","Sorter efter Etikette Nr"),
                new ControlRegistrationsHeader("Fustage","Sorter efter Fustage"),
                new ControlRegistrationsHeader("Signatur","Sorter efter Signatur"),
                new ControlRegistrationsHeader("Første palle depalleteret","Sorter efter Første palle depalleteret"),
                new ControlRegistrationsHeader("Sidste palle depalleteret","Sorter efter Sidste palle depalleteret")

            };
        }

    }
}
