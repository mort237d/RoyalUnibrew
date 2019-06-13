using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class Frontpages : INotifyPropertyChanged
    {
        #region Fields

        private string _note;

        //Helpers
        private string _processOrderNoIntHelper;
        private string _weekNoIntHelper;
        private string _colunmIntHelper;
        private string _finishedProductNoIntHelper;
        private string _dateStringHelper;

        #endregion

        #region Constructors

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

        #endregion

        #region Properties

        public int ProcessOrder_No { get; set; }

        public DateTime Date { get; set; }

        public int FinishedProduct_No { get; set; }

        public int Colunm { get; set; }

        public string Note
        {
            get => _note;
            set
            {
                _note = value;
                OnPropertyChanged();
            }
        }

        public int Week_No { get; set; }

        public virtual Products Product { get; set; }

        #region StringHelpers
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
        public string FinishedProductNoIntHelper
        {
            get { return _finishedProductNoIntHelper; }
            set
            {
                if (_finishedProductNoIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        FinishedProduct_No = i;
                    }
                }
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
                if (_colunmIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        Colunm = i;
                    }
                }
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
                if (_dateStringHelper != value)
                {
                    if (DateTime.TryParse(value, out DateTime time))
                    {
                        Date = time;

                        //https://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date
                        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
                        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                        {
                            time = time.AddDays(3);
                        }

                        // Return the week of our adjusted day
                        Week_No = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                        WeekNoIntHelper = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();

                    }
                }
                _dateStringHelper = value;
                OnPropertyChanged();
            }
        }
#endregion

        #endregion

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
