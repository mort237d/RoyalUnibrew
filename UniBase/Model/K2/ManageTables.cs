using System;
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

        private FrontpageMethod _frontpageMethod = new FrontpageMethod();
        private ControlRegistrationMethod _controlRegistrationMethod = new ControlRegistrationMethod();
        private ControlScheduleMethod _controlScheduleMethod = new ControlScheduleMethod();
        private ProductionMethod _productionMethod = new ProductionMethod();
        private ShiftRegistrationMethod _shiftRegistrationMethod = new ShiftRegistrationMethod();
        private TUMethod _tuMethod = new TUMethod();

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

        public FrontpageMethod FrontpageMethod
        {
            get { return _frontpageMethod; }
            set { _frontpageMethod = value; }
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

        public ObservableCollection<string> KegSizes
        {
            get { return _kegSizes; }
            set
            {
                _kegSizes = value;
                OnPropertyChanged();
            }
        }

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
            FrontpagesList = ModelGenerics.GetLastTenInDatabasae(new Frontpages());
            ControlRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ControlRegistrations());
            ControlSchedulesList = ModelGenerics.GetLastTenInDatabasae(new ControlSchedules());
            ProductionsList = ModelGenerics.GetLastTenInDatabasae(new Productions());
            ProductsList = ModelGenerics.GetLastTenInDatabasae(new Products());
            ShiftRegistrationsList = ModelGenerics.GetLastTenInDatabasae(new ShiftRegistrations());
            TuList = ModelGenerics.GetLastTenInDatabasae(new TUs());

            if (FrontpagesList.Count > 0)
            {
                foreach (var VARIABLE in FrontpagesList)
                {
                    VARIABLE.DateTimeStringHelper = VARIABLE.Date.ToString().Remove(10);
                }
            NewControlRegistrationsToAdd.ControlAlcoholSpearDispenser = false;
            NewFrontpagesToAdd.ProcessOrder_No = FrontpagesList[FrontpagesList.Count - 1].ProcessOrder_No + 1;
            NewFrontpagesToAdd.Date = DateTime.Now;
            NewFrontpagesToAdd.DateTimeStringHelper = NewFrontpagesToAdd.Date.ToString().Remove(10);
            NewFrontpagesToAdd.Week_No = FrontpageMethod.FindWeekNumber(NewFrontpagesToAdd.Date);
                
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
