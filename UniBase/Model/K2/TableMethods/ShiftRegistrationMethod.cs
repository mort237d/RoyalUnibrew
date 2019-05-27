using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2.TableMethods
{
    public class ShiftRegistrationMethod : IManageButtonMethods
    {
        public ShiftRegistrationMethod()
        {
            Initialize();
        }
        #region Fields
        private ObservableCollection<ShiftRegistrations> _completeShiftRegistrationsList;

        private ObservableCollection<ShiftRegistrations> _shiftRegistrationsList;

        private ShiftRegistrations _newShiftRegistrations = new ShiftRegistrations();

        private Message _message = new Message();

        private XamlBindings _xamlBindings = new XamlBindings();
        private GenericMethod _genericMethod = new GenericMethod();
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

                Filter(0, _shiftRegistrationIdTextBoxOutput);
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

        public string StartTimeTextBoxOutput
        {
            get { return _startTimeTextBoxOutput; }
            set
            {
                _startTimeTextBoxOutput = value;

                Filter(2, _startTimeTextBoxOutput);
            }
        }

        public string EndDateTextBoxOutput
        {
            get { return _endDateTextBoxOutput; }
            set
            {
                _endDateTextBoxOutput = value;

                Filter(3, _endDateTextBoxOutput);
            }
        }

        public string BreaksTextBoxOutput
        {
            get { return _breaksTextBoxOutput; }
            set
            {
                _breaksTextBoxOutput = value;

                Filter(4, _breaksTextBoxOutput);
            }
        }

        public string TotalHoursTextBoxOutput
        {
            get { return _totalHoursTextBoxOutput; }
            set
            {
                _totalHoursTextBoxOutput = value;

                Filter(5, _totalHoursTextBoxOutput);
            }
        }

        public string StaffTextBoxOutput
        {
            get { return _staffTextBoxOutput; }
            set
            {
                _staffTextBoxOutput = value;

                Filter(6, _staffTextBoxOutput);
            }
        }

        public string InitialsTextBoxOutput
        {
            get { return _initialsTextBoxOutput; }
            set
            {
                _initialsTextBoxOutput = value;

                Filter(7, _initialsTextBoxOutput);
            }
        }

        public ObservableCollection<ShiftRegistrations> CompleteShiftRegistrationsList
        {
            get { return _completeShiftRegistrationsList; }
            set { _completeShiftRegistrationsList = value; }
        }

        #endregion

        #region ButtonMethods

        private void Filter(int propIndex, string textBox)
        {
            _genericMethod.Filter(new ShiftRegistrations(), ShiftRegistrationsList, CompleteShiftRegistrationsList, PropertyInfos[propIndex].Name, textBox, Initialize, FillStringHelpers);
        }

        public async void Initialize()
        {
            ShiftRegistrationsList = await ModelGenerics.GetLastTenInDatabase(new ShiftRegistrations());

            FillStringHelpers();

            _completeShiftRegistrationsList = await ModelGenerics.GetAll(new ShiftRegistrations());

            NewShiftRegistrations = new ShiftRegistrations
            {
                ShiftRegistrationIdIntHelper = (ShiftRegistrationsList.Last().ShiftRegistration_ID + 1).ToString(),
                ProcessOrderNoIntHelper = ShiftRegistrationsList.Last().ProcessOrder_No.ToString()
            };
        }

        public async void RefreshAll()
        {
            ShiftRegistrationsList = await ModelGenerics.GetAll(new ShiftRegistrations());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }

        public async void RefreshLastTen()
        {
            ShiftRegistrationsList = await ModelGenerics.GetLastTenInDatabase(new ShiftRegistrations());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }

        public void SaveAll()
        {
            _genericMethod.SaveAll(ShiftRegistrationsList, "ShiftRegistration_ID", "Vagt Registrerings");
        }

        public void DeleteItem()
        {
            _genericMethod.DeleteSelected(SelectedShiftRegistration, new ShiftRegistrations(), CompleteShiftRegistrationsList, ShiftRegistrationsList, "ShiftRegistration_ID", "Vagt Registrering");
        }

        public async void AddNewItem()
        {
            var lastestShiftRegistration = await ModelGenerics.GetLastTenInDatabase(new ShiftRegistrations());
            NewShiftRegistrations.ShiftRegistration_ID = lastestShiftRegistration.Last().ShiftRegistration_ID + 1;
            if (ModelGenerics.CreateByObject(NewShiftRegistrations))
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
            SelectedShiftRegistrationId = _genericMethod.SelectParentItem((int) obj, ShiftRegistrationsList, "ShiftRegistration_ID");
        }

        public void SortButtonClick(object id)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (id.ToString() == _xamlBindings.ShiftRegistrationHeaderList[i].Header)
                {
                    ShiftRegistrationsList = _genericMethod.Sort<ShiftRegistrations>(ShiftRegistrationsList, PropertyInfos[i].Name);
                    break;
                }
            }
        }

        private void FillStringHelpers()
        {
            foreach (var shiftRegistration in ShiftRegistrationsList)
            {
                shiftRegistration.BreaksIntHelper = shiftRegistration.Breaks.ToString();
                shiftRegistration.ProcessOrderNoIntHelper = shiftRegistration.ProcessOrder_No.ToString();
                shiftRegistration.ShiftRegistrationIdIntHelper = shiftRegistration.ShiftRegistration_ID.ToString();
                shiftRegistration.StaffIntHelper = shiftRegistration.Staff.ToString();
                shiftRegistration.TotalHoursIntHelper = shiftRegistration.TotalHours.ToString();
                FillStringHelpersHelper(shiftRegistration);
            }
        }

        private void FillStringHelpersHelper(ShiftRegistrations shiftRegistration)
        {
            string temp, temp2, temp3, temp4;
            if (shiftRegistration.Start_Time.Hour < 10) temp = "0" + shiftRegistration.Start_Time.Hour;
            else temp = shiftRegistration.Start_Time.Hour.ToString();

            if (shiftRegistration.Start_Time.Minute == 0) temp2 = "00";
            else if (shiftRegistration.Start_Time.Minute < 10) temp2 = "0" + shiftRegistration.Start_Time.Minute;
            else temp2 = shiftRegistration.Start_Time.Minute.ToString();

            if (shiftRegistration.End_Date.Hour < 10) temp3 = "0" + shiftRegistration.End_Date.Hour;
            else temp3 = shiftRegistration.End_Date.Hour.ToString();

            if (shiftRegistration.End_Date.Minute == 0) temp4 = "00";
            else if (shiftRegistration.End_Date.Minute < 10) temp4 = "0" + shiftRegistration.End_Date.Minute;
            else temp4 = shiftRegistration.End_Date.Minute.ToString();


            shiftRegistration.StartTimeStringHelper = string.Format("{0}:{1}", temp, temp2);
            shiftRegistration.EndDateStringHelper = string.Format("{0}:{1}", temp3, temp4);
        }


        #region SingleTon
        private static ShiftRegistrationMethod _instance;
        private static object syncLock = new object();

        public static ShiftRegistrationMethod Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ShiftRegistrationMethod();
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
