﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using UniBase.Annotations;
using UniBase.Model.K2.ButtonMethods;

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

        private ControlRegistrations _newControlRegistrationsToAdd = new ControlRegistrations();
        private ControlSchedules _newControlSchedules = new ControlSchedules();
        private Frontpages _newFrontpagesToAdd = new Frontpages();
        private Productions _newProductions = new Productions();
        private ShiftRegistrations _newShiftRegistrations = new ShiftRegistrations();
        private TUs _newTUs = new TUs();

        private ObservableCollection<string> _kegSizes = new ObservableCollection<string>();


        private Message message = new Message();
        private FrontpageButtonMethod _frontpageButtonMethod = new FrontpageButtonMethod();
        private ControlRegistrationMethod _controlRegistrationMethod = new ControlRegistrationMethod();
        private ControlScheduleMethod _controlScheduleMethod = new ControlScheduleMethod();
        private ProductionMethod _productionMethod = new ProductionMethod();
        private ShiftRegistrationMethod _shiftRegistrationMethod = new ShiftRegistrationMethod();
        private TUMethod _tuMethod = new TUMethod();

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
        
        public ControlRegistrations NewControlRegistrationsToAdd
        {
            get => _newControlRegistrationsToAdd;
            set
            {
                _newControlRegistrationsToAdd = value;
                OnPropertyChanged();
            }
        }

        public ControlSchedules NewControlSchedules
        {
            get { return _newControlSchedules; }
            set
            {
                _newControlSchedules = value; 
                OnPropertyChanged();
            }
        }

        public Productions NewProductions
        {
            get { return _newProductions; }
            set
            {
                _newProductions = value;
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

        public TUs NewTUs
        {
            get { return _newTUs; }
            set
            {
                _newTUs = value; 
                OnPropertyChanged();
            }
        }



        public FrontpageButtonMethod FrontpageButtonMethod
        {
            get { return _frontpageButtonMethod; }
            set { _frontpageButtonMethod = value; }
        }

        public ControlRegistrationMethod ControlRegistrationMethod
        {
            get { return _controlRegistrationMethod; }
            set { _controlRegistrationMethod = value; }
        }

        public ControlScheduleMethod ControlScheduleMethod
        {
            get { return _controlScheduleMethod; }
            set { _controlScheduleMethod = value; }
        }

        public ProductionMethod ProductionMethod
        {
            get { return _productionMethod; }
            set { _productionMethod = value; }
        }

        public ShiftRegistrationMethod ShiftRegistrationMethod
        {
            get { return _shiftRegistrationMethod; }
            set { _shiftRegistrationMethod = value; }
        }

        public TUMethod TuMethod
        {
            get { return _tuMethod; }
            set { _tuMethod = value; }
        }

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
                    FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                }
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
                    FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
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
                    FrontpagesList =  ModelGenerics.GetLastTenInDatabasae(new Frontpages());
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
                    FrontpagesList =  ModelGenerics.GetLastTenInDatabasae(new Frontpages());
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
                    FrontpagesList =  ModelGenerics.GetLastTenInDatabasae(new Frontpages());
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
                    FrontpagesList =  ModelGenerics.GetLastTenInDatabasae(new Frontpages());
                }
            }
        }

        public ObservableCollection<string> KegSizes
        {
            get { return _kegSizes; }
            set
            {
                _kegSizes = value;
                OnPropertyChanged();
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
            NewControlRegistrationsToAdd.ControlAlcoholSpearDispenser = false;
            NewFrontpagesToAdd.ProcessOrder_No = FrontpagesList[FrontpagesList.Count - 1].ProcessOrder_No + 1;
            NewFrontpagesToAdd.Date = DateTime.Now;
            NewFrontpagesToAdd.DateTimeStringHelper = NewFrontpagesToAdd.Date.ToString().Remove(10);
            NewFrontpagesToAdd.Week_No = FrontpageButtonMethod.FindWeekNumber(NewFrontpagesToAdd);
                
            }

            if (ControlRegistrationsList.Count > 0)
            {

                NewControlRegistrationsToAdd.CapNo = ControlRegistrationsList.Last().CapNo;
                NewControlRegistrationsToAdd.EtiquetteNo = ControlRegistrationsList.Last().EtiquetteNo;
                NewControlRegistrationsToAdd.ControlRegistration_ID = ControlRegistrationsList.Last().ControlRegistration_ID + 1;
                NewControlRegistrationsToAdd.KegSize = ControlRegistrationsList.Last().KegSize;
                NewControlRegistrationsToAdd.ProcessOrder_No = ControlRegistrationsList.Last().ProcessOrder_No;
            }
        }
        
        private void GenerateHeaderLists()
        {
            ControlRegistrationProps = new List<string>{"Kontrol Registrering ID", "ProcessOrdre Nr", "Tid", "Produktionsdato", "Kommentar vedr. ændret dato", "Kontrol af sprit på anstikker", "Hætte Nr", "Etikette Nr", "Fustage", "Signatur", "Første palle depalleteret" , "Sidste palle depalleteret" };
            ControlScheduleProps = new List<string>{"Kontrol skema ID", "ProcessOrdre Nr", "Klokkeslæt", "Vægt kontrol", "Kontrol af fustage", "LudKoncentration", "Mip MA", "Signatur operatør", "Note"};
            //FrontPageProps = new List<string> {"ProcessOrdre Nr", "Dato", "Færdigt Produkt Nr", "Kolonne", "Note", "Uge Nr"};
            ProductionProps = new List<string>{"Produktions ID", "ProcessOrdre Nr", "Paller lagt på lager 0001", "Tappemaskine", "Antal fustager pr. palle", "Tæller", "Palle tæller", "Batchdato"};
            ProductProps = new List<string>{"Færdigvarer Nr", "Produkt Navn", "Antal dage før udløbsdato"};
            ShiftRegistrationProps = new List<string>{"Vagt registrerings ID", "ProcessOrdre Nr", "Start tidspunkt", "Slut tidspunkt", "Pauser", "Total timer", "Bemanding", "Initialer"};
            TuProps = new List<string>{"TU ID", "ProcessOrdre Nr", "Første dag start TU", "Første dag slut TU", "Første dag TU i alt", "Anden dag start TU", "Anden dag slut TU", "Anden dag TU i alt", "Tredje dag start TU", "Tredje dag slut TU", "Tredje dag TU i alt" };

            KegSizes = new ObservableCollection<string>{"25L", "30L", "35L"};
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
