using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class Productions : INotifyPropertyChanged
    {
        private string _productionIdIntHelper;
        private string _palletPutInStock0001IntHelper;
        private string _tapmachineIntHelper;
        private string _totalKegsPrPalletIntHelper;
        private string _counterIntHelper;
        private string _palletCounterIntHelper;
        private string _processOrderNoIntHelper;

        private string _batchDateStringHelper;


        public Productions()
        {
            
        }

        public Productions(int production_ID, int palletPutInStock0001, int tapmachine, int totalKegsPrPallet, int counter, int palletCounter, DateTime batchDate, int processOrder_No)
        {
            Production_ID = production_ID;
            PalletPutInStock0001 = palletPutInStock0001;
            Tapmachine = tapmachine;
            TotalKegsPrPallet = totalKegsPrPallet;
            Counter = counter;
            PalletCounter = palletCounter;
            BatchDate = batchDate;
            ProcessOrder_No = processOrder_No;
        }

        public int Production_ID { get; set; }

        public int ProcessOrder_No { get; set; }

        public int PalletPutInStock0001 { get; set; }

        public int Tapmachine { get; set; }

        public int TotalKegsPrPallet { get; set; }

        public int Counter { get; set; }

        public int PalletCounter { get; set; }

        public DateTime BatchDate { get; set; }


        #region Helpers
        [JsonIgnore]
        public string ProductionIdIntHelper
        {
            get { return _productionIdIntHelper; }
            set
            {
                if (_productionIdIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        Production_ID = i;
                    }
                }
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
                if (_processOrderNoIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        ProcessOrder_No = i;
                    }
                }
                _processOrderNoIntHelper = value;
                OnPropertyChanged();
                //PalletCounter = CalculateProductions.CalculatePalletCounter();
            }
        }
        [JsonIgnore]
        public string PalletPutInStock0001IntHelper
        {
            get { return _palletPutInStock0001IntHelper; }
            set
            {
                if (_palletPutInStock0001IntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        PalletPutInStock0001 = i;
                    }
                }
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
                if (_tapmachineIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        Tapmachine = i;
                    }
                }
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
                if (_totalKegsPrPalletIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        TotalKegsPrPallet = i;
                    }
                }
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
                if (_counterIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        Counter = i;
                    }
                }
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
                if (_palletCounterIntHelper != value)
                {
                    if (int.TryParse(value, out int i))
                    {
                        PalletCounter = i;
                    }
                }
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
                if (_batchDateStringHelper != value)
                {
                    if (DateTime.TryParse(value, out DateTime time))
                    {
                        BatchDate = time;
                    }
                }
                _batchDateStringHelper = value;
                OnPropertyChanged();
            }
        }
        #endregion

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
