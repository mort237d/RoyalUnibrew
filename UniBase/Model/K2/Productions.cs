using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UniBase.Annotations;
using UniBase.Model.K2.ButtonMethods;

namespace UniBase.Model.K2
{
    public class Productions : INotifyPropertyChanged
    {
        private int _productionId;
        private int _palletPutInStock0001;
        private int _tapmachine;
        private int _totalKegsPrPallet;
        private int _counter;
        private int _palletCounter;
        private int _processOrderNo;
        private DateTime _batchDate;

        //Helpers
        private string _productionIdIntHelper;
        private string _palletPutInStock0001IntHelper;
        private string _tapmachineIntHelper;
        private string _totalKegsPrPalletIntHelper;
        private string _counterIntHelper;
        private string _palletCounterIntHelper;
        private string _processOrderNoIntHelper;
        private CalculateTUTotal _calculateTuTotal = new CalculateTUTotal();

        private string _batchDateStringHelper;


        public Productions()
        {
            
        }

        public Productions(int production_ID, int palletPutInStock0001, int tapmachine, int totalKegsPrPallet, int counter, int palletCounter, DateTime batchDate, int processOrder_No, Frontpages frontpage)
        {
            Production_ID = production_ID;
            PalletPutInStock0001 = palletPutInStock0001;
            Tapmachine = tapmachine;
            TotalKegsPrPallet = totalKegsPrPallet;
            Counter = counter;
            PalletCounter = palletCounter;
            BatchDate = batchDate;
            ProcessOrder_No = processOrder_No;
            Frontpage = frontpage;
        }


        #region Helpers
        [JsonIgnore]
        public string ProductionIdIntHelper
        {
            get { return _productionIdIntHelper; }
            set
            {
                _productionIdIntHelper = value; 
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
                PalletCounter = CalculateProductions.CalculatePalletCounter();
            }
        }
        [JsonIgnore]
        public string PalletPutInStock0001IntHelper
        {
            get { return _palletPutInStock0001IntHelper; }
            set
            {
                _palletPutInStock0001IntHelper = value; 
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string TapmachineIntHelper
        {
            get { return _tapmachineIntHelper; }
            set
            {
                _tapmachineIntHelper = value; 
                OnPropertyChanged();
                //TotalKegs = _calculateTuTotal.CalculateTotalKegs(TotalKegsPrPallet, PalletCounter);
            }
        }
        [JsonIgnore]
        public string TotalKegsPrPalletIntHelper
        {
            get { return _totalKegsPrPalletIntHelper; }
            set
            {
                _totalKegsPrPalletIntHelper = value;
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string CounterIntHelper
        {
            get { return _counterIntHelper; }
            set
            {
                _counterIntHelper = value; 
                OnPropertyChanged();
            }
        }
        [JsonIgnore]
        public string PalletCounterIntHelper
        {
            get { return _palletCounterIntHelper; }
            set
            {
                _palletCounterIntHelper = value; 
                OnPropertyChanged();
                //TotalKegs = _calculateTuTotal.CalculateTotalKegs(TotalKegsPrPallet, PalletCounter);
            }
        }
        [JsonIgnore]
        public string BatchDateStringHelper
        {
            get { return _batchDateStringHelper; }
            set
            {
                _batchDateStringHelper = value; 
                OnPropertyChanged();
            }
        }
        #endregion
        public int Production_ID
        {
            get => _productionId;
            set
            {
                _productionId = value;
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
        public int PalletPutInStock0001
        {
            get => _palletPutInStock0001;
            set
            {
                _palletPutInStock0001 = value;
            }
        }
        public int Tapmachine
        {
            get => _tapmachine;
            set
            {
                _tapmachine = value;
            }
        }
        public int TotalKegsPrPallet
        {
            get => _totalKegsPrPallet;
            set
            {
                _totalKegsPrPallet = value;
            }
        }
        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
            }
        }
        public int PalletCounter
        {
            get => _palletCounter;
            set
            {
                _palletCounter = value;
            }
        }
        public DateTime BatchDate
        {
            get => _batchDate;
            set
            {
                _batchDate = value;
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
