using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UniBase.Model.K2;
using UniBase.Model.K2.ButtonMethods;

namespace UniBase.Model
{
    public class SortAndFilter
    {
        private FrontpageMethod _frontpageMethod = FrontpageMethod.Instance;
        private ControlRegistrationMethod _controlRegistrationMethod = ControlRegistrationMethod.Instance;

        XamlBindings xamlBindings = new XamlBindings();

        private bool sorted = true;
        private PropertyInfo[] frontpagePropertyInfos = typeof(Frontpages).GetProperties();
        
        private PropertyInfo[] controlRegistrationPropertyInfos = typeof(Frontpages).GetProperties();

        //TODO FIX DRYYYYYYYY
        private ObservableCollection<T> SortWay<T>(ObservableCollection<T> input, string property)
        {
            var tempList = new ObservableCollection<T>();
            PropertyInfo prop = typeof(T).GetProperty(property);
            
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
            //if (xamlBindings.FrontPageHeaderList[0].Header.Equals(id.ToString()))
            //{
                
            //}
            switch (id.ToString())
            {
                case "ProcessOrdre Nr":
                    _frontpageMethod.FrontpagesList = SortWay<Frontpages>(_frontpageMethod.FrontpagesList, frontpagePropertyInfos[0].Name);
                    break;
                case "Dato":
                    _frontpageMethod.FrontpagesList = SortWay<Frontpages>(_frontpageMethod.FrontpagesList, frontpagePropertyInfos[1].Name);
                    break;
                case "Færdigt Produkt Nr":
                    _frontpageMethod.FrontpagesList = SortWay<Frontpages>(_frontpageMethod.FrontpagesList, frontpagePropertyInfos[2].Name);
                    break;
                case "Kolonne":
                    _frontpageMethod.FrontpagesList = SortWay<Frontpages>(_frontpageMethod.FrontpagesList, frontpagePropertyInfos[3].Name);
                    break;
                case "Note":
                    _frontpageMethod.FrontpagesList = SortWay<Frontpages>(_frontpageMethod.FrontpagesList, frontpagePropertyInfos[4].Name);
                    break;
                case "Uge Nr":
                    _frontpageMethod.FrontpagesList = SortWay<Frontpages>(_frontpageMethod.FrontpagesList, frontpagePropertyInfos[5].Name);
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
                    _controlRegistrationMethod.ControlRegistrationsList = SortWay<ControlRegistrations>(_controlRegistrationMethod.ControlRegistrationsList, controlRegistrationPropertyInfos[0].Name);
                    break;
                case "ProcessOrdre Nr":
                    _controlRegistrationMethod.ControlRegistrationsList = SortWay<ControlRegistrations>(_controlRegistrationMethod.ControlRegistrationsList, controlRegistrationPropertyInfos[1].Name);
                    break;
                case "Tid":
                    _controlRegistrationMethod.ControlRegistrationsList = SortWay<ControlRegistrations>(_controlRegistrationMethod.ControlRegistrationsList, controlRegistrationPropertyInfos[2].Name);
                    break;
                case "Produktionsdato":
                    _controlRegistrationMethod.ControlRegistrationsList = SortWay<ControlRegistrations>(_controlRegistrationMethod.ControlRegistrationsList, controlRegistrationPropertyInfos[3].Name);
                    break;
                case "Kommentar vedr. ændret dato":
                    _controlRegistrationMethod.ControlRegistrationsList = SortWay<ControlRegistrations>(_controlRegistrationMethod.ControlRegistrationsList, controlRegistrationPropertyInfos[4].Name);
                    break;
                case "Uge Nr":
                    _controlRegistrationMethod.ControlRegistrationsList = SortWay<ControlRegistrations>(_controlRegistrationMethod.ControlRegistrationsList, controlRegistrationPropertyInfos[5].Name);
                    break;
                default:
                    Debug.WriteLine("Nothing");
                    break;
            }
        }
    }
}
