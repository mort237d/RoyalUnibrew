using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Newtonsoft.Json;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class ControlSchedules : INotifyPropertyChanged
    {
        private string _kegTest;
        private string _note;
        private string _signature;

        //Helpers
        private string _weightDoubleHelper;
        private string _ludKoncentrationDoubleHelper;
        private string _mipMaDoubleHelper;
        private string _controlScheduleIdIntHelper;
        private string _processOrderNoIntHelper;
        private string _timeStringHelper;
        
        private SolidColorBrush weightColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush mipMaColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush ludKoncentrationColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private double _mipMa;
        private double _weight;
        private double _ludKoncentration;

        public ControlSchedules()
        {

        }

        public ControlSchedules(int controlSchedule_ID, DateTime time, double weight, string kegTest, double ludKoncentration, double mipMA, string signature, string note, int processOrder_No, Frontpages frontpage)
        {
            ControlSchedule_ID = controlSchedule_ID;
            Time = time;
            Weight = weight;
            KegTest = kegTest;
            LudKoncentration = ludKoncentration;
            MipMA = mipMA;
            Signature = signature;
            Note = note;
            ProcessOrder_No = processOrder_No;
            Frontpage = frontpage;
        }

        public int ControlSchedule_ID { get; set; }

        public int ProcessOrder_No { get; set; }

        public DateTime Time { get; set; }

        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                WeightColorBrush = OutOfBoundColorChange.ChangeListViewColor(_weight, ConstantValues.MinWeight, ConstantValues.MaxWeight);
                OnPropertyChanged();
            }
        }

        public string KegTest
        {
            get => _kegTest;
            set
            {
                _kegTest = value;
                OnPropertyChanged();
            }
        }

        public double LudKoncentration
        {
            get => _ludKoncentration;
            set
            {
                _ludKoncentration = value;
                LudKoncentrationColorBrush = OutOfBoundColorChange.ChangeListViewColor(_ludKoncentration, ConstantValues.MinLudkoncentration, ConstantValues.MaxLudkoncentration);
                OnPropertyChanged();
            }

        }

        public double MipMA
        {
            get => _mipMa;
            set
            {
                _mipMa = value;
                MipMaColorBrush = OutOfBoundColorChange.ChangeListViewColor(_mipMa, ConstantValues.MinMipMa, ConstantValues.MaxMipMa);
                OnPropertyChanged();
            }
        }

        public string Signature
        {
            get => _signature;
            set
            {
                _signature = value;
                OnPropertyChanged();
            }
        }

        public string Note
        {
            get => _note;
            set
            {
                _note = value;
                OnPropertyChanged();
            }
        }

        #region Helpers
        [JsonIgnore]
        public string ControlScheduleIdIntHelper
        {
            get { return _controlScheduleIdIntHelper; }
            set
            {
                if (_controlScheduleIdIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        ControlSchedule_ID = i;
                    }
                }
                _controlScheduleIdIntHelper = value;
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
        public string TimeStringHelper
        {
            get { return _timeStringHelper; }
            set
            {
                if (_processOrderNoIntHelper != value)
                {
                    if (DateTime.TryParse(value, out DateTime t))
                    {
                        Time = t;
                    }
                }
                _timeStringHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string WeightDoubleHelper
        {
            get { return _weightDoubleHelper; }
            set
            {
                if (_weightDoubleHelper != value)
                {
                    if (value.Contains("."))
                    {
                        Double.TryParse(value.Replace('.', ','), out Double i);
                        Weight = i;

                    }
                    else 
                    {
                        Double.TryParse(value, out Double i);
                        Weight = i;
                    }
                }
                _weightDoubleHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string LudKoncentrationDoubleHelper
        {
            get { return _ludKoncentrationDoubleHelper; }
            set
            {
                if (_ludKoncentrationDoubleHelper != value)
                {
                    if (value.Contains("."))
                    {
                        Double.TryParse(value.Replace('.', ','), out Double i);
                        LudKoncentration = i;

                    }
                    else
                    {
                        Double.TryParse(value, out Double i);
                        LudKoncentration = i;
                    }
                }
                _ludKoncentrationDoubleHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string MipMaDoubleHelper
        {
            get { return _mipMaDoubleHelper; }
            set
            {
                if (_mipMaDoubleHelper != value)
                {
                    if (value.Contains("."))
                    {
                        Double.TryParse(value.Replace('.', ','), out Double i);
                        MipMA = i;

                    }
                    else
                    {
                        Double.TryParse(value, out Double i);
                        MipMA = i;
                    }
                }
                _mipMaDoubleHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public SolidColorBrush WeightColorBrush
        {
            get { return weightColorBrush; }
            set
            {
                weightColorBrush = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public SolidColorBrush MipMaColorBrush
        {
            get { return mipMaColorBrush; }
            set
            {
                mipMaColorBrush = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public SolidColorBrush LudKoncentrationColorBrush
        {
            get { return ludKoncentrationColorBrush; }
            set
            {
                ludKoncentrationColorBrush = value;
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
