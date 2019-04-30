using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            int tempDayOfScheduleList = MngTables.ControlSchedulesList[0].Time.DayOfYear;
            List<double> tempItemList = new List<double>();
            int timeHorizon = 0;

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
                if (MngTables.ControlSchedulesList[i].Time >= DateTime.Now - new TimeSpan(1000, 0, 0, 0) && MngTables.ControlSchedulesList[i].Time <= DateTime.Now)
                {

                    if (tempDayOfScheduleList == MngTables.ControlSchedulesList[i].Time.DayOfYear)
                    {
                        amountOfItemsWithSameDate++;
                        totalWeightPrDay += MngTables.ControlSchedulesList[i].Weight;
                    }
                    if(tempDayOfScheduleList != MngTables.ControlSchedulesList[i+1].Time.DayOfYear)
                    {
                        double tempAverage = totalWeightPrDay / amountOfItemsWithSameDate;
                        TrendList.Add(new Trends(tempAverage, MngTables.ControlSchedulesList[i].Time.ToString("s").Substring(0, 10)));
                        tempAverage = 0;
                        totalWeightPrDay = 0;
                        amountOfItemsWithSameDate = 0;

                        tempDayOfScheduleList = MngTables.ControlSchedulesList[i].Time.DayOfYear;
                    }
                    
                }
               
            }
        }



        //                        if (comboboxInput == "MipMa")
        //                        {
        //                            if (tempDayOfScheduleList == schedulesListItem.Time.Day)
        //                            {
        //                                tempItemList.Add(schedulesListItem.MipMA);
        //                            }
        //                            else
        //                            {
        //                                double tempAverage = tempItemList.Sum() / tempItemList.Count;
        //                                TrendList.Add(new Trends(tempAverage, schedulesListItem.Time.ToString("s").Substring(0, 10)));
        //                            }
        //                        }
        //                        else if (comboboxInput == "Lud Koncentration")
        //                        {
        //                            if (tempDayOfScheduleList == schedulesListItem.Time.Day)
        //                            {
        //                                tempItemList.Add(schedulesListItem.LudKoncentration);
        //                            }
        //                            else
        //                            {
        //                                double tempAverage = tempItemList.Sum() / tempItemList.Count;
        //                                TrendList.Add(new Trends(tempAverage, schedulesListItem.Time.ToString("s").Substring(0, 10)));
        //                            }
        //                        }


    }

}

       
  