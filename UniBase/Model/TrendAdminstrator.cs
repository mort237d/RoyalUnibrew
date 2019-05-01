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

        public void GraphComboboxSelectedMethod(string comboboxInput, string comboboxTimeInput)
        {
            
                CreateGraph(comboboxInput, comboboxTimeInput);
            
        }
        public void CreateGraph(string comboboxInput,string timePeriod)
        {
            TrendList.Clear();
            DateTime tempDayOfScheduleList = MngTables.ControlSchedulesList[0].Time;
            int timeHorizon = 0;
            int timeHorizonDivider = 0;
            DateTime currentItemDate = DateTime.Now;

            if (timePeriod == "En Uge")
            {
                timeHorizon = 7;
                timeHorizonDivider = 1;
            }
            else if (timePeriod == "En Måned")
            {
                timeHorizon = 30;
                timeHorizonDivider = 4;
            }
            else if (timePeriod == "Et Kvartal")
            {
                timeHorizon = 91;
                timeHorizonDivider = 15;
            }
            else if (timePeriod == "Et År")
            {
                timeHorizon = 365;
                timeHorizonDivider = 30;
            }

            int amountOfItemsWithSameDate = 0;
            double totalWeightPrDay = 0;

            for (int i = 0; i < MngTables.ControlSchedulesList.Count; i++)
            {
                if (MngTables.ControlSchedulesList[i].Time >= DateTime.Now - new TimeSpan(timeHorizon, 0, 0, 0) && MngTables.ControlSchedulesList[i].Time <= DateTime.Now)
                {
                    currentItemDate = MngTables.ControlSchedulesList[i].Time.Subtract(new TimeSpan(0,
                        MngTables.ControlSchedulesList[i].Time.Hour, MngTables.ControlSchedulesList[i].Time.Minute,
                        MngTables.ControlSchedulesList[i].Time.Second));

                    here:

                    if (tempDayOfScheduleList <= currentItemDate + new TimeSpan(timeHorizonDivider, 0, 0, 0) && tempDayOfScheduleList >= currentItemDate)
                    {
                        amountOfItemsWithSameDate++;
                        if (comboboxInput == "Vægt")
                        {
                            totalWeightPrDay += MngTables.ControlSchedulesList[i].Weight;
                        }
                        else if (comboboxInput == "MipMa")
                        {
                            totalWeightPrDay += MngTables.ControlSchedulesList[i].MipMA;

                        }
                        else if (comboboxInput == "Lud Koncentration")
                        {
                            totalWeightPrDay += MngTables.ControlSchedulesList[i].LudKoncentration;
                        }

                        continue;
                    }

                    if (amountOfItemsWithSameDate != 0)
                    {
                        TrendList.Add(new Trends(totalWeightPrDay / amountOfItemsWithSameDate, currentItemDate.Year + "/" + currentItemDate.Month + "/" + tempDayOfScheduleList.Day));
                    }

                    totalWeightPrDay = 0;
                    amountOfItemsWithSameDate = 0;

                    if (new TimeSpan(timeHorizonDivider,0,0,0) <= currentItemDate - tempDayOfScheduleList)
                    {
                        tempDayOfScheduleList = currentItemDate;
                        goto here;
                    }
                }
            }
            if (amountOfItemsWithSameDate != 0)
            {
                TrendList.Add(new Trends(totalWeightPrDay / amountOfItemsWithSameDate, currentItemDate.Year + "/" + currentItemDate.Month + "/" + tempDayOfScheduleList.Day));
            }
        }
    }
}
