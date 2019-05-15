﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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


        private string _startTimeStringHelper;
        private string _endDateStringHelper;

        public ShiftRegistrations()
        {
            
        }

        public ShiftRegistrations(int shiftRegistrationId, DateTime startTime, DateTime endDate, int breaks, int totalHours, int staff, string initials, int processOrderNo, Frontpages frontpage)
        {
            ShiftRegistrationId = shiftRegistrationId;
            StartTime = startTime;
            EndDate = endDate;
            Breaks = breaks;
            TotalHours = totalHours;
            Staff = staff;
            Initials = initials;
            ProcessOrderNo = processOrderNo;
            Frontpage = frontpage;
        }

        public string StartTimeStringHelper
        {
            get { return _startTimeStringHelper; }
            set
            {
                _startTimeStringHelper = value;
                OnPropertyChanged();
            }
        }

        public string EndDateStringHelper
        {
            get { return _endDateStringHelper; }
            set
            {
                _endDateStringHelper = value;
                OnPropertyChanged();
            }
        }

        public int ShiftRegistrationId
        {
            get => _shiftRegistrationId;
            set
            {
                if (value == _shiftRegistrationId) return;
                _shiftRegistrationId = value;
                OnPropertyChanged();
            }
        }

        public int Breaks
        {
            get => _breaks;
            set
            {
                if (value == _breaks) return;
                _breaks = value;
                OnPropertyChanged();
            }
        }

        public int TotalHours
        {
            get => _totalHours;
            set
            {
                if (value == _totalHours) return;
                _totalHours = value;
                OnPropertyChanged();
            }
        }

        public int Staff
        {
            get => _staff;
            set
            {
                if (value == _staff) return;
                _staff = value;
                OnPropertyChanged();
            }
        }

        public string Initials
        {
            get => _initials;
            set
            {
                if (value == _initials) return;
                _initials = value;
                OnPropertyChanged();
            }
        }

        public int ProcessOrderNo
        {
            get => _processOrderNo;
            set
            {
                if (value == _processOrderNo) return;
                _processOrderNo = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                if (value.Equals(_startTime)) return;
                _startTime = value;
                OnPropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (value.Equals(_endDate)) return;
                _endDate = value;
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
