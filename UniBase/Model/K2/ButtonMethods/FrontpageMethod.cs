using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2.ButtonMethods
{
    public class FrontpageMethod : IManageButtonMethods
    {
        #region Fields
        private ObservableCollection<Frontpages> _frontpagesList;
        private ObservableCollection<Frontpages> _completeFrontpagesList;

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

            for (int i = 0; i < PropertyInfos.Length; i++)
            {
                Debug.WriteLine(PropertyInfos[i].Name, i.ToString());
            }
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
        private PropertyInfo[] PropertyInfos = typeof(Frontpages).GetProperties();
        //private PropertyInfo[] PropertyTextBoxInfos = typeof(FrontpageMethod).GetProperties();

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                //for (int i = 0; i < PropertyTextBoxInfos.Length; i++)
                //{
                //    Debug.WriteLine(PropertyTextBoxInfos[i].Name, i.ToString());
                //}

                Filter(0, _processOrderNoTextBoxOutput);
                //FinishedProductNoTextBoxOutput = "";
                //OnPropertyChanged();
            }
        }

        public string DateTextBoxOutput
        {
            get { return _dateTextBoxOutput; }
            set
            {
                _dateTextBoxOutput = value;

                Filter(1, _dateTextBoxOutput);
            }
        }

        public string FinishedProductNoTextBoxOutput
        {
            get { return _finishedProductNoTextBoxOutput; }
            set
            {
                _finishedProductNoTextBoxOutput = value;

                Filter(2, _finishedProductNoTextBoxOutput);
                //OnPropertyChanged();
            }
        }

        public string ColumnTextBoxOutput
        {
            get { return _columnTextBoxOutput; }
            set
            {
                _columnTextBoxOutput = value;

                Filter(3, _columnTextBoxOutput);
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                Filter(4, _noteTextBoxOutput);
            }
        }

        public string WeekNoTextBoxOutput
        {
            get { return _weekNoTextBoxOutput; }
            set
            {
                _weekNoTextBoxOutput = value;

                Filter(5, _weekNoTextBoxOutput);
            }
        }
        #endregion

        private void Filter(int propIndex, string textBox)
        {
            _genericMethod.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, PropertyInfos[propIndex].Name, textBox, Initialize, FillStringHelpers);
        }

        #region ButtonMethods
        public async void Initialize()
        {
            FrontpagesList = await ModelGenerics.GetLastTenInDatabase(new Frontpages());
            FillStringHelpers();

            _completeFrontpagesList = await ModelGenerics.GetAll(new Frontpages());

            NewFrontpagesToAdd = new Frontpages();
        }
        
        public async void RefreshAll()
        {
            FrontpagesList = await ModelGenerics.GetAll(new Frontpages());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public async void RefreshLastTen()
        {
            FrontpagesList = await ModelGenerics.GetLastTenInDatabase(new Frontpages());
            FillStringHelpers();
            _message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void SaveAll()
        {
            _genericMethod.SaveAll(FrontpagesList, "ProcessOrder_No", "Forside");
        }

        public async void DeleteItem()
        {
            var ControlRegistrationList = await ModelGenerics.GetAll(new ControlRegistrations());
            var ControlScheduleList = await ModelGenerics.GetAll(new ControlSchedules());
            var ProductionList = await ModelGenerics.GetAll(new Productions());
            var ShiftRegistrationList = await ModelGenerics.GetAll(new ShiftRegistrations());
            var TuList = await ModelGenerics.GetAll(new TUs());
            

            //TODO Update all lists!!!
            if (SelectedFrontpage != null)
            {
                foreach (var i in ControlRegistrationList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new ControlRegistrations(), i.ControlRegistration_ID);
                        Debug.WriteLine("\t \n ControlRegistration_ID: " + i.ControlRegistration_ID, "DELETE");
                    }
                }
                foreach (var i in ControlScheduleList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new ControlSchedules(), i.ControlSchedule_ID);
                        Debug.WriteLine("\t \n ControlSchedule_ID: " + i.ControlSchedule_ID, "DELETE");
                    }
                }
                foreach (var i in ProductionList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new Productions(), i.Production_ID);
                        Debug.WriteLine("\t \n Production_ID: " + i.Production_ID, "DELETE");
                    }
                }
                foreach (var i in ShiftRegistrationList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new ShiftRegistrations(), i.ShiftRegistration_ID);
                        Debug.WriteLine("\t \n ShiftRegistration_ID: " + i.ShiftRegistration_ID, "DELETE");
                    }
                }
                foreach (var i in TuList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new TUs(), i.TU_ID);
                        Debug.WriteLine("\t \n TU_ID: " + i.TU_ID, "DELETE");
                    }
                }
                _genericMethod.DeleteSelected(SelectedFrontpage, new Frontpages(), _completeFrontpagesList, FrontpagesList, "ProcessOrder_No", "Forside");
            }
            else
            {
                _message.ShowToastNotification("Fejl", "Marker venligst ønskede forside, for at slette");
            }
        }

        public async void AddNewItem()
        {
            if (ModelGenerics.CreateByObject(NewFrontpagesToAdd))
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
            SelectedFrontpageId = _genericMethod.SelectParentItem((int)obj, FrontpagesList, "ProcessOrder_No");
        }
        public void SortButtonClick(object id)
        {
            for (int i = 0; i <= 5; i++)
            {
                if (id.ToString() == _xamlBindings.FrontPageHeaderList[i].Header)
                {
                    FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, PropertyInfos[i].Name);
                    break;
                }
            }
        }
        private void FillStringHelpers()
        {
            foreach (var frontpage in FrontpagesList)
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
                frontpage.ColunmIntHelper = frontpage.Colunm.ToString();
                frontpage.FinishedProductNoIntHelper = frontpage.FinishedProduct_No.ToString();
                frontpage.ProcessOrderNoIntHelper = frontpage.ProcessOrder_No.ToString();
                frontpage.WeekNoIntHelper = frontpage.Week_No.ToString();
            }
        }

        #region SingleTon
        private static FrontpageMethod _instance;
        private static object syncLock = new object();

        public static FrontpageMethod Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
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
