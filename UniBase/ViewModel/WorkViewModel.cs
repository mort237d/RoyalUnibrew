﻿using System.ComponentModel;
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

        public RelayCommand RefreshTuTable { get; set; }
        public RelayCommand RefreshLastTenTuTable { get; set; }
        public RelayCommand SaveTuTable { get; set; }
        public RelayCommand DeleteTuTable { get; set; }
        public RelayCommand AddTuTable { get; set; }

        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand DeleteUserCommand { get; set; }
        
        public RelayCommand<object> ControlledClickCommand { get; set; }
        public RelayCommand ControlledClickCommand2 { get; set; }

        public RelayCommand<object> SelectParentItemFrontpageCommand { get; set; }
        public RelayCommand<object> SelectParentItemControlRegistrationCommand { get; set; }
        public RelayCommand<object> SelectParentItemControlScheduleCommand { get; set; }
        public RelayCommand<object> SelectParentItemProductionCommand { get; set; }
        public RelayCommand<object> SelectParentItemShiftRegistrationCommand { get; set; }
        public RelayCommand<object> SelectParentItemTuCommand { get; set; }
        
        #endregion

        public ManageTables Column2 { get; set; }
        public PredefinedColors PredefinedColors { get; set; }

        public ManageUser ManageUser { get; set; }
        
        public WorkViewModel()
        {
            Column2 = ManageTables.Instance;
            PredefinedColors = new PredefinedColors();
            ManageUser = new ManageUser();
            

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

            //Frontpage
            RefreshFrontpageTable = new RelayCommand(Column2.FrontpageMethod.RefreshAll);
            RefreshLastTenFrontpageTable = new RelayCommand(Column2.FrontpageMethod.RefreshLastTen);
            SaveFrontpageTable = new RelayCommand(Column2.FrontpageMethod.SaveAll);
            AddFrontpageTable = new RelayCommand(Column2.FrontpageMethod.AddNewItem);
            DeleteFrontpageTable = new RelayCommand(Column2.FrontpageMethod.DeleteItem);

            //ControlRegistration
            RefreshControlRegistrationTable = new RelayCommand(Column2.ControlRegistrationMethod.RefreshAll);
            RefreshLastTenControlRegistrationTable = new RelayCommand(Column2.ControlRegistrationMethod.RefreshLastTen);
            SaveControlRegistrationTable = new RelayCommand(Column2.ControlRegistrationMethod.SaveAll);
            AddControlRegistrationsTable = new RelayCommand(Column2.ControlRegistrationMethod.AddNewItem);
            DeleteControlRegistrationTable = new RelayCommand(Column2.ControlRegistrationMethod.DeleteItem);

            //ControlSchedule
            RefreshControlScheduleTable = new RelayCommand(Column2.ControlScheduleMethod.RefreshAll);
            RefreshLastTenControlScheduleTable = new RelayCommand(Column2.ControlScheduleMethod.RefreshLastTen);
            SaveControlScheduleTable = new RelayCommand(Column2.ControlScheduleMethod.SaveAll);
            AddControlScheduleTable = new RelayCommand(Column2.ControlScheduleMethod.AddNewItem);
            DeleteControlScheduleTable = new RelayCommand(Column2.ControlScheduleMethod.DeleteItem);

            //Production
            RefreshProductionTable = new RelayCommand(Column2.ProductionMethod.RefreshAll);
            RefreshLastTenProductionTable = new RelayCommand(Column2.ProductionMethod.RefreshLastTen);
            SaveProductionTable = new RelayCommand(Column2.ProductionMethod.SaveAll);
            AddProductionTable = new RelayCommand(Column2.ProductionMethod.AddNewItem);
            DeleteProductionTable = new RelayCommand(Column2.ProductionMethod.DeleteItem);

            //ShiftRegistration
            RefreshShiftRegistrationTable = new RelayCommand(Column2.ShiftRegistrationMethod.RefreshAll);
            RefreshLastTenShiftRegistrationTable = new RelayCommand(Column2.ShiftRegistrationMethod.RefreshLastTen);
            SaveShiftRegistrationTable = new RelayCommand(Column2.ShiftRegistrationMethod.SaveAll);
            AddShiftRegistrationTable = new RelayCommand(Column2.ShiftRegistrationMethod.AddNewItem);
            DeleteShiftRegistrationTable = new RelayCommand(Column2.ShiftRegistrationMethod.DeleteItem);

            //TU
            RefreshTuTable = new RelayCommand(Column2.TuMethod.RefreshAll);
            RefreshLastTenTuTable = new RelayCommand(Column2.TuMethod.RefreshLastTen);
            SaveTuTable = new RelayCommand(Column2.TuMethod.SaveAll);
            AddTuTable = new RelayCommand(Column2.TuMethod.AddNewItem);
            DeleteTuTable = new RelayCommand(Column2.TuMethod.DeleteItem);

            //User
            AddUserCommand = new RelayCommand(ManageUser.AddUser);
            DeleteUserCommand = new RelayCommand(ManageUser.RemoveUser);

            //Sort
            SortFrontpageCommand = new RelayCommand<object>(Column2.FrontpageMethod.SortButtonClick);
            SortControlRegistrationCommand = new RelayCommand<object>(Column2.ControlRegistrationMethod.SortButtonClick);
            SortControlScheduleCommand = new RelayCommand<object>(Column2.ControlScheduleMethod.SortButtonClick);
            SortProductionCommand = new RelayCommand<object>(Column2.ProductionMethod.SortButtonClick);
            SortShiftRegistrationCommand = new RelayCommand<object>(Column2.ShiftRegistrationMethod.SortButtonClick);
            SortTuCommand = new RelayCommand<object>(Column2.TuMethod.SortButtonClick);

            ControlledClickCommand = new RelayCommand<object>(Column2.ControlRegistrationMethod.ControlledClick);

            //SelectParent
            SelectParentItemFrontpageCommand = new RelayCommand<object>(Column2.FrontpageMethod.SelectParentItem);
            SelectParentItemControlRegistrationCommand = new RelayCommand<object>(Column2.ControlRegistrationMethod.SelectParentItem);
            SelectParentItemControlScheduleCommand = new RelayCommand<object>(Column2.ControlScheduleMethod.SelectParentItem);
            SelectParentItemProductionCommand = new RelayCommand<object>(Column2.ProductionMethod.SelectParentItem);
            SelectParentItemShiftRegistrationCommand = new RelayCommand<object>(Column2.ShiftRegistrationMethod.SelectParentItem);
            SelectParentItemTuCommand = new RelayCommand<object>(Column2.TuMethod.SelectParentItem);

            ControlledClickCommand2 = new RelayCommand(Column2.ControlRegistrationMethod.ControlledClickAdd);
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