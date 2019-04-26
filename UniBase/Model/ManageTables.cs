using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;

namespace UniBase.Model
{
    public class ManageTables
    {
        private List<ControlRegistration> _controlRegistrationsList;
        private List<ControlSchedule> controlSchedulesList;
        private List<Frontpages> _frontpagesList;
        private List<Production> _productionsList;
        private List<Products> _productsList;
        private List<ShiftRegistration> _shiftRegistrationsList;
        private List<TU> _tuList;

        public ManageTables()
        {
            _controlRegistrationsList = ModelGenerics.GetAll(new ControlRegistration());
            _controlRegistrationsList = ModelGenerics.GetAll(new ControlRegistration());
            _frontpagesList = ModelGenerics.GetAll(new Frontpages());
            _productionsList = ModelGenerics.GetAll(new Production());
            _productsList = ModelGenerics.GetAll(new Products());
            _shiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistration());
            _tuList = ModelGenerics.GetAll(new TU());
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
