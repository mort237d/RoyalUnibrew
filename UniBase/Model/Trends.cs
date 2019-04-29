using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniBase.Model
{
    class Trends
    {
        public Trends(double selectedCategory, String date)
        {
            SelectedCategory = selectedCategory;
            Date = date;
        }


        public double SelectedCategory { get; set; }
        public String Date { get; set; }


    }
}
