using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.TU_ID.ToString().ToLower();
                    if (v.Contains(_tuIdTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_tuIdTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string FirstDayStartTuTextBoxOutput
        {
            get { return _firstDayStartTuTextBoxOutput; }
            set
            {
                _firstDayStartTuTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.FirstDayStart_TU.ToString().ToLower();
                    if (v.Contains(_firstDayStartTuTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_firstDayStartTuTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string FirstDayEndTuTextBoxOutput
        {
            get { return _firstDayEndTuTextBoxOutput; }
            set
            {
                _firstDayEndTuTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.FirstDayEnd_TU.ToString().ToLower();
                    if (v.Contains(_firstDayEndTuTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_firstDayEndTuTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string FirstDayTotalTextBoxOutput
        {
            get { return _firstDayTotalTextBoxOutput; }
            set
            {
                _firstDayTotalTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.FirstDay_Total.ToString().ToLower();
                    if (v.Contains(_firstDayTotalTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_firstDayTotalTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string SecoundDayStartTuTextBoxOutput
        {
            get { return _secoundDayStartTuTextBoxOutput; }
            set
            {
                _secoundDayStartTuTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.SecoundDayStart_TU.ToString().ToLower();
                    if (v.Contains(_secoundDayStartTuTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_secoundDayStartTuTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string SecoundDayEndTuTextBoxOutput
        {
            get { return _secoundDayEndTuTextBoxOutput; }
            set
            {
                _secoundDayEndTuTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.SecoundDayEnd_TU.ToString().ToLower();
                    if (v.Contains(_secoundDayEndTuTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_secoundDayEndTuTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string SecoundDayTotalTextBoxOutput
        {
            get { return _secoundDayTotalTextBoxOutput; }
            set
            {
                _secoundDayTotalTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.SecoundDay_Total.ToString().ToLower();
                    if (v.Contains(_secoundDayTotalTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_secoundDayTotalTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string ThirdDayStartTuTextBoxOutput
        {
            get { return _thirdDayStartTuTextBoxOutput; }
            set
            {
                _thirdDayStartTuTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.ThirdDayStart_TU.ToString().ToLower();
                    if (v.Contains(_thirdDayStartTuTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_thirdDayStartTuTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string ThirdDayEndTuTextBoxOutput
        {
            get { return _thirdDayEndTuTextBoxOutput; }
            set
            {
                _thirdDayEndTuTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.ThirdDayEnd_TU.ToString().ToLower();
                    if (v.Contains(_thirdDayEndTuTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_thirdDayEndTuTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string ThirdDayTotalTextBoxOutput
        {
            get { return _thirdDayTotalTextBoxOutput; }
            set
            {
                _thirdDayTotalTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.ThirdDay_Total.ToString().ToLower();
                    if (v.Contains(_thirdDayTotalTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_thirdDayTotalTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput.ToLower()))
                    {
                        TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
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
        #endregion
        
        #region ButtonMethods
        public void Initialize()
        {
            TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
        }

        public void RefreshAll()
        {
            TuList = ModelGenerics.GetAll(new TUs());
            _message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
            _message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }

        public void SaveAll()
        {
            Parallel.ForEach(TuList, tus =>
            {
                InputValidator.CheckIfInputsAreValid(ref tus);
            });
            Parallel.ForEach(TuList, tus =>
            {
                ModelGenerics.UpdateByObjectAndId((int)tus.TU_ID, tus);
            });
            _message.ShowToastNotification("Gemt", "TU-tabellen er gemt");
        }

        public void DeleteItem()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewItem()
        {
            var ObjectToAdd = NewTUs;
            InputValidator.CheckIfInputsAreValid(ref ObjectToAdd);

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

        public void SortButtonClick(object obj)
        {
            throw new System.NotImplementedException();
        }

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
