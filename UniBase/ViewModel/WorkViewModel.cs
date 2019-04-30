using System;
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
                _trendAdminstrator.GraphComboboxSelectedMethod(_graphCombobox);
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

      
        private void TempMethod()
        {
            Debug.WriteLine("Hej", "Button Clicked");
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
