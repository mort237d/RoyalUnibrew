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

        public void GraphComboboxSelectedMethod(string input)
        {
            if (input == "Weight")
            {
                CreateWeightGraph();
            }
            else if (input == "MipMa")
            {
                CreateMipMAGraph();
            }
            else if (input == "Lud Koncentration")
            {
                CreateLudKoncentrationGraph();
            }
        }

        public void CreateWeightGraph()
        {
            TrendList.Clear();
            for (int i = 0; i < MngTables._controlSchedulesList.Count; i++)
            {
                TrendList.Add(new Trends(MngTables._controlSchedulesList[i].Weight, MngTables._controlSchedulesList[i].Time.ToString("s").Substring(0, 10)));

            }
        }

        public void CreateMipMAGraph()
        {
            TrendList.Clear();
            for (int i = 0; i < MngTables._controlSchedulesList.Count; i++)
            {
                TrendList.Add(new Trends(MngTables._controlSchedulesList[i].MipMA, MngTables._controlSchedulesList[i].Time.ToString("s").Substring(0, 10)));

            }
        }

        public void CreateLudKoncentrationGraph()
        {
            TrendList.Clear();
            for (int i = 0; i < MngTables._controlSchedulesList.Count; i++)
            {
                TrendList.Add(new Trends(MngTables._controlSchedulesList[i].LudKoncentration, MngTables._controlSchedulesList[i].Time.ToString("s").Substring(0, 10)));

            }
        }
    }
}
