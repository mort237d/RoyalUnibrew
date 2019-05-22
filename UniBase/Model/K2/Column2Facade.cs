using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;
using UniBase.Model.K2.ButtonMethods;
using UniBase.Model.Login;
using UniBase.View;


namespace UniBase.Model.K2
{
    public class Column2Facade
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
        public PredefinedColors PredefinedColors { get; set; }
        public ManageUser ManageUser { get; set; }
        public ManageLogin ManageLogin { get; set; }
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

        public Column2Facade()
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
            PredefinedColors = new PredefinedColors();
            ManageUser = new ManageUser();
            ManageLogin = new ManageLogin();
        }

        #region SingleTon
        private static Column2Facade _instance;
        private static object syncLock = new object();

        public static Column2Facade Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Column2Facade();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion
    }
}
