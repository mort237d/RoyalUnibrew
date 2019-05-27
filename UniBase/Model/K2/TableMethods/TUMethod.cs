using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2.TableMethods
{
    public class TuMethod : IManageButtonMethods
    {
        public TuMethod()
        {
            Initialize();
        }
        #region Fields

        private ObservableCollection<TUs> _tuList;
        private TUs _newTUs = new TUs();
        
        private Message _message = new Message();

        private XamlBindings _xamlBindings = new XamlBindings();
        private GenericMethod _genericMethod = new GenericMethod();
        private PropertyInfo[] PropertyInfos = typeof(TUs).GetProperties();

        private int _selectedTuId;
        private TUs _selectedTu;

        private ObservableCollection<TUs> _completeTUsList;
        private string _tuIdTextBoxOutput;
        private string _firstDayStartTuTextBoxOutput;
        private string _firstDayEndTuTextBoxOutput;
        private string _firstDayTotalTextBoxOutput;
        private string _secoundDayStartTuTextBoxOutput;
        private string _secoundDayEndTuTextBoxOutput;
        private string _secoundDayTotalTextBoxOutput;
        private string _thirdDayStartTuTextBoxOutput;
        private string _thirdDayEndTuTextBoxOutput;
        private string _thirdDayTotalTextBoxOutput;
        private string _processOrderNoTextBoxOutput;
        #endregion
        
        #region Filter

        public string TuIdTextBoxOutput
        {
            get { return _tuIdTextBoxOutput; }
            set
            {
                _tuIdTextBoxOutput = value;

                Filter(0, _tuIdTextBoxOutput);
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

        public string FirstDayStartTuTextBoxOutput
        {
            get { return _firstDayStartTuTextBoxOutput; }
            set
            {
                _firstDayStartTuTextBoxOutput = value;

                Filter(2, _firstDayStartTuTextBoxOutput);
            }
        }

        public string FirstDayEndTuTextBoxOutput
        {
            get { return _firstDayEndTuTextBoxOutput; }
            set
            {
                _firstDayEndTuTextBoxOutput = value;

                Filter(3, _firstDayEndTuTextBoxOutput);
            }
        }

        public string FirstDayTotalTextBoxOutput
        {
            get { return _firstDayTotalTextBoxOutput; }
            set
            {
                _firstDayTotalTextBoxOutput = value;

                Filter(4, _firstDayTotalTextBoxOutput);
            }
        }

        public string SecoundDayStartTuTextBoxOutput
        {
            get { return _secoundDayStartTuTextBoxOutput; }
            set
            {
                _secoundDayStartTuTextBoxOutput = value;

                Filter(5, _secoundDayStartTuTextBoxOutput);
            }
        }

        public string SecoundDayEndTuTextBoxOutput
        {
            get { return _secoundDayEndTuTextBoxOutput; }
            set
            {
                _secoundDayEndTuTextBoxOutput = value;

                Filter(6, _secoundDayEndTuTextBoxOutput);
            }
        }

        public string SecoundDayTotalTextBoxOutput
        {
            get { return _secoundDayTotalTextBoxOutput; }
            set
            {
                _secoundDayTotalTextBoxOutput = value;

                Filter(7, _secoundDayTotalTextBoxOutput);
            }
        }

        public string ThirdDayStartTuTextBoxOutput
        {
            get { return _thirdDayStartTuTextBoxOutput; }
            set
            {
                _thirdDayStartTuTextBoxOutput = value;

                Filter(8, _thirdDayStartTuTextBoxOutput);
            }
        }

        public string ThirdDayEndTuTextBoxOutput
        {
            get { return _thirdDayEndTuTextBoxOutput; }
            set
            {
                _thirdDayEndTuTextBoxOutput = value;

                Filter(9, _thirdDayEndTuTextBoxOutput);
            }
        }

        public string ThirdDayTotalTextBoxOutput
        {
            get { return _thirdDayTotalTextBoxOutput; }
            set
            {
                _thirdDayTotalTextBoxOutput = value;

                Filter(10, _thirdDayTotalTextBoxOutput);
            }
        }

        private void Filter(int propIndex, string textBox)
        {
            _genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[propIndex].Name, textBox, Initialize, FillStringHelpers);
        }
        #endregion

        #region Properties
        public int SelectedTuId
        {
            get { return _selectedTuId; }
            set
            {
                _selectedTuId = value;
                OnPropertyChanged();
            }
        }

        public TUs SelectedTu
        {
            get { return _selectedTu; }
            set
            {
                _selectedTu = value;
                OnPropertyChanged();
            }
        }

        public TUs NewTUs
        {
            get { return _newTUs; }
            set
            {
                _newTUs = value;
            }
        }
        
        public ObservableCollection<TUs> TuList
        {
            get { return _tuList; }
            set
            {
                _tuList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TUs> CompleteTUsList
        {
            get { return _completeTUsList; }
            set { _completeTUsList = value; }
        }

        #endregion
        
        #region ButtonMethods
        public async void Initialize()
        {
            TuList = await ModelGenerics.GetLastTenInDatabase(new TUs(), "TU_ID", "TU");

            FillStringHelpers();

            _completeTUsList = await ModelGenerics.GetAll(new TUs());

            NewTUs = new TUs
            {
                TuIdIntHelper = (TuList.Last().TU_ID + 1).ToString(),
                ProcessOrderNoIntHelper = TuList.Last().ProcessOrder_No.ToString()
            };
        }

        /// <summary>
        /// Uses the GetAll method from the ModelGenerics class to update the entire table.
        /// </summary>
        public async void RefreshAll()
        {
            TuList = await ModelGenerics.GetAll(new TUs());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }
        
        /// <summary>
        /// Uses the GetLastTenInDatabase method from the ModelGenerics class to update the last ten in the table.
        /// </summary>
        public async void RefreshLastTen()
        {
            TuList = await ModelGenerics.GetLastTenInDatabase(new TUs(), "TU_ID", "TU");
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }

        /// <summary>
        /// Uses the SaveAll method from the GenericMethod class to save the table.
        /// </summary>
        public void SaveAll()
        {
            _genericMethod.SaveAll(TuList, "TU_ID", "TU", "TU ID");
        }

        public void DeleteItem()
        {
            _genericMethod.DeleteSelected(SelectedTu, new TUs(), CompleteTUsList, TuList, "TU_ID", "TU", "TU ID");
        }

        public async void AddNewItem()
        {
            var latestTU = await ModelGenerics.GetLastTenInDatabase(new TUs(), "TU_ID", "TU");
            NewTUs.TU_ID = latestTU.Last().TU_ID + 1;
            if (ModelGenerics.CreateByObject(NewTUs, "TU_ID", "TU ID"))
            {
                Initialize();
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Forsøg venligst igen og gennemkig eventuelt for tastefejl");
            }
        }
        #endregion

        public void SelectParentItem(object obj)
        {
            SelectedTuId = _genericMethod.SelectParentItem((int)obj, TuList, "TU_ID");
        }

        public void SortButtonClick(object id)
        {
            for (int i = 0; i <= 10; i++)
            {
                if (id.ToString() == _xamlBindings.TUHeaderList[i].Header)
                {
                    TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[i].Name);
                    break;
                }
            }
        }
        /// <summary>
        /// Puts the stringhelpers, which are bound to the view, with their respective values.
        /// </summary>
        private void FillStringHelpers()
        {
            foreach (var Tu in TuList)
            {
                Tu.ProcessOrderNoIntHelper = Tu.ProcessOrder_No.ToString();
                Tu.FirstDayEndTuIntHelper = Tu.FirstDayEnd_TU.ToString();
                Tu.FirstDayStartTuIntHelper = Tu.FirstDayStart_TU.ToString();
                Tu.FirstDayTotalIntHelper = Tu.FirstDay_Total.ToString();
                Tu.SecoundDayEndTuIntHelper = Tu.SecoundDayEnd_TU.ToString();
                Tu.SecoundDayStartTuIntHelper = Tu.SecoundDayStart_TU.ToString();
                Tu.SecoundDayTotalIntHelper = Tu.SecoundDay_Total.ToString();
                Tu.ThirdDayEndTuIntHelper = Tu.ThirdDayEnd_TU.ToString();
                Tu.ThirdDayStartTuIntHelper = Tu.ThirdDayEnd_TU.ToString();
                Tu.ThirdDayTotalIntHelper = Tu.ThirdDay_Total.ToString();
                Tu.TuIdIntHelper = Tu.TU_ID.ToString();
            }
        }

        #region SingleTon
        private static TuMethod _instance;
        private static object syncLock = new object();

        public static TuMethod Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new TuMethod();
                        }
                    }
                }

                return _instance;
            }
        }


        #endregion

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
