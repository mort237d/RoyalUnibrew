using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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

        private Message _message = new Message();

        private XamlBindings _xamlBindings = new XamlBindings();
        private GenericMethod _genericMethod = new GenericMethod();
        private PropertyInfo[] _propertyInfos = typeof(Productions).GetProperties();

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

                _genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, _propertyInfos[0].Name, _productionIdTextBoxOutput);
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                _genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, _propertyInfos[1].Name, _processOrderNoTextBoxOutput);
            }
        }

        public string PalletPutInStock0001TextBoxOutput
        {
            get { return _palletPutInStock0001TextBoxOutput; }
            set
            {
                _palletPutInStock0001TextBoxOutput = value;

                _genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, _propertyInfos[2].Name, _palletPutInStock0001TextBoxOutput);
            }
        }

        public string TapmachineTextBoxOutput
        {
            get { return _tapmachineTextBoxOutput; }
            set
            {
                _tapmachineTextBoxOutput = value;

                _genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, _propertyInfos[3].Name, _tapmachineTextBoxOutput);
            }
        }

        public string TotalKegsPrPalletTextBoxOutput
        {
            get { return _totalKegsPrPalletTextBoxOutput; }
            set
            {
                _totalKegsPrPalletTextBoxOutput = value;

                _genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, _propertyInfos[4].Name, _totalKegsPrPalletTextBoxOutput);
            }
        }

        public string CounterTextBoxOutput
        {
            get { return _counterTextBoxOutput; }
            set
            {
                _counterTextBoxOutput = value;

                _genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, _propertyInfos[5].Name, _counterTextBoxOutput);
            }
        }

        public string PalletCounterTextBoxOutput
        {
            get { return _palletCounterTextBoxOutput; }
            set
            {
                _palletCounterTextBoxOutput = value;

                _genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, _propertyInfos[6].Name, _palletCounterTextBoxOutput);
            }
        }

        public string BatchDateTextBoxOutput
        {
            get { return _batchDateTextBoxOutput; }
            set
            {
                _batchDateTextBoxOutput = value;

                _genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, _propertyInfos[7].Name, _batchDateTextBoxOutput);
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

        public ObservableCollection<Productions> CompleteProductionsList
        {
            get { return _completeProductionsList; }
            set { _completeProductionsList = value; }
        }

        #endregion

        #region ButtonMethods
        public void Initialize()
        {
            ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());

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
            _message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());

            Parallel.ForEach(ProductionsList, production =>
            {
                production.BatchDateStringHelper = production.BatchDate.ToString("yyyy/MM/dd");
            });
            _message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
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
                ModelGenerics.UpdateByObjectAndId((int)production.ProductionId, production);
            });
            _message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void DeleteItem()
        {
            if (SelectedProduction != null)
            {
                _genericMethod.DeleteSelected(SelectedProduction, new Productions(), CompleteProductionsList, ProductionsList, "Production_ID");
                _message.ShowToastNotification("Slettet", "Produktion slettet");
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Marker venligst ønskede produktion, for at slette");
            }
        }

        public void AddNewItem()
        {
            var objectToAdd = NewProductions;
            InputValidator.CheckIfInputsAreValid(ref objectToAdd);

            //Autofills

            if (ModelGenerics.CreateByObject(objectToAdd))
            {
                Initialize();

                NewProductions = new Productions
                {
                    ProcessOrderNo = ProductionsList.Last().ProcessOrderNo
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

            Productions del = ProductionsList.First(d => d.ProductionId == id);
            int index = ProductionsList.IndexOf(del);

            SelectedProductionId = index;
        }

        public void SortButtonClick(object id)
        {
            if (id.ToString() == _xamlBindings.ProductionsHeaderList[0].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList,_propertyInfos[0].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[1].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, _propertyInfos[1].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[2].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, _propertyInfos[2].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[3].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, _propertyInfos[3].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[4].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, _propertyInfos[4].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[5].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, _propertyInfos[5].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[6].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, _propertyInfos[6].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[7].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, _propertyInfos[7].Name);
            else
                Debug.WriteLine("Error");
        }

        #region SingleTon
        private static ProductionMethod _instance;
        private static object _syncLock = new object();

        public static ProductionMethod Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ProductionMethod();
                        }
                    }
                }

                return _instance;
            }
        }


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
