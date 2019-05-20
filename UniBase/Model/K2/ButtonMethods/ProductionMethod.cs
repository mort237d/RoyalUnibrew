﻿using System.Collections.ObjectModel;
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

                //_genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, PropertyInfos[0].Name, _productionIdTextBoxOutput, Initialize);
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                //_genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, PropertyInfos[1].Name, _processOrderNoTextBoxOutput, Initialize);
            }
        }

        public string PalletPutInStock0001TextBoxOutput
        {
            get { return _palletPutInStock0001TextBoxOutput; }
            set
            {
                _palletPutInStock0001TextBoxOutput = value;

                //_genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, PropertyInfos[2].Name, _palletPutInStock0001TextBoxOutput, Initialize);
            }
        }

        public string TapmachineTextBoxOutput
        {
            get { return _tapmachineTextBoxOutput; }
            set
            {
                _tapmachineTextBoxOutput = value;

                //_genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, PropertyInfos[3].Name, _tapmachineTextBoxOutput, Initialize);
            }
        }

        public string TotalKegsPrPalletTextBoxOutput
        {
            get { return _totalKegsPrPalletTextBoxOutput; }
            set
            {
                _totalKegsPrPalletTextBoxOutput = value;

                //_genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, PropertyInfos[4].Name, _totalKegsPrPalletTextBoxOutput, Initialize);
            }
        }

        public string CounterTextBoxOutput
        {
            get { return _counterTextBoxOutput; }
            set
            {
                _counterTextBoxOutput = value;

                //_genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, PropertyInfos[5].Name, _counterTextBoxOutput, Initialize);
            }
        }

        public string PalletCounterTextBoxOutput
        {
            get { return _palletCounterTextBoxOutput; }
            set
            {
                _palletCounterTextBoxOutput = value;

                //_genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, PropertyInfos[6].Name, _palletCounterTextBoxOutput, Initialize);
            }
        }

        public string BatchDateTextBoxOutput
        {
            get { return _batchDateTextBoxOutput; }
            set
            {
                _batchDateTextBoxOutput = value;

                //_genericMethod.Filter(new Productions(), ProductionsList, CompleteProductionsList, PropertyInfos[7].Name, _batchDateTextBoxOutput, Initialize);
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
                production.ProcessOrderNoIntHelper = production.ProcessOrder_No.ToString();
                production.CounterIntHelper = production.Counter.ToString();
                production.PalletCounterIntHelper = production.PalletCounter.ToString();
                production.PalletPutInStock0001IntHelper = production.PalletPutInStock0001.ToString();
                production.ProductionIdIntHelper = production.Production_ID.ToString();
                production.TapmachineIntHelper = production.Tapmachine.ToString();
                production.TotalKegsPrPalletIntHelper = production.TotalKegsPrPallet.ToString();
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
                ModelGenerics.UpdateByObjectAndId((int)production.Production_ID, production);
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
            var ObjectToAdd = NewProductions;
            InputValidator.CheckIfInputsAreValid(ref ObjectToAdd);

            //Autofills

            if (ModelGenerics.CreateByObject(ObjectToAdd))
            {
                Initialize();

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

        public void SortButtonClick(object id)
        {
            if (id.ToString() == _xamlBindings.ProductionsHeaderList[0].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList,PropertyInfos[0 + 8].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[1].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, PropertyInfos[1 + 8].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[2].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, PropertyInfos[2 + 8].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[3].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, PropertyInfos[3 + 8].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[4].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, PropertyInfos[4 + 8].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[5].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, PropertyInfos[5 + 8].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[6].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, PropertyInfos[6 + 8].Name);
            else if (id.ToString() == _xamlBindings.ProductionsHeaderList[7].Header)
                ProductionsList = _genericMethod.Sort<Productions>(ProductionsList, PropertyInfos[7 + 8].Name);
            else
                Debug.WriteLine("Error");
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
