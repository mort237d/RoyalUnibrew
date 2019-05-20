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

        private ObservableCollection<TUs> _completeTUsList = ModelGenerics.GetAll(new TUs());
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

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[0].Name, _tuIdTextBoxOutput, Initialize);
            }
        }

        public string FirstDayStartTuTextBoxOutput
        {
            get { return _firstDayStartTuTextBoxOutput; }
            set
            {
                _firstDayStartTuTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[1].Name, _firstDayStartTuTextBoxOutput, Initialize);
            }
        }

        public string FirstDayEndTuTextBoxOutput
        {
            get { return _firstDayEndTuTextBoxOutput; }
            set
            {
                _firstDayEndTuTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[2].Name, _firstDayEndTuTextBoxOutput, Initialize);
            }
        }

        public string FirstDayTotalTextBoxOutput
        {
            get { return _firstDayTotalTextBoxOutput; }
            set
            {
                _firstDayTotalTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[3].Name, _firstDayTotalTextBoxOutput, Initialize);
            }
        }

        public string SecoundDayStartTuTextBoxOutput
        {
            get { return _secoundDayStartTuTextBoxOutput; }
            set
            {
                _secoundDayStartTuTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[4].Name, _secoundDayStartTuTextBoxOutput, Initialize);
            }
        }

        public string SecoundDayEndTuTextBoxOutput
        {
            get { return _secoundDayEndTuTextBoxOutput; }
            set
            {
                _secoundDayEndTuTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[5].Name, _secoundDayEndTuTextBoxOutput, Initialize);
            }
        }

        public string SecoundDayTotalTextBoxOutput
        {
            get { return _secoundDayTotalTextBoxOutput; }
            set
            {
                _secoundDayTotalTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[6].Name, _secoundDayTotalTextBoxOutput, Initialize);
            }
        }

        public string ThirdDayStartTuTextBoxOutput
        {
            get { return _thirdDayStartTuTextBoxOutput; }
            set
            {
                _thirdDayStartTuTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[7].Name, _thirdDayStartTuTextBoxOutput, Initialize);
            }
        }

        public string ThirdDayEndTuTextBoxOutput
        {
            get { return _thirdDayEndTuTextBoxOutput; }
            set
            {
                _thirdDayEndTuTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[8].Name, _thirdDayEndTuTextBoxOutput, Initialize);
            }
        }

        public string ThirdDayTotalTextBoxOutput
        {
            get { return _thirdDayTotalTextBoxOutput; }
            set
            {
                _thirdDayTotalTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[9].Name, _thirdDayTotalTextBoxOutput, Initialize);
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                //_genericMethod.Filter(new TUs(), TuList, CompleteTUsList, PropertyInfos[10].Name, _processOrderNoTextBoxOutput, Initialize);
            }
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
        public void Initialize()
        {
            TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
            Parallel.ForEach(TuList, Tu =>
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
            });
        }

        public void RefreshAll()
        {
            TuList = ModelGenerics.GetAll(new TUs());
            Parallel.ForEach(TuList, Tu =>
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
            });
            _message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
            Parallel.ForEach(TuList, Tu =>
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
            });
            _message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }

        public void SaveAll()
        {
            //Parallel.ForEach(TuList, tus =>
            //{
            //    InputValidator.CheckIfInputsAreValid(ref tus);
            //});
            Parallel.ForEach(TuList, tus =>
            {
                ModelGenerics.UpdateByObjectAndId((int)tus.TU_ID, tus);
            });
            _message.ShowToastNotification("Gemt", "TU-tabellen er gemt");
        }

        public void DeleteItem()
        {
            if (SelectedTu != null)
            {
                _genericMethod.DeleteSelected(SelectedTu, new TUs(), CompleteTUsList, TuList, "TU_ID");
                _message.ShowToastNotification("Slettet", "TU slettet");
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Marker venligst ønskede TU, for at slette");
            }
        }

        public void AddNewItem()
        {
            var ObjectToAdd = NewTUs;
            //InputValidator.CheckIfInputsAreValid(ref ObjectToAdd);

            //Autofills

            if (ModelGenerics.CreateByObject(ObjectToAdd))
            {
                Initialize();

                NewTUs = new TUs();
                
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

            TUs del = TuList.First(d => d.TU_ID == id);
            int index = TuList.IndexOf(del);

            SelectedTuId = index;
        }

        public void SortButtonClick(object id)
        {
            if (id.ToString() == _xamlBindings.TUHeaderList[0].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[0 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[1].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[1 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[2].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[2 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[3].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[3 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[4].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[4 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[5].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[5 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[6].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[6 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[7].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[7 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[8].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[8 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[9].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[9 + 11].Name);
            else if (id.ToString() == _xamlBindings.TUHeaderList[10].Header)
                TuList = _genericMethod.Sort<TUs>(TuList, PropertyInfos[10 + 11].Name);
            else
                Debug.WriteLine("Error");
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
