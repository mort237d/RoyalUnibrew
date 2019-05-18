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
        private double _weight;
        private double _ludKoncentration;
        private double _mipMa;
        private int _controlScheduleId;
        private string _kegTest;
        private int _processOrderNo;
        private string _note;
        private string _signature;
        private DateTime _time;


        //Helpers
        private string _weightDoubleHelper;
        private string _ludKoncentrationDoubleHelper;
        private string _mipMaDoubleHelper;
        private string _controlScheduleIdIntHelper;
        private string _processOrderNoIntHelper;
        private string _timeStringHelper;

        
        private OutOfBoundColorChange ofBoundColorChange = new OutOfBoundColorChange();
        private ConstantValues constantValues = new ConstantValues();
        private SolidColorBrush weightColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush mipMaColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush ludKoncentrationColorBrush = new SolidColorBrush(Colors.LightSalmon);

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

        #region Helpers
        [JsonIgnore]
        public string ControlScheduleIdIntHelper
        {
            get { return _controlScheduleIdIntHelper; }
            set
            {
                _controlScheduleIdIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string WeightDoubleHelper
        {
            get { return _weightDoubleHelper; }
            set
            {
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
                _mipMaDoubleHelper = value;
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
        public string TimeStringHelper
        {
            get { return _timeStringHelper; }
            set
            {
                _timeStringHelper = value;
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

        public int ControlSchedule_ID
        {
            get => _controlScheduleId;
            set
            {
                _controlScheduleId = value;
            }
        }
        
        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                //if (_weight != null)
                //{
                //    WeightColorBrush = ofBoundColorChange.ChangeListViewColor((double)_weight, constantValues.MinWeight, constantValues.MaxWeight);
                //}
            }
        }

        public string KegTest
        {
            get => _kegTest;
            set
            {
                if (value == _kegTest) return;
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
                if (_ludKoncentration != null)
                {
                    LudKoncentrationColorBrush = ofBoundColorChange.ChangeListViewColor((double)_ludKoncentration, constantValues.MinLudkoncentration, constantValues.MaxLudkoncentration);
                }
            }
        }

        public double MipMA
        {
            get => _mipMa;
            set
            {
                _mipMa = value;
                //if (_mipMa != null) //todo fix this
                //{
                //    MipMaColorBrush = ofBoundColorChange.ChangeListViewColor((double)_mipMa, constantValues.MinMipMa, constantValues.MaxMipMa);
                //}
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

        public int ProcessOrder_No
        {
            get => _processOrderNo;
            set
            {
                _processOrderNo = value;
            }
        }

        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
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
