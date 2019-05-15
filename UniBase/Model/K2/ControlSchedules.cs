using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml.Media;
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
        


        private string _timeStringHelper;


        private OutOfBoundColorChange _ofBoundColorChange = new OutOfBoundColorChange();
        private ConstantValues _constantValues = new ConstantValues();
        private SolidColorBrush _weightColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _mipMaColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _ludKoncentrationColorBrush = new SolidColorBrush(Colors.LightSalmon);

        public ControlSchedules()
        {

        }

        public ControlSchedules(int controlScheduleId, DateTime time, double weight, string kegTest, double ludKoncentration, double mipMa, string signature, string note, int processOrderNo, Frontpages frontpage)
        {
            ControlScheduleId = controlScheduleId;
            Time = time;
            Weight = weight;
            KegTest = kegTest;
            LudKoncentration = ludKoncentration;
            MipMa = mipMa;
            Signature = signature;
            Note = note;
            ProcessOrderNo = processOrderNo;
            Frontpage = frontpage;
        }

        public int ControlScheduleId
        {
            get => _controlScheduleId;
            set
            {
                if (value == _controlScheduleId) return;
                _controlScheduleId = value;
                OnPropertyChanged();
            }
        }
        
        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged();
                if (_weight != null)
                {
                    WeightColorBrush = _ofBoundColorChange.ChangeListViewColor((double)_weight, _constantValues.MinWeight, _constantValues.MaxWeight);
                }
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
                OnPropertyChanged();
                if (_ludKoncentration != null)
                {
                    LudKoncentrationColorBrush = _ofBoundColorChange.ChangeListViewColor((double)_ludKoncentration, _constantValues.MinLudkoncentration, _constantValues.MaxLudkoncentration);
                }
            }
        }

        public double MipMa
        {
            get => _mipMa;
            set
            {
                _mipMa = value;
                OnPropertyChanged();
                if (_mipMa != null)
                {
                    MipMaColorBrush = _ofBoundColorChange.ChangeListViewColor((double)_mipMa, _constantValues.MinMipMa, _constantValues.MaxMipMa);
                }
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

        public int ProcessOrderNo
        {
            get => _processOrderNo;
            set
            {
                _processOrderNo = value;
                OnPropertyChanged();
            }
        }

        public string TimeStringHelper
        {
            get { return _timeStringHelper; }
            set
            {
                _timeStringHelper = value; 
                OnPropertyChanged();
            }
        }

        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        public virtual Frontpages Frontpage { get; set; }

        public SolidColorBrush WeightColorBrush
        {
            get { return _weightColorBrush; }
            set
            {
                _weightColorBrush = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush MipMaColorBrush
        {
            get { return _mipMaColorBrush; }
            set
            {
                _mipMaColorBrush = value; 
                OnPropertyChanged();
            }
        }

        public SolidColorBrush LudKoncentrationColorBrush
        {
            get { return _ludKoncentrationColorBrush; }
            set
            {
                _ludKoncentrationColorBrush = value; 
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
