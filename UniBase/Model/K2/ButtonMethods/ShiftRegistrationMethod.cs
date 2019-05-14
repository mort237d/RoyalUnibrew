using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class ShiftRegistrationMethod : IManageButtonMethods
    {
        public ShiftRegistrationMethod()
        {
            Initialize();
        }
        #region Fields
        private ObservableCollection<ShiftRegistrations> _completeShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());

        private ObservableCollection<ShiftRegistrations> _shiftRegistrationsList;

        private ShiftRegistrations _newShiftRegistrations = new ShiftRegistrations();

        private Message message = new Message();

        private int _selectedShiftRegistrationId;
        private ShiftRegistrations _selectedShiftRegistration;

        private string _shiftRegistrationIdTextBoxOutput;
        private string _startTimeTextBoxOutput;
        private string _endDateTextBoxOutput;
        private string _breaksTextBoxOutput;
        private string _totalHoursTextBoxOutput;
        private string _staffTextBoxOutput;
        private string _initialsTextBoxOutput;
        private string _processOrderNoTextBoxOutput;

        #endregion

        #region Properties
        public int SelectedShiftRegistrationId
        {
            get { return _selectedShiftRegistrationId; }
            set
            {
                _selectedShiftRegistrationId = value;
                OnPropertyChanged();
            }
        }

        public ShiftRegistrations SelectedShiftRegistration
        {
            get { return _selectedShiftRegistration; }
            set
            {
                _selectedShiftRegistration = value;
                OnPropertyChanged();
            }
        }

        public ShiftRegistrations NewShiftRegistrations
        {
            get { return _newShiftRegistrations; }
            set
            {
                _newShiftRegistrations = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ShiftRegistrations> ShiftRegistrationsList
        {
            get { return _shiftRegistrationsList; }
            set
            {
                _shiftRegistrationsList = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Filters

        public string ShiftRegistrationIdTextBoxOutput
        {
            get { return _shiftRegistrationIdTextBoxOutput; }
            set
            {
                _shiftRegistrationIdTextBoxOutput = value;

                ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.ShiftRegistration_ID.ToString().ToLower();
                    if (v.Contains(_shiftRegistrationIdTextBoxOutput.ToLower()))
                    {
                        ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_shiftRegistrationIdTextBoxOutput))
                {
                    ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string StartTimeTextBoxOutput
        {
            get { return _startTimeTextBoxOutput; }
            set
            {
                _startTimeTextBoxOutput = value;

                ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.Start_Time.ToString().ToLower();
                    if (v.Contains(_startTimeTextBoxOutput.ToLower()))
                    {
                        ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_startTimeTextBoxOutput))
                {
                    ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string EndDateTextBoxOutput
        {
            get { return _endDateTextBoxOutput; }
            set
            {
                _endDateTextBoxOutput = value;

                ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.End_Date.ToString().ToLower();
                    if (v.Contains(_endDateTextBoxOutput.ToLower()))
                    {
                        ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_endDateTextBoxOutput))
                {
                    ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string BreaksTextBoxOutput
        {
            get { return _breaksTextBoxOutput; }
            set
            {
                _breaksTextBoxOutput = value;

                ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.Breaks.ToString().ToLower();
                    if (v.Contains(_breaksTextBoxOutput.ToLower()))
                    {
                        ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_breaksTextBoxOutput))
                {
                    ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string TotalHoursTextBoxOutput
        {
            get { return _totalHoursTextBoxOutput; }
            set
            {
                _totalHoursTextBoxOutput = value;

                ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.TotalHours.ToString().ToLower();
                    if (v.Contains(_totalHoursTextBoxOutput.ToLower()))
                    {
                        ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_totalHoursTextBoxOutput))
                {
                    ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string StaffTextBoxOutput
        {
            get { return _staffTextBoxOutput; }
            set
            {
                _staffTextBoxOutput = value;

                ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.Staff.ToString().ToLower();
                    if (v.Contains(_staffTextBoxOutput.ToLower()))
                    {
                        ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_staffTextBoxOutput))
                {
                    ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string InitialsTextBoxOutput
        {
            get { return _initialsTextBoxOutput; }
            set
            {
                _initialsTextBoxOutput = value;

                ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.Initials.ToString().ToLower();
                    if (v.Contains(_initialsTextBoxOutput.ToLower()))
                    {
                        ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_initialsTextBoxOutput))
                {
                    ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput.ToLower()))
                    {
                        ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        #endregion

        #region ButtonMethods
        public void Initialize()
        {
            ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
        }

        public void RefreshAll()
        {
            ShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }

        public void SaveAll()
        {
            Parallel.ForEach(ShiftRegistrationsList, shiftRegistrations =>
            {
                InputValidator.CheckIfInputsAreValid(ref shiftRegistrations);
            });
            Parallel.ForEach(ShiftRegistrationsList, shiftRegistrations =>
            {
                ModelGenerics.UpdateByObjectAndId((int)shiftRegistrations.ShiftRegistration_ID, shiftRegistrations);
            });
            message.ShowToastNotification("Gemt", "Vagt Registrerings-tabellen er gemt");
        }

        public void DeleteItem()
        {
            if (SelectedShiftRegistration != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(SelectedShiftRegistration.ShiftRegistration_ID);
            }
        }

        public void AddNewItem()
        {
            var ObjectToAdd = NewShiftRegistrations;
            InputValidator.CheckIfInputsAreValid(ref ObjectToAdd);

            //Autofills

            if (ModelGenerics.CreateByObject(ObjectToAdd))
            {
                Initialize();

                NewShiftRegistrations = new ShiftRegistrations()
                {
                    
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

            ShiftRegistrations del = ShiftRegistrationsList.First(d => d.ShiftRegistration_ID == id);
            int index = ShiftRegistrationsList.IndexOf(del);

            SelectedShiftRegistrationId = index;
        }

        public void SortButtonClick(object obj)
        {
            throw new System.NotImplementedException();
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
