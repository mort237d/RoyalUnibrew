using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBase.Model.K2;

namespace UniBase.Model
{
    public class SortAndFilter
    {
        private ManageTables _mt = ManageTables.Instance;

        private List<bool> sorted = new List<bool> { true, false, false, false, false, false };
        
        //TODO FIX DRYYYYYYYY
        private ObservableCollection<Frontpages> SortWay(int index, int property)
        {
            var tempList = new ObservableCollection<Frontpages>();

            if (!sorted[index])
            {
                tempList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderBy(T => T.ProcessOrder_No));
                for (int i = 0; i < sorted.Count - 1; i++)
                {
                    sorted[i] = false;
                }
                sorted[index] = true;
            }
            else
            {
                tempList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderByDescending(i => property.GetType()));
                sorted[index] = false;
            }

            return tempList;
        }
        public void SortFrontpagesButtonClick(object id)
        {
            switch (id.ToString())
            {
                case "ProcessOrdre Nr":
                    if (!sorted[0])
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderBy(i => i.ProcessOrder_No));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderByDescending(i => i.ProcessOrder_No));
                        sorted[0] = false;
                    }
                    break;
                case "Dato":
                    if (!sorted[0])
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderBy(i => i.Date));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderByDescending(i => i.Date));
                        sorted[0] = false;
                    }
                    break;
                case "Færdigt Produkt Nr":
                    if (!sorted[0])
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderBy(i => i.FinishedProduct_No));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderByDescending(i => i.FinishedProduct_No));
                        sorted[0] = false;
                    }
                    break;
                case "Kolonne":
                    if (!sorted[0])
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderBy(i => i.Colunm));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderByDescending(i => i.Colunm));
                        sorted[0] = false;
                    }
                    break;
                case "Note":
                    if (!sorted[0])
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderBy(i => i.Note));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderByDescending(i => i.Note));
                        sorted[0] = false;
                    }
                    break;
                case "Uge Nr":
                    if (!sorted[0])
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderBy(i => i.Week_No));

                        for (int i = 0; i < sorted.Count - 1; i++)
                        {
                            sorted[i] = false;
                        }
                        sorted[0] = true;
                    }
                    else
                    {
                        _mt.FrontpagesList = new ObservableCollection<Frontpages>(_mt.FrontpagesList.OrderByDescending(i => i.Week_No));
                        sorted[0] = false;
                    }
                    break;
                default:
                    Debug.WriteLine("Nothing");
                    break;
            }
        }
    }
}
