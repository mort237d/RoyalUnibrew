using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UniBase.Annotations;
using UniBase.Model.K2.ButtonMethods;

namespace UniBase.Model.K2
{
    public class TUs : INotifyPropertyChanged
    {
        private int _tuId;
        private int _firstDayStartTu;
        private int _firstDayEndTu;
        private int _firstDayTotal;
        private int _secoundDayStartTu;
        private int _secoundDayEndTu;
        private int _secoundDayTotal;
        private int _thirdDayStartTu;
        private int _thirdDayEndTu;
        private int _thirdDayTotal;
        private int _processOrderNo;

        //Helpers
        private string _tuIdIntHelper;
        private string _firstDayStartTuIntHelper;
        private string _firstDayEndTuIntHelper;
        private string _firstDayTotalIntHelper;
        private string _secoundDayStartTuIntHelper;
        private string _secoundDayEndTuIntHelper;
        private string _secoundDayTotalIntHelper;
        private string _thirdDayStartTuIntHelper;
        private string _thirdDayEndTuIntHelper;
        private string _thirdDayTotalIntHelper;
        private string _processOrderNoIntHelper;

        private CalculateTUTotal _calculateTuTotal = new CalculateTUTotal();
        private Productions _productions = new Productions();
        public TUs()
        {
            
        }

        public TUs(int tU_ID, int firstDayStart_TU, int firstDayEnd_TU, int firstDay_Total, int secoundDayStart_TU, int secoundDayEnd_TU, int secoundDay_Total, int thirdDayStart_TU, int thirdDayEnd_TU, int thirdDay_Total, int processOrder_No, Frontpages frontpage)
        {
            TU_ID = tU_ID;
            FirstDayStart_TU = firstDayStart_TU;
            FirstDayEnd_TU = firstDayEnd_TU;
            FirstDay_Total = firstDay_Total;
            SecoundDayStart_TU = secoundDayStart_TU;
            SecoundDayEnd_TU = secoundDayEnd_TU;
            SecoundDay_Total = secoundDay_Total;
            ThirdDayStart_TU = thirdDayStart_TU;
            ThirdDayEnd_TU = thirdDayEnd_TU;
            ThirdDay_Total = thirdDay_Total;
            ProcessOrder_No = processOrder_No;
            Frontpage = frontpage;
        }

        #region Helpers
        [JsonIgnore]
        public string TuIdIntHelper
        {
            get { return _tuIdIntHelper; }
            set
            {
                _tuIdIntHelper = value;
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
        public string FirstDayStartTuIntHelper
        {
            get { return _firstDayStartTuIntHelper; }
            set
            {
                _firstDayStartTuIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string FirstDayEndTuIntHelper
        {
            get { return _firstDayEndTuIntHelper; }
            set
            {
                _firstDayEndTuIntHelper = value; 
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string FirstDayTotalIntHelper
        {
            get { return _firstDayTotalIntHelper; }
            set
            {
                _firstDayTotalIntHelper = value; 
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string SecoundDayStartTuIntHelper
        {
            get { return _secoundDayStartTuIntHelper; }
            set
            {
                _secoundDayStartTuIntHelper = value; 
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string SecoundDayEndTuIntHelper
        {
            get { return _secoundDayEndTuIntHelper; }
            set
            {
                _secoundDayEndTuIntHelper = value; 
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string SecoundDayTotalIntHelper
        {
            get { return _secoundDayTotalIntHelper; }
            set
            {
                _secoundDayTotalIntHelper = value; 
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string ThirdDayStartTuIntHelper
        {
            get { return _thirdDayStartTuIntHelper; }
            set
            {
                _thirdDayStartTuIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string ThirdDayEndTuIntHelper
        {
            get { return _thirdDayEndTuIntHelper; }
            set
            {
                _thirdDayEndTuIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string ThirdDayTotalIntHelper
        {
            get { return _thirdDayTotalIntHelper; }
            set
            {
                _thirdDayTotalIntHelper = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public int TU_ID
        {
            get => _tuId;
            set
            {
                _tuId = value;
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
        public int FirstDayStart_TU
        {
            get => _firstDayStartTu;
            set
            {
                _firstDayStartTu = value;
            }
        }
        public int FirstDayEnd_TU
        {
            get => _firstDayEndTu;
            set
            {
                _firstDayEndTu = value;
            }
        }
        public int FirstDay_Total
        {
            get => _firstDayTotal;
            set
            {
                _firstDayTotal = value;
                OnPropertyChanged();
                _productions.PalletCounter = CalculateProductions.CalculatePalletCounter();
            }
        }
        public int SecoundDayStart_TU
        {
            get => _secoundDayStartTu;
            set
            {
                _secoundDayStartTu = value;
            }
        }
        public int SecoundDayEnd_TU
        {
            get => _secoundDayEndTu;
            set
            {
                _secoundDayEndTu = value;
            }
        }
        public int SecoundDay_Total
        {
            get => _secoundDayTotal;
            set
            {
                _secoundDayTotal = value;
                OnPropertyChanged();
                _productions.PalletCounter = CalculateProductions.CalculatePalletCounter();
            }
        }
        public int ThirdDayStart_TU
        {
            get => _thirdDayStartTu;
            set
            {
                _thirdDayStartTu = value;
            }
        }
        public int ThirdDayEnd_TU
        {
            get => _thirdDayEndTu;
            set
            {
                _thirdDayEndTu = value;
            }
        }
        public int ThirdDay_Total
        {
            get => _thirdDayTotal;
            set
            {
                _thirdDayTotal = value;
                OnPropertyChanged();
                _productions.PalletCounter = CalculateProductions.CalculatePalletCounter();
            }
        }

//        public int ProcessOrder_No
//        {
//            get => _processOrderNo;
//            set
//            {
//                if (value == _processOrderNo) return;
//                _processOrderNo = value;
//                OnPropertyChanged();
//            }
//        }

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
