﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
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

        public string PlaceHolderDate { get; set; } = "2000/01/01";
        public string PlaceHolderTimeSpan { get; set; } = "00:00:00";

        public RelayCommand<object> SortFrontpageCommand { get; set; }

        public RelayCommand RefreshFrontpageTable { get; set; }
        public RelayCommand RefreshLastTenControlRegistrationTable { get; set; }
        public RelayCommand SaveFrontpageTable { get; set; }
        public RelayCommand AddFrontpageTable { get; set; }
        public RelayCommand<object> DeleteFrontpageTable { get; set; }

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

        public RelayCommand<object> ControlledClickCommand { get; set; }
        public RelayCommand ControlledClickCommand2 { get; set; }

        public Model.K2.ManageTables Column_2 { get; set; }
        public Colors PredefinedColors { get; set; }

        public SortAndFilter SortAndFilter { get; set; }
        
        public TrendAdminstrator TrendAdminstrator { get; set; }
        public XamlBindings XamlBindings { get; set; }


        public WorkViewModel()
        {
            Column_2 = ManageTables.Instance;
            PredefinedColors = new Colors();
            SortAndFilter = new SortAndFilter();

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

            RefreshFrontpageTable = new RelayCommand(Column_2.RefreshFrontpages);
            RefreshLastTenFrontpageTable = new RelayCommand(Column_2.RefreshLastTenFrontpages);
            SaveFrontpageTable = new RelayCommand(Column_2.SaveFrontpages);
            AddFrontpageTable = new RelayCommand(Column_2.AddNewFrontpages);
            DeleteFrontpageTable = new RelayCommand<object>(Column_2.DeleteFrontpage);

            RefreshControlRegistrationTable = new RelayCommand(Column_2.RefreshControlRegistrations);
            RefreshLastTenControlRegistrationTable = new RelayCommand(Column_2.RefreshLastTenControlRegistrations);
            SaveControlRegistrationTable = new RelayCommand(Column_2.SaveControlRegistrations);
            AddControlRegistrationsTable = new RelayCommand(Column_2.AddNewControlRegistrations);

            RefreshControlScheduleTable = new RelayCommand(Column_2.RefreshControlSchedules);
            RefreshLastTenControlScheduleTable = new RelayCommand(Column_2.RefreshLastTenControlSchedules);
            SaveControlScheduleTable = new RelayCommand(Column_2.SaveControlSchedules);

            RefreshProductionTable = new RelayCommand(Column_2.RefreshProductions);
            RefreshLastTenProductionTable = new RelayCommand(Column_2.RefreshProductions);
            SaveProductionTable = new RelayCommand(Column_2.SaveProductions);

            RefreshShiftRegistrationTable = new RelayCommand(Column_2.RefreshShiftRegistrations);
            RefreshLastTenShiftRegistrationTable = new RelayCommand(Column_2.RefreshLastTenShiftRegistrations);
            SaveShiftRegistrationTable = new RelayCommand(Column_2.SaveShiftRegistrations);

            RefreshTUTable = new RelayCommand(Column_2.RefreshTUs);
            RefreshLastTenTUTable = new RelayCommand(Column_2.RefreshLastTenTUs);
            SaveTUTable = new RelayCommand(Column_2.SaveTUs);

            SortFrontpageCommand = new RelayCommand<object>(SortAndFilter.SortFrontpagesButtonClick);

            ControlledClickCommand = new RelayCommand<object>(Column_2.ControlledClick);

            SelectParentItemFrontpageCommand = new RelayCommand<object>(Column_2.SelectParentItemFrontpage);
            ControlledClickCommand2 = new RelayCommand(Column_2.ControlledClickAdd);
        }

        public RelayCommand<object> SelectParentItemFrontpageCommand { get; set; }

        public RelayCommand<object> ControlledClickCommand { get; set; }

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
