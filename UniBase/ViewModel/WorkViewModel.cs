using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Command;
using UniBase.Annotations;
using UniBase.Model;
using UniBase.Model.K2;
using UniBase.View;

namespace UniBase.ViewModel
{
    class WorkViewModel : INotifyPropertyChanged
    {
        #region Relaycommands
        public RelayCommand<object> SortFrontpageCommand { get; set; }

        public RelayCommand RefreshFrontpageTable { get; set; }
        public RelayCommand RefreshLastTenControlRegistrationTable { get; set; }
        public RelayCommand SaveFrontpageTable { get; set; }
        public RelayCommand AddFrontpageTable { get; set; }
        public RelayCommand DeleteFrontpageTable { get; set; }

        public RelayCommand RefreshControlRegistrationTable { get; set; }
        public RelayCommand RefreshLastTenFrontpageTable { get; set; }
        public RelayCommand SaveControlRegistrationTable { get; set; }
        public RelayCommand AddControlRegistrationsTable { get; set; }


        public RelayCommand RefreshControlScheduleTable { get; set; }
        public RelayCommand RefreshLastTenControlScheduleTable { get; set; }
        public RelayCommand SaveControlScheduleTable { get; set; }

        public RelayCommand RefreshProductionTable { get; set; }
        public RelayCommand RefreshLastTenProductionTable { get; set; }
        public RelayCommand SaveProductionTable { get; set; }

        public RelayCommand RefreshShiftRegistrationTable { get; set; }
        public RelayCommand RefreshLastTenShiftRegistrationTable { get; set; }
        public RelayCommand SaveShiftRegistrationTable { get; set; }

        public RelayCommand RefreshTUTable { get; set; }
        public RelayCommand RefreshLastTenTUTable { get; set; }
        public RelayCommand SaveTUTable { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand DeleteUserCommand { get; set; }
        
        public RelayCommand<object> ControlledClickCommand { get; set; }
        public RelayCommand ControlledClickCommand2 { get; set; }

        public RelayCommand<object> SelectParentItemFrontpageCommand { get; set; }
        public RelayCommand<object> SelectParentItemControlRegistrationCommand { get; set; }

        #endregion

        public ManageTables Column_2 { get; set; }
        public PredefinedColors PredefinedColors { get; set; }
        public SortAndFilter SortAndFilter { get; set; }
        
        public TrendAdminstrator TrendAdminstrator { get; set; }
        public XamlBindings XamlBindings { get; set; }

        public ManageUser ManageUser { get; set; }
        
        public WorkViewModel()
        {
            Column_2 = ManageTables.Instance;
            PredefinedColors = new PredefinedColors();
            SortAndFilter = new SortAndFilter();
            ManageUser = new ManageUser();
            TrendAdminstrator = new TrendAdminstrator();
            XamlBindings = new XamlBindings();

            #region Update(SavedForLater)

            //int month = 2;
            //int day = 11;
            //Udfyld controlschdual.
            //Random radnom = new Random();
            //            for (int i = 0; i < 120; i++)
            //            {
            //                ModelGenerics.CreateByObject(new ControlSchedules(i+39, new DateHelper(2019, month, day),radnom.NextDouble()*100, "hej", radnom.NextDouble() * 100, radnom.NextDouble() * 100, "mig", "Very good"));
            //                day++;
            //                if (day == 29)
            //                {
            //                    month++;
            //                    day = 1;
            //                }
            //            }
            //            foreach (var VARIABLE in Column_2.ControlSchedulesList)
            //            {
            //                
            //                VARIABLE.Time = new DateHelper(2019, month, day);
            //                VARIABLE.Weight = radnom.NextDouble()* 1.7 + 36.9;
            //                VARIABLE.MipMA = radnom.NextDouble() * 2.7 + 23.9;
            //                VARIABLE.LudKoncentration = radnom.NextDouble() * 1.2 + 0.9;
            //                ModelGenerics.UpdateByObjectAndId(VARIABLE.ControlSchedule_ID, VARIABLE);
            //                day++;
            //                if (day > 30)
            //                {
            //                    month++;
            //                    day = 1;
            //                }
            //            
            //            }

            #endregion

            RefreshFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.RefreshFrontpages);
            RefreshLastTenFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.RefreshLastTenFrontpages);
            SaveFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.SaveFrontpages);
            AddFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.AddNewFrontpages);
            DeleteFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.DeleteFrontpage);

            RefreshControlRegistrationTable = new RelayCommand(Column_2.ControlRegistrationMethod.RefreshControlRegistrations);
            RefreshLastTenControlRegistrationTable = new RelayCommand(Column_2.ControlRegistrationMethod.RefreshLastTenControlRegistrations);
            SaveControlRegistrationTable = new RelayCommand(Column_2.ControlRegistrationMethod.SaveControlRegistrations);
            AddControlRegistrationsTable = new RelayCommand(Column_2.ControlRegistrationMethod.AddNewControlRegistrations);
            DeleteControlRegistrationTable = new RelayCommand(Column_2.ControlRegistrationMethod.DeleteControlRegistration);

            RefreshControlScheduleTable = new RelayCommand(Column_2.ControlScheduleMethod.RefreshControlSchedules);
            RefreshLastTenControlScheduleTable = new RelayCommand(Column_2.ControlScheduleMethod.RefreshLastTenControlSchedules);
            SaveControlScheduleTable = new RelayCommand(Column_2.ControlScheduleMethod.SaveControlSchedules);

            RefreshProductionTable = new RelayCommand(Column_2.ProductionMethod.RefreshProductions);
            RefreshLastTenProductionTable = new RelayCommand(Column_2.ProductionMethod.RefreshProductions);
            SaveProductionTable = new RelayCommand(Column_2.ProductionMethod.SaveProductions);

            RefreshShiftRegistrationTable = new RelayCommand(Column_2.ShiftRegistrationMethod.RefreshShiftRegistrations);
            RefreshLastTenShiftRegistrationTable = new RelayCommand(Column_2.ShiftRegistrationMethod.RefreshLastTenShiftRegistrations);
            SaveShiftRegistrationTable = new RelayCommand(Column_2.ShiftRegistrationMethod.SaveShiftRegistrations);

            RefreshTUTable = new RelayCommand(Column_2.TuMethod.RefreshTUs);
            RefreshLastTenTUTable = new RelayCommand(Column_2.TuMethod.RefreshLastTenTUs);
            SaveTUTable = new RelayCommand(Column_2.TuMethod.SaveTUs);

            AddUserCommand = new RelayCommand(ManageUser.AddUser);
            DeleteUserCommand = new RelayCommand(ManageUser.RemoveUser);

            SortFrontpageCommand = new RelayCommand<object>(SortAndFilter.SortFrontpagesButtonClick);

            ControlledClickCommand = new RelayCommand<object>(Column_2.ControlRegistrationMethod.ControlledClick);

            SelectParentItemFrontpageCommand = new RelayCommand<object>(Column_2.FrontpageMethod.SelectParentItem);
            SelectParentItemControlRegistrationCommand = new RelayCommand<object>(Column_2.ControlRegistrationMethod.SelectParentItem);

            ControlledClickCommand2 = new RelayCommand(Column_2.ControlRegistrationMethod.ControlledClickAdd);
        }

        public RelayCommand DeleteControlRegistrationTable { get; set; }


        private void TempMethod2()
        {
            Debug.WriteLine("\n \tHej", "Button Clicked");
        }

        private void TempMethod(object id)
        {
            Debug.WriteLine("\n \tHej", "Button Clicked");
            Debug.WriteLine(id);
        }

        #region Properties
        

        #endregion

        #region InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
    
}
