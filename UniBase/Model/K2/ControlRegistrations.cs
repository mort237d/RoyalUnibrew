﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class ControlRegistrations : INotifyPropertyChanged
    {
        #region Fields

        private string _commentsOnChangedDate;
        private bool _controlAlcoholSpearDispenser = false;
        private string _kegSize;
        private string _signature;

        private string _controlRegistrationIdIntHelper;
        private string _capNoIntHelper;
        private string _etiquetteNoIntHelper;
        private string _processOrderNoIntHelper;
        private string _timeStringHelper;
        private string _productionsDateStringHelper;
        private string _firstPalletDepalletizingStringHelper;
        private string _lastPalletDepalletizingStringHelper;
        private string _expiryDateStringHelper;
        private string _controlRegistrationAlcoholSpearDispenserControlled;
        private int _kegSizeIndex;

        #endregion

        #region Constructors

        public ControlRegistrations()
        {
            
        }

        public ControlRegistrations(int controlRegistration_ID, TimeSpan time, DateTime production_Date,
            DateTime expiry_Date, string commentsOnChangedDate, bool controlAlcoholSpearDispenser, int capNo,
            int etiquetteNo, string kegSize, string signature, DateTime firstPalletDepalletizing,
            DateTime lastPalletDepalletizing, int processOrder_No)
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
        }

        #endregion
        
        #region Properties

        public int ControlRegistration_ID { get; set; }

        public int ProcessOrder_No { get; set; }

        public TimeSpan Time { get; set; }

        public DateTime Production_Date { get; set; }

        public DateTime Expiry_Date { get; set; }

        public string CommentsOnChangedDate
        {
            get => _commentsOnChangedDate;
            set
            {
                _commentsOnChangedDate = value;
                OnPropertyChanged();
            }
        }
        
        public bool ControlAlcoholSpearDispenser
        {
            get => _controlAlcoholSpearDispenser;
            set
            {
                _controlAlcoholSpearDispenser = value;

                OnPropertyChanged();

                if (ControlAlcoholSpearDispenser)
                {
                    ControlRegistrationAlcoholSpearDispenserControlled = "Images/Box/CheckedCheckbox.png";
                }
                else
                {
                    ControlRegistrationAlcoholSpearDispenserControlled = "Images/Box/UnCheckedCheckbox.png";
                }
            }
        }

        public int CapNo { get; set; }

        public int EtiquetteNo { get; set; }

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
                _signature = value;
                OnPropertyChanged();
            }
        }
        
        public DateTime FirstPalletDepalletizing { get; set; }

        public DateTime LastPalletDepalletizing { get; set; }

        public string ControlRegistrationAlcoholSpearDispenserControlled
        {
            get => _controlRegistrationAlcoholSpearDispenserControlled;
            set
            {
                _controlRegistrationAlcoholSpearDispenserControlled = value; 
                OnPropertyChanged();
            }
        }

        public int KegSizeIndex
        {
            get => _kegSizeIndex;
            set
            {
                _kegSizeIndex = value;
                if (value == 0)
                {
                    KegSize = "20L";
                }
                else if (value == 1)
                {
                    KegSize = "25L";
                }
                else if (value == 2)
                {
                    KegSize = "30L";
                }
                OnPropertyChanged();
            }
        }

        #region StringHelpers
        [JsonIgnore]
        public string ControlRegistrationIdIntHelper
        {
            get { return _controlRegistrationIdIntHelper; }
            set
            {
                if (_controlRegistrationIdIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
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

        public virtual Frontpages Frontpage { get; set; }
        #endregion
        
        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
