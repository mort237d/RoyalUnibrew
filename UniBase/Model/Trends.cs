using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model
{
    class Trends
    {
        public Trends(int size, int weight, int months)
        {
            Size = size;
            Weight = weight;
            Months = months;
        }

        public int Size { get; set; }
        public int Weight { get; set; }
        public int Months { get; set; }


    }
}
