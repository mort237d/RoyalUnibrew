using System.Collections.Generic;

namespace UniBase.Model
{
    public class XamlBindings
    {
        #region Properties
        public string PlaceHolderDate { get; set; } = "2000/01/01";
        public string PlaceHolderTimeSpan { get; set; } = "00:00:00";
        public string PlaceholderString { get; set; } = "Tekst";
        public string PlaceHolderInt { get; set; } = "0";
        public string PlaceHolderDouble { get; set; } = "0,00";
        public string PlaceHolderTime { get; set; } = "00:00";
        #endregion

        #region PropertyLists
        public List<HeaderAndToolTip> FrontPageHeaderList { get; set; }
        public List<HeaderAndToolTip> ControlRegistrationsHeaderList { get; set; }
        public List<HeaderAndToolTip> ControlSchedulesHeaderList { get; set; }
        public List<HeaderAndToolTip> ProductionsHeaderList { get; set; }
        public List<HeaderAndToolTip> ShiftRegistrationHeaderList { get; set; }
        public List<HeaderAndToolTip> TUHeaderList { get; set; }
        


        #endregion

        public XamlBindings()
        {
            CreateFrontpageHeader();
            CreateControlRegistrationHeader();
            CreateControlSchedulesHeader();
            CreateProductionsHeader();
            CreateShiftRegistrationHeader();
            CreateTUHeader();
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
                new HeaderAndToolTip("Udløbsdato", "Sorter efter Udløbsdato"),
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
            ProductionsHeaderList = new List<HeaderAndToolTip>
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

        public void CreateShiftRegistrationHeader()
        {
            ShiftRegistrationHeaderList = new List<HeaderAndToolTip>
            {
                new HeaderAndToolTip("Vagt registrerings ID", "Sorter efter Vagt registrerings ID"),
                new HeaderAndToolTip("ProcessOrdre Nr", "Sorter efter ProcessOrdre Nr"),
                new HeaderAndToolTip("Start tidspunkt", "Sorter efter Start tidspunkt"),
                new HeaderAndToolTip("Slut tidspunkt", "Sorter efter Slut tidspunkt"),
                new HeaderAndToolTip("Pauser", "Sorter efter Pauser"),
                new HeaderAndToolTip("Total timer", "Sorter efter Total timer"),
                new HeaderAndToolTip("Bemanding", "Sorter efter Bemanding"),
                new HeaderAndToolTip("Initialer", "Sorter efter Initialer")
            };
        }

        public void CreateTUHeader()
        {
            TUHeaderList = new List<HeaderAndToolTip>
            {
                new HeaderAndToolTip("TU ID", "Sorter efter TU ID"),
                new HeaderAndToolTip("ProcessOrdre Nr", "Sorter efter ProcessOrdre Nr"),
                new HeaderAndToolTip("Første dag start TU", "Sorter efter Første dag start TU"),
                new HeaderAndToolTip("Første dag slut TU", "Sorter efter Første dag slut TU"),
                new HeaderAndToolTip("Første dag TU i alt", "Sorter efter Første dag TU i alt"),
                new HeaderAndToolTip("Anden dag start TU", "Sorter efter Anden dag start TU"),
                new HeaderAndToolTip("Anden dag slut TU", "Sorter efter Anden dag slut TU"),
                new HeaderAndToolTip("Anden dag TU i alt", "Sorter efter Anden dag TU i alt"),
                new HeaderAndToolTip("Tredje dag start TU", "Sorter efter Tredje dag start TU"),
                new HeaderAndToolTip("Tredje dag slut TU", "Sorter efter Tredje dag slut TU"),
                new HeaderAndToolTip("Tredje dag TU i alt", "Sorter efter Tredje dag TU i alt")
            };
        }
    }
}
