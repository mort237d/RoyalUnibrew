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
        public List<HeaderAndToolTip> FrontPageHeaderList { get; set; }
        public List<HeaderAndToolTip> ControlRegistrationsHeaderList { get; set; }
        


        #endregion

        public XamlBindings()
        {
            CreateFrontpageHeader();
            CreateControlRegistrationHeader();
        }

        public void CreateFrontpageHeader()
        {
            FrontPageHeaderList = new List<HeaderAndToolTip>
            {
                new HeaderAndToolTip("ProcessOrdre Nr", "Sorter efter ProcessOdre Nr"),
                new HeaderAndToolTip("Dato", "Sorter efter Dato"),
                new HeaderAndToolTip("Færdigt Produkt Nr", "Sorter efter Færdigt Produkt Nr"),
                new HeaderAndToolTip("Kolonne", "Sorter efter Kolonne"),
                new HeaderAndToolTip("Note", "Sorter efter Note"),
                new HeaderAndToolTip("Uge Nr", "Sorter efter Uge Nr")
            };
        }

        public void CreateControlRegistrationHeader()
        {
            ControlRegistrationsHeaderList = new List<HeaderAndToolTip>
            {
                new HeaderAndToolTip("Kontrol Registrering ID", "Sorter efter Kontrol Registrering ID"),
                new HeaderAndToolTip("ProcessOrdre Nr", "Sorter efter ProcessOrdre Nr"),
                new HeaderAndToolTip("Tid","Sorter efter Tid"),
                new HeaderAndToolTip("Produktionsdato","Sorter efter Produktionsdato"),
                new HeaderAndToolTip("Kommentar vedr. ændret dato","Sorter efter Kommentar vedr. ændret dato"),
                new HeaderAndToolTip("Kontrol af sprit på anstikker","Sorter efter Kontrol af sprit på anstikker"),
                new HeaderAndToolTip("Hætte Nr","Sorter efter Hætte Nr"),
                new HeaderAndToolTip("Etikette Nr","Sorter efter Etikette Nr"),
                new HeaderAndToolTip("Fustage","Sorter efter Fustage"),
                new HeaderAndToolTip("Signatur","Sorter efter Signatur"),
                new HeaderAndToolTip("Første palle depalleteret","Sorter efter Første palle depalleteret"),
                new HeaderAndToolTip("Sidste palle depalleteret","Sorter efter Sidste palle depalleteret")

            };
        }

    }
}
