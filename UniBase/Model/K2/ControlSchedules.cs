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
        private OutOfBoundColorChange ofBoundColorChange = new OutOfBoundColorChange();
        private ConstantValues constantValues = new ConstantValues();
        private double _weight;

        private Brush weightColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private Brush mipMaColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private Brush ludKoncentrationColorBrush = new SolidColorBrush(Colors.LightSalmon);
        private double _ludKoncentration;
        private double _mipMa;

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

        public DateTime Time { get; set; }

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

        public string KegTest { get; set; }

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
                MipMaColorBrush =
                    ofBoundColorChange.ChangeListViewColor(_mipMa, constantValues.MinMipMa, constantValues.MaxMipMa);
            }
        }

        public string Signature { get; set; }

        public string Note { get; set; }

        public int ProcessOrder_No { get; set; }

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


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
