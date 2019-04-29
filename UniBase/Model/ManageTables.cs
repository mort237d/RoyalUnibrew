using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        public ManageTables()
        {
            _frontpagesList = ModelGenerics.GetAll(new Frontpages());
            _controlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            _controlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            _productionsList = ModelGenerics.GetAll(new Productions());
            _productsList = ModelGenerics.GetAll(new Products());
            _shiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            _tuList = ModelGenerics.GetAll(new TUs());

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
            FrontPageProps = GetProperties(new Frontpages());
            FrontPageProps.RemoveRange(6, FrontPageProps.Count-6);
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
