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
            DateTime tempDayOfScheduleList = MngTables.ControlSchedulesList[0].Time;
            List<double> tempItemList = new List<double>();
            int timeHorizon = 0;
            DateTime currentItemDate = DateTime.Now;

            if (timePeriod == "En Uge")
            {
                timeHorizon = 7;
            }
            else if (timePeriod == "Et år")
            {
                timeHorizon = 365;
            }

            int amountOfItemsWithSameDate = 0;
            double totalWeightPrDay = 0;
            for (int i = 0; i < MngTables.ControlSchedulesList.Count; i++)
            {
                if (MngTables.ControlSchedulesList[i].Time >= DateTime.Now - new TimeSpan(timeHorizon, 0, 0, 0) && MngTables.ControlSchedulesList[i].Time <= DateTime.Now)
                {
                    here:
                    currentItemDate = MngTables.ControlSchedulesList[i].Time.Subtract(new TimeSpan(0,
                        MngTables.ControlSchedulesList[i].Time.Hour, MngTables.ControlSchedulesList[i].Time.Minute,
                        MngTables.ControlSchedulesList[i].Time.Second));
                    if (tempDayOfScheduleList <= currentItemDate + new TimeSpan(1, 0, 0, 0) && tempDayOfScheduleList >= currentItemDate)
                    {
                        amountOfItemsWithSameDate++;
                        totalWeightPrDay += MngTables.ControlSchedulesList[i].Weight;
                        continue;
                    }

                    if (amountOfItemsWithSameDate != 0)
                    {
                        TrendList.Add(new Trends(totalWeightPrDay / amountOfItemsWithSameDate, currentItemDate.Year + "/" + currentItemDate.Month + "/" + currentItemDate.Day));

                    }

                    tempDayOfScheduleList = currentItemDate;
                    totalWeightPrDay = 0;
                    amountOfItemsWithSameDate = 0;
                    goto here;
                }
            }
            if (amountOfItemsWithSameDate != 0)
            {
                TrendList.Add(new Trends(totalWeightPrDay / amountOfItemsWithSameDate, currentItemDate.Year + "/" + currentItemDate.Month + "/" + currentItemDate.Day));
            }

        }
        //        public void CreateGraph(string timePeriod, string comboboxInput)
        //        {
        //            TrendList.Clear();
        //            if (timePeriod == "En Uge")
        //            {
        //            }
        //
        //            int year = DateTime.Now.Year;
        //            int month = DateTime.Now.Month;
        //            int day = DateTime.Now.Day; //todo fix
        //            double totalWeight = 0;
        //            int counter = 0;
        //            //Todo nested if / switch
        //            switch (comboboxInput)
        //            {
        //                case "Weight":
        //                    break;
        //                case "MipMa":
        //                    break;
        //                case "Lud Koncentration":
        //
        //                    break;
        //            }
        //
        //
        //            foreach (var t in MngTables.ControlSchedulesList)
        //            {
        //            here:
        //                if (t.Time.Year == year && t.Time.Month == month)
        //                {
        //                    totalWeight += t.Weight;
        //                    
        //                    counter++;
        //                    continue;
        //                }
        //
        //                if (totalWeight != 0 || counter != 0)
        //                {
        //                    _trendList.Add(new Trends((totalWeight / counter), "YY: " + year + " MM: " + month));
        //                }
        //
        //                month = t.Time.Month;
        //                year = t.Time.Year;
        //                totalWeight = 0;
        //                counter = 0;
        //                goto here;
        //
        //            }
        //            _trendList.Add(new Trends((totalWeight / counter), "YY: " + year + " MM: " + month));
        //
        //
        //            //Todo fix
        //            foreach (var controleScheduleItem in MngTables.ControlSchedulesList)
        //            {
        //            here:
        //                if (controleScheduleItem.Time.Day == day && controleScheduleItem.Time.Month == month)
        //                {
        //                    totalWeight += controleScheduleItem.Weight;
        //                    counter++;
        //                    continue;
        //                }
        //
        //                if (totalWeight != 0 || counter != 0)
        //                {
        //                    _trendList.Add(new Trends((totalWeight / counter), year + "/" + month + "/" + day));
        //                }
        //
        //                day = controleScheduleItem.Time.Day;
        //                month = controleScheduleItem.Time.Month;
        //                year = controleScheduleItem.Time.Year;
        //                totalWeight = 0;
        //                counter = 0;
        //                goto here;
        //            }
        //            _trendList.Add(new Trends((totalWeight / counter), year + "/" + month + "/" + day));
        //        }
    }
}
