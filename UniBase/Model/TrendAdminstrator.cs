using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using UniBase.Annotations;
using UniBase.Model.K2;

namespace UniBase.Model
{
    public class TrendAdminstrator : INotifyPropertyChanged
    {
        #region Fields

        private ComboBoxItem _graphType = new ComboBoxItem();
        private ComboBoxItem _graphTimePeriod = new ComboBoxItem();
        private string _graphProcessOrderNo;
        private bool _graphCheckBox = true;
        private bool _isEnabled = false;
        private int _graphScrollLenght = 1000;
        
        private List<Trends> _tempTrendList = new List<Trends>();
        private ObservableCollection<Trends> _trendGraphList = new ObservableCollection<Trends>();
        private ObservableCollection<ControlSchedules> _completeControlSchedulesList;

        #endregion

        public TrendAdminstrator()
        {
            
            //Choose the default value for the comboboxes.
            GraphType.Content = "Vægt";
            GraphTimePeriod.Content = "En Uge";
            CreateGraph(GraphType.Content.ToString(), GraphTimePeriod.Content.ToString(), GraphProcessOrderNo, GraphCheckBox);
            
            _screenWidth = ApplicationView.GetForCurrentView().VisibleBounds.Width;
        }

        #region Properties

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
                if (GraphCheckBox)
                {
                    CreateGraph(GraphType.Content.ToString(), GraphTimePeriod.Content.ToString(), GraphProcessOrderNo, GraphCheckBox);

                }
                else CreateProcessOrderNoGraph(int.Parse(GraphProcessOrderNo), GraphType.Content.ToString());
            }
        }

        public ComboBoxItem GraphTimePeriod
        {
            get { return _graphTimePeriod; }
            set
            {
                _graphTimePeriod = value; 
                OnPropertyChanged();
                if (GraphCheckBox)
                {
                CreateGraph(GraphType.Content.ToString(), GraphTimePeriod.Content.ToString(), GraphProcessOrderNo, GraphCheckBox);
                    
                }
            }
        }

        private int j = 0;
        public string GraphProcessOrderNo
        {
            get { return _graphProcessOrderNo; }
            set
            {
                _graphProcessOrderNo = value;
                OnPropertyChanged();
                CreateProcessOrderNoGraph(int.Parse(GraphProcessOrderNo), GraphType.Content.ToString());
                
            }
        }

        

        public bool GraphCheckBox
        {
            get { return _graphCheckBox; }
            set
            {
                _graphCheckBox = value; 
                OnPropertyChanged();
                CreateGraph(GraphType.Content.ToString(), GraphTimePeriod.Content.ToString(), GraphProcessOrderNo, GraphCheckBox);
                if (GraphCheckBox)
                {
                    IsEnabled = false;
                }
                else
                {
                    IsEnabled = true;
                }
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value; 
                OnPropertyChanged();
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

        public ObservableCollection<ControlSchedules> CompleteControlSchedulesList
        {
            get { return _completeControlSchedulesList; }
            set { _completeControlSchedulesList = value; }
        }

        private double _screenWidth;
        public double ScreenWidth
        {
            get { return _screenWidth; }
            set
            {
                _screenWidth = value;
                
            }
        }

        #endregion

        

        public void CreateProcessOrderNoGraph(int processordernumber, string comboboxInput)
        {
            _completeControlSchedulesList = ModelGenerics.GetAllsync(new ControlSchedules());
            TrendGraphList.Clear();
            GraphScrollLenght = 4000;

            foreach (var controlSchedule in CompleteControlSchedulesList)
            {
                if (controlSchedule.ProcessOrder_No == processordernumber)
                {
                    if (comboboxInput == "Vægt")
                        TrendGraphList.Add(new Trends(controlSchedule.Weight,
                            controlSchedule.Time.Year + "/" + controlSchedule.Time.Month + "/" +
                            controlSchedule.Time.Day + "/" + controlSchedule.Time.Hour + ":" +
                            controlSchedule.Time.Minute, ConstantValues.MinWeight, ConstantValues.MaxWeight));
                    if (comboboxInput == "MipMa")
                        TrendGraphList.Add(new Trends(controlSchedule.MipMA,
                            controlSchedule.Time.Year + "/" + controlSchedule.Time.Month + "/" +
                            controlSchedule.Time.Day + "/" + controlSchedule.Time.Hour + ":" +
                            controlSchedule.Time.Minute, ConstantValues.MinMipMa, ConstantValues.MaxMipMa));
                    if (comboboxInput == "Lud Koncentration")
                        TrendGraphList.Add(new Trends(controlSchedule.LudKoncentration,
                            controlSchedule.Time.Year + "/" + controlSchedule.Time.Month + "/" +
                            controlSchedule.Time.Day + "/" + controlSchedule.Time.Hour + ":" +
                            controlSchedule.Time.Minute, ConstantValues.MinLudkoncentration,
                            ConstantValues.MaxLudkoncentration));
                }
            }

            GraphScrollLenght = TrendGraphList.Count*150;
        }

        /// <summary>
        /// Takes an imput from two comboboxes that decides the timeperiod and type og graph to show.
        /// Goes through the list of controlschedules and depending on the comboboxes, puts the data into another list.
        /// </summary>
        /// <param name="comboboxInput"></param>
        /// <param name="timePeriod"></param>
        /// <param name="graphProcessOrderNo"></param>
        /// <param name="graphCheckBox"></param>
        public void CreateGraph(string comboboxInput, string timePeriod, string graphProcessOrderNo, bool graphCheckBox)
        {
            _completeControlSchedulesList = ModelGenerics.GetAllsync(new ControlSchedules());

            TempTrendList.Clear();
            DateTime tempDayOfScheduleList = _completeControlSchedulesList[0].Time;
            int timeHorizon = 0;
            int timeHorizonDivider = 0;
            DateTime currentItemDate = DateTime.Now;
            double minValue = 0;
            double maxValue = 0;
            
            //checks the parameter for what is selected in the combobox
            if (timePeriod == "Idag")
            {
                timeHorizon = 1;
                timeHorizonDivider = 0;
                //GraphScrollLenght = 1500;
            }
            if (timePeriod == "En Uge")
            {
                timeHorizon = 7;
                timeHorizonDivider = 1;
                //GraphScrollLenght = 1500;
            }
            else if (timePeriod == "En Måned")
            {
                timeHorizon = 30;
                timeHorizonDivider = 3;
                //GraphScrollLenght = 1500;
            }
            else if (timePeriod == "Et Kvartal")
            {
                timeHorizon = 91;
                timeHorizonDivider = 10;
                //GraphScrollLenght = 1500;
            }
            else if (timePeriod == "Et År")
            {
                timeHorizon = 365;
                timeHorizonDivider = 30;
                //GraphScrollLenght = 1500;
            }
            if (timePeriod == "En Uge (Detaljeret)")
            {
                timeHorizon = 7;
                timeHorizonDivider = 0;
                //GraphScrollLenght = 4000;
            }
            else if (timePeriod == "En Måned (Detaljeret)")
            {
                timeHorizon = 30;
                timeHorizonDivider = 0;
                //GraphScrollLenght = 8000;
            }
            else if (timePeriod == "Et Kvartal (Detaljeret)")
            {
                timeHorizon = 91;
                timeHorizonDivider = 1;
                //GraphScrollLenght = 4000;
            }
            else if (timePeriod == "Et År (Detaljeret)")
            {
                timeHorizon = 365;
                timeHorizonDivider = 1;
                //GraphScrollLenght = 11000;
            }

            int amountOfItemsWithSameDate = 0;
            double tempTotalValue = 0;
            foreach (var scheduleItem in _completeControlSchedulesList)
            {
                
                    //checks the item date and only if the date is between the selected timeperiod and now, the data is put in the list.
                    if (scheduleItem.Time >= DateTime.Now - new TimeSpan(timeHorizon, 0, 0, 0) &&
                        scheduleItem.Time <= DateTime.Now)
                    {
                        currentItemDate = scheduleItem.Time.Subtract(new TimeSpan(0,
                            scheduleItem.Time.Hour, scheduleItem.Time.Minute,
                            scheduleItem.Time.Second));
                        //if timehorizonDivider == 0 we want all data directly in the list and not the average of the day.
                        if (timeHorizonDivider == 0)
                        {
                            if (comboboxInput == "Vægt")
                                TempTrendList.Add(new Trends(scheduleItem.Weight,
                                    scheduleItem.Time.Year + "/" + scheduleItem.Time.Month + "/" +
                                    scheduleItem.Time.Day + "/" + scheduleItem.Time.Hour + ":" +
                                    scheduleItem.Time.Minute, ConstantValues.MinWeight, ConstantValues.MaxWeight));
                            if (comboboxInput == "MipMa")
                                TempTrendList.Add(new Trends(scheduleItem.MipMA,
                                    scheduleItem.Time.Year + "/" + scheduleItem.Time.Month + "/" +
                                    scheduleItem.Time.Day + "/" + scheduleItem.Time.Hour + ":" +
                                    scheduleItem.Time.Minute, ConstantValues.MinMipMa, ConstantValues.MaxMipMa));
                            if (comboboxInput == "Lud Koncentration")
                                TempTrendList.Add(new Trends(scheduleItem.LudKoncentration,
                                    scheduleItem.Time.Year + "/" + scheduleItem.Time.Month + "/" +
                                    scheduleItem.Time.Day + "/" + scheduleItem.Time.Hour + ":" +
                                    scheduleItem.Time.Minute, ConstantValues.MinLudkoncentration,
                                    ConstantValues.MaxLudkoncentration));
                            continue;
                        }

                        here:
                        //checks if the date is within the time horizon of how many days we want the avarage.
                        if (tempDayOfScheduleList <= currentItemDate + new TimeSpan(timeHorizonDivider, 0, 0, 0) &&
                            tempDayOfScheduleList >= currentItemDate)
                        {
                            //adds the values to a tempTotalValue for each item that is within the same time horizon.
                            amountOfItemsWithSameDate++;
                            if (comboboxInput == "Vægt")
                            {
                                tempTotalValue += (double) scheduleItem.Weight;
                                minValue = ConstantValues.MinWeight;
                                maxValue = ConstantValues.MaxWeight;
                            }
                            else if (comboboxInput == "MipMa")
                            {
                                tempTotalValue += (double) scheduleItem.MipMA;
                                minValue = ConstantValues.MinMipMa;
                                maxValue = ConstantValues.MaxMipMa;
                            }
                            else if (comboboxInput == "Lud Koncentration")
                            {
                                tempTotalValue += (double) scheduleItem.LudKoncentration;
                                minValue = ConstantValues.MinLudkoncentration;
                                maxValue = ConstantValues.MaxLudkoncentration;
                            }

                            continue;
                        }

                        //Adds the average from the time horizon to the list
                        if (amountOfItemsWithSameDate != 0)
                        {
                            TempTrendList.Add(new Trends(tempTotalValue / amountOfItemsWithSameDate,
                                tempDayOfScheduleList.Year + "/" + tempDayOfScheduleList.Month + "/" +
                                tempDayOfScheduleList.Day, minValue, maxValue));
                        }

                        //Resets values
                        tempTotalValue = 0;
                        amountOfItemsWithSameDate = 0;
                        //Only changes the tempDayOfScheduleList if it has proceeded the timeHorizonDivider
                        if (new TimeSpan(timeHorizonDivider, 0, 0, 0) <= currentItemDate - tempDayOfScheduleList)
                        {
                            tempDayOfScheduleList = currentItemDate;
                            goto here;
                        }

                    }
                
            }
            //Adds the last tempTotalValue to the list
            if (amountOfItemsWithSameDate != 0)
            {
                TempTrendList.Add(new Trends(tempTotalValue / amountOfItemsWithSameDate, currentItemDate.Year + "/" + currentItemDate.Month + "/" + currentItemDate.Day, minValue, maxValue));
            }
            //Gives the list to a new observableCollection, so the graph doesn't use the list while it is changing.
            TrendGraphList = new ObservableCollection<Trends> (TempTrendList);
            if (TrendGraphList.Count > 10)
            {
            GraphScrollLenght = TrendGraphList.Count*100;
            }
            else
            {
                GraphScrollLenght = 1100;
            }
        }
        
        #region INotify

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
