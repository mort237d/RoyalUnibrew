using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
        private int _graphScrollLenght = 1000;
        
        private List<Trends> _tempTrendList = new List<Trends>();
        private ObservableCollection<Trends> _trendGraphList = new ObservableCollection<Trends>();


        public TrendAdminstrator()
        {GraphType.Content = "Vægt";
            GraphTimePeriod.Content = "En Uge";
            CreateGraph(GraphType.Content.ToString(), GraphTimePeriod.Content.ToString());
        }

        public List<Trends> TempTrendList
        {
            get { return _tempTrendList; }
            set { _tempTrendList = value; }
        }
        public ObservableCollection<Trends> TrendGraphList
        {
            get { return _trendGraphList; }
            set
            {
                _trendGraphList = value;
                OnPropertyChanged();
            }
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

        public int GraphScrollLenght
        {
            get { return _graphScrollLenght; }
            set
            {
                _graphScrollLenght = value; 
                OnPropertyChanged();
            }
        }


        public void CreateGraph(string comboboxInput, string timePeriod)
        {
            ObservableCollection<ControlSchedules> completeControlSchedulesList = ControlScheduleMethod.Instance.CompleteControlSchedulesList;

            TempTrendList.Clear();
            DateTime tempDayOfScheduleList = completeControlSchedulesList[0].Time;
            int timeHorizon = 0;
            int timeHorizonDivider = 0;
            DateTime currentItemDate = DateTime.Now;
            double minValue = 0;
            double maxValue = 0;
            

            if (timePeriod == "Idag")
            {
                timeHorizon = 1;
                timeHorizonDivider = 0;
                GraphScrollLenght = 1000;
            }
            if (timePeriod == "En Uge")
            {
                timeHorizon = 7;
                timeHorizonDivider = 1;
                GraphScrollLenght = 1000;
            }
            else if (timePeriod == "En Måned")
            {
                timeHorizon = 30;
                timeHorizonDivider = 3;
                GraphScrollLenght = 1000;
            }
            else if (timePeriod == "Et Kvartal")
            {
                timeHorizon = 91;
                timeHorizonDivider = 10;
                GraphScrollLenght = 1000;
            }
            else if (timePeriod == "Et År")
            {
                timeHorizon = 365;
                timeHorizonDivider = 30;
                GraphScrollLenght = 1000;
            }
            if (timePeriod == "En Uge (Detaljeret)")
            {
                timeHorizon = 7;
                timeHorizonDivider = 0;
                GraphScrollLenght = 4000;
            }
            else if (timePeriod == "En Måned (Detaljeret)")
            {
                timeHorizon = 30;
                timeHorizonDivider = 0;
                GraphScrollLenght = 8000;
            }
            else if (timePeriod == "Et Kvartal (Detaljeret)")
            {
                timeHorizon = 91;
                timeHorizonDivider = 1;
                GraphScrollLenght = 5000;
            }
            else if (timePeriod == "Et År (Detaljeret)")
            {
                timeHorizon = 365;
                timeHorizonDivider = 1;
                GraphScrollLenght = 10000;
            }

            int amountOfItemsWithSameDate = 0;
            double tempTotalValue = 0;
            Parallel.ForEach(completeControlSchedulesList, scheduleItem =>
            {           
                if (scheduleItem.Time >= DateTime.Now - new TimeSpan(timeHorizon, 0, 0, 0) && scheduleItem.Time <= DateTime.Now)
                {
                    currentItemDate = scheduleItem.Time.Subtract(new TimeSpan(0,
                        scheduleItem.Time.Hour, scheduleItem.Time.Minute,
                        scheduleItem.Time.Second));

                    if (timeHorizonDivider == 0)
                    {
                        if (comboboxInput == "Vægt") TempTrendList.Add(new Trends(scheduleItem.Weight, scheduleItem.Time.Year + "/" + scheduleItem.Time.Month + "/" + scheduleItem.Time.Day + "/" + scheduleItem.Time.Hour + ":" + scheduleItem.Time.Minute, ConstantValues.MinWeight, ConstantValues.MaxWeight));
                        if (comboboxInput == "MipMa") TempTrendList.Add(new Trends(scheduleItem.MipMA, scheduleItem.Time.Year + "/" + scheduleItem.Time.Month + "/" + scheduleItem.Time.Day + "/" + scheduleItem.Time.Hour + ":" + scheduleItem.Time.Minute, ConstantValues.MinMipMa, ConstantValues.MaxMipMa));
                        if (comboboxInput == "Lud Koncentration") TempTrendList.Add(new Trends(scheduleItem.LudKoncentration, scheduleItem.Time.Year + "/" + scheduleItem.Time.Month + "/" + scheduleItem.Time.Day + "/" + scheduleItem.Time.Hour + ":" + scheduleItem.Time.Minute, ConstantValues.MinLudkoncentration, ConstantValues.MaxLudkoncentration));
                        goto continueHere;
                    }

                here:

                    if (tempDayOfScheduleList <= currentItemDate + new TimeSpan(timeHorizonDivider, 0, 0, 0) && tempDayOfScheduleList >= currentItemDate)
                    {
                        amountOfItemsWithSameDate++;
                        if (comboboxInput == "Vægt")
                        { 
                            tempTotalValue += (double)scheduleItem.Weight;
                            minValue = ConstantValues.MinWeight;
                            maxValue = ConstantValues.MaxWeight;
                        }
                        else if (comboboxInput == "MipMa")
                        {
                            tempTotalValue += (double)scheduleItem.MipMA;
                            minValue = ConstantValues.MinMipMa;
                            maxValue = ConstantValues.MaxMipMa;
                        }
                        else if (comboboxInput == "Lud Koncentration")
                        {
                            tempTotalValue += (double)scheduleItem.LudKoncentration;
                            minValue = ConstantValues.MinLudkoncentration;
                            maxValue = ConstantValues.MaxLudkoncentration;
                        }

                        goto continueHere;
                    }

                    if (amountOfItemsWithSameDate != 0)
                    {
                        TempTrendList.Add(new Trends(tempTotalValue / amountOfItemsWithSameDate, currentItemDate.Year + "/" + currentItemDate.Month + "/" + currentItemDate.Day, minValue, maxValue));
                    }

                    tempTotalValue = 0;
                    amountOfItemsWithSameDate = 0;

                    if (new TimeSpan(timeHorizonDivider,0,0,0) <= currentItemDate - tempDayOfScheduleList)
                    {
                        tempDayOfScheduleList = currentItemDate;
                        goto here;
                    }
                
                }
                continueHere: ;
            });
            if (amountOfItemsWithSameDate != 0)
            {
                TempTrendList.Add(new Trends(tempTotalValue / amountOfItemsWithSameDate, currentItemDate.Year + "/" + currentItemDate.Month + "/" + currentItemDate.Day, minValue, maxValue));
            }

            TrendGraphList = new ObservableCollection<Trends> (TempTrendList);

        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
