using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using ModelLibrary;

namespace UniBase.Model
{
    public class ManageTables
    {
        public ObservableCollection<Frontpages> _frontpagesList;
        public ObservableCollection<ControlRegistrations> _controlRegistrationsList;
        public ObservableCollection<ControlSchedules> _controlSchedulesList;
        public ObservableCollection<Productions> _productionsList;
        public ObservableCollection<Products> _productsList;
        public ObservableCollection<ShiftRegistrations> _shiftRegistrationsList;
        public ObservableCollection<TUs> _tuList;

        public List<string> FrontPageProps { get; set; }
        public List<string> ProductProps { get; set; }
        public List<string> ProductionProps { get; set; }
        public List<string> ShiftRegistrationProps { get; set; }
        public List<string> TuProps { get; set; }
        public List<string> ControlRegistrationProps { get; set; }
        public List<string> ControlScheduleProps { get; set; }

        public ManageTables()
        {
            _frontpagesList = ModelGenerics.GetAll(new Frontpages());
            _controlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            _controlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
            _frontpagesList = ModelGenerics.GetAll(new Frontpages());
            _productionsList = ModelGenerics.GetAll(new Productions());
            _productsList = ModelGenerics.GetAll(new Products());
            _shiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            _tuList = ModelGenerics.GetAll(new TUs());

            FrontPageProps = new List<string>();
            ProductProps = new List<string>();
            CompleteLists();
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
            FrontPageProps.AddRange(new List<string> {"ProcessOrdre Nr", "Dato", "Færdigt Produkt Nr", "Kolonne", "Note", "Uge Nr"});
            ProductProps.AddRange(new List<string>{ "Færdigt Produkt Nr", "Produkt Navn", "Antal dage før udløbsdato"});
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
