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
        public ObservableCollection<ControlRegistrations> _controlRegistrationsList;
        public ObservableCollection<ControlSchedules> _controlSchedulesList;
        public ObservableCollection<Frontpages> _frontpagesList;
        public ObservableCollection<Productions> _productionsList;
        public ObservableCollection<Products> _productsList;
        public ObservableCollection<ShiftRegistrations> _shiftRegistrationsList;
        public ObservableCollection<TUs> _tuList;

        public ManageTables()
        {
            _controlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            _controlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
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
