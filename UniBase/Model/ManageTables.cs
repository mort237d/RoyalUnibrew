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

        private List<Frontpages> _frontpagesList;
        private List<Products> _productsList;
        private List<Frontpages> _allFrontpages;
        public ManageTables()
        {
            _allFrontpages = ModelGenerics.GetAll(new Frontpages());
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
