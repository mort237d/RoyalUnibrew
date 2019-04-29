using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;

namespace UniBase.Model
{
    public class ManageTables
    {
        public static ObservableCollection<ControlRegistrations> _controlRegistrationsList;
        public static ObservableCollection<ControlSchedules> _controlSchedulesList;
        public static ObservableCollection<Frontpages> _frontpagesList;
        public static ObservableCollection<Productions> _productionsList;
        public static ObservableCollection<Products> _productsList;
        public static ObservableCollection<ShiftRegistrations> _shiftRegistrationsList;
        public static ObservableCollection<TUs> _tuList;

        public ManageTables()
        {
            _controlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            _controlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            _frontpagesList = ModelGenerics.GetAll(new Frontpages());
            _productionsList = ModelGenerics.GetAll(new Productions());
            _productsList = ModelGenerics.GetAll(new Products());
            _shiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            _tuList = ModelGenerics.GetAll(new TUs());
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
