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
            TrendList.Add(new Trends(24, 200, 1));
            TrendList.Add(new Trends(29, 220, 2));
            TrendList.Add(new Trends(25, 190, 3));
            TrendList.Add(new Trends(21, 170, 4));
            TrendList.Add(new Trends(18, 160, 5));
            TrendList.Add(new Trends(26, 200, 6));

        }

        public ObservableCollection<Trends> TrendList
        {
            get { return _trendList; }
            set { _trendList = value; }
        }
    }
}
