using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ModelLibrary;
using UniBase.Model.K2;

namespace UniBase.Model
{
    class TrendAdminstrator
    {
        public ObservableCollection<Trends> _trendList = new ObservableCollection<Trends>();
        public ManageTables MngTables = ManageTables.Instance;
        public TrendAdminstrator()
        {
            
           
        }

        public ObservableCollection<Trends> TrendList
        {
            get { return _trendList; }
            set { _trendList = value; }
        }

        public void GraphComboboxSelectedMethod(string comboboxInput)
        {
            
                CreateGraph("En Uge", comboboxInput);
            
        }

        public void CreateGraph(string timePeriod, string comboboxInput)
        {
            TrendList.Clear();
            if (timePeriod == "En Uge")
            {
            }

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day; //todo fix
            double totalWeight = 0;
            int counter = 0;
            //Todo nested if / switch
            switch (comboboxInput)
            {
                case "Weight":
                    break;
                case "MipMa":
                    break;
                case "Lud Koncentration":

                    break;
            }


            foreach (var t in MngTables.ControlSchedulesList)
            {
            here:
                if (t.Time.Year == year && t.Time.Month == month)
                {
                    totalWeight += t.Weight;
                    
                    counter++;
                    continue;
                }

                if (totalWeight != 0 || counter != 0)
                {
                    _trendList.Add(new Trends((totalWeight / counter), "YY: " + year + " MM: " + month));
                }

                month = t.Time.Month;
                year = t.Time.Year;
                totalWeight = 0;
                counter = 0;
                goto here;

            }
            _trendList.Add(new Trends((totalWeight / counter), "YY: " + year + " MM: " + month));


            //Todo fix
            foreach (var controleScheduleItem in MngTables.ControlSchedulesList)
            {
            here:
                if (controleScheduleItem.Time.Day == day && controleScheduleItem.Time.Month == month)
                {
                    totalWeight += controleScheduleItem.Weight;
                    counter++;
                    continue;
                }

                if (totalWeight != 0 || counter != 0)
                {
                    _trendList.Add(new Trends((totalWeight / counter), year + "/" + month + "/" + day));
                }

                day = controleScheduleItem.Time.Day;
                month = controleScheduleItem.Time.Month;
                year = controleScheduleItem.Time.Year;
                totalWeight = 0;
                counter = 0;
                goto here;
            }
            _trendList.Add(new Trends((totalWeight / counter), year + "/" + month + "/" + day));
        }
    }
}
