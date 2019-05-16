using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;
using UniBase.Model.K2.ButtonMethods;

namespace UniBase.Model.K2
{
    public class TUs : INotifyPropertyChanged
    {
        private int _processOrderNo;
        private int _thirdDayTotal;
        private int _thirdDayEndTu;
        private int _thirdDayStartTu;
        private int _secoundDayTotal;
        private int _secoundDayEndTu;
        private int _secoundDayStartTu;
        private int _firstDayTotal;
        private int _firstDayEndTu;
        private int _firstDayStartTu;
        private int _tuId;


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

        public int TU_ID
        {
            get => _tuId;
            set
            {
                if (value == _tuId) return;
                _tuId = value;
                OnPropertyChanged();
            }
        }

        public int FirstDayStart_TU
        {
            get => _firstDayStartTu;
            set
            {
                if (value == _firstDayStartTu) return;
                _firstDayStartTu = value;
                OnPropertyChanged();
                FirstDay_Total = _calculateTuTotal.CalculateTUDayTotal(FirstDayStart_TU, FirstDayEnd_TU);
            }
        }

        public int FirstDayEnd_TU
        {
            get => _firstDayEndTu;
            set
            {
                if (value == _firstDayEndTu) return;
                _firstDayEndTu = value;
                OnPropertyChanged();
                FirstDay_Total = _calculateTuTotal.CalculateTUDayTotal(FirstDayStart_TU, FirstDayEnd_TU);
            }
        }

        public int FirstDay_Total
        {
            get => _firstDayTotal;
            set
            {
                if (value == _firstDayTotal) return;
                _firstDayTotal = value;
                OnPropertyChanged();
                _calculateTuTotal.CalculatePalletCounter(FirstDay_Total, SecoundDay_Total, ThirdDay_Total,
                    _productions.PalletPutInStock0001);
            }
        }

        public int SecoundDayStart_TU
        {
            get => _secoundDayStartTu;
            set
            {
                if (value == _secoundDayStartTu) return;
                _secoundDayStartTu = value;
                OnPropertyChanged();
                SecoundDay_Total = _calculateTuTotal.CalculateTUDayTotal(SecoundDayStart_TU, SecoundDayEnd_TU);
            }
        }

        public int SecoundDayEnd_TU
        {
            get => _secoundDayEndTu;
            set
            {
                if (value == _secoundDayEndTu) return;
                _secoundDayEndTu = value;
                OnPropertyChanged();
                SecoundDay_Total = _calculateTuTotal.CalculateTUDayTotal(SecoundDayStart_TU, SecoundDayEnd_TU);
            }
        }

        public int SecoundDay_Total
        {
            get => _secoundDayTotal;
            set
            {
                if (value == _secoundDayTotal) return;
                _secoundDayTotal = value;
                OnPropertyChanged();
                _calculateTuTotal.CalculatePalletCounter(FirstDay_Total, SecoundDay_Total, ThirdDay_Total,
                    _productions.PalletPutInStock0001);
            }
        }

        public int ThirdDayStart_TU
        {
            get => _thirdDayStartTu;
            set
            {
                if (value == _thirdDayStartTu) return;
                _thirdDayStartTu = value;
                OnPropertyChanged();
                ThirdDay_Total = _calculateTuTotal.CalculateTUDayTotal(ThirdDayStart_TU, ThirdDayEnd_TU);
            }
        }

        public int ThirdDayEnd_TU
        {
            get => _thirdDayEndTu;
            set
            {
                if (value == _thirdDayEndTu) return;
                _thirdDayEndTu = value;
                OnPropertyChanged();
                ThirdDay_Total = _calculateTuTotal.CalculateTUDayTotal(ThirdDayStart_TU, ThirdDayEnd_TU);
            }
        }

        public int ThirdDay_Total
        {
            get => _thirdDayTotal;
            set
            {
                if (value == _thirdDayTotal) return;
                _thirdDayTotal = value;
                OnPropertyChanged();
                _calculateTuTotal.CalculatePalletCounter(FirstDay_Total, SecoundDay_Total, ThirdDay_Total,
                    _productions.PalletPutInStock0001);
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
