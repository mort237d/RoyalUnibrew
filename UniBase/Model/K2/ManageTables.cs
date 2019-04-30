using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using ModelLibrary;

namespace UniBase.Model.K2
{
    public class ManageTables
    {
        public ObservableCollection<Frontpages> FrontpagesList { get; set; }
        public ObservableCollection<ControlRegistrations> ControlRegistrationsList { get; set; }
        public ObservableCollection<ControlSchedules> ControlSchedulesList { get; set; }
        public ObservableCollection<Productions> ProductionsList { get; set; }
        public ObservableCollection<Products> ProductsList { get; set; }
        public ObservableCollection<ShiftRegistrations> ShiftRegistrationsList { get; set; }
        public ObservableCollection<TUs> TuList { get; set; } 

        public List<string> FrontPageProps { get; set; }
        public List<string> ProductProps { get; set; }
        public List<string> ProductionProps { get; set; }
        public List<string> ShiftRegistrationProps { get; set; }
        public List<string> TuProps { get; set; }
        public List<string> ControlRegistrationProps { get; set; }
        public List<string> ControlScheduleProps { get; set; }

        public ManageTables()
        {
            InitializeObservableCollections();
            CompleteLists();
        }


        private void InitializeObservableCollections()
        {
            FrontpagesList = ModelGenerics.GetAll(new Frontpages());
            ControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            ControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
            FrontpagesList = ModelGenerics.GetAll(new Frontpages());
            ProductionsList = ModelGenerics.GetAll(new Productions());
            ProductsList = ModelGenerics.GetAll(new Products());
            ShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            TuList = ModelGenerics.GetAll(new TUs());
        }

        /*private List<string> GetProperties<T>(T type)
        {
            List<string> properties = new List<string>();
            var prop = type.GetType().GetProperties();

            foreach (var propertyInfo in prop)
            {
                Debug.WriteLine(propertyInfo.Name);
                properties.Add(propertyInfo.Name);
            }

            return properties;
        }*/

        private void CompleteLists()
        {
            ControlRegistrationProps = new List<string>{"Kontrol Registrering ID", "Tid", "Produktionsdato", "Kommentar vedr. ændret dato", "Kontrol af sprit på anstikker", "Hætte Nr", "Etikette Nr", "Fustage", "Signatur", "Første palle depalleteret" , "Sidste palle depalleteret" };
            ControlScheduleProps = new List<string>{"Kontrol skema ID","Klokkeslæt", "Vægt kontrol", "Kontrol af fustage", "LudKoncentration", "Mip MA", "Signatur operatør", "Note"};
            FrontPageProps = new List<string> {"ProcessOrdre Nr", "Dato", "Færdigt Produkt Nr", "Kolonne", "Note", "Uge Nr"};
            ProductionProps = new List<string>{"Produktions ID","Paller lagt på lager 0001", "Tappemaskine", "Antal fustager pr. palle", "Tæller", "Palle tæller", "Batchdato"};
            ProductProps = new List<string>{"Færdigvarer Nr", "Produkt Navn", "Antal dage før udløbsdato"};
            ShiftRegistrationProps = new List<string>{"Vagt registrerings ID","Start tidspunkt", "Slut tidspunkt", "Pauser", "Total timer", "Bemanding", "Initialer"};
            TuProps = new List<string>{"TU ID", "Første dag start TU", "Første dag slut TU", "Anden dag start TU", "Anden dag slut TU", "Tredje dag start TU", "Tredje dag slut TU" };
        }


        #region SingleTon
        
        private static ManageTables _instance;
        public static ManageTables Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ManageTables();
                }

                return _instance;
            }
        }
        #endregion
    }
}
