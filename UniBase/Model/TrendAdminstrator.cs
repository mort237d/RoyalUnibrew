using System;
using System.Collections.ObjectModel;

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

        public void CreateWeightGraph()
        {
            for (int i = 0; i < MngTables._controlSchedulesList.Count; i++)
            {
                TrendList.Add(new Trends(Convert.ToDouble(MngTables._controlSchedulesList[i].Weight), MngTables._controlSchedulesList[i].WeightControlTime.ToString("s").Substring(0, 10)));

            }
        }

        public void CreateMipMAGraph()
        {
            for (int i = 0; i < MngTables._controlSchedulesList.Count; i++)
            {
                TrendList.Add(new Trends(MngTables._controlSchedulesList[i].MipMA, MngTables._controlSchedulesList[i].Time.ToString("s").Substring(0, 10)));

            }
        }

        public void CreateLudKoncentrationGraph()
        {
            for (int i = 0; i < MngTables._controlSchedulesList.Count; i++)
            {
                TrendList.Add(new Trends(MngTables._controlSchedulesList[i].LudKoncentration, MngTables._controlSchedulesList[i].Time.ToString("s").Substring(0, 10)));

            }
        }
    }
}
