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
        public List<HeaderAndToolTip> ControlSchedulesHeaderList { get; set; }
        public List<HeaderAndToolTip> ProductionsList { get; set; }
        


        #endregion

        public XamlBindings()
        {
            CreateFrontpageHeader();
            CreateControlRegistrationHeader();
            CreateControlSchedulesHeader();
            CreateProductionsHeader();

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

        public void CreateControlSchedulesHeader()
        {
            ControlSchedulesHeaderList = new List<HeaderAndToolTip>
            {
                new HeaderAndToolTip("Kontrol skema ID","Sorter efter Kontrol skema ID"),
                new HeaderAndToolTip("ProcessOrdre Nr","Sorter efter ProcessOrdre Nr"),
                new HeaderAndToolTip("Klokkeslæt","Sorter efter Klokkeslæt"),
                new HeaderAndToolTip("Vægt kontrol","Sorter efter Vægt kontrol"),
                new HeaderAndToolTip("Kontrol af fustage","Sorter efter Kontrol af fustage"),
                new HeaderAndToolTip("LudKoncentration","Sorter efter LudKoncentration"),
                new HeaderAndToolTip("Mip MA","Sorter efter Mip MA"),
                new HeaderAndToolTip("Signatur operatør","Sorter efter Signatur operatør"),
                new HeaderAndToolTip("Note","Sorter efter Note"),


            };
        }

        public void CreateProductionsHeader()
        {
            ProductionsList = new List<HeaderAndToolTip>
            {
                new HeaderAndToolTip("Produktions ID", "Sorter efter Produktions ID"),
                new HeaderAndToolTip("ProcessOrdre Nr", "Sorter efter ProcessOrdre Nr"),
                new HeaderAndToolTip("Paller lagt på lager 0001", "Sorter efter Paller lagt på lager 0001"),
                new HeaderAndToolTip("Tappemaskine", "Sorter efter Tappemaskine"),
                new HeaderAndToolTip("Antal fustager pr. palle", "Sorter efter Antal fustager pr. palle"),
                new HeaderAndToolTip("Tæller", "Sorter efter Tæller"),
                new HeaderAndToolTip("Palle tæller", "Sorter efter Palle tæller"),
                new HeaderAndToolTip("Batchdato", "Sorter efter Batchdato")
            };
        }


    }
}
