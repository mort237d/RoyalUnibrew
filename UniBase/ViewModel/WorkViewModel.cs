using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using ModelLibrary;
using UniBase.Annotations;
using UniBase.Model;

namespace UniBase.ViewModel
{
    class WorkViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Frontpages> ListFrontpages { get; set; } 
        public ObservableCollection<ControlSchedules> ListControlScheduleses { get; set; }

        public TrendAdminstrator _trendAdminstrator = new TrendAdminstrator();
        public RelayCommand SaveWorkCommand { get; set; }
        public RelayCommand TestCommand { get; set; }

        public ManageTables MngTables { get; set; }

        public WorkViewModel()
        {
            MngTables = ManageTables.Instance;

            ListFrontpages = MngTables._frontpagesList;
            ListControlScheduleses = MngTables._controlSchedulesList;
            Administrator a = new Administrator("Morten", "d","31223437","Hej","?");
            Debug.WriteLine("\n \t" + a.Name, "Admin");
            Debug.WriteLine("\n \tError Message", "Category");
            //Debug.WriteLine("\n \tError Message", ListFrontpages[1].Product.ProductName);

            SaveWorkCommand = new RelayCommand(TempMethod);
            TestCommand = new RelayCommand(TempMethod);
        }

        private void TempMethod()
        {
            Debug.WriteLine("CLicked", "Button");
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
