using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class Frontpages : INotifyPropertyChanged
    {
        private int _processOrderNo;
        private DateTime _date;
        private string _dateHelper;
        private int _weekNo;
        private string _note;
        private int _colunm;
        private int _finishedProductNo;

        public Frontpages()
        {
            
        }

        public Frontpages(int processOrder_No, DateTime date, int finishedProduct_No, int colunm, string note, int week_No)
        {
            ProcessOrder_No = processOrder_No;
            Date = date;
            FinishedProduct_No = finishedProduct_No;
            Colunm = colunm;
            Note = note;
            Week_No = week_No;
        }

        public int ProcessOrder_No
        {
            get => _processOrderNo;
            set
            {
                if (value == _processOrderNo) return;
                _processOrderNo = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                if (value.Equals(_date)) return;
                _date = value;
                OnPropertyChanged();
            }
        }

        public string DateHelper
        {
            get => _dateHelper;
            set
            {
                if (value == _dateHelper) return;
                _dateHelper = value;
                OnPropertyChanged();
            }
        }

        public int FinishedProduct_No
        {
            get => _finishedProductNo;
            set
            {
                if (value == _finishedProductNo) return;
                _finishedProductNo = value;
                OnPropertyChanged();
            }
        }

        public int Colunm
        {
            get => _colunm;
            set
            {
                if (value == _colunm) return;
                _colunm = value;
                OnPropertyChanged();
            }
        }

        public string Note
        {
            get => _note;
            set
            {
                if (value == _note) return;
                _note = value;
                OnPropertyChanged();
            }
        }

        public int Week_No
        {
            get => _weekNo;
            set
            {
                if (value == _weekNo) return;
                _weekNo = value;
                OnPropertyChanged();
            }
        }

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
