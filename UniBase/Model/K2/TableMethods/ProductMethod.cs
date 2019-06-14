using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2.TableMethods
{
    public class ProductMethod : IManageTableMethods
    {
        #region Fields

        private ObservableCollection<Products> _productList;
        private Products _newProducts = new Products();

        private Message _message = Message.Instance;

        private XamlBindings _xamlBindings = new XamlBindings();
        private GenericMethod _genericMethod = new GenericMethod();
        private PropertyInfo[] PropertyInfos = typeof(Products).GetProperties();

        private int _selectedProductId;
        private Products _selectedProduct;

        private ObservableCollection<Products> _completeProductList;
        private string _finishedProduct_NoTextBoxOutput;
        private string _productNameTextBoxOutput;
        private string _bestBeforeDateLengthTextBoxOutput;
        #endregion

        public ProductMethod()
        {
            Initialize();
        }

        #region Properties

        public int SelectedProductId
        {
            get { return _selectedProductId; }
            set
            {
                _selectedProductId = value;
                OnPropertyChanged();
            }
        }

        public Products SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public Products NewProducts
        {
            get { return _newProducts; }
            set
            {
                _newProducts = value; 
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Products> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<Products> CompleteProductList
        {
            get { return _completeProductList; }
            set { _completeProductList = value; }
        }

        #region Filter

        public string FinishedProductNoTextBoxOutput
        {
            get { return _finishedProduct_NoTextBoxOutput; }
            set
            {
                _finishedProduct_NoTextBoxOutput = value;

                Filter(0, _finishedProduct_NoTextBoxOutput);
            }
        }

        public string ProductNameTextBoxOutput
        {
            get { return _productNameTextBoxOutput; }
            set
            {
                _productNameTextBoxOutput = value;

                Filter(1, _productNameTextBoxOutput);
            }
        }

        public string BestBeforeDateLengthTextBoxOutput
        {
            get { return _bestBeforeDateLengthTextBoxOutput; }
            set
            {
                _bestBeforeDateLengthTextBoxOutput = value;

                Filter(2, _bestBeforeDateLengthTextBoxOutput);
            }
        }

        #endregion
        #endregion

        private void Filter(int propIndex, string textBox)
        {
            _genericMethod.Filter(new Products(), ProductList, CompleteProductList, PropertyInfos[propIndex].Name, textBox, Initialize);
        }

        public async void Initialize()
        {
            ProductList = await ModelGenerics.GetLastTenInDatabase(new Products(), "FinishedProduct_No", "Product");

            _completeProductList = await ModelGenerics.GetAll(new Products());

            NewProducts = new Products();
        }

        #region RelayCommandMethods

        public async void RefreshAll()
        {
            ProductList = await ModelGenerics.GetAll(new Products());
            _message.ShowToastNotification("Opdateret", "Produkt-tabellen er opdateret");
        }

        public async void RefreshLastTen()
        {
            ProductList = await ModelGenerics.GetLastTenInDatabase(new Products(), "FinishedProduct_No", "Product");
            _message.ShowToastNotification("Opdateret", "Produkt-tabellen er opdateret");
        }

        public void SaveAll()
        {
            _genericMethod.SaveAll(ProductList, "FinishedProduct_No", "Product", "Færdigt Produkt Nr.");
        }

        public void DeleteItem()
        {
            _genericMethod.DeleteSelected(SelectedProduct, new Products(), CompleteProductList, ProductList, "FinishedProduct_No", "Product", "Færdigt Produkt Nr.");
        }

        public async void AddNewItem()
        {
            if (ModelGenerics.CreateByObject(NewProducts, "FinishedProduct_No", "Færdigt Produkt Nr."))
            {
                Initialize();
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Forsøg venligst igen og gennemkig eventuelt for tastefejl");
            }
        }

        public void SelectParentItem(object obj)
        {
            SelectedProductId = _genericMethod.SelectParentItem(int.Parse(obj.ToString()), ProductList, "FinishedProduct_No");
        }

        public void SortButtonClick(object id)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (id.ToString() == _xamlBindings.ProductHeaderList[i].Header)
                {
                    ProductList = _genericMethod.Sort<Products>(ProductList, PropertyInfos[i].Name);
                    break;
                }
            }
        }

        #endregion

        #region Singleton

        private static ProductMethod _instance;
        private static object syncLock = new object();

        public static ProductMethod Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ProductMethod();
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
