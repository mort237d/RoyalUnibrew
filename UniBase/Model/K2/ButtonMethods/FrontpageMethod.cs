using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class FrontpageMethod : IManageButtonMethods
    {
        #region Fields
        private ObservableCollection<Frontpages> _frontpagesList;
        private ObservableCollection<Frontpages> _completeFrontpagesList = ModelGenerics.GetAll(new Frontpages());

        private Frontpages _newFrontpagesToAdd = new Frontpages();
        private Message _message = new Message();
        private GenericMethod _genericMethod = new GenericMethod();
        private XamlBindings _xamlBindings = new XamlBindings();
        
        private int _selectedFrontpageId;
        private Frontpages _selectedFrontpage;

        private string _processOrderNoTextBoxOutput;
        private string _dateTextBoxOutput;
        private string _finishedProductNoTextBoxOutput;
        private string _columnTextBoxOutput;
        private string _noteTextBoxOutput;
        private string _weekNoTextBoxOutput;
        #endregion

        public FrontpageMethod()
        {
            Initialize();
        }

        public int SelectedFrontpageId
        {
            get { return _selectedFrontpageId; }
            set
            {
                _selectedFrontpageId = value;
                OnPropertyChanged();
            }
        }

        public Frontpages SelectedFrontpage
        {
            get { return _selectedFrontpage; }
            set
            {
                _selectedFrontpage = value;
                OnPropertyChanged();
            }
        }

        public Frontpages NewFrontpagesToAdd
        {
            get => _newFrontpagesToAdd;
            set
            {
                _newFrontpagesToAdd = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Frontpages> FrontpagesList
        {
            get { return _frontpagesList; }
            set
            {
                _frontpagesList = value;
                OnPropertyChanged();
            }
        }

        #region Filter
        private PropertyInfo[] _propertyInfos = typeof(Frontpages).GetProperties();

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                _genericMethod.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, _propertyInfos[0].Name, _processOrderNoTextBoxOutput);
            }
        }

        public string DateTextBoxOutput
        {
            get { return _dateTextBoxOutput; }
            set
            {
                _dateTextBoxOutput = value;

                _genericMethod.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, _propertyInfos[1].Name, _dateTextBoxOutput);
            }
        }

        public string FinishedProductNoTextBoxOutput
        {
            get { return _finishedProductNoTextBoxOutput; }
            set
            {
                _finishedProductNoTextBoxOutput = value;

                _genericMethod.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, _propertyInfos[2].Name, _finishedProductNoTextBoxOutput);
            }
        }

        public string ColumnTextBoxOutput
        {
            get { return _columnTextBoxOutput; }
            set
            {
                _columnTextBoxOutput = value;

                _genericMethod.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, _propertyInfos[3].Name, _columnTextBoxOutput);
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                _genericMethod.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, _propertyInfos[4].Name, _noteTextBoxOutput);
            }
        }

        public string WeekNoTextBoxOutput
        {
            get { return _weekNoTextBoxOutput; }
            set
            {
                _weekNoTextBoxOutput = value;

                _genericMethod.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, _propertyInfos[5].Name, _weekNoTextBoxOutput);
            }
        }
        #endregion

        #region ButtonMethods
        public void Initialize()
        {
            FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            Parallel.ForEach(FrontpagesList, frontpage =>
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
            });
        }

        public void RefreshAll()
        {
            FrontpagesList = ModelGenerics.GetAll(new Frontpages());
            Parallel.ForEach(FrontpagesList, frontpage =>
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
            });
            _message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void RefreshLastTen()
        {
            FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            foreach (var frontpage in FrontpagesList)
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
            }
            _message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void SaveAll()
        {
            Parallel.ForEach(FrontpagesList, frontpage =>
            {
                InputValidator.CheckIfInputsAreValid(ref frontpage);
            });

            Parallel.ForEach(FrontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId((int)frontpage.ProcessOrderNo, frontpage);
            });
            _message.ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        public void DeleteItem()
        {
            var crm = ControlRegistrationMethod.Instance;
            var csm = ControlScheduleMethod.Instance;
            var pm = ProductionMethod.Instance;
            var srm = ShiftRegistrationMethod.Instance;
            var tm = TuMethod.Instance;
            

            //TODO Update all lists!!!
            if (SelectedFrontpage != null)
            {
                foreach (var i in crm.CompleteControlRegistrationsList)
                {
                    if (SelectedFrontpage.ProcessOrderNo == i.ProcessOrderNo)
                    {
                        ModelGenerics.DeleteById(new ControlRegistrations(), i.ControlRegistrationId);
                        Debug.WriteLine("\t \n ControlRegistration_ID: " + i.ControlRegistrationId, "DELETE");
                    }
                }
                foreach (var i in csm.CompleteControlSchedulesList)
                {
                    if (SelectedFrontpage.ProcessOrderNo == i.ProcessOrderNo)
                    {
                        ModelGenerics.DeleteById(new ControlSchedules(), i.ControlScheduleId);
                        Debug.WriteLine("\t \n ControlSchedule_ID: " + i.ControlScheduleId, "DELETE");
                    }
                }
                foreach (var i in pm.CompleteProductionsList)
                {
                    if (SelectedFrontpage.ProcessOrderNo == i.ProcessOrderNo)
                    {
                        ModelGenerics.DeleteById(new Productions(), i.ProductionId);
                        Debug.WriteLine("\t \n Production_ID: " + i.ProductionId, "DELETE");
                    }
                }
                foreach (var i in srm.CompleteShiftRegistrationsList)
                {
                    if (SelectedFrontpage.ProcessOrderNo == i.ProcessOrderNo)
                    {
                        ModelGenerics.DeleteById(new ShiftRegistrations(), i.ShiftRegistrationId);
                        Debug.WriteLine("\t \n ShiftRegistration_ID: " + i.ShiftRegistrationId, "DELETE");
                    }
                }
                foreach (var i in tm.CompleteTUsList)
                {
                    if (SelectedFrontpage.ProcessOrderNo == i.ProcessOrderNo)
                    {
                        ModelGenerics.DeleteById(new Us(), i.TuId);
                        Debug.WriteLine("\t \n TU_ID: " + i.TuId, "DELETE");
                    }
                }
                _genericMethod.DeleteSelected(SelectedFrontpage, new Frontpages(), _completeFrontpagesList, FrontpagesList, "ProcessOrder_No");

                _message.ShowToastNotification("Slettet","Forside slettet");
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Marker venligst ønskede forside, for at slette");
            }
        }

        public void AddNewItem()
        {
            var instanceNewFrontpagesToAdd = NewFrontpagesToAdd;
            InputValidator.CheckIfInputsAreValid(ref instanceNewFrontpagesToAdd);

            //Autofills
            instanceNewFrontpagesToAdd.WeekNo = FindWeekNumber(instanceNewFrontpagesToAdd.Date);

            
            if (ModelGenerics.CreateByObject(instanceNewFrontpagesToAdd))
            {
                Initialize();

                NewFrontpagesToAdd = new Frontpages();
                NewFrontpagesToAdd.WeekNo = FindWeekNumber(NewFrontpagesToAdd.Date);
            }
            else
            {
                //error
            }
        }

        #endregion

        public int FindWeekNumber(DateTime time)
        {
            // https://stackoverflow.com/questions/11154673/get-the-correct-week-number-of-a-given-date
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public void SelectParentItem(object obj)
        {
            int id = (int)obj;

            Frontpages del = FrontpagesList.First(d => d.ProcessOrderNo == id);
            int index = FrontpagesList.IndexOf(del);

            SelectedFrontpageId = index;
        }

        public void SortButtonClick(object id)
        {
            if (id.ToString() == _xamlBindings.FrontPageHeaderList[0].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, _propertyInfos[0].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[1].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, _propertyInfos[1].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[2].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, _propertyInfos[2].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[3].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, _propertyInfos[3].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[4].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, _propertyInfos[4].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[5].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, _propertyInfos[5].Name);
            else
                Debug.WriteLine("Error");
        }

        #region SingleTon
        private static FrontpageMethod _instance;
        private static object _syncLock = new object();

        public static FrontpageMethod Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FrontpageMethod();
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
