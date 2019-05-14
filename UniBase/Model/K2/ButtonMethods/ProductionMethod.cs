using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ProductionMethod : IManageButtonMethods
    {
        public ProductionMethod()
        {
            Initialize();
        }
        #region Fields
        private ObservableCollection<Productions> _completeProductionsList = ModelGenerics.GetAll(new Productions());

        private ObservableCollection<Productions> _productionsList;

        private Productions _newProductions = new Productions();


        private Message message = new Message();

        private int _selectedProductionId;
        private Productions _selectedProduction;

        private string _productionIdTextBoxOutput;
        private string _palletPutInStock0001TextBoxOutput;
        private string _tapmachineTextBoxOutput;
        private string _totalKegsPrPalletTextBoxOutput;
        private string _counterTextBoxOutput;
        private string _palletCounterTextBoxOutput;
        private string _batchDateTextBoxOutput;
        private string _processOrderNoTextBoxOutput;
        #endregion

        #region Properties
        public Productions NewProductions
        {
            get { return _newProductions; }
            set
            {
                _newProductions = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Productions> ProductionsList
        {
            get { return _productionsList; }
            set
            {
                _productionsList = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Filter
        public string ProductionIdTextBoxOutput
        {
            get { return _productionIdTextBoxOutput; }
            set
            {
                _productionIdTextBoxOutput = value;

                ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.Production_ID.ToString().ToLower();
                    if (v.Contains(_productionIdTextBoxOutput.ToLower()))
                    {
                        ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_productionIdTextBoxOutput))
                {
                    ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string PalletPutInStock0001TextBoxOutput
        {
            get { return _palletPutInStock0001TextBoxOutput; }
            set
            {
                _palletPutInStock0001TextBoxOutput = value;

                ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.PalletPutInStock0001.ToString().ToLower();
                    if (v.Contains(_palletPutInStock0001TextBoxOutput.ToLower()))
                    {
                        ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_palletPutInStock0001TextBoxOutput))
                {
                    ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string TapmachineTextBoxOutput
        {
            get { return _tapmachineTextBoxOutput; }
            set
            {
                _tapmachineTextBoxOutput = value;

                ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.Tapmachine.ToString().ToLower();
                    if (v.Contains(_tapmachineTextBoxOutput.ToLower()))
                    {
                        ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_tapmachineTextBoxOutput))
                {
                    ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string TotalKegsPrPalletTextBoxOutput
        {
            get { return _totalKegsPrPalletTextBoxOutput; }
            set
            {
                _totalKegsPrPalletTextBoxOutput = value;

                ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.TotalKegsPrPallet.ToString().ToLower();
                    if (v.Contains(_totalKegsPrPalletTextBoxOutput.ToLower()))
                    {
                        ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_totalKegsPrPalletTextBoxOutput))
                {
                    ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string CounterTextBoxOutput
        {
            get { return _counterTextBoxOutput; }
            set
            {
                _counterTextBoxOutput = value;

                ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.Counter.ToString().ToLower();
                    if (v.Contains(_counterTextBoxOutput.ToLower()))
                    {
                        ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_counterTextBoxOutput))
                {
                    ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string PalletCounterTextBoxOutput
        {
            get { return _palletCounterTextBoxOutput; }
            set
            {
                _palletCounterTextBoxOutput = value;

                ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.PalletCounter.ToString().ToLower();
                    if (v.Contains(_palletCounterTextBoxOutput.ToLower()))
                    {
                        ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_palletCounterTextBoxOutput))
                {
                    ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string BatchDateTextBoxOutput
        {
            get { return _batchDateTextBoxOutput; }
            set
            {
                _batchDateTextBoxOutput = value;

                ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.BatchDate.ToString().ToLower();
                    if (v.Contains(_batchDateTextBoxOutput.ToLower()))
                    {
                        ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_batchDateTextBoxOutput))
                {
                    ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput.ToLower()))
                    {
                        ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public int SelectedProductionId
        {
            get { return _selectedProductionId; }
            set
            {
                _selectedProductionId = value;
                OnPropertyChanged();
            }
        }

        public Productions SelectedProduction
        {
            get { return _selectedProduction; }
            set
            {
                _selectedProduction = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region ButtonMethods
        public void Initialize()
        {
            ProductionsList = ModelGenerics.GetAll(new Productions());

            Parallel.ForEach(ProductionsList, production =>
            {
                production.BatchDateStringHelper = production.BatchDate.ToString("yyyy/MM/dd");
            });
        }
        public void RefreshAll()
        {
            ProductionsList = ModelGenerics.GetAll(new Productions());

            Parallel.ForEach(ProductionsList, production =>
            {
                production.BatchDateStringHelper = production.BatchDate.ToString("yyyy/MM/dd");
            });
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());

            Parallel.ForEach(ProductionsList, production =>
            {
                production.BatchDateStringHelper = production.BatchDate.ToString("yyyy/MM/dd");
            });
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void SaveAll()
        {
            ProductionsList = ModelGenerics.GetAll(new Productions());

            Parallel.ForEach(ProductionsList, production =>
            {
                InputValidator.CheckIfInputsAreValid(ref production);
            });

            Parallel.ForEach(ProductionsList, production =>
            {
                ModelGenerics.UpdateByObjectAndId((int)production.Production_ID, production);
            });
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void DeleteItem()
        {
            if (SelectedProduction != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(SelectedProduction.ProcessOrder_No);
            }
        }

        public void AddNewItem()
        {
            var ObjectToAdd = NewProductions;
            InputValidator.CheckIfInputsAreValid(ref ObjectToAdd);

            //Autofills

            if (ModelGenerics.CreateByObject(ObjectToAdd))
            {
                ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());

                NewProductions = new Productions
                {
                    ProcessOrder_No = ProductionsList.Last().ProcessOrder_No
                };
            }
            else
            {
                //error
            }
        }
        #endregion
        
        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            Productions del = ProductionsList.First(d => d.Production_ID == id);
            int index = ProductionsList.IndexOf(del);

            SelectedProductionId = index;
        }

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
