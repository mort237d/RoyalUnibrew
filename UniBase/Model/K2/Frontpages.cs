using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
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
        private DateTime _date;
        private Products _product;

        //Helpers
        private string _processOrderNoIntHelper;
        private string _weekNoIntHelper;
        private string _colunmIntHelper;
        private string _finishedProductNoIntHelper;
        private string _dateStringHelper;

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

        #region PropertyHelpers
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
        public string FinishedProductNoIntHelper
        {
            get { return _finishedProductNoIntHelper; }
            set
            {
                _finishedProductNoIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string ColunmIntHelper
        {
            get { return _colunmIntHelper; }
            set
            {
                _colunmIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string WeekNoIntHelper
        {
            get { return _weekNoIntHelper; }
            set
            {
                _weekNoIntHelper = value;

                OnPropertyChanged();
            }
        }
        [JsonIgnore]
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
        #endregion
        
        public int ProcessOrder_No
        {
            get => _processOrderNo;
            set
            {
                _processOrderNo = value;
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

        public int FinishedProduct_No
        {
            get => _finishedProductNo;
            set
            {
                _finishedProductNo = value;
            }
        }

        public int Colunm
        {
            get => _colunm;
            set
            {
                _colunm = value;
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
                _weekNo = value;
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
