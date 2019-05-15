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

        private XamlBindings _xamlBindings = new XamlBindings();
        private SortAndFilter _sortAndFilter = new SortAndFilter();
        private PropertyInfo[] PropertyInfos = typeof(ShiftRegistrations).GetProperties();

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

                _sortAndFilter.Filter(new ShiftRegistrations(), ShiftRegistrationsList, _completeShiftRegistrationsList, PropertyInfos[0].Name, _shiftRegistrationIdTextBoxOutput);
            }
        }

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                _sortAndFilter.Filter(new ShiftRegistrations(), ShiftRegistrationsList, _completeShiftRegistrationsList, PropertyInfos[1].Name, _processOrderNoTextBoxOutput);
            }
        }

        public string StartTimeTextBoxOutput
        {
            get { return _startTimeTextBoxOutput; }
            set
            {
                _startTimeTextBoxOutput = value;

                _sortAndFilter.Filter(new ShiftRegistrations(), ShiftRegistrationsList, _completeShiftRegistrationsList, PropertyInfos[2].Name, _startTimeTextBoxOutput);
            }
        }

        public string EndDateTextBoxOutput
        {
            get { return _endDateTextBoxOutput; }
            set
            {
                _endDateTextBoxOutput = value;

                _sortAndFilter.Filter(new ShiftRegistrations(), ShiftRegistrationsList, _completeShiftRegistrationsList, PropertyInfos[3].Name, _endDateTextBoxOutput);
            }
        }

        public string BreaksTextBoxOutput
        {
            get { return _breaksTextBoxOutput; }
            set
            {
                _breaksTextBoxOutput = value;

                _sortAndFilter.Filter(new ShiftRegistrations(), ShiftRegistrationsList, _completeShiftRegistrationsList, PropertyInfos[4].Name, _breaksTextBoxOutput);
            }
        }

        public string TotalHoursTextBoxOutput
        {
            get { return _totalHoursTextBoxOutput; }
            set
            {
                _totalHoursTextBoxOutput = value;

                _sortAndFilter.Filter(new ShiftRegistrations(), ShiftRegistrationsList, _completeShiftRegistrationsList, PropertyInfos[5].Name, _totalHoursTextBoxOutput);
            }
        }

        public string StaffTextBoxOutput
        {
            get { return _staffTextBoxOutput; }
            set
            {
                _staffTextBoxOutput = value;

                _sortAndFilter.Filter(new ShiftRegistrations(), ShiftRegistrationsList, _completeShiftRegistrationsList, PropertyInfos[6].Name, _staffTextBoxOutput);
            }
        }

        public string InitialsTextBoxOutput
        {
            get { return _initialsTextBoxOutput; }
            set
            {
                _initialsTextBoxOutput = value;

                _sortAndFilter.Filter(new ShiftRegistrations(), ShiftRegistrationsList, _completeShiftRegistrationsList, PropertyInfos[7].Name, _initialsTextBoxOutput);
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

        public void SortButtonClick(object id)
        {
            if (id.ToString() == _xamlBindings.ShiftRegistrationHeaderList[0].Header)
                ShiftRegistrationsList = _sortAndFilter.Sort<ShiftRegistrations>(ShiftRegistrationsList, PropertyInfos[0].Name);
            else if (id.ToString() == _xamlBindings.ShiftRegistrationHeaderList[1].Header)
                ShiftRegistrationsList = _sortAndFilter.Sort<ShiftRegistrations>(ShiftRegistrationsList, PropertyInfos[1].Name);
            else if (id.ToString() == _xamlBindings.ShiftRegistrationHeaderList[2].Header)
                ShiftRegistrationsList = _sortAndFilter.Sort<ShiftRegistrations>(ShiftRegistrationsList, PropertyInfos[2].Name);
            else if (id.ToString() == _xamlBindings.ShiftRegistrationHeaderList[3].Header)
                ShiftRegistrationsList = _sortAndFilter.Sort<ShiftRegistrations>(ShiftRegistrationsList, PropertyInfos[3].Name);
            else if (id.ToString() == _xamlBindings.ShiftRegistrationHeaderList[4].Header)
                ShiftRegistrationsList = _sortAndFilter.Sort<ShiftRegistrations>(ShiftRegistrationsList, PropertyInfos[4].Name);
            else if (id.ToString() == _xamlBindings.ShiftRegistrationHeaderList[5].Header)
                ShiftRegistrationsList = _sortAndFilter.Sort<ShiftRegistrations>(ShiftRegistrationsList, PropertyInfos[5].Name);
            else if (id.ToString() == _xamlBindings.ShiftRegistrationHeaderList[6].Header)
                ShiftRegistrationsList = _sortAndFilter.Sort<ShiftRegistrations>(ShiftRegistrationsList, PropertyInfos[6].Name);
            else if (id.ToString() == _xamlBindings.ShiftRegistrationHeaderList[7].Header)
                ShiftRegistrationsList = _sortAndFilter.Sort<ShiftRegistrations>(ShiftRegistrationsList, PropertyInfos[7].Name);
            else
                Debug.WriteLine("Error");
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
