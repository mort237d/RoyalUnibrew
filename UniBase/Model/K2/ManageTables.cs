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
        #region Properties
        public ControlRegistrationMethod ControlRegistrationMethod { get; private set; }
        public ControlScheduleMethod ControlScheduleMethod { get; private set; }
        public FrontpageMethod FrontpageMethod { get; private set; }
        public ProductionMethod ProductionMethod { get; set; }
        public ShiftRegistrationMethod ShiftRegistrationMethod { get; set; }
        public TuMethod TuMethod { get; set; }
        public XamlBindings XamlBindings { get; set; }
        public TrendAdminstrator TrendAdminstrator { get; private set; }
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

            SortAndFilter = new SortAndFilter();
        }

        public void InitializeObservableCollections()
        {
            ControlRegistrationMethod = new ControlRegistrationMethod();
            ControlScheduleMethod = new ControlScheduleMethod();
            FrontpageMethod = new FrontpageMethod();
            ProductionMethod = new ProductionMethod();
            ShiftRegistrationMethod = new ShiftRegistrationMethod();
            TuMethod = new TuMethod();
            XamlBindings = new XamlBindings();
            TrendAdminstrator = new TrendAdminstrator();
        }
        
        private void GenerateHeaderLists()
        {
            //ControlRegistrationProps = new List<string>{"Kontrol Registrering ID", "ProcessOrdre Nr", "Tid", "Produktionsdato", "Kommentar vedr. ændret dato", "Kontrol af sprit på anstikker", "Hætte Nr", "Etikette Nr", "Fustage", "Signatur", "Første palle depalleteret" , "Sidste palle depalleteret" };
            //ControlScheduleProps = new List<string>{"Kontrol skema ID", "ProcessOrdre Nr", "Klokkeslæt", "Vægt kontrol", "Kontrol af fustage", "LudKoncentration", "Mip MA", "Signatur operatør", "Note"};
            //FrontPageProps = new List<string> {"ProcessOrdre Nr", "Dato", "Færdigt Produkt Nr", "Kolonne", "Note", "Uge Nr"};
            //ProductionProps = new List<string>{"Produktions ID", "ProcessOrdre Nr", "Paller lagt på lager 0001", "Tappemaskine", "Antal fustager pr. palle", "Tæller", "Palle tæller", "Batchdato"};
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
