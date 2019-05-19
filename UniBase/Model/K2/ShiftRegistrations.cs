using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class ShiftRegistrations : INotifyPropertyChanged
    {
        private int _shiftRegistrationId;
        private int _breaks;
        private int _processOrderNo;
        private string _initials;
        private int _staff;
        private int _totalHours;
        private DateTime _startTime;
        private DateTime _endDate;

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

        public ShiftRegistrations(int shiftRegistration_ID, DateTime start_Time, DateTime end_Date, int breaks, int totalHours, int staff, string initials, int processOrder_No, Frontpages frontpage)
        {
            ShiftRegistration_ID = shiftRegistration_ID;
            Start_Time = start_Time;
            End_Date = end_Date;
            Breaks = breaks;
            TotalHours = totalHours;
            Staff = staff;
            Initials = initials;
            ProcessOrder_No = processOrder_No;
            Frontpage = frontpage;
        }

        #region Helpers
        [JsonIgnore]
        public string ShiftRegistrationIdIntHelper
        {
            get { return _shiftRegistrationIdIntHelper; }
            set
            {
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
                _staffIntHelper = value; 
                OnPropertyChanged();
            }
        }
        #endregion
        public int ShiftRegistration_ID
        {
            get => _shiftRegistrationId;
            set
            {
                _shiftRegistrationId = value;
            }
        }

        public int ProcessOrder_No
        {
            get => _processOrderNo;
            set
            {
                _processOrderNo = value;
            }
        }

        public DateTime Start_Time
        {
            get => _startTime;
            set
            {
                _startTime = value;
            }
        }

        public DateTime End_Date
        {
            get => _endDate;
            set
            {
                _endDate = value;
            }
        }

        public int Breaks
        {
            get => _breaks;
            set
            {
                _breaks = value;
            }
        }

        public int TotalHours
        {
            get => _totalHours;
            set
            {
                _totalHours = value;
            }
        }

        public int Staff
        {
            get => _staff;
            set
            {
                _staff = value;
            }
        }

        public string Initials
        {
            get => _initials;
            set
            {
                _initials = value;
                OnPropertyChanged();
            }
        }
        
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
