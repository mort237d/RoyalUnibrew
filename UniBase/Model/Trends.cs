using System;

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
