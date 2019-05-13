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
        #region Fields
        private ObservableCollection<Productions> _completeProductionsList = ModelGenerics.GetAll(new Productions());

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

        #region Filter
        public string ProductionIdTextBoxOutput
        {
            get { return _productionIdTextBoxOutput; }
            set
            {
                _productionIdTextBoxOutput = value;

                ManageTables.Instance.ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.Production_ID.ToString().ToLower();
                    if (v.Contains(_productionIdTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_productionIdTextBoxOutput))
                {
                    ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string PalletPutInStock0001TextBoxOutput
        {
            get { return _palletPutInStock0001TextBoxOutput; }
            set
            {
                _palletPutInStock0001TextBoxOutput = value;

                ManageTables.Instance.ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.PalletPutInStock0001.ToString().ToLower();
                    if (v.Contains(_palletPutInStock0001TextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_palletPutInStock0001TextBoxOutput))
                {
                    ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string TapmachineTextBoxOutput
        {
            get { return _tapmachineTextBoxOutput; }
            set
            {
                _tapmachineTextBoxOutput = value;

                ManageTables.Instance.ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.Tapmachine.ToString().ToLower();
                    if (v.Contains(_tapmachineTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_tapmachineTextBoxOutput))
                {
                    ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string TotalKegsPrPalletTextBoxOutput
        {
            get { return _totalKegsPrPalletTextBoxOutput; }
            set
            {
                _totalKegsPrPalletTextBoxOutput = value;

                ManageTables.Instance.ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.TotalKegsPrPallet.ToString().ToLower();
                    if (v.Contains(_totalKegsPrPalletTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_totalKegsPrPalletTextBoxOutput))
                {
                    ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string CounterTextBoxOutput
        {
            get { return _counterTextBoxOutput; }
            set
            {
                _counterTextBoxOutput = value;

                ManageTables.Instance.ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.Counter.ToString().ToLower();
                    if (v.Contains(_counterTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_counterTextBoxOutput))
                {
                    ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string PalletCounterTextBoxOutput
        {
            get { return _palletCounterTextBoxOutput; }
            set
            {
                _palletCounterTextBoxOutput = value;

                ManageTables.Instance.ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.PalletCounter.ToString().ToLower();
                    if (v.Contains(_palletCounterTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_palletCounterTextBoxOutput))
                {
                    ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string BatchDateTextBoxOutput
        {
            get { return _batchDateTextBoxOutput; }
            set
            {
                _batchDateTextBoxOutput = value;

                ManageTables.Instance.ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.BatchDate.ToString().ToLower();
                    if (v.Contains(_batchDateTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_batchDateTextBoxOutput))
                {
                    ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                ManageTables.Instance.ProductionsList.Clear();

                foreach (var f in _completeProductionsList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ProductionsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
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

        public void RefreshAll()
        {
            ManageTables.Instance.ProductionsList = ModelGenerics.GetAll(new Productions());

            Parallel.ForEach(ManageTables.Instance.ProductionsList, production =>
            {
                production.BatchDateStringHelper = production.BatchDate.ToString("yyyy/MM/dd");
            });
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());

            Parallel.ForEach(ManageTables.Instance.ProductionsList, production =>
            {
                production.BatchDateStringHelper = production.BatchDate.ToString("yyyy/MM/dd");
            });
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void SaveAll()
        {
            ManageTables.Instance.ProductionsList = ModelGenerics.GetAll(new Productions());

            Parallel.ForEach(ManageTables.Instance.ProductionsList, production =>
            {
                InputValidator.CheckIfInputsAreValid(ref production);
            });

            Parallel.ForEach(ManageTables.Instance.ProductionsList, production =>
                {
                    ModelGenerics.UpdateByObjectAndId(production.Production_ID, production);
                });
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void DeleteItem()
        {
            //if (SelectedFrontpage != null)
            //{
            //    //TODO Make deletion method
            //    Debug.WriteLine(SelectedFrontpage.ProcessOrder_No);
            //}
        }

        public void AddNewItem()
        {
            var ObjectToAdd = ManageTables.Instance.NewProductions;
            InputValidator.CheckIfInputsAreValid(ref ObjectToAdd);

            //Autofills

            if (ModelGenerics.CreateByObject(ObjectToAdd))
            {
                ManageTables.Instance.ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());

                ManageTables.Instance.NewProductions = new Productions
                {
                    ProcessOrder_No = ManageTables.Instance.ProductionsList.Last().ProcessOrder_No
                };
            }
            else
            {
                //error
            }
        }

        public void DeleteProduction()
        {
            if (SelectedProduction != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(SelectedProduction.Production_ID);
            }
        }

        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            Productions del = ManageTables.Instance.ProductionsList.First(d => d.Production_ID == id);
            int index = ManageTables.Instance.ProductionsList.IndexOf(del);

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
