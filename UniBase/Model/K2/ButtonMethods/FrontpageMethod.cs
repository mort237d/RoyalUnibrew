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
        private Message message = new Message();
        private SortAndFilter _sortAndFilter = new SortAndFilter();
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

                _sortAndFilter.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, PropertyInfos[0].Name, _processOrderNoTextBoxOutput);
            }
        }

        public string DateTextBoxOutput
        {
            get { return _dateTextBoxOutput; }
            set
            {
                _dateTextBoxOutput = value;

                _sortAndFilter.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, PropertyInfos[1].Name, _dateTextBoxOutput);
            }
        }

        public string FinishedProductNoTextBoxOutput
        {
            get { return _finishedProductNoTextBoxOutput; }
            set
            {
                _finishedProductNoTextBoxOutput = value;

                _sortAndFilter.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, PropertyInfos[2].Name, _finishedProductNoTextBoxOutput);
            }
        }

        public string ColumnTextBoxOutput
        {
            get { return _columnTextBoxOutput; }
            set
            {
                _columnTextBoxOutput = value;

                _sortAndFilter.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, PropertyInfos[3].Name, _columnTextBoxOutput);
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                _sortAndFilter.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, PropertyInfos[4].Name, _noteTextBoxOutput);
            }
        }

        public string WeekNoTextBoxOutput
        {
            get { return _weekNoTextBoxOutput; }
            set
            {
                _weekNoTextBoxOutput = value;

                _sortAndFilter.Filter(new Frontpages(), FrontpagesList, _completeFrontpagesList, PropertyInfos[5].Name, _weekNoTextBoxOutput);
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
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void RefreshLastTen()
        {
            FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            foreach (var frontpage in FrontpagesList)
            {
                frontpage.DateTimeStringHelper = frontpage.Date.ToString("yyyy/MM/dd");
            }
            message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
        }
        public void SaveAll()
        {
            Parallel.ForEach(FrontpagesList, frontpage =>
            {
                InputValidator.CheckIfInputsAreValid(ref frontpage);
            });

            Parallel.ForEach(FrontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId((int)frontpage.ProcessOrder_No, frontpage);
            });
            message.ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        public void DeleteItem()
        {
            if (SelectedFrontpage != null)
            {
                //TODO Make deletion method
                Debug.WriteLine(SelectedFrontpage.ProcessOrder_No);
            }
        }

        public void AddNewItem()
        {
            var instanceNewFrontpagesToAdd = NewFrontpagesToAdd;
            InputValidator.CheckIfInputsAreValid(ref instanceNewFrontpagesToAdd);

            //Autofills
            instanceNewFrontpagesToAdd.Week_No = FindWeekNumber(instanceNewFrontpagesToAdd.Date);

            
            if (ModelGenerics.CreateByObject(instanceNewFrontpagesToAdd))
            {
                Initialize();

                NewFrontpagesToAdd = new Frontpages();
                NewFrontpagesToAdd.Week_No = FindWeekNumber(NewFrontpagesToAdd.Date);
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

            Frontpages del = FrontpagesList.First(d => d.ProcessOrder_No == id);
            int index = FrontpagesList.IndexOf(del);

            SelectedFrontpageId = index;
        }

        public void SortButtonClick(object id)
        {
            //if (xamlBindings.FrontPageHeaderList[0].Header.Equals(id.ToString()))
            //{

            //}
            if (id.ToString() == _xamlBindings.FrontPageHeaderList[0].Header)
                FrontpagesList = _sortAndFilter.Sort<Frontpages>(FrontpagesList, PropertyInfos[0].Name);
            else if (id.ToString() == "Dato")
                FrontpagesList = _sortAndFilter.Sort<Frontpages>(FrontpagesList, PropertyInfos[1].Name);
            else if (id.ToString() == "Færdigt Produkt Nr")
                FrontpagesList = _sortAndFilter.Sort<Frontpages>(FrontpagesList, PropertyInfos[2].Name);
            else if (id.ToString() == "Kolonne")
                FrontpagesList = _sortAndFilter.Sort<Frontpages>(FrontpagesList, PropertyInfos[3].Name);
            else if (id.ToString() == "Note")
                FrontpagesList = _sortAndFilter.Sort<Frontpages>(FrontpagesList, PropertyInfos[4].Name);
            else if (id.ToString() == "Uge Nr")
                FrontpagesList = _sortAndFilter.Sort<Frontpages>(FrontpagesList, PropertyInfos[5].Name);
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
