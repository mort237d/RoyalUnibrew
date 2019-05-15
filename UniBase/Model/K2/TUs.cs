using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;
using UniBase.Model.K2.ButtonMethods;

namespace UniBase.Model.K2
{
    public class Us : INotifyPropertyChanged
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


        private CalculateTuTotal _calculateTuTotal = new CalculateTuTotal();

        public Us()
        {
            
        }

        public Us(int tUId, int firstDayStartTu, int firstDayEndTu, int firstDayTotal, int secoundDayStartTu, int secoundDayEndTu, int secoundDayTotal, int thirdDayStartTu, int thirdDayEndTu, int thirdDayTotal, int processOrderNo, Frontpages frontpage)
        {
            TuId = tUId;
            FirstDayStartTu = firstDayStartTu;
            FirstDayEndTu = firstDayEndTu;
            FirstDayTotal = firstDayTotal;
            SecoundDayStartTu = secoundDayStartTu;
            SecoundDayEndTu = secoundDayEndTu;
            SecoundDayTotal = secoundDayTotal;
            ThirdDayStartTu = thirdDayStartTu;
            ThirdDayEndTu = thirdDayEndTu;
            ThirdDayTotal = thirdDayTotal;
            ProcessOrderNo = processOrderNo;
            Frontpage = frontpage;
        }

        public int TuId
        {
            get => _tuId;
            set
            {
                if (value == _tuId) return;
                _tuId = value;
                OnPropertyChanged();
            }
        }

        public int FirstDayStartTu
        {
            get => _firstDayStartTu;
            set
            {
                if (value == _firstDayStartTu) return;
                _firstDayStartTu = value;
                OnPropertyChanged();
                FirstDayTotal = _calculateTuTotal.CalculateTuDayTotal(FirstDayStartTu, FirstDayEndTu);
            }
        }

        public int FirstDayEndTu
        {
            get => _firstDayEndTu;
            set
            {
                if (value == _firstDayEndTu) return;
                _firstDayEndTu = value;
                OnPropertyChanged();
                FirstDayTotal = _calculateTuTotal.CalculateTuDayTotal(FirstDayStartTu, FirstDayEndTu);
            }
        }

        public int FirstDayTotal
        {
            get => _firstDayTotal;
            set
            {
                if (value == _firstDayTotal) return;
                _firstDayTotal = value;
                OnPropertyChanged();
            }
        }

        public int SecoundDayStartTu
        {
            get => _secoundDayStartTu;
            set
            {
                if (value == _secoundDayStartTu) return;
                _secoundDayStartTu = value;
                OnPropertyChanged();
                SecoundDayTotal = _calculateTuTotal.CalculateTuDayTotal(SecoundDayStartTu, SecoundDayEndTu);
            }
        }

        public int SecoundDayEndTu
        {
            get => _secoundDayEndTu;
            set
            {
                if (value == _secoundDayEndTu) return;
                _secoundDayEndTu = value;
                OnPropertyChanged();
                SecoundDayTotal = _calculateTuTotal.CalculateTuDayTotal(SecoundDayStartTu, SecoundDayEndTu);
            }
        }

        public int SecoundDayTotal
        {
            get => _secoundDayTotal;
            set
            {
                if (value == _secoundDayTotal) return;
                _secoundDayTotal = value;
                OnPropertyChanged();
            }
        }

        public int ThirdDayStartTu
        {
            get => _thirdDayStartTu;
            set
            {
                if (value == _thirdDayStartTu) return;
                _thirdDayStartTu = value;
                OnPropertyChanged();
                ThirdDayTotal = _calculateTuTotal.CalculateTuDayTotal(ThirdDayStartTu, ThirdDayEndTu);
            }
        }

        public int ThirdDayEndTu
        {
            get => _thirdDayEndTu;
            set
            {
                if (value == _thirdDayEndTu) return;
                _thirdDayEndTu = value;
                OnPropertyChanged();
                ThirdDayTotal = _calculateTuTotal.CalculateTuDayTotal(ThirdDayStartTu, ThirdDayEndTu);
            }
        }

        public int ThirdDayTotal
        {
            get => _thirdDayTotal;
            set
            {
                if (value == _thirdDayTotal) return;
                _thirdDayTotal = value;
                OnPropertyChanged();
            }
        }

        public int ProcessOrderNo
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
