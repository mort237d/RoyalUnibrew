using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UniBase.Model.K2;

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

        
        public void GraphComboboxSelectedMethod(string comboboxInput, string comboboxTimeInput)
        {
            
                CreateGraph(comboboxInput, comboboxTimeInput);
            
        }
        public void CreateGraph(string comboboxInput,string timePeriod)
        {
            TrendList.Clear();
            DateTime tempDayOfScheduleList = MngTables.CompleteControlSchedulesList[0].Time;
            int timeHorizon = 0;
            int timeHorizonDivider = 0;
            DateTime currentItemDate = DateTime.Now;
            ConstantValues constantValues = new ConstantValues();
            double minValue = 0;
            double maxValue = 0;

            if (timePeriod == "En Uge")
            {
                timeHorizon = 7;
                timeHorizonDivider = 1;
            }
            else if (timePeriod == "En Måned")
            {
                timeHorizon = 30;
                timeHorizonDivider = 3;
            }
            else if (timePeriod == "Et Kvartal")
            {
                timeHorizon = 91;
                timeHorizonDivider = 10;
            }
            else if (timePeriod == "Et År")
            {
                timeHorizon = 365;
                timeHorizonDivider = 30;
            }

            int amountOfItemsWithSameDate = 0;
            double tempTotalValue = 0;

            for (int i = 0; i < MngTables.CompleteControlSchedulesList.Count; i++)
            {
                if (MngTables.CompleteControlSchedulesList[i].Time >= DateTime.Now - new TimeSpan(timeHorizon, 0, 0, 0) && MngTables.CompleteControlSchedulesList[i].Time <= DateTime.Now)
                {
                    currentItemDate = MngTables.CompleteControlSchedulesList[i].Time.Subtract(new TimeSpan(0,
                        MngTables.CompleteControlSchedulesList[i].Time.Hour, MngTables.CompleteControlSchedulesList[i].Time.Minute,
                        MngTables.CompleteControlSchedulesList[i].Time.Second));

                    here:

                    if (tempDayOfScheduleList <= currentItemDate + new TimeSpan(timeHorizonDivider, 0, 0, 0) && tempDayOfScheduleList >= currentItemDate)
                    {
                        amountOfItemsWithSameDate++;
                        if (comboboxInput == "Vægt")
                        {
                            tempTotalValue += MngTables.CompleteControlSchedulesList[i].Weight;
                            minValue = constantValues.MinWeight;
                            maxValue = constantValues.MaxWeight;
                            
                        }
                        else if (comboboxInput == "MipMa")
                        {
                            tempTotalValue += MngTables.CompleteControlSchedulesList[i].MipMA;
                            minValue = constantValues.MinMipMa;
                            maxValue = constantValues.MaxMipMa;
                        }
                        else if (comboboxInput == "Lud Koncentration")
                        {
                            tempTotalValue += MngTables.CompleteControlSchedulesList[i].LudKoncentration;
                            minValue = constantValues.MinLudkoncentration;
                            maxValue = constantValues.MaxLudkoncentration;
                        }

                        continue;
                    }

                    if (amountOfItemsWithSameDate != 0)
                    {
                        TrendList.Add(new Trends(tempTotalValue / amountOfItemsWithSameDate, currentItemDate.Year + "/" + currentItemDate.Month + "/" + tempDayOfScheduleList.Day, minValue, maxValue));
                    }

                    tempTotalValue = 0;
                    amountOfItemsWithSameDate = 0;

                    if (new TimeSpan(timeHorizonDivider,0,0,0) <= currentItemDate - tempDayOfScheduleList)
                    {
                        tempDayOfScheduleList = currentItemDate;
                        goto here;
                    }
                }
            }
            if (amountOfItemsWithSameDate != 0)
            {
                TrendList.Add(new Trends(tempTotalValue / amountOfItemsWithSameDate, currentItemDate.Year + "/" + currentItemDate.Month + "/" + tempDayOfScheduleList.Day, minValue, maxValue));
            }
        }
    }
}
