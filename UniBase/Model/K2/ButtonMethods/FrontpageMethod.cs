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
        private PropertyInfo[] PropertyInfos = typeof(Frontpages).GetProperties();

        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                Filter(0 + 5);
            }
        }

        public string DateTextBoxOutput
        {
            get { return _dateTextBoxOutput; }
            set
            {
                _dateTextBoxOutput = value;

                Filter(1 + 5);
            }
        }

        public string FinishedProductNoTextBoxOutput
        {
            get { return _finishedProductNoTextBoxOutput; }
            set
            {
                _finishedProductNoTextBoxOutput = value;

                Filter(2 + 5);
            }
        }

        public string ColumnTextBoxOutput
        {
            get { return _columnTextBoxOutput; }
            set
            {
                _columnTextBoxOutput = value;

                Filter(3 + 5);
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                Filter(4 + 5);
            }
        }

        public string WeekNoTextBoxOutput
        {
            get { return _weekNoTextBoxOutput; }
            set
            {
                _weekNoTextBoxOutput = value;

                Filter(5+5);
            }
        }
        #endregion

        private void Filter(int propIndex)
        {
            _genericMethod.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, PropertyInfos[propIndex].Name, _weekNoTextBoxOutput, Initialize, Helpers);
        }

        #region ButtonMethods
        public void Initialize()
        {
            FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            Helpers();
        }

        private void Helpers()
        {
            Parallel.ForEach(FrontpagesList, frontpage =>
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
                frontpage.ColunmIntHelper = frontpage.Colunm.ToString();
                frontpage.FinishedProductNoIntHelper = frontpage.FinishedProduct_No.ToString();
                frontpage.ProcessOrderNoIntHelper = frontpage.ProcessOrder_No.ToString();
                frontpage.WeekNoIntHelper = frontpage.Week_No.ToString();
            });
        }

        public void RefreshAll()
        {
            FrontpagesList = ModelGenerics.GetAll(new Frontpages());
            Parallel.ForEach(FrontpagesList, frontpage =>
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
                frontpage.ColunmIntHelper = frontpage.Colunm.ToString();
                frontpage.FinishedProductNoIntHelper = frontpage.FinishedProduct_No.ToString();
                frontpage.ProcessOrderNoIntHelper = frontpage.ProcessOrder_No.ToString();
                frontpage.WeekNoIntHelper = frontpage.Week_No.ToString();
            });
            _message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void RefreshLastTen()
        {
            FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            foreach (var frontpage in FrontpagesList)
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
                frontpage.ColunmIntHelper = frontpage.Colunm.ToString();
                frontpage.FinishedProductNoIntHelper = frontpage.FinishedProduct_No.ToString();
                frontpage.ProcessOrderNoIntHelper = frontpage.ProcessOrder_No.ToString();
                frontpage.WeekNoIntHelper = frontpage.Week_No.ToString();
            }
            _message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void SaveAll()
        {
            //Parallel.ForEach(FrontpagesList, frontpage =>
            //{
            //    InputValidator.CheckIfInputsAreValid(ref frontpage);
            //});

            Parallel.ForEach(FrontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId((int)frontpage.ProcessOrder_No, frontpage);
            });
            _message.ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        public void DeleteItem()
        {
            var CRM = ControlRegistrationMethod.Instance;
            var CSM = ControlScheduleMethod.Instance;
            var PM = ProductionMethod.Instance;
            var SRM = ShiftRegistrationMethod.Instance;
            var TM = TuMethod.Instance;
            

            //TODO Update all lists!!!
            if (SelectedFrontpage != null)
            {
                foreach (var i in CRM.CompleteControlRegistrationsList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new ControlRegistrations(), i.ControlRegistration_ID);
                        Debug.WriteLine("\t \n ControlRegistration_ID: " + i.ControlRegistration_ID, "DELETE");
                    }
                }
                foreach (var i in CSM.CompleteControlSchedulesList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new ControlSchedules(), i.ControlSchedule_ID);
                        Debug.WriteLine("\t \n ControlSchedule_ID: " + i.ControlSchedule_ID, "DELETE");
                    }
                }
                foreach (var i in PM.CompleteProductionsList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new Productions(), i.Production_ID);
                        Debug.WriteLine("\t \n Production_ID: " + i.Production_ID, "DELETE");
                    }
                }
                foreach (var i in SRM.CompleteShiftRegistrationsList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new ShiftRegistrations(), i.ShiftRegistration_ID);
                        Debug.WriteLine("\t \n ShiftRegistration_ID: " + i.ShiftRegistration_ID, "DELETE");
                    }
                }
                foreach (var i in TM.CompleteTUsList)
                {
                    if (SelectedFrontpage.ProcessOrder_No == i.ProcessOrder_No)
                    {
                        ModelGenerics.DeleteById(new TUs(), i.TU_ID);
                        Debug.WriteLine("\t \n TU_ID: " + i.TU_ID, "DELETE");
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
            //InputValidator.CheckIfInputsAreValid(ref instanceNewFrontpagesToAdd);

            
            if (ModelGenerics.CreateByObject(instanceNewFrontpagesToAdd))
            {
                Initialize();

                NewFrontpagesToAdd = new Frontpages();
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

            Frontpages del = FrontpagesList.First(d => d.ProcessOrder_No == id);
            int index = FrontpagesList.IndexOf(del);

            SelectedFrontpageId = index;
        }

        public void SortButtonClick(object id)
        {
            Debug.WriteLine(id.ToString(), "ID");
            if (id.ToString() == _xamlBindings.FrontPageHeaderList[0].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, PropertyInfos[0 + 5].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[1].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, PropertyInfos[1 + 5].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[2].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, PropertyInfos[2 + 5].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[3].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, PropertyInfos[3 + 5].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[4].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, PropertyInfos[4 + 5].Name);
            else if (id.ToString() == _xamlBindings.FrontPageHeaderList[5].Header)
                FrontpagesList = _genericMethod.Sort<Frontpages>(FrontpagesList, PropertyInfos[5 + 5].Name);
            else
                Debug.WriteLine("Error");
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
