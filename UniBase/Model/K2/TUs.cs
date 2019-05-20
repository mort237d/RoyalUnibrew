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
        //private CalculateProductions _calculateProductions = new CalculateProductions();
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
                //_productions.PalletCounter = _calculateProductions.CalculatePalletCounter(ProcessOrder_No);
            }
        }
        public int SecoundDayStart_TU
        {
            get => _secoundDayStartTu;
            set
            {
                _secoundDayStartTu = value;
                SecoundDay_Total = _calculateTuTotal.CalculateTUDayTotal(SecoundDayStart_TU, SecoundDayEnd_TU);
            }
        }
        public int SecoundDayEnd_TU
        {
            get => _secoundDayEndTu;
            set
            {
                _secoundDayEndTu = value;
                SecoundDay_Total = _calculateTuTotal.CalculateTUDayTotal(SecoundDayStart_TU, SecoundDayEnd_TU);
            }
        }
        public int SecoundDay_Total
        {
            get => _secoundDayTotal;
            set
            {
                _secoundDayTotal = value;
                OnPropertyChanged();
                //_productions.PalletCounter = CalculateProductions.CalculatePalletCounter();
            }
        }
        public int ThirdDayStart_TU
        {
            get => _thirdDayStartTu;
            set
            {
                _thirdDayStartTu = value;
                ThirdDay_Total = _calculateTuTotal.CalculateTUDayTotal(ThirdDayStart_TU, ThirdDayEnd_TU);
            }
        }
        public int ThirdDayEnd_TU
        {
            get => _thirdDayEndTu;
            set
            {
                _thirdDayEndTu = value;
                ThirdDay_Total = _calculateTuTotal.CalculateTUDayTotal(ThirdDayStart_TU, ThirdDayEnd_TU);
            }
        }
        public int ThirdDay_Total
        {
            get => _thirdDayTotal;
            set
            {
                _thirdDayTotal = value;
                OnPropertyChanged();
                //_productions.PalletCounter = CalculateProductions.CalculatePalletCounter();
            }
        }

        #region Helpers
        [JsonIgnore]
        public string TuIdIntHelper
        {
            get { return _tuIdIntHelper; }
            set
            {
                if (_tuIdIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        TU_ID = i;
                    }
                }
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
        public string FirstDayStartTuIntHelper
        {
            get { return _firstDayStartTuIntHelper; }
            set
            {
                if (_firstDayStartTuIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        FirstDayStart_TU = i;
                    }
                }
                _firstDayStartTuIntHelper = value;
                OnPropertyChanged();

                FirstDay_Total = _calculateTuTotal.CalculateTUDayTotal(FirstDayStart_TU, FirstDayEnd_TU);
            }
        }
        [JsonIgnore]
        public string FirstDayEndTuIntHelper
        {
            get { return _firstDayEndTuIntHelper; }
            set
            {
                if (_firstDayEndTuIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        FirstDayEnd_TU = i;
                    }
                }
                _firstDayEndTuIntHelper = value;
                OnPropertyChanged();
                FirstDay_Total = _calculateTuTotal.CalculateTUDayTotal(FirstDayStart_TU, FirstDayEnd_TU);
            }
        }
        [JsonIgnore]
        public string FirstDayTotalIntHelper
        {
            get { return _firstDayTotalIntHelper; }
            set
            {
                if (_firstDayTotalIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        FirstDay_Total = i;
                    }
                }
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
                if (_secoundDayStartTuIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        SecoundDayStart_TU = i;
                    }
                }
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
                if (_secoundDayEndTuIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        SecoundDayEnd_TU = i;
                    }
                }
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
                if (_secoundDayTotalIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        SecoundDay_Total = i;
                    }
                }
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
                if (_thirdDayStartTuIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        ThirdDayStart_TU = i;
                    }
                }
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
                if (_thirdDayEndTuIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        ThirdDayEnd_TU = i;
                    }
                }
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
                if (_thirdDayTotalIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        ThirdDay_Total = i;
                    }
                }
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
