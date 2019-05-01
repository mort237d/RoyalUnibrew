﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using ModelLibrary;
using UniBase.Annotations;
using UniBase.Model;
using UniBase.Model.K2;
using UniBase.Model.Login;
using UniBase.View;

namespace UniBase.ViewModel
{
    class WorkViewModel : INotifyPropertyChanged
    {
        private string _graphCombobox;

        public RelayCommand SaveWorkCommand { get; set; }
        public RelayCommand TestCommand { get; set; }
        public RelayCommand RefreshFrontpageTable { get; set; }
        public RelayCommand DeleteFrontpageTable { get; set; }
        public RelayCommand AddFrontpageTable { get; set; }

        public Model.K2.ManageTables Column_2 { get; set; }
        public Colors PredefinedColors { get; set; }
        
        public TrendAdminstrator TrendAdminstrator { get; set; } 
        
        public WorkViewModel()
        {
            Column_2 = ManageTables.Instance;
            PredefinedColors = new Colors();

            TrendAdminstrator = new TrendAdminstrator();

            SaveWorkCommand = new RelayCommand(Column_2.SaveFrontpages);
            RefreshFrontpageTable = new RelayCommand(Column_2.RefreshFrontpages);
            DeleteFrontpageTable = new RelayCommand(TempMethod);
            AddFrontpageTable = new RelayCommand(TempMethod);

            TestCommand = new RelayCommand(TempMethod);
        }

      
        private void TempMethod()
        {
            Debug.WriteLine("\n \tHej", "Button Clicked");
        }

        #region Properties
        public string GraphCombobox
        {
            get { return _graphCombobox; }
            set
            {
                _graphCombobox = value;
                OnPropertyChanged();
                TrendAdminstrator.GraphComboboxSelectedMethod(_graphCombobox);
            }
        }

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
