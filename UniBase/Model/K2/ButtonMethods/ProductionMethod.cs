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

        private ObservableCollection<Productions> _completeProductionsList;

        private ObservableCollection<Productions> _productionsList;

        private Productions _newProductions = new Productions();

        private Message _message = new Message();

        private XamlBindings _xamlBindings = new XamlBindings();
        private GenericMethod _genericMethod = new GenericMethod();
        private PropertyInfo[] PropertyInfos = typeof(Productions).GetProperties();

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

                Filter(0, _productionIdTextBoxOutput);
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                Filter(1, _processOrderNoTextBoxOutput);
            }
        }

        public string PalletPutInStock0001TextBoxOutput
        {
            get { return _palletPutInStock0001TextBoxOutput; }
            set
            {
                _palletPutInStock0001TextBoxOutput = value;

                Filter(2, _palletPutInStock0001TextBoxOutput);
            }
        }

        public string TapmachineTextBoxOutput
        {
            get { return _tapmachineTextBoxOutput; }
            set
            {
                _tapmachineTextBoxOutput = value;

                Filter(3, _tapmachineTextBoxOutput);
            }
        }

        public string TotalKegsPrPalletTextBoxOutput
        {
            get { return _totalKegsPrPalletTextBoxOutput; }
            set
            {
                _totalKegsPrPalletTextBoxOutput = value;

                Filter(4, _totalKegsPrPalletTextBoxOutput);
            }
        }

        public string CounterTextBoxOutput
        {
            get { return _counterTextBoxOutput; }
            set
            {
                _counterTextBoxOutput = value;

                Filter(5, _counterTextBoxOutput);
            }
        }

        public string PalletCounterTextBoxOutput
        {
            get { return _palletCounterTextBoxOutput; }
            set
            {
                _palletCounterTextBoxOutput = value;

                Filter(6, _palletCounterTextBoxOutput);
            }
        }

        public string BatchDateTextBoxOutput
        {
            get { return _batchDateTextBoxOutput; }
            set
            {
                _batchDateTextBoxOutput = value;

                Filter(7, _batchDateTextBoxOutput);
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

        private void Filter(int propIndex, string textBox)
        {
            _genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, PropertyInfos[propIndex].Name, textBox, Initialize, FillStringHelpers);
        }

        #region ButtonMethods
        public async void Initialize()
        {
            ProductionsList = await ModelGenerics.GetLastTenInDatabase(new Productions());

            FillStringHelpers();

            _completeProductionsList = await ModelGenerics.GetAll(new Productions());

            NewProductions = new Productions
            {
                ProcessOrderNoIntHelper = ProductionsList.Last().ProcessOrder_No.ToString(),
                ProductionIdIntHelper = (ProductionsList.Last().Production_ID + 1).ToString()
            };
        }
        
        public async void RefreshAll()
        {
            ProductionsList = await ModelGenerics.GetAll(new Productions());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public async void RefreshLastTen()
        {
            ProductionsList = await ModelGenerics.GetLastTenInDatabase(new Productions());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }

        public void SaveAll()
        {
            _genericMethod.SaveAll(ProductionsList, "Production_ID", "Produktions");
        }

        public void DeleteItem()
        {
            _genericMethod.DeleteSelected(SelectedProduction, new Productions(), CompleteProductionsList, ProductionsList, "Production_ID", "Produktion");
        }

        public void AddNewItem()
        {
            if (ModelGenerics.CreateByObject(NewProductions))
            {
                Initialize();

                NewProductions = new Productions
                {
                    ProcessOrderNoIntHelper = ProductionsList.Last().ProcessOrder_No.ToString(),
                    ProductionIdIntHelper = (ProductionsList.Last().Production_ID + 1).ToString()
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
            SelectedProductionId = _genericMethod.SelectParentItem((int)obj, ProductionsList, "Production_ID");
        }

        public void SortButtonClick(object id)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (id.ToString() == _xamlBindings.ProductionsHeaderList[i].Header)
                {
                    ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, PropertyInfos[i].Name);
                    break;
                }
            }
        }

        private void FillStringHelpers()
        {
            foreach (var production in ProductionsList)
            {
                production.BatchDateStringHelper = production.BatchDate.ToString("yyyy/MM/dd");
                production.ProcessOrderNoIntHelper = production.ProcessOrder_No.ToString();
                production.CounterIntHelper = production.Counter.ToString();
                production.PalletCounterIntHelper = production.PalletCounter.ToString();
                production.PalletPutInStock0001IntHelper = production.PalletPutInStock0001.ToString();
                production.ProductionIdIntHelper = production.Production_ID.ToString();
                production.TapmachineIntHelper = production.Tapmachine.ToString();
                production.TotalKegsPrPalletIntHelper = production.TotalKegsPrPallet.ToString();
            }
        }

        #region SingleTon
        private static ProductionMethod _instance;
        private static object syncLock = new object();

        public static ProductionMethod Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
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
