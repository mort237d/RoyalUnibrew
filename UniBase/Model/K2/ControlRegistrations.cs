using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Newtonsoft.Json;
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
        private TimeSpan _time;
        private DateTime _productionDate;
        private DateTime _firstPalletDepalletizing;
        private DateTime _lastPalletDepalletizing;
        private DateTime _expiryDate;

        private string _controlRegistrationIdIntHelper;
        private string _capNoIntHelper;
        private string _etiquetteNoIntHelper;
        private string _processOrderNoIntHelper;
        private string _controlRegistrationAlcoholSpearDispenserControlled;
        private string _timeStringHelper;
        private string _productionsDateStringHelper;
        private string _firstPalletDepalletizingStringHelper;
        private string _lastPalletDepalletizingStringHelper;
        private string _expiryDateStringHelper;
        private ComboBoxItem _kegSizeItem = new ComboBoxItem();

        private SolidColorBrush _controlRegistrationIdColor = new SolidColorBrush(Colors.White);
        private SolidColorBrush _commentsOnChangedDatecolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _controlAlcoholSpearDispensercolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _capNocolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _etiquetteNocolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _kegSizecolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _signaturecolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _processOrderNocolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _timecolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _productionDatecolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _firstPalletDepalletizingcolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _lastPalletDepalletizingcolor = new SolidColorBrush(Colors.LightSalmon);
        private SolidColorBrush _expiryDatecolor = new SolidColorBrush(Colors.LightSalmon);

        public ControlRegistrations()
        {
            
        }

        public ControlRegistrations(int controlRegistration_ID, TimeSpan time, DateTime production_Date,
            DateTime expiry_Date, string commentsOnChangedDate, bool controlAlcoholSpearDispenser, int capNo,
            int etiquetteNo, string kegSize, string signature, DateTime firstPalletDepalletizing,
            DateTime lastPalletDepalletizing, int processOrder_No, Frontpages frontpage)
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

        #region StringHelpers
        [JsonIgnore]
        public  string ControlRegistrationIdIntHelper
        {
            get { return _controlRegistrationIdIntHelper; }
            set
            {
                if (_controlRegistrationIdIntHelper != value)
                {
                    if(int.TryParse(value, out int i))
                    {
                        ControlRegistration_ID = i;
                    }
                }
                _controlRegistrationIdIntHelper = value;
                
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
        public string TimeStringHelper
        {
            get { return _timeStringHelper; }
            set
            {
                if (_timeStringHelper != value)
                {
                    if (TimeSpan.TryParse(value, out TimeSpan t))
                    {
                        Time = t;
                    }
                }
                _timeStringHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string ProductionsDateStringHelper
        {
            get { return _productionsDateStringHelper; }
            set
            {
                if (_productionsDateStringHelper != value)
                {
                    if (DateTime.TryParse(value, out DateTime t))
                    {
                        Production_Date = t;

                        int frontpage = ModelGenerics.GetById(new Frontpages(), ProcessOrder_No).FinishedProduct_No;
                        int experationDateLength = ModelGenerics.GetById(new Products(), frontpage ).BestBeforeDateLength;
                        Expiry_Date = t.AddDays(experationDateLength);
                        ExpiryDateStringHelper = Expiry_Date.ToString("yyyy/MM/dd");
                    }
                }
                _productionsDateStringHelper = value;
                
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string ExpiryDateStringHelper
        {
            get { return _expiryDateStringHelper; }
            set
            {
                if (_expiryDateStringHelper != value)
                {
                    if (DateTime.TryParse(value, out DateTime t))
                    {
                        Expiry_Date = t;
                    }
                }
                _expiryDateStringHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string CapNoIntHelper
        {
            get { return _capNoIntHelper; }
            set
            {
                if (_capNoIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        CapNo = i;
                    }
                }
                _capNoIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string EtiquetteNoIntHelper
        {
            get { return _etiquetteNoIntHelper; }
            set
            {
                if (_etiquetteNoIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        EtiquetteNo = i;
                    }
                }
                _etiquetteNoIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string FirstPalletDepalletizingStringHelper
        {
            get { return _firstPalletDepalletizingStringHelper; }
            set
            {
                if (_firstPalletDepalletizingStringHelper != value)
                {
                    if (DateTime.TryParse(value, out DateTime t))
                    {
                        FirstPalletDepalletizing = t;
                    }
                }
                _firstPalletDepalletizingStringHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string LastPalletDepalletizingStringHelper
        {
            get { return _lastPalletDepalletizingStringHelper; }
            set
            {
                if (_lastPalletDepalletizingStringHelper != value)
                {
                    if (DateTime.TryParse(value, out DateTime t))
                    {
                        LastPalletDepalletizing = t;
                    }
                }
                _lastPalletDepalletizingStringHelper = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public int ControlRegistration_ID
        {
            get => _controlRegistrationId;
            set
            {
                _controlRegistrationId = value;
            }
        }
        public int ProcessOrder_No
        {
            get => _processOrderNo;
            set
            {
                if (value == _processOrderNo) return;
                _processOrderNo = value;
            }
        }
        public TimeSpan Time
        {
            get => _time;
            set
            {
                _time = value;
            }
        }
        public DateTime Production_Date
        {
            get => _productionDate;
            set
            {
                _productionDate = value;
            }
        }

        public DateTime Expiry_Date
        {
            get => _expiryDate;
            set
            {
                _expiryDate = value;
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
                _capNo = value;
            }
        }

        public int EtiquetteNo
        {
            get => _etiquetteNo;
            set
            {
                if (value == _etiquetteNo) return;
                _etiquetteNo = value;
            }
        }

        public string KegSize
        {
            get => _kegSize;
            set
            {
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
            }
        }

        public DateTime LastPalletDepalletizing
        {
            get => _lastPalletDepalletizing;
            set
            {
                if (value.Equals(_lastPalletDepalletizing)) return;
                _lastPalletDepalletizing = value;
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
