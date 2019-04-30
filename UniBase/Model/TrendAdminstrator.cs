using System;
using System.Collections.ObjectModel;
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
                for (int i = 0; i < MngTables.ControlSchedulesList.Count; i++)
                {
                    if (MngTables.ControlSchedulesList[i].Time >= DateTime.Now - new TimeSpan(7, 0, 0, 0) && MngTables.ControlSchedulesList[i].Time <= DateTime.Now)
                    {

                        if (comboboxInput == "Weight")
                        {
                            TrendList.Add(new Trends(MngTables.ControlSchedulesList[i].Weight, MngTables.ControlSchedulesList[i].Time.ToString("s").Substring(0, 10)));
                        }
                        else if (comboboxInput == "MipMa")
                        {
                            TrendList.Add(new Trends(MngTables.ControlSchedulesList[i].MipMA, MngTables.ControlSchedulesList[i].Time.ToString("s").Substring(0, 10)));
                        }
                        else if (comboboxInput == "Lud Koncentration")
                        {
                            TrendList.Add(new Trends(MngTables.ControlSchedulesList[i].LudKoncentration, MngTables.ControlSchedulesList[i].Time.ToString("s").Substring(0, 10)));
                        }
                    }
                }

            }

        }

       
    }
}
