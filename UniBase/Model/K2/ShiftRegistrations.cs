using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class ShiftRegistrations : INotifyPropertyChanged
    {
        private string _initials;

        private string _shiftRegistrationIdIntHelper;
        private string _breaksIntHelper;
        private string _processOrderNoIntHelper;
        private string _staffIntHelper;
        private string _totalHoursIntHelper;
        private string _startTimeStringHelper;
        private string _endDateStringHelper;

        public ShiftRegistrations()
        {
            
        }

        public ShiftRegistrations(int shiftRegistration_ID, DateTime start_Time, DateTime end_Date, int breaks, int totalHours, int staff, string initials, int processOrder_No)
        {
            ShiftRegistration_ID = shiftRegistration_ID;
            Start_Time = start_Time;
            End_Date = end_Date;
            Breaks = breaks;
            TotalHours = totalHours;
            Staff = staff;
            Initials = initials;
            ProcessOrder_No = processOrder_No;
        }

        public int ShiftRegistration_ID { get; set; }

        public int ProcessOrder_No { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime End_Date { get; set; }

        public int Breaks { get; set; }

        public int TotalHours { get; set; }

        public int Staff { get; set; }

        public string Initials
        {
            get => _initials;
            set
            {
                _initials = value;
                OnPropertyChanged();
            }
        }

        #region Helpers
        [JsonIgnore]
        public string ShiftRegistrationIdIntHelper
        {
            get { return _shiftRegistrationIdIntHelper; }
            set
            {
                if (_shiftRegistrationIdIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        ShiftRegistration_ID = i;
                    }
                }
                _shiftRegistrationIdIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string ProcessOrderNoIntHelper
        {
            get { return _processOrderNoIntHelper; }
            set
            {
                if (_processOrderNoIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        ProcessOrder_No = i;
                    }
                }
                _processOrderNoIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string StartTimeStringHelper
        {
            get { return _startTimeStringHelper; }
            set
            {
                if (_startTimeStringHelper != value)
                {
                    if (DateTime.TryParse(value, out DateTime parsedDateTime))
                    {
                        if (Start_Time == DateTime.MinValue)
                        {
                            Start_Time = parsedDateTime;
                        }
                        else
                        {
                            TimeSpan priorTimeSpan = new TimeSpan(parsedDateTime.Hour, parsedDateTime.Minute, 0);
                            Start_Time = parsedDateTime.Date + priorTimeSpan;
                        }
                    }
                }
                _startTimeStringHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string EndDateStringHelper
        {
            get { return _endDateStringHelper; }
            set
            {
                if (_endDateStringHelper != value)
                {
                    if (DateTime.TryParse(value, out DateTime parsedDateTime))
                    {
                        if (End_Date == DateTime.MinValue)
                        {
                            End_Date = parsedDateTime;
                        }
                        else
                        {
                            TimeSpan priorTimeSpan = new TimeSpan(parsedDateTime.Hour, parsedDateTime.Minute, 0);
                            End_Date = parsedDateTime.Date + priorTimeSpan;
                        }
                    }
                }
                _endDateStringHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string BreaksIntHelper
        {
            get { return _breaksIntHelper; }
            set
            {
                if (_breaksIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        Breaks = i;
                    }
                }
                _breaksIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string TotalHoursIntHelper
        {
            get { return _totalHoursIntHelper; }
            set
            {
                if (_totalHoursIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        TotalHours = i;
                    }
                }
                _totalHoursIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string StaffIntHelper
        {
            get { return _staffIntHelper; }
            set
            {
                if (_staffIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        Staff = i;
                    }
                }
                _staffIntHelper = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public virtual Frontpages Frontpage { get; set; }


        #region InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
