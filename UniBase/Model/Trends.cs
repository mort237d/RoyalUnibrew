using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model
{
    class Trends
    {
        public Trends(double size, double weight, String date)
        {
            Size = size;
            Weight = weight;
            Date = date;
        }

        public double Size { get; set; }
        public double Weight { get; set; }
        public String Date { get; set; }


    }
}
