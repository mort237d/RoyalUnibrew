using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UniBase.Model.K2;

namespace UniBase.Model
{
    public class SortAndFilter
    {
        private ManageTables _mt = ManageTables.Instance;

        XamlBindings xamlBindings = new XamlBindings();

        private bool sorted = true;
        private PropertyInfo[] frontpagePropertyInfos = typeof(Frontpages).GetProperties();
        
        private PropertyInfo[] controlRegistrationPropertyInfos = typeof(Frontpages).GetProperties();

        //TODO FIX DRYYYYYYYY
        private ObservableCollection<T> SortWay<T>(ObservableCollection<T> input, string property)
        {
            PropertyInfo prop = typeof(T).GetProperty(property);

            var tempList = new ObservableCollection<T>();

            if (!sorted)
            {
                tempList = new ObservableCollection<T>(input.OrderBy(item => prop.GetValue(item, null)));
                sorted = true;
            }
            else
            {
                tempList = new ObservableCollection<T>(input.OrderByDescending(item => prop.GetValue(item, null)));
                sorted = false;
            }

            return tempList;
        }

        public void SortFrontpagesButtonClick(object id)
        {
            switch (id.ToString())
            {
                case "ProcessOrdre Nr":
                    _mt.FrontpagesList = SortWay<Frontpages>(_mt.FrontpagesList, frontpagePropertyInfos[0].Name);
                    break;
                case "Dato":
                    _mt.FrontpagesList = SortWay<Frontpages>(_mt.FrontpagesList, frontpagePropertyInfos[1].Name);
                    break;
                case "Færdigt Produkt Nr":
                    _mt.FrontpagesList = SortWay<Frontpages>(_mt.FrontpagesList, frontpagePropertyInfos[2].Name);
                    break;
                case "Kolonne":
                    _mt.FrontpagesList = SortWay<Frontpages>(_mt.FrontpagesList, frontpagePropertyInfos[3].Name);
                    break;
                case "Note":
                    _mt.FrontpagesList = SortWay<Frontpages>(_mt.FrontpagesList, frontpagePropertyInfos[4].Name);
                    break;
                case "Uge Nr":
                    _mt.FrontpagesList = SortWay<Frontpages>(_mt.FrontpagesList, frontpagePropertyInfos[5].Name);
                    break;
                default:
                    Debug.WriteLine("Nothing");
                    break;
            }
        }

        public void SortControlRegistrationsButtonClick(object id)
        {
            switch (id.ToString())
            {
                case "Kontrol Registrering ID":
                    _mt.ControlRegistrationsList = SortWay<ControlRegistrations>(_mt.ControlRegistrationsList, controlRegistrationPropertyInfos[0].Name);
                    break;
                case "ProcessOrdre Nr":
                    _mt.ControlRegistrationsList = SortWay<ControlRegistrations>(_mt.ControlRegistrationsList, controlRegistrationPropertyInfos[1].Name);
                    break;
                case "Tid":
                    _mt.ControlRegistrationsList = SortWay<ControlRegistrations>(_mt.ControlRegistrationsList, controlRegistrationPropertyInfos[2].Name);
                    break;
                case "Produktionsdato":
                    _mt.ControlRegistrationsList = SortWay<ControlRegistrations>(_mt.ControlRegistrationsList, controlRegistrationPropertyInfos[3].Name);
                    break;
                case "Kommentar vedr. ændret dato":
                    _mt.ControlRegistrationsList = SortWay<ControlRegistrations>(_mt.ControlRegistrationsList, controlRegistrationPropertyInfos[4].Name);
                    break;
                case "Uge Nr":
                    _mt.ControlRegistrationsList = SortWay<ControlRegistrations>(_mt.ControlRegistrationsList, controlRegistrationPropertyInfos[5].Name);
                    break;
                default:
                    Debug.WriteLine("Nothing");
                    break;
            }
        }
    }
}
