using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using ModelLibrary;

namespace UniBase.Model
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
            InitializeLists();

            FrontPageProps = new List<string>();
            ProductProps = new List<string>();
            CompleteLists();
        }

        private void InitializeLists()
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

        private List<string> GetProperties<T>(T type)
        {
            List<string> properties = new List<string>();
            var prop = type.GetType().GetProperties();

            foreach (var propertyInfo in prop)
            {
                Debug.WriteLine(propertyInfo.Name);
                properties.Add(propertyInfo.Name);
            }

            return properties;
        }

        private void CompleteLists()
        {
            FrontPageProps = new List<string> {"ProcessOrdre Nr", "Dato", "Færdigt Produkt Nr", "Kolonne", "Note", "Uge Nr"};
            ProductProps = new List<string>{ "Færdigt Produkt Nr", "Produkt Navn", "Antal dage før udløbsdato"};
            //ProductionProps.AddRange(new List<string>{"Produktion ID", ""});
        }

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
    }
}
