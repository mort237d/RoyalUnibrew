using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Command;
using UniBase.Annotations;
using UniBase.Model;
using UniBase.Model.K2;
using UniBase.Model.Login;
using UniBase.View;

namespace UniBase.ViewModel
{
    class WorkViewModel : INotifyPropertyChanged
    {
        #region Relaycommands
        public RelayCommand<object> SortFrontpageCommand { get; set; }
        public RelayCommand<object> SortControlRegistrationCommand { get; set; }
        public RelayCommand<object> SortControlScheduleCommand { get; set; }
        public RelayCommand<object> SortProductionCommand { get; set; }
        public RelayCommand<object> SortShiftRegistrationCommand { get; set; }
        public RelayCommand<object> SortTuCommand { get; set; }

        public RelayCommand RefreshFrontpageTable { get; set; }
        public RelayCommand RefreshLastTenControlRegistrationTable { get; set; }
        public RelayCommand SaveFrontpageTable { get; set; }
        public RelayCommand AddFrontpageTable { get; set; }
        public RelayCommand DeleteFrontpageTable { get; set; }

        public RelayCommand RefreshControlRegistrationTable { get; set; }
        public RelayCommand RefreshLastTenFrontpageTable { get; set; }
        public RelayCommand SaveControlRegistrationTable { get; set; }
        public RelayCommand DeleteControlRegistrationTable { get; set; }
        public RelayCommand AddControlRegistrationsTable { get; set; }
        
        public RelayCommand RefreshControlScheduleTable { get; set; }
        public RelayCommand RefreshLastTenControlScheduleTable { get; set; }
        public RelayCommand SaveControlScheduleTable { get; set; }
        public RelayCommand DeleteControlScheduleTable { get; set; }
        public RelayCommand AddControlScheduleTable { get; set; }

        public RelayCommand RefreshProductionTable { get; set; }
        public RelayCommand RefreshLastTenProductionTable { get; set; }
        public RelayCommand SaveProductionTable { get; set; }
        public RelayCommand DeleteProductionTable { get; set; }
        public RelayCommand AddProductionTable { get; set; }

        public RelayCommand RefreshShiftRegistrationTable { get; set; }
        public RelayCommand RefreshLastTenShiftRegistrationTable { get; set; }
        public RelayCommand SaveShiftRegistrationTable { get; set; }
        public RelayCommand DeleteShiftRegistrationTable { get; set; }
        public RelayCommand AddShiftRegistrationTable { get; set; }

        public RelayCommand RefreshTUTable { get; set; }
        public RelayCommand RefreshLastTenTUTable { get; set; }
        public RelayCommand SaveTUTable { get; set; }
        public RelayCommand DeleteTUTable { get; set; }
        public RelayCommand AddTUTable { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand DeleteUserCommand { get; set; }
        public RelayCommand ChangeUserCommand { get; set; }
        public RelayCommand UserImageBrowserCommand { get; set; }
        public RelayCommand LogOffCommand { get; set; }

        public RelayCommand<object> ControlledClickCommand { get; set; }
        public RelayCommand ControlledClickCommand2 { get; set; }

        public RelayCommand<object> SelectParentItemFrontpageCommand { get; set; }
        public RelayCommand<object> SelectParentItemControlRegistrationCommand { get; set; }
        public RelayCommand<object> SelectParentItemControlScheduleCommand { get; set; }
        public RelayCommand<object> SelectParentItemProductionCommand { get; set; }
        public RelayCommand<object> SelectParentItemShiftRegistrationCommand { get; set; }
        public RelayCommand<object> SelectParentItemTuCommand { get; set; }
        
        #endregion

        public ManageTables Column_2 { get; set; }
        public PredefinedColors PredefinedColors { get; set; }

        public ManageUser ManageUser { get; set; }
        public ManageLogin Login { get; set; }
        
        public WorkViewModel()
        {
            Column_2 = ManageTables.Instance;
            PredefinedColors = new PredefinedColors();
            ManageUser = new ManageUser();
            Login = new ManageLogin();

            #region Update(SavedForLater)

            int month = 4;
            int day = 27;
            int year = 2019;
            int hour = 1;
            double weight = 0;
            double mipMa = 0;
            double ludKoncentration = 0;
            int processordernext = 1;
            //Udfyld controlschdual.
            Random random = new Random();
//            for (int i = 0; i < 70; i++)
//            {
//                weight = random.NextDouble() * 1.7 + 36.9;
//                mipMa = random.NextDouble() * 2.7 + 23.9;
//                ludKoncentration = random.NextDouble() * 1.2 + 0.9;
//                ModelGenerics.CreateByObject(new ControlSchedules(i+330, new DateTime(year, month, day),weight, "hej", ludKoncentration, mipMa, "mig", "Very good",processordernext));
//                
//                processordernext++;
//                if (processordernext > 37)
//                {
//                    processordernext = 1;
//                }
//                hour += 3;
//                if (hour > 9)
//                {
//                    hour = 1;
//                    day++;
//                }
//                if (day == 29)
//                {
//                    month++;
//                    day = 1;
//                }
//                if (month > 11)
//                {
//                    year++;
//                    month = 1;
//                }
//            }
//            foreach (var VARIABLE in Column_2.ControlScheduleMethod.CompleteControlSchedulesList)
//            {
//                if (VARIABLE.Time > new DateTime(2019,4,25))
//                {
//                    
//                VARIABLE.Time = new DateTime(year, month, day, hour, random.Next(0,59), 0);
//                VARIABLE.Weight = random.NextDouble()* 2 + 36.8;
//                VARIABLE.MipMA = random.NextDouble() * 3 + 23.8;
//                VARIABLE.LudKoncentration = random.NextDouble() * 1.5 + 0.8;
//                ModelGenerics.UpdateByObjectAndId(VARIABLE.ControlSchedule_ID, VARIABLE);
//                hour += 3;
//                if (hour > 9)
//                {
//                    hour = 1;
//                    day++;
//                }
//                if (day == 29)
//                {
//                    month++;
//                    day = 1;
//                }
//             
//                if (month > 11)
//                {
//                    year++;
//                    month = 1;
//                }
//               
//                }
//            }

            #endregion

            //Frontpage
            RefreshFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.RefreshAll);
            RefreshLastTenFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.RefreshLastTen);
            SaveFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.SaveAll);
            AddFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.AddNewItem);
            DeleteFrontpageTable = new RelayCommand(Column_2.FrontpageMethod.DeleteItem);

            //ControlRegistration
            RefreshControlRegistrationTable = new RelayCommand(Column_2.ControlRegistrationMethod.RefreshAll);
            RefreshLastTenControlRegistrationTable = new RelayCommand(Column_2.ControlRegistrationMethod.RefreshLastTen);
            SaveControlRegistrationTable = new RelayCommand(Column_2.ControlRegistrationMethod.SaveAll);
            AddControlRegistrationsTable = new RelayCommand(Column_2.ControlRegistrationMethod.AddNewItem);
            DeleteControlRegistrationTable = new RelayCommand(Column_2.ControlRegistrationMethod.DeleteItem);

            //ControlSchedule
            RefreshControlScheduleTable = new RelayCommand(Column_2.ControlScheduleMethod.RefreshAll);
            RefreshLastTenControlScheduleTable = new RelayCommand(Column_2.ControlScheduleMethod.RefreshLastTen);
            SaveControlScheduleTable = new RelayCommand(Column_2.ControlScheduleMethod.SaveAll);
            AddControlScheduleTable = new RelayCommand(Column_2.ControlScheduleMethod.AddNewItem);
            DeleteControlScheduleTable = new RelayCommand(Column_2.ControlScheduleMethod.DeleteItem);

            //Production
            RefreshProductionTable = new RelayCommand(Column_2.ProductionMethod.RefreshAll);
            RefreshLastTenProductionTable = new RelayCommand(Column_2.ProductionMethod.RefreshLastTen);
            SaveProductionTable = new RelayCommand(Column_2.ProductionMethod.SaveAll);
            AddProductionTable = new RelayCommand(Column_2.ProductionMethod.AddNewItem);
            DeleteProductionTable = new RelayCommand(Column_2.ProductionMethod.DeleteItem);

            //ShiftRegistration
            RefreshShiftRegistrationTable = new RelayCommand(Column_2.ShiftRegistrationMethod.RefreshAll);
            RefreshLastTenShiftRegistrationTable = new RelayCommand(Column_2.ShiftRegistrationMethod.RefreshLastTen);
            SaveShiftRegistrationTable = new RelayCommand(Column_2.ShiftRegistrationMethod.SaveAll);
            AddShiftRegistrationTable = new RelayCommand(Column_2.ShiftRegistrationMethod.AddNewItem);
            DeleteShiftRegistrationTable = new RelayCommand(Column_2.ShiftRegistrationMethod.DeleteItem);

            //TU
            RefreshTUTable = new RelayCommand(Column_2.TuMethod.RefreshAll);
            RefreshLastTenTUTable = new RelayCommand(Column_2.TuMethod.RefreshLastTen);
            SaveTUTable = new RelayCommand(Column_2.TuMethod.SaveAll);
            AddTUTable = new RelayCommand(Column_2.TuMethod.AddNewItem);
            DeleteTUTable = new RelayCommand(Column_2.TuMethod.DeleteItem);

            //Users
            AddUserCommand = new RelayCommand(ManageUser.AddUser);
            DeleteUserCommand = new RelayCommand(ManageUser.RemoveUser);
            ChangeUserCommand = new RelayCommand(ManageUser.ChangeSelectedUser);
            UserImageBrowserCommand = new RelayCommand(ManageUser.BrowseImageButton);
            LogOffCommand = new RelayCommand(Login.LogOffMethod);
            ClearTbCommand = new RelayCommand(ManageUser.ClearTb);
            AdminCheckClickCommand = new RelayCommand(ManageUser.AdminCheckClick);

            //Sort
            SortFrontpageCommand = new RelayCommand<object>(Column_2.FrontpageMethod.SortButtonClick);
            SortControlRegistrationCommand = new RelayCommand<object>(Column_2.ControlRegistrationMethod.SortButtonClick);
            SortControlScheduleCommand = new RelayCommand<object>(Column_2.ControlScheduleMethod.SortButtonClick);
            SortProductionCommand = new RelayCommand<object>(Column_2.ProductionMethod.SortButtonClick);
            SortShiftRegistrationCommand = new RelayCommand<object>(Column_2.ShiftRegistrationMethod.SortButtonClick);
            SortTuCommand = new RelayCommand<object>(Column_2.TuMethod.SortButtonClick);

            ControlledClickCommand = new RelayCommand<object>(Column_2.ControlRegistrationMethod.ControlledClick);

            //SelectParent
            SelectParentItemFrontpageCommand = new RelayCommand<object>(Column_2.FrontpageMethod.SelectParentItem);
            SelectParentItemControlRegistrationCommand = new RelayCommand<object>(Column_2.ControlRegistrationMethod.SelectParentItem);
            SelectParentItemControlScheduleCommand = new RelayCommand<object>(Column_2.ControlScheduleMethod.SelectParentItem);
            SelectParentItemProductionCommand = new RelayCommand<object>(Column_2.ProductionMethod.SelectParentItem);
            SelectParentItemShiftRegistrationCommand = new RelayCommand<object>(Column_2.ShiftRegistrationMethod.SelectParentItem);
            SelectParentItemTuCommand = new RelayCommand<object>(Column_2.TuMethod.SelectParentItem);

            ControlledClickCommand2 = new RelayCommand(Column_2.ControlRegistrationMethod.ControlledClickAdd);
        }

        public RelayCommand AdminCheckClickCommand { get; set; }

        public RelayCommand ClearTbCommand { get; set; }

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