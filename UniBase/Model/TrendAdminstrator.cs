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
            if (timePeriod == "En Uge")
            {
                int tempDayOfScheduleList = MngTables.ControlSchedulesList[0].Time.Day;
                List<double> tempItemList = new List<double>();
                foreach (var schedulesListItem in MngTables.ControlSchedulesList)
                {
                    if (schedulesListItem.Time >= DateTime.Now - new TimeSpan(7, 0, 0, 0) && schedulesListItem.Time <= DateTime.Now)
                    {

                        if (comboboxInput == "Weight")
                        {
                            if (tempDayOfScheduleList == schedulesListItem.Time.Day)
                            {
                                tempItemList.Add(schedulesListItem.Weight);
                            }
                            else
                            {
                                double tempAverage = tempItemList.Sum() / tempItemList.Count;
                                TrendList.Add(new Trends(tempAverage, schedulesListItem.Time.ToString("s").Substring(0, 10)));
                            }

                        }
                        else if (comboboxInput == "MipMa")
                        {
                            if (tempDayOfScheduleList == schedulesListItem.Time.Day)
                            {
                                tempItemList.Add(schedulesListItem.MipMA);
                            }
                            else
                            {
                                double tempAverage = tempItemList.Sum() / tempItemList.Count;
                                TrendList.Add(new Trends(tempAverage, schedulesListItem.Time.ToString("s").Substring(0, 10)));
                            }
                        }
                        else if (comboboxInput == "Lud Koncentration")
                        {
                            if (tempDayOfScheduleList == schedulesListItem.Time.Day)
                            {
                                tempItemList.Add(schedulesListItem.LudKoncentration);
                            }
                            else
                            {
                                double tempAverage = tempItemList.Sum() / tempItemList.Count;
                                TrendList.Add(new Trends(tempAverage, schedulesListItem.Time.ToString("s").Substring(0, 10)));
                            }
                        }
                    }
                }
                //                for (int i = 0; i < MngTables.ControlSchedulesList.Count; i++)
                //                {
                //                    if (MngTables.ControlSchedulesList[i].Time >= DateTime.Now - new TimeSpan(7, 0, 0, 0) && MngTables.ControlSchedulesList[i].Time <= DateTime.Now)
                //                    {
                //
                //                        if (comboboxInput == "Weight")
                //                        {
                //                            int tempDayOfScheduleList = MngTables.ControlSchedulesList[i];
                //
                //                            
                //                            TrendList.Add(new Trends(MngTables.ControlSchedulesList[i].Weight, MngTables.ControlSchedulesList[i].Time.ToString("s").Substring(0, 10)));
                //                        }
                //                        else if (comboboxInput == "MipMa")
                //                        {
                //                            TrendList.Add(new Trends(MngTables.ControlSchedulesList[i].MipMA, MngTables.ControlSchedulesList[i].Time.ToString("s").Substring(0, 10)));
                //                        }
                //                        else if (comboboxInput == "Lud Koncentration")
                //                        {
                //                            TrendList.Add(new Trends(MngTables.ControlSchedulesList[i].LudKoncentration, MngTables.ControlSchedulesList[i].Time.ToString("s").Substring(0, 10)));
                //                        }
                //                    }
                //                }

            }

        }

       
    }
}
