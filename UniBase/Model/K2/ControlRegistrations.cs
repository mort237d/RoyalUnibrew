using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class ControlRegistrations : INotifyPropertyChanged
    {
        private int _controlRegistrationId;
        private string _commentsOnChangedDate;
        private bool _controlAlcoholSpearDispenser = false;
        private int _capNo;
        private int _etiquetteNo;
        private string _kegSize;
        private string _signature;
        private int _processOrderNo;
        private int _finishedProduct_No;
        private TimeSpan _time;
        private DateTime _productionDate;
        private DateTime _firstPalletDepalletizing;
        private DateTime _lastPalletDepalletizing;
        private DateTime _expiryDate; //ToDo add to GUI through binding
        

        private string _timeStringHelper;
        private string _productionsDateStringHelper;
        private string _firstPalletDepalletizingStringHelper;
        private string _lastPalletDepalletizingStringHelper;

        private string _controlRegistrationAlcoholSpearDispenserControlled;

        public ControlRegistrations()
        {
            
        }

        public ControlRegistrations(int controlRegistration_ID, TimeSpan time, DateTime production_Date,
            DateTime expiry_Date, string commentsOnChangedDate, bool controlAlcoholSpearDispenser, int capNo,
            int etiquetteNo, string kegSize, string signature, DateTime firstPalletDepalletizing,
            DateTime lastPalletDepalletizing, int processOrder_No, Frontpages frontpage, int finishedProductNo)
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
            FinishedProductNo = finishedProductNo;
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
        public int FinishedProductNo
        {
            get { return _finishedProduct_No; }
            set
            {
                _finishedProduct_No = value;
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

        public bool ControlAlcoholSpearDispenser
        {
            get => _controlAlcoholSpearDispenser;
            set
            {
                //if (value == _controlAlcoholSpearDispenser) return;
                _controlAlcoholSpearDispenser = value;

                OnPropertyChanged();

                if (ControlAlcoholSpearDispenser)
                {
                    ControlRegistrationAlcoholSpearDispenserControlled = "Images/CheckedCheckbox.png";
                }
                else
                {
                    ControlRegistrationAlcoholSpearDispenserControlled = "Images/UnCheckedCheckbox.png";
                }
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

        public string KegSize
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

        public string ControlRegistrationAlcoholSpearDispenserControlled
        {
            get { return _controlRegistrationAlcoholSpearDispenserControlled; }
            set
            {
                _controlRegistrationAlcoholSpearDispenserControlled = value;
                OnPropertyChanged();
            }
        }

        #region StringHelpers

        public string TimeStringHelper
        {
            get { return _timeStringHelper; }
            set
            {
                _timeStringHelper = value; 
                OnPropertyChanged();
            }
        }

        public string ProductionsDateStringHelper
        {
            get { return _productionsDateStringHelper; }
            set
            {               
                _productionsDateStringHelper = value; 
                OnPropertyChanged();
            }
        }

        public string FirstPalletDepalletizingStringHelper
        {
            get { return _firstPalletDepalletizingStringHelper; }
            set
            {
                _firstPalletDepalletizingStringHelper = value;
                OnPropertyChanged();
            }
        }

        public string LastPalletDepalletizingStringHelper
        {
            get { return _lastPalletDepalletizingStringHelper; }
            set
            {
                _lastPalletDepalletizingStringHelper = value;
                OnPropertyChanged();
            }
        }

       #endregion

        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        public DateTime Production_Date
        {
            get => _productionDate;
            set
            {
                _productionDate = value;
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
        
        public DateTime Expiry_Date
        {
            get => _expiryDate;
            set
            {
                _expiryDate = value;
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
