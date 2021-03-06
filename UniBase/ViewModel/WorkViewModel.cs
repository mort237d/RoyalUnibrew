﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using GalaSoft.MvvmLight.Command;
using UniBase.Annotations;
using UniBase.Model;
using UniBase.Model.K2;

namespace UniBase.ViewModel
{
    class WorkViewModel
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
        public RelayCommand LogOffCommand { get; set; }

        public RelayCommand<object> ControlledClickCommand { get; set; }
        public RelayCommand ControlledClickCommand2 { get; set; }

        public RelayCommand<object> SelectParentItemFrontpageCommand { get; set; }
        public RelayCommand<object> SelectParentItemControlRegistrationCommand { get; set; }
        public RelayCommand<object> SelectParentItemControlScheduleCommand { get; set; }
        public RelayCommand<object> SelectParentItemProductionCommand { get; set; }
        public RelayCommand<object> SelectParentItemShiftRegistrationCommand { get; set; }
        public RelayCommand<object> SelectParentItemTuCommand { get; set; }

        public RelayCommand AdminCheckClickCommand { get; set; }

        public RelayCommand ClearTbCommand { get; set; }
        #endregion

        public Column2Facade Column2FacadePath { get; set; }
        
        public WorkViewModel()
        {
            Column2FacadePath = Column2Facade.Instance;


            //Frontpage
            RefreshFrontpageTable = new RelayCommand(Column2FacadePath.FrontpageMethod.RefreshAll);
            RefreshLastTenFrontpageTable = new RelayCommand(Column2FacadePath.FrontpageMethod.RefreshLastTen);
            SaveFrontpageTable = new RelayCommand(Column2FacadePath.FrontpageMethod.SaveAll);
            AddFrontpageTable = new RelayCommand(Column2FacadePath.FrontpageMethod.AddNewItem);
            DeleteFrontpageTable = new RelayCommand(Column2FacadePath.FrontpageMethod.DeleteItem);

            //ControlRegistration
            RefreshControlRegistrationTable = new RelayCommand(Column2FacadePath.ControlRegistrationMethod.RefreshAll);
            RefreshLastTenControlRegistrationTable = new RelayCommand(Column2FacadePath.ControlRegistrationMethod.RefreshLastTen);
            SaveControlRegistrationTable = new RelayCommand(Column2FacadePath.ControlRegistrationMethod.SaveAll);
            AddControlRegistrationsTable = new RelayCommand(Column2FacadePath.ControlRegistrationMethod.AddNewItem);
            DeleteControlRegistrationTable = new RelayCommand(Column2FacadePath.ControlRegistrationMethod.DeleteItem);

            //ControlSchedule
            RefreshControlScheduleTable = new RelayCommand(Column2FacadePath.ControlScheduleMethod.RefreshAll);
            RefreshLastTenControlScheduleTable = new RelayCommand(Column2FacadePath.ControlScheduleMethod.RefreshLastTen);
            SaveControlScheduleTable = new RelayCommand(Column2FacadePath.ControlScheduleMethod.SaveAll);
            AddControlScheduleTable = new RelayCommand(Column2FacadePath.ControlScheduleMethod.AddNewItem);
            DeleteControlScheduleTable = new RelayCommand(Column2FacadePath.ControlScheduleMethod.DeleteItem);

            //Production
            RefreshProductionTable = new RelayCommand(Column2FacadePath.ProductionMethod.RefreshAll);
            RefreshLastTenProductionTable = new RelayCommand(Column2FacadePath.ProductionMethod.RefreshLastTen);
            SaveProductionTable = new RelayCommand(Column2FacadePath.ProductionMethod.SaveAll);
            AddProductionTable = new RelayCommand(Column2FacadePath.ProductionMethod.AddNewItem);
            DeleteProductionTable = new RelayCommand(Column2FacadePath.ProductionMethod.DeleteItem);

            //ShiftRegistration
            RefreshShiftRegistrationTable = new RelayCommand(Column2FacadePath.ShiftRegistrationMethod.RefreshAll);
            RefreshLastTenShiftRegistrationTable = new RelayCommand(Column2FacadePath.ShiftRegistrationMethod.RefreshLastTen);
            SaveShiftRegistrationTable = new RelayCommand(Column2FacadePath.ShiftRegistrationMethod.SaveAll);
            AddShiftRegistrationTable = new RelayCommand(Column2FacadePath.ShiftRegistrationMethod.AddNewItem);
            DeleteShiftRegistrationTable = new RelayCommand(Column2FacadePath.ShiftRegistrationMethod.DeleteItem);

            //TU
            RefreshTUTable = new RelayCommand(Column2FacadePath.TuMethod.RefreshAll);
            RefreshLastTenTUTable = new RelayCommand(Column2FacadePath.TuMethod.RefreshLastTen);
            SaveTUTable = new RelayCommand(Column2FacadePath.TuMethod.SaveAll);
            AddTUTable = new RelayCommand(Column2FacadePath.TuMethod.AddNewItem);
            DeleteTUTable = new RelayCommand(Column2FacadePath.TuMethod.DeleteItem);

            //Users
            AddUserCommand = new RelayCommand(Column2FacadePath.ManageUser.AddUser);
            DeleteUserCommand = new RelayCommand(Column2FacadePath.ManageUser.RemoveUser);
            ChangeUserCommand = new RelayCommand(Column2FacadePath.ManageUser.ChangeSelectedUser);
            ClearTbCommand = new RelayCommand(Column2FacadePath.ManageUser.ClearTb);
            AdminCheckClickCommand = new RelayCommand(Column2FacadePath.ManageUser.AdminCheckClick);
            LogOffCommand = new RelayCommand(Column2FacadePath.ManageLogin.LogOffMethod);

            //Sort
            SortFrontpageCommand = new RelayCommand<object>(Column2FacadePath.FrontpageMethod.SortButtonClick);
            SortControlRegistrationCommand = new RelayCommand<object>(Column2FacadePath.ControlRegistrationMethod.SortButtonClick);
            SortControlScheduleCommand = new RelayCommand<object>(Column2FacadePath.ControlScheduleMethod.SortButtonClick);
            SortProductionCommand = new RelayCommand<object>(Column2FacadePath.ProductionMethod.SortButtonClick);
            SortShiftRegistrationCommand = new RelayCommand<object>(Column2FacadePath.ShiftRegistrationMethod.SortButtonClick);
            SortTuCommand = new RelayCommand<object>(Column2FacadePath.TuMethod.SortButtonClick);

            ControlledClickCommand = new RelayCommand<object>(Column2FacadePath.ControlRegistrationMethod.CheckBoxClick);

            //SelectParent
            SelectParentItemFrontpageCommand = new RelayCommand<object>(Column2FacadePath.FrontpageMethod.SelectParentItem);
            SelectParentItemControlRegistrationCommand = new RelayCommand<object>(Column2FacadePath.ControlRegistrationMethod.SelectParentItem);
            SelectParentItemControlScheduleCommand = new RelayCommand<object>(Column2FacadePath.ControlScheduleMethod.SelectParentItem);
            SelectParentItemProductionCommand = new RelayCommand<object>(Column2FacadePath.ProductionMethod.SelectParentItem);
            SelectParentItemShiftRegistrationCommand = new RelayCommand<object>(Column2FacadePath.ShiftRegistrationMethod.SelectParentItem);
            SelectParentItemTuCommand = new RelayCommand<object>(Column2FacadePath.TuMethod.SelectParentItem);

            ControlledClickCommand2 = new RelayCommand(Column2FacadePath.ControlRegistrationMethod.CheckBoxClickAdd);


            //Test stuff
            //AddFrontpageTable = new RelayCommand(UpdateListsblaaa);
        }

        private async void UpdateListsblaaa()
        {
            bool add = true;
            int month = 05;
            int day = 17;
            int year = 2019;
            int hour = 1;
            double weight = 0;
            double mipMa = 0;
            double ludKoncentration = 0;
            int processordernext = 1;
            int start = 1;
            int amountToAdd = 55;
            var listi = await ModelGenerics.GetLastTenInDatabase(new ControlSchedules(), "ControlSchedule_ID", "Kontrol Skema");
            var processOrderNo = listi.Last().ControlSchedule_ID;
            //Udfyld controlschdual.
            Random random = new Random();
            if (add)
            {
                for (int i = start; i < amountToAdd; i++)
                {
                    weight = Math.Round((random.NextDouble() * 1.65 + 36.92), 2);
                    mipMa = Math.Round((random.NextDouble() * 2.65 + 23.92), 2);
                    ludKoncentration = Math.Round((random.NextDouble() * 1.15 + 0.92), 2);
                    ModelGenerics.CreateByObject(
                        new ControlSchedules(i + processOrderNo, new DateTime(year, month, day, hour, 30, 0), weight, "OK",
                            ludKoncentration, mipMa, "IEO", "", processordernext), "ControlSchedule_ID",
                        "Kontrol Skema");

                    processordernext++;
                    if (processordernext > 19)
                    {
                        processordernext = 1;
                    }

                    hour += 2;
                    if (hour > 9)
                    {
                        hour = 1;
                        day++;
                    }

                    if (day == 29)
                    {
                        month++;
                        day = 1;
                    }

                    if (month > 11)
                    {
                        year++;
                        month = 1;
                    }
                }
            }
            else
            {
                foreach (var VARIABLE in Column2FacadePath.ControlScheduleMethod.CompleteControlSchedulesList)
                {
                    if (VARIABLE.Time > new DateTime(2019, 05, 17))
                    {
                        VARIABLE.Time = new DateTime(year, month, day, hour, random.Next(0, 59), 0);
                        VARIABLE.Weight = Math.Round((random.NextDouble() * 1.65 + 36.92), 2);
                        VARIABLE.MipMA = Math.Round((random.NextDouble() * 2.65 + 23.92), 2);
                        VARIABLE.LudKoncentration = Math.Round((random.NextDouble() * 1.15 + 0.92), 2);
                        ModelGenerics.UpdateByObjectAndId(VARIABLE.ControlSchedule_ID, VARIABLE, "ControlSchedule_ID", "Kontrol Skema");
                        hour += 2;
                        if (hour > 9)
                        {
                            hour = 1;
                            day++;
                        }
                        if (day == 29)
                        {
                            month++;
                            day = 1;
                        }

                        if (month > 11)
                        {
                            year++;
                            month = 1;
                        }
                    }
                }
            }
            ControlledClickCommand2 = new RelayCommand(Column2FacadePath.ControlRegistrationMethod.CheckBoxClickAdd);
        }
    }
}