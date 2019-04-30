﻿using System;
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
            for (int i = 0; i < MngTables.ControlSchedulesList.Count; i++)
            {
                TrendList.Add(new Trends(Convert.ToDouble(MngTables.ControlSchedulesList[i].Weight), MngTables.ControlSchedulesList[i].WeightControlTime.ToString("s").Substring(0, 10)));

            }
        }

        public void CreateMipMAGraph()
        {
            for (int i = 0; i < MngTables.ControlSchedulesList.Count; i++)
            {
                TrendList.Add(new Trends(MngTables.ControlSchedulesList[i].MipMA, MngTables.ControlSchedulesList[i].Time.ToString("s").Substring(0, 10)));

            }
        }

        public void CreateLudKoncentrationGraph()
        {
            for (int i = 0; i < MngTables.ControlSchedulesList.Count; i++)
            {
                TrendList.Add(new Trends(MngTables.ControlSchedulesList[i].LudKoncentration, MngTables.ControlSchedulesList[i].Time.ToString("s").Substring(0, 10)));

            }
        }
    }
}
