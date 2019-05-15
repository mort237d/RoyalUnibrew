using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class Frontpages : INotifyPropertyChanged
    {
        private int _processOrderNo;
        private int _weekNo;
        private string _note;
        private int _colunm;
        private int _finishedProductNo;
        private Products _product;
        private DateTime _date;



        private string _dateStringHelper;

        public Frontpages()
        {

        }

        public Frontpages(int processOrderNo, DateTime date, int finishedProductNo, int colunm, string note, int weekNo)
        {
            ProcessOrderNo = processOrderNo;
            Date = date;
            FinishedProductNo = finishedProductNo;
            Colunm = colunm;
            Note = note;
            WeekNo = weekNo;
        }

        public int ProcessOrderNo
        {
            get => _processOrderNo;
            set
            {
                _processOrderNo = value;
                OnPropertyChanged();
            }
        }
        public string DateTimeStringHelper
        {
            get => _dateStringHelper;
            set
            {
                if (value == _dateStringHelper) return;
                _dateStringHelper = value;
                OnPropertyChanged();
            }
        }

        public int FinishedProductNo
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

        public int WeekNo
        {
            get => _weekNo;
            set
            {
                if (value == _weekNo) return;
                _weekNo = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
            }
        }

        public virtual Products Product
        {
            get { return _product; }
            set { _product = value; }
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
