using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class ManageTables :INotifyPropertyChanged
    {
        #region Field
        private ObservableCollection<Frontpages> _completeFrontpagesList;
        private ObservableCollection<ControlRegistrations> _completeControlRegistrationsList;
        private ObservableCollection<ControlSchedules> _completeControlSchedulesList;
        private ObservableCollection<Productions> _completeProductionsList;
        private ObservableCollection<Products> _completeProductsList;
        private ObservableCollection<ShiftRegistrations> _completeShiftRegistrationsList;
        private ObservableCollection<TUs> _completeTuList;

        private ObservableCollection<Frontpages> _frontpagesList;
        private ObservableCollection<ControlRegistrations> _controlRegistrationsList;
        private ObservableCollection<ControlSchedules> _controlSchedulesList;
        private ObservableCollection<Productions> _productionsList;
        private ObservableCollection<Products> _productsList;
        private ObservableCollection<ShiftRegistrations> _shiftRegistrationsList;
        private ObservableCollection<TUs> _tuList;

        private Frontpages _newFrontpagesToAdd = new Frontpages();


        private Message message = new Message();

        private string _processOrderNoTextBoxOutput;
        private string _dateTextBoxOutput;
        private string _finishedProductNoTextBoxOutput;
        private string _columnTextBoxOutput;
        private string _noteTextBoxOutput;
        private string _weekNoTextBoxOutput;

        #endregion

        #region Properties

        public Frontpages NewFrontpagesToAdd
        {
            get => _newFrontpagesToAdd;
            set
            {
                _newFrontpagesToAdd = value; 
                OnPropertyChanged();
            }
        }

        List<int> temp = new List<int>();
        public string ProcessOrderNoTextBoxOutput
        {
            get { return _processOrderNoTextBoxOutput; }
            set
            {
                _processOrderNoTextBoxOutput = value;

                FrontpagesList.Clear();

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.ProcessOrder_No.ToString();
                    if (v.Contains(_processOrderNoTextBoxOutput))
                    {
                        FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                {
                    FrontpagesList = GetLastTen(new Frontpages());
                }

                #region Test

                //if (string.IsNullOrEmpty(DateTextBoxOutput) && string.IsNullOrEmpty(FinishedProductNoTextBoxOutput) && string.IsNullOrEmpty(ColumnTextBoxOutput) && string.IsNullOrEmpty(NoteTextBoxOutput) && string.IsNullOrEmpty(WeekNoTextBoxOutput))
                //{
                //    FrontpagesList.Clear();

                //    foreach (var f in CompleteFrontpagesList)
                //    {
                //        var v = f.ProcessOrder_No.ToString();
                //        if (v.Contains(_processOrderNoTextBoxOutput.ToString()))
                //        {
                //            FrontpagesList.Add(f);
                //        }
                //    }

                //    if (string.IsNullOrEmpty(_processOrderNoTextBoxOutput))
                //    {
                //        FrontpagesList = GetLastTen(new Frontpages());
                //    }
                //}

                //else
                //{
                //    var temp = new ObservableCollection<Frontpages>();
                //    foreach (var f in FrontpagesList)
                //    {
                //        var v = f.ProcessOrder_No.ToString();
                //        if (v.Contains(_processOrderNoTextBoxOutput.ToString()))
                //        {
                //            temp.Add(f);
                //        }
                //    }

                //    FrontpagesList = temp;
                //}

                #endregion
                
            }
        }

        public string DateTextBoxOutput
        {
            get { return _dateTextBoxOutput; }
            set
            {
                _dateTextBoxOutput = value;

                FrontpagesList.Clear();

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.Date.ToString();
                    if (v.Contains(_dateTextBoxOutput))
                    {
                        FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_dateTextBoxOutput))
                {
                    FrontpagesList = GetLastTen(new Frontpages());
                }
            }
        }

        public string FinishedProductNoTextBoxOutput
        {
            get { return _finishedProductNoTextBoxOutput; }
            set
            {
                _finishedProductNoTextBoxOutput = value;

                FrontpagesList.Clear();

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.FinishedProduct_No.ToString();
                    if (v.Contains(_finishedProductNoTextBoxOutput))
                    {
                        FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_finishedProductNoTextBoxOutput))
                {
                    FrontpagesList = GetLastTen(new Frontpages());
                }
            }
        }

        public string ColumnTextBoxOutput
        {
            get { return _columnTextBoxOutput; }
            set
            {
                _columnTextBoxOutput = value;

                FrontpagesList.Clear();

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.Colunm.ToString();
                    if (v.Contains(_columnTextBoxOutput))
                    {
                        FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_columnTextBoxOutput))
                {
                    FrontpagesList = GetLastTen(new Frontpages());
                }
            }
        }

        public string NoteTextBoxOutput
        {
            get { return _noteTextBoxOutput; }
            set
            {
                _noteTextBoxOutput = value;

                FrontpagesList.Clear();

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.Note;
                    if (v.Contains(_noteTextBoxOutput))
                    {
                        FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_noteTextBoxOutput))
                {
                    FrontpagesList = GetLastTen(new Frontpages());
                }
            }
        }

        public string WeekNoTextBoxOutput
        {
            get { return _weekNoTextBoxOutput; }
            set
            {
                _weekNoTextBoxOutput = value;

                FrontpagesList.Clear();

                foreach (var f in CompleteFrontpagesList)
                {
                    var v = f.Week_No.ToString();
                    if (v.Contains(_weekNoTextBoxOutput))
                    {
                        FrontpagesList.Add(f);
                    }
                }

                if (string.IsNullOrEmpty(_weekNoTextBoxOutput))
                {
                    FrontpagesList = GetLastTen(new Frontpages());
                }
            }
        }

        public ObservableCollection<Frontpages> CompleteFrontpagesList { get => _completeFrontpagesList; set => _completeFrontpagesList = value; }
        public ObservableCollection<ControlRegistrations> CompleteControlRegistrationsList { get => _completeControlRegistrationsList; set => _completeControlRegistrationsList = value; }
        public ObservableCollection<ControlSchedules> CompleteControlSchedulesList { get => _completeControlSchedulesList; set => _completeControlSchedulesList = value; }
        public ObservableCollection<Productions> CompleteProductionsList { get => _completeProductionsList; set => _completeProductionsList = value; }
        public ObservableCollection<Products> CompleteProductsList { get => _completeProductsList; set => _completeProductsList = value; }
        public ObservableCollection<ShiftRegistrations> CompleteShiftRegistrationsList { get => _completeShiftRegistrationsList; set => _completeShiftRegistrationsList = value; }
        public ObservableCollection<TUs> CompleteTuList { get => _completeTuList; set => _completeTuList = value; }

        #region ObservableLists

        public ObservableCollection<Frontpages> FrontpagesList
        {
            get { return _frontpagesList; }
            set
            {
                _frontpagesList = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ControlRegistrations> ControlRegistrationsList
        {
            get { return _controlRegistrationsList; }
            set
            {
                _controlRegistrationsList = value; 
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ControlSchedules> ControlSchedulesList
        {
            get { return _controlSchedulesList; }
            set
            {
                _controlSchedulesList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Productions> ProductionsList
        {
            get { return _productionsList; }
            set
            {
                _productionsList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Products> ProductsList
        {
            get { return _productsList; }
            set
            {
                _productsList = value;
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

        #endregion

        #region PropLists

        public List<string> FrontPageProps { get; set; }
        public List<string> ProductProps { get; set; }
        public List<string> ProductionProps { get; set; }
        public List<string> ShiftRegistrationProps { get; set; }
        public List<string> TuProps { get; set; }
        public List<string> ControlRegistrationProps { get; set; }
        public List<string> ControlScheduleProps { get; set; }

        #endregion

        public ManageTables()
        {
            InitializeObservableCollections();
            GenerateHeaderLists();
        }

        public void InitializeObservableCollections()
        {
            
            
            CompleteFrontpagesList = ModelGenerics.GetAll(new Frontpages());
            CompleteControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            CompleteControlSchedulesList = ModelGenerics.GetAll(new ControlSchedules());
            CompleteProductionsList = ModelGenerics.GetAll(new Productions());
            CompleteProductsList = ModelGenerics.GetAll(new Products());
            CompleteShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            CompleteTuList = ModelGenerics.GetAll(new TUs());


            FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
            ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
            ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
            ProductsList = ModelGenerics.GetLastTenInDatabasae(new Products());
            ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
            TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());

            if (FrontpagesList.Count > 0)
            {
            NewFrontpagesToAdd.ProcessOrder_No = FrontpagesList[FrontpagesList.Count - 1].ProcessOrder_No + 1;
            NewFrontpagesToAdd.Date = DateTime.Now;
            NewFrontpagesToAdd.Week_No = FindWeekNumber(NewFrontpagesToAdd);
                
            }
        }
        
        #region ButtonMethods

        #region FrontPageMethods

        public void RefreshFrontpages()
        {
            var tempList = ModelGenerics.GetAll(new Frontpages());
            FrontpagesList = new ObservableCollection<Frontpages>();
            if (tempList.Count > 10)
            {
                for (int i = tempList.Count-10; i < tempList.Count; i++)
                {
                    FrontpagesList.Add(tempList[i]);
                }

                message.ShowToastNotification("Opdateret", "Forside-tabellen er opdateret");
            }
        }
        public void SaveFrontpages()
        {
            
            Parallel.ForEach(_frontpagesList, frontpage =>
            {
                ModelGenerics.UpdateByObjectAndId(frontpage.ProcessOrder_No, frontpage);
            });
            message.ShowToastNotification("Gemt", "Forside-tabellen er gemt");
        }

        #endregion

        #region ControlRegistrationMethods

        public void RefreshControlRegistrations()
        {
            ControlRegistrationsList = ModelGenerics.GetAll(new ControlRegistrations());
            message.ShowToastNotification("Opdateret", "Kontrol Registrerings-tabellen er opdateret");
        }
        public void SaveControlRegistrations()
        {
            Parallel.ForEach(_controlRegistrationsList, controlRegistration =>
            {
                ModelGenerics.UpdateByObjectAndId(controlRegistration.ControlRegistration_ID, controlRegistration);
            });
            message.ShowToastNotification("Gemt", "Kontrol Registrerings-tabellen er gemt");
        }

        #endregion

        #region ControlScheduleMethods

        public void RefreshControlSchedules()
        {
            var tempList = ModelGenerics.GetAll(new ControlSchedules());
            ControlSchedulesList = new ObservableCollection<ControlSchedules>();
            if (tempList.Count > 10)
            {
                for (int i = tempList.Count - 10; i < tempList.Count; i++)
                {
                    ControlSchedulesList.Add(tempList[i]);
                }

                message.ShowToastNotification("Opdateret", "Kontrol Skema-tabellen er opdateret");
            }
        }
        public void SaveControlSchedules()
        {
            Parallel.ForEach(_controlSchedulesList, controlSchedules =>
            {
                ModelGenerics.UpdateByObjectAndId(controlSchedules.ControlSchedule_ID, controlSchedules);
            });
            message.ShowToastNotification("Gemt", "Kontrol Skema-tabellen er gemt");
        }

        #endregion

        #region ProductionMethods

        public void RefreshProductions()
        {
            ProductionsList = ModelGenerics.GetAll(new Productions());
            message.ShowToastNotification("Opdateret", "Produktions-tabellen er opdateret");
        }
        public void SaveProductions()
        {
            Parallel.ForEach(_productionsList, productions =>
            {
                ModelGenerics.UpdateByObjectAndId(productions.Production_ID, productions);
            });
            message.ShowToastNotification("Gemt", "Produktions-tabellen er gemt");
        }

        #endregion

        #region ShiftRegistrationMethods

        public void RefreshShiftRegistrations()
        {
            ShiftRegistrationsList = ModelGenerics.GetAll(new ShiftRegistrations());
            message.ShowToastNotification("Opdateret", "Vagt Registrerings-tabellen er opdateret");
        }
        public void SaveShiftRegistrations()
        {
            Parallel.ForEach(_shiftRegistrationsList, shiftRegistrations =>
            {
                ModelGenerics.UpdateByObjectAndId(shiftRegistrations.ShiftRegistration_ID, shiftRegistrations);
            });
            message.ShowToastNotification("Gemt", "Vagt Registrerings-tabellen er gemt");
        }

        #endregion

        #region TUMethods

        public void RefreshTUs()
        {
            TuList = ModelGenerics.GetAll(new TUs());
            message.ShowToastNotification("Opdateret", "TU-tabellen er opdateret");
        }
        public void SaveTUs()
        {
            Parallel.ForEach(_tuList, tus =>
            {
                ModelGenerics.UpdateByObjectAndId(tus.TU_ID, tus);
            });
            message.ShowToastNotification("Gemt", "TU-tabellen er gemt");
        }

        #endregion

        public void AddNewFrontpages()
        {
            if (NewFrontpagesToAdd.FinishedProduct_No == 0 || NewFrontpagesToAdd.FinishedProduct_No <= 0)
            {
                //something wrong mate
            }

            if (NewFrontpagesToAdd.ProcessOrder_No == 0 || NewFrontpagesToAdd.ProcessOrder_No <= 0)
            {
                //Something wrong again matey
            }

            if (NewFrontpagesToAdd.Colunm == 0 || NewFrontpagesToAdd.Colunm <= 0)
            {
                //Still something wrong dude
            }

            if (NewFrontpagesToAdd.Note == null)
            {
                NewFrontpagesToAdd.Note = " ";
            }

            CheckDateTime();

            NewFrontpagesToAdd.Week_No = FindWeekNumber(NewFrontpagesToAdd);



            //Checks whether any of the properties are null if any are returns true
            bool isNull = NewFrontpagesToAdd.GetType().GetProperties().All(p => p.GetValue(NewFrontpagesToAdd) == null);

            if (!isNull)
            {
                if (ModelGenerics.CreateByObject(NewFrontpagesToAdd))
                {
                    //_frontpagesList.Add(NewFrontpagesToAdd);
                    FrontpagesList = GetLastTen(new Frontpages());
                    NewFrontpagesToAdd = new Frontpages();
                    NewFrontpagesToAdd.ProcessOrder_No = _frontpagesList[FrontpagesList.Count - 1].ProcessOrder_No + 1;
                    NewFrontpagesToAdd.Date = DateTime.Now;
                    NewFrontpagesToAdd.Week_No = FindWeekNumber(NewFrontpagesToAdd);
                }
                else
                {

                }
            }
        }

        private void CheckDateTime()
        {
            string[] splitDateTimeString = new string[3];

            if (NewFrontpagesToAdd.DateHelper != null)
            {
                splitDateTimeString = NewFrontpagesToAdd.DateHelper.Split('/');

                //Check if day is 2 long, month is 2 and year is 4 ex. 02 / 02 / 2018 (semi check order)
                if (splitDateTimeString[0].Length == 2 && splitDateTimeString[1].Length == 2 && splitDateTimeString[2].Length == 4)
                {
                    //Check if they are numbers
                    if (int.TryParse(splitDateTimeString[0], out int year) && int.TryParse(splitDateTimeString[0], out int month) && int.TryParse(splitDateTimeString[0], out int day))
                    {
                        //Check if they are valid numbers
                        if (year > 0 && month > 0 && month < 13 && day < 32 && day > 0)
                        {
                            NewFrontpagesToAdd.Date = new DateTime(year, month, day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
                        }
                        else
                        {
                            //Sumthing wong boss
                        }
                    }
                    else
                    {
                        //wrong format you filty filty peasant
                    }
                }
                else
                {
                    //sumtin wong
                }
            }
        }

        private int FindWeekNumber(Frontpages frontpage)
        {
            int dayOfYear = frontpage.Date.DayOfYear;
            int weekNumber = 1;
            if (dayOfYear > 7)
            {
                if (dayOfYear % 1 != 0)
                {
                    weekNumber = (dayOfYear / 7) + 1;
                }
                else
                {
                    weekNumber = (dayOfYear / 7) + 1;
                }
            }

            return weekNumber;
        }
        #endregion

        private ObservableCollection<T> GetLastTen<T>(T type)
        {
            var tempList = ModelGenerics.GetAll(type);
            ObservableCollection<T> result = new ObservableCollection<T>();

            if (tempList.Count > 10)
            {
                for (int i = tempList.Count - 10; i < tempList.Count; i++)
                {
                    result.Add(tempList[i]);
                }
            }
            else
            {
                result = tempList;
            }

            return result;
        }

        private void GenerateHeaderLists()
        {
            ControlRegistrationProps = new List<string>{"Kontrol Registrering ID", "ProcessOrdre Nr", "Tid", "Produktionsdato", "Kommentar vedr. ændret dato", "Kontrol af sprit på anstikker", "Hætte Nr", "Etikette Nr", "Fustage", "Signatur", "Første palle depalleteret" , "Sidste palle depalleteret" };
            ControlScheduleProps = new List<string>{"Kontrol skema ID", "ProcessOrdre Nr", "Klokkeslæt", "Vægt kontrol", "Kontrol af fustage", "LudKoncentration", "Mip MA", "Signatur operatør", "Note"};
            FrontPageProps = new List<string> {"ProcessOrdre Nr", "Dato", "Færdigt Produkt Nr", "Kolonne", "Note", "Uge Nr"};
            ProductionProps = new List<string>{"Produktions ID", "ProcessOrdre Nr", "Paller lagt på lager 0001", "Tappemaskine", "Antal fustager pr. palle", "Tæller", "Palle tæller", "Batchdato"};
            ProductProps = new List<string>{"Færdigvarer Nr", "Produkt Navn", "Antal dage før udløbsdato"};
            ShiftRegistrationProps = new List<string>{"Vagt registrerings ID", "ProcessOrdre Nr", "Start tidspunkt", "Slut tidspunkt", "Pauser", "Total timer", "Bemanding", "Initialer"};
            TuProps = new List<string>{"TU ID", "ProcessOrdre Nr", "Første dag start TU", "Første dag slut TU", "Første dag TU i alt", "Anden dag start TU", "Anden dag slut TU", "Anden dag TU i alt", "Tredje dag start TU", "Tredje dag slut TU", "Tredje dag TU i alt" };
        }


        #region SingleTon
        private static ManageTables _instance;
        private static object syncLock = new object();

        public static ManageTables Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ManageTables();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        #region INotifyPropertiesChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
