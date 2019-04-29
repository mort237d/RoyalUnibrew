using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;

namespace UniBase.Model
{
    class TrendAdminstrator
    {
        public ObservableCollection<Trends> _trendList = new ObservableCollection<Trends>();
        ManageTables MngTables;
        public TrendAdminstrator()
        {
            MngTables = ManageTables.Instance;
            List<DateTime> DT = new List<DateTime>
            {
                new DateTime(2019, 01, 01),
                new DateTime(2019, 02, 01),
                new DateTime(2019, 03, 01),
                new DateTime(2019, 04, 01),
                new DateTime(2019, 05, 01),
                new DateTime(2019, 06, 01),
                new DateTime(2019, 07, 01),
                new DateTime(2019, 08, 01),
                new DateTime(2019, 09, 01),
                new DateTime(2019, 10, 01),
                new DateTime(2019, 11, 01),
                new DateTime(2019, 12, 01)
            };
            List<double> WeightList = new List<double>
            {
                200.1,
                202.3,
                180.3,
                190.2,
                280.2,
                240.2,
                200.1,
                202.3,
                180.3,
                190.2,
                280.2,
                240.2
            };
            List<double> SizeList = new List<double>
            {
                100.1, 
                302.3,
                280.3,
                190.2,
                580.2,
                440.2,
                200.1,
                102.3,
                280.3,
                490.2,
                220.2,
                210.2 
            };


            for (int i = 0; i < MngTables._controlSchedulesList.Count; i++)
            {
                 TrendList.Add(new Trends(Convert.ToDouble(MngTables._controlSchedulesList[i].Weight), MngTables._controlSchedulesList[i].WeightControlTime.ToString("s").Substring(0, 10)));


            }

        }

        public ObservableCollection<Trends> TrendList
        {
            get { return _trendList; }
            set { _trendList = value; }
        }
    }
}
