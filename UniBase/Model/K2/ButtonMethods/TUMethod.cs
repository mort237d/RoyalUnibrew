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
        #region Fields
        private ObservableCollection<TUs> _completeTUsList = ModelGenerics.GetAll(new TUs());

        private Message _message = new Message();

        private int _selectedTuId;
        private TUs _selectedTu;

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

        #region Filter

        public string TuIdTextBoxOutput
        {
            get { return _tuIdTextBoxOutput; }
            set
            {
                _tuIdTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.TU_ID.ToString().ToLower();
                    if (v.Contains(_tuIdTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_tuIdTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string FirstDayStartTuTextBoxOutput
        {
            get { return _firstDayStartTuTextBoxOutput; }
            set
            {
                _firstDayStartTuTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.FirstDayStart_TU.ToString().ToLower();
                    if (v.Contains(_firstDayStartTuTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_firstDayStartTuTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string FirstDayEndTuTextBoxOutput
        {
            get { return _firstDayEndTuTextBoxOutput; }
            set
            {
                _firstDayEndTuTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.FirstDayEnd_TU.ToString().ToLower();
                    if (v.Contains(_firstDayEndTuTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_firstDayEndTuTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string FirstDayTotalTextBoxOutput
        {
            get { return _firstDayTotalTextBoxOutput; }
            set
            {
                _firstDayTotalTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.FirstDay_Total.ToString().ToLower();
                    if (v.Contains(_firstDayTotalTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_firstDayTotalTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string SecoundDayStartTuTextBoxOutput
        {
            get { return _secoundDayStartTuTextBoxOutput; }
            set
            {
                _secoundDayStartTuTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.SecoundDayStart_TU.ToString().ToLower();
                    if (v.Contains(_secoundDayStartTuTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_secoundDayStartTuTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string SecoundDayEndTuTextBoxOutput
        {
            get { return _secoundDayEndTuTextBoxOutput; }
            set
            {
                _secoundDayEndTuTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.SecoundDayEnd_TU.ToString().ToLower();
                    if (v.Contains(_secoundDayEndTuTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_secoundDayEndTuTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string SecoundDayTotalTextBoxOutput
        {
            get { return _secoundDayTotalTextBoxOutput; }
            set
            {
                _secoundDayTotalTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.SecoundDay_Total.ToString().ToLower();
                    if (v.Contains(_secoundDayTotalTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_secoundDayTotalTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string ThirdDayStartTuTextBoxOutput
        {
            get { return _thirdDayStartTuTextBoxOutput; }
            set
            {
                _thirdDayStartTuTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.ThirdDayStart_TU.ToString().ToLower();
                    if (v.Contains(_thirdDayStartTuTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_thirdDayStartTuTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string ThirdDayEndTuTextBoxOutput
        {
            get { return _thirdDayEndTuTextBoxOutput; }
            set
            {
                _thirdDayEndTuTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.ThirdDayEnd_TU.ToString().ToLower();
                    if (v.Contains(_thirdDayEndTuTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_thirdDayEndTuTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string ThirdDayTotalTextBoxOutput
        {
            get { return _thirdDayTotalTextBoxOutput; }
            set
            {
                _thirdDayTotalTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.ThirdDay_Total.ToString().ToLower();
                    if (v.Contains(_thirdDayTotalTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_thirdDayTotalTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                ManageTables.Instance.TuList.Clear();

                foreach (var f in _completeTUsList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.TuList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ManageTables.Instance.TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
                }
            }
        }

        #endregion
        
        public void RefreshAll()
        private ObservableCollection<TUs> _tuList;

        public ObservableCollection<TUs> TuList
        {
            get { return _tuList; }
            set
            {
                _tuList = value;
                OnPropertyChanged();
            }
        }

        public TUMethod()
        {
            RefreshLastTen();
        }


        public void RefreshAll()
        {
            TuList = ModelGenerics.GetAll(new TUs());
            message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());
            message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
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
            message.ShowToastNotification("Gemt", "TU-tabellen er gemt");
        }

        public void DeleteItem()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewItem()
        {
            var ObjectToAdd = ManageTables.Instance.NewTUs;
            InputValidator.CheckIfInputsAreValid(ref ObjectToAdd);

            //Autofills

            if (ModelGenerics.CreateByObject(ObjectToAdd))
            {
                TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());

                ManageTables.Instance.NewTUs = new TUs();
                
            }
            else
            {
                //error
            }
        }

        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            ControlRegistrations del = ManageTables.Instance.ControlRegistrationsList.First(d => d.ControlRegistration_ID == id);
            int index = ManageTables.Instance.ControlRegistrationsList.IndexOf(del);

           // SelectedControlRegistrationId = index;
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
