using System.Collections.Generic;
using System.ComponentModel;
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
        public TrendAdminstrator TrendAdminstrator { get; set; }
        public GenericMethod GenericMethod { get; set; }
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
            GenericMethod = new GenericMethod();
        }
        
        


        #region SingleTon
        private static ManageTables _instance;
        private static object _syncLock = new object();

        public static ManageTables Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncLock)
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
