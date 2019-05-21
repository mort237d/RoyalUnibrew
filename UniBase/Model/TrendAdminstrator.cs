using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using UniBase.Annotations;
using UniBase.Model.K2;
using UniBase.Model.K2.ButtonMethods;

namespace UniBase.Model
{
    public class TrendAdminstrator : INotifyPropertyChanged
    {
        private ComboBoxItem _graphType = new ComboBoxItem();
        private ComboBoxItem _graphTimePeriod = new ComboBoxItem();
        
        public ObservableCollection<Trends> _trendList = new ObservableCollection<Trends>();

        private ObservableCollection<ControlSchedules> CompleteControlSchedulesList = ControlScheduleMethod.Instance.CompleteControlSchedulesList;

        public TrendAdminstrator()
        {GraphType.Content = "Vægt";
            GraphTimePeriod.Content = "En Uge";
            CreateGraph(GraphType.Content.ToString(), GraphTimePeriod.Content.ToString());
        }

        public ObservableCollection<Trends> TrendList
        {
            get { return _trendList; }
            set { _trendList = value; }
        }

        public ComboBoxItem GraphType
        {
            get { return _graphType; }
            set
            {
                _graphType = value;
                OnPropertyChanged();
                CreateGraph(GraphType.Content.ToString(), GraphTimePeriod.Content.ToString());
            }
        }

        public ComboBoxItem GraphTimePeriod
        {
            get { return _graphTimePeriod; }
            set
            {
                _graphTimePeriod = value; 
                OnPropertyChanged();
                CreateGraph(GraphType.Content.ToString(), GraphTimePeriod.Content.ToString());
            }
        }

        public void CreateGraph(string comboboxInput, string timePeriod)
        {
            TrendList.Clear();
            DateTime tempDayOfScheduleList = CompleteControlSchedulesList[0].Time;
            int timeHorizon = 0;
            int timeHorizonDivider = 0;
            DateTime currentItemDate = DateTime.Now;
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

            for (int i = 0; i < CompleteControlSchedulesList.Count; i++)
            {
                if (CompleteControlSchedulesList[i].Time >= DateTime.Now - new TimeSpan(timeHorizon, 0, 0, 0) && CompleteControlSchedulesList[i].Time <= DateTime.Now)
                {
                    currentItemDate = CompleteControlSchedulesList[i].Time.Subtract(new TimeSpan(0,
                        CompleteControlSchedulesList[i].Time.Hour, CompleteControlSchedulesList[i].Time.Minute,
                        CompleteControlSchedulesList[i].Time.Second));

                here:

                    if (tempDayOfScheduleList <= currentItemDate + new TimeSpan(timeHorizonDivider, 0, 0, 0) && tempDayOfScheduleList >= currentItemDate)
                    {
                        amountOfItemsWithSameDate++;
                        if (comboboxInput == "Vægt")
                        { 
                            tempTotalValue += (double)CompleteControlSchedulesList[i].Weight;
                            minValue = ConstantValues.MinWeight;
                            maxValue = ConstantValues.MaxWeight;
                        }
                        else if (comboboxInput == "MipMa")
                        {
                            tempTotalValue += (double)CompleteControlSchedulesList[i].MipMA;
                            minValue = ConstantValues.MinMipMa;
                            maxValue = ConstantValues.MaxMipMa;
                        }
                        else if (comboboxInput == "Lud Koncentration")
                        {
                            tempTotalValue += (double)CompleteControlSchedulesList[i].LudKoncentration;
                            minValue = ConstantValues.MinLudkoncentration;
                            maxValue = ConstantValues.MaxLudkoncentration;
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
