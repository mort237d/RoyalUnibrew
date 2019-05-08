using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class ControlRegistrations : INotifyPropertyChanged
    {
        private int _controlRegistrationId;
        private TimeSpan _time;
        private DateTime _productionDate;
        private DateTime _expiryDate;
        private string _commentsOnChangedDate;
        private bool _controlAlcoholSpearDispenser;
        private int _capNo;
        private int _etiquetteNo;
        private double _kegSize;
        private string _signature;
        private DateTime _firstPalletDepalletizing;
        private DateTime _lastPalletDepalletizing;
        private int _processOrderNo;

        public ControlRegistrations()
        {
            
        }

        public ControlRegistrations(int controlRegistration_ID, TimeSpan time, DateTime production_Date, DateTime expiry_Date, string commentsOnChangedDate, bool controlAlcoholSpearDispenser, int capNo, int etiquetteNo, double kegSize, string signature, DateTime firstPalletDepalletizing, DateTime lastPalletDepalletizing, int processOrder_No, Frontpages frontpage)
        {
            ControlRegistration_ID = controlRegistration_ID;
            Time = time;
            Production_Date = production_Date;
            Expiry_Date = expiry_Date;
            CommentsOnChangedDate = commentsOnChangedDate;
            ControlAlcoholSpearDispenser = controlAlcoholSpearDispenser;
            CapNo = capNo;
            EtiquetteNo = etiquetteNo;
            KegSize = kegSize;
            Signature = signature;
            FirstPalletDepalletizing = firstPalletDepalletizing;
            LastPalletDepalletizing = lastPalletDepalletizing;
            ProcessOrder_No = processOrder_No;
            Frontpage = frontpage;
        }

        public int ControlRegistration_ID
        {
            get => _controlRegistrationId;
            set
            {
                if (value == _controlRegistrationId) return;
                _controlRegistrationId = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan Time
        {
            get => _time;
            set
            {
                if (value.Equals(_time)) return;
                _time = value;
                OnPropertyChanged();
            }
        }

        public DateTime Production_Date
        {
            get => _productionDate;
            set
            {
                if (value.Equals(_productionDate)) return;
                _productionDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime Expiry_Date
        {
            get => _expiryDate;
            set
            {
                if (value.Equals(_expiryDate)) return;
                _expiryDate = value;
                OnPropertyChanged();
            }
        }


        public string CommentsOnChangedDate
        {
            get => _commentsOnChangedDate;
            set
            {
                if (value == _commentsOnChangedDate) return;
                _commentsOnChangedDate = value;
                OnPropertyChanged();
            }
        }

        public bool ControlAlcoholSpearDispenser
        {
            get => _controlAlcoholSpearDispenser;
            set
            {
                if (value == _controlAlcoholSpearDispenser) return;
                _controlAlcoholSpearDispenser = value;
                OnPropertyChanged();
            }
        }

        public int CapNo
        {
            get => _capNo;
            set
            {
                if (value == _capNo) return;
                _capNo = value;
                OnPropertyChanged();
            }
        }

        public int EtiquetteNo
        {
            get => _etiquetteNo;
            set
            {
                if (value == _etiquetteNo) return;
                _etiquetteNo = value;
                OnPropertyChanged();
            }
        }

        public double KegSize
        {
            get => _kegSize;
            set
            {
                if (value.Equals(_kegSize)) return;
                _kegSize = value;
                OnPropertyChanged();
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

        public DateTime FirstPalletDepalletizing
        {
            get => _firstPalletDepalletizing;
            set
            {
                if (value.Equals(_firstPalletDepalletizing)) return;
                _firstPalletDepalletizing = value;
                OnPropertyChanged();
            }
        }

        public DateTime LastPalletDepalletizing
        {
            get => _lastPalletDepalletizing;
            set
            {
                if (value.Equals(_lastPalletDepalletizing)) return;
                _lastPalletDepalletizing = value;
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
