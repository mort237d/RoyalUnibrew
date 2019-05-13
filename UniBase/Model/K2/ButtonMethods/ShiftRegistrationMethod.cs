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
        #region Fields
        private ObservableCollection<ShiftRegistrations> _completeShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());

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

        #region Filters

        public string ShiftRegistrationIdTextBoxOutput
        {
            get { return _shiftRegistrationIdTextBoxOutput; }
            set
            {
                _shiftRegistrationIdTextBoxOutput = value;

                ManageTables.Instance.ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.ShiftRegistration_ID.ToString().ToLower();
                    if (v.Contains(_shiftRegistrationIdTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_shiftRegistrationIdTextBoxOutput))
                {
                    ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string StartTimeTextBoxOutput
        {
            get { return _startTimeTextBoxOutput; }
            set
            {
                _startTimeTextBoxOutput = value;

                ManageTables.Instance.ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.Start_Time.ToString().ToLower();
                    if (v.Contains(_startTimeTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_startTimeTextBoxOutput))
                {
                    ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string EndDateTextBoxOutput
        {
            get { return _endDateTextBoxOutput; }
            set
            {
                _endDateTextBoxOutput = value;

                ManageTables.Instance.ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.End_Date.ToString().ToLower();
                    if (v.Contains(_endDateTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_endDateTextBoxOutput))
                {
                    ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string BreaksTextBoxOutput
        {
            get { return _breaksTextBoxOutput; }
            set
            {
                _breaksTextBoxOutput = value;

                ManageTables.Instance.ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.Breaks.ToString().ToLower();
                    if (v.Contains(_breaksTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_breaksTextBoxOutput))
                {
                    ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string TotalHoursTextBoxOutput
        {
            get { return _totalHoursTextBoxOutput; }
            set
            {
                _totalHoursTextBoxOutput = value;

                ManageTables.Instance.ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.TotalHours.ToString().ToLower();
                    if (v.Contains(_totalHoursTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_totalHoursTextBoxOutput))
                {
                    ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string StaffTextBoxOutput
        {
            get { return _staffTextBoxOutput; }
            set
            {
                _staffTextBoxOutput = value;

                ManageTables.Instance.ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.Staff.ToString().ToLower();
                    if (v.Contains(_staffTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_staffTextBoxOutput))
                {
                    ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string InitialsTextBoxOutput
        {
            get { return _initialsTextBoxOutput; }
            set
            {
                _initialsTextBoxOutput = value;

                ManageTables.Instance.ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.Initials.ToString().ToLower();
                    if (v.Contains(_initialsTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_initialsTextBoxOutput))
                {
                    ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                ManageTables.Instance.ShiftRegistrationsList.Clear();

                foreach (var f in _completeShiftRegistrationsList)
                {
                    var v = f.ProcessOrder_No.ToString().ToLower();
                    if (v.Contains(_processOrderNoTextBoxOutput.ToLower()))
                    {
                        ManageTables.Instance.ShiftRegistrationsList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
                }
            }
        }

        #endregion


        public void RefreshAll()
        {
            ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }

        public void RefreshLastTen()
        {
            ManageTables.Instance.ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }

        public void SaveAll()
        {
            Parallel.ForEach(ManageTables.Instance.ShiftRegistrationsList, shiftRegistrations =>
            {
                ModelGenerics.UpdateByObjectAndId(shiftRegistrations.ShiftRegistration_ID, shiftRegistrations);
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
            var ObjectToAdd = ManageTables.Instance.NewShiftRegistrations;
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

        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            ShiftRegistrations del = ManageTables.Instance.ShiftRegistrationsList.First(d => d.ShiftRegistration_ID == id);
            int index = ManageTables.Instance.ShiftRegistrationsList.IndexOf(del);

            SelectedShiftRegistrationId = index;
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
