using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model
{
    class TrendAdminstrator
    {
        public ObservableCollection<Trends> _trendList = new ObservableCollection<Trends>();

        public TrendAdminstrator()
        {
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

            for (int i = 0; i < DT.Count; i++)
            {
                
                TrendList.Add(new Trends(SizeList[i], WeightList[i], DT[i].ToString("s").Substring(0, 10)));
                
            }

//            TrendList.Add(new Trends(240, 200, DT[0].ToString("s").Substring(0, 10)));
//            TrendList.Add(new Trends(290, 220, DT[1].ToString("s").Substring(0, 10)));
//            TrendList.Add(new Trends(250, 190, DT[2].ToString("s").Substring(0, 10)));
//            TrendList.Add(new Trends(210, 170, DT[3].ToString("s").Substring(0, 10)));
//            TrendList.Add(new Trends(180, 160, DT[4].ToString("s").Substring(0, 10)));
//            TrendList.Add(new Trends(260, 200, DT[5].ToString("s").Substring(0, 10)));

        }

        public ObservableCollection<Trends> TrendList
        {
            get { return _trendList; }
            set { _trendList = value; }
        }
    }
}
