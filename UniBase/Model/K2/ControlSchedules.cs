using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Text;
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


        private OutOfBoundColorChange ofBoundColorChange = new OutOfBoundColorChange();
        private ConstantValues constantValues = new ConstantValues();
        private Brush weightColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private Brush mipMaColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private Brush ludKoncentrationColorBrush = new SolidColorBrush(Colors.LightSalmon);

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

        public int ControlSchedule_ID
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
                WeightColorBrush = ofBoundColorChange.ChangeListViewColor(_weight, constantValues.MinWeight, constantValues.MaxWeight);
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
                LudKoncentrationColorBrush = ofBoundColorChange.ChangeListViewColor(_ludKoncentration,
                    constantValues.MinLudkoncentration, constantValues.MaxLudkoncentration);
            }
        }

        public double MipMA
        {
            get => _mipMa;
            set
            {
                _mipMa = value;
                OnPropertyChanged();
                MipMaColorBrush = ofBoundColorChange.ChangeListViewColor(_mipMa, constantValues.MinMipMa, constantValues.MaxMipMa);
            }
        }

        public string Signature
        {
            get => _signature;
            set
            {
                if (value == _signature) return;
                _signature = value;
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
                if (value.Equals(_time)) return;
                _time = value;
                OnPropertyChanged();
            }
        }

        public virtual Frontpages Frontpage { get; set; }

        public Brush WeightColorBrush
        {
            get { return weightColorBrush; }
            set
            {
                weightColorBrush = value;
                OnPropertyChanged();
            }
        }

        public Brush MipMaColorBrush
        {
            get { return mipMaColorBrush; }
            set
            {
                mipMaColorBrush = value; 
                OnPropertyChanged();
            }
        }

        public Brush LudKoncentrationColorBrush
        {
            get { return ludKoncentrationColorBrush; }
            set
            {
                ludKoncentrationColorBrush = value; 
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
