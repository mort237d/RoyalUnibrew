﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using ModelLibrary;
using UniBase.Annotations;
using UniBase.Model;

namespace UniBase.ViewModel
{
    class WorkViewModel : INotifyPropertyChanged
    {
        

        public TrendAdminstrator _trendAdminstrator = new TrendAdminstrator();
        private string _graphCombobox;
        public RelayCommand SaveWorkCommand { get; set; }
        public RelayCommand TestCommand { get; set; }

        public ManageTables Column_2 { get; set; }

        public string GraphCombobox
        {
            get { return _graphCombobox; }
            set
            {
                _graphCombobox = value; 
                OnPropertyChanged();
                if (_graphCombobox == "Weight")
                {
                    _trendAdminstrator.CreateWeightGraph();
                }
                else if (_graphCombobox == "MipMa")
                {
                    _trendAdminstrator.CreateMipMAGraph();
                }
                else if (_graphCombobox == "Lud Koncentration")
                {
                    _trendAdminstrator.CreateLudKoncentrationGraph();
                }
            }
        }

        public WorkViewModel()
        {
            Column_2 = ManageTables.Instance;
            
            Administrator a = new Administrator("Morten", "d","31223437","Hej","?");
            Debug.WriteLine("\n \t" + a.Name, "Admin");
            Debug.WriteLine("\n \tError Message", "Category");

            SaveWorkCommand = new RelayCommand(TempMethod);
            TestCommand = new RelayCommand(TempMethod);
        }

        private Button _frontPageButton;

        public Button FrontPageButton
        {
            get
            {
                return this._frontPageButton;
            }
            set
            {
                this._frontPageButton = value;
            }
        }
        private void TempMethod()
        {
            if (FrontPageButton.Name.ToLower() == "finishedproduct_no")
            {
                Debug.WriteLine("Yay", "Button");
            }
            else
            {
                Debug.WriteLine("...", "Button");
            }
        }

        #region Propeties

        public TrendAdminstrator TrendAdminstrator
        {
            get { return _trendAdminstrator; }
            set { _trendAdminstrator = value; }
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
