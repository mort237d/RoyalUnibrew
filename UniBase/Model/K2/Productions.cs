using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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


        //private CalculateTUTotal _calculateTuTotal = new CalculateTUTotal();
        //private TUs _tUs = new TUs();

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

        public int Production_ID
        {
            get => _productionId;
            set
            {
                if (value == _productionId) return;
                _productionId = value;
                OnPropertyChanged();
            }
        }

        public int PalletPutInStock0001
        {
            get => _palletPutInStock0001;
            set
            {
                if (value == _palletPutInStock0001) return;
                _palletPutInStock0001 = value;
                OnPropertyChanged();
                //_calculateTuTotal.CalculatePalletCounter(_tUs.FirstDay_Total, _tUs.SecoundDay_Total,_tUs.ThirdDay_Total, PalletPutInStock0001);
            }
        }

        public int Tapmachine
        {
            get => _tapmachine;
            set
            {
                if (value == _tapmachine) return;
                _tapmachine = value;
                OnPropertyChanged();
            }
        }

        public int TotalKegsPrPallet
        {
            get => _totalKegsPrPallet;
            set
            {
                if (value == _totalKegsPrPallet) return;
                _totalKegsPrPallet = value;
                OnPropertyChanged();
            }
        }

        public int Counter
        {
            get => _counter;
            set
            {
                if (value == _counter) return;
                _counter = value;
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

        public int PalletCounter
        {
            get => _palletCounter;
            set
            {
                if (value == _palletCounter) return;
                _palletCounter = value;
                OnPropertyChanged();
            }
        }

        public string BatchDateStringHelper
        {
            get { return _batchDateStringHelper; }
            set
            {
                _batchDateStringHelper = value; 
                OnPropertyChanged();
            }
        }

        public DateTime BatchDate
        {
            get => _batchDate;
            set
            {
                if (value.Equals(_batchDate)) return;
                _batchDate = value;
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
