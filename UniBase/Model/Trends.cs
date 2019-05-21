using System;

namespace UniBase.Model
{
    public class Trends
    {
        public Trends(double selectedCategory, String date, double minValue, double maxValue)
        {
            SelectedCategory = selectedCategory;
            Date = date;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public double SelectedCategory { get; set; }
        public String Date { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}
