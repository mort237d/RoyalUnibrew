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
        public ObservableCollection<>

        public TrendAdminstrator _trendAdminstrator = new TrendAdminstrator();
        public RelayCommand SaveWorkCommand { get; set; }
        ManageTables mngTables = ManageTables.Instance;

        public WorkViewModel()
        {
            ListFrontpages = mngTables._frontpagesList;
            ListControlScheduleses = mngTables._controlSchedulesList;
            Administrator a = new Administrator("Morten", "d","31223437","Hej","?");
            Debug.WriteLine("\n \t" + a.Name, "Admin");
            Debug.WriteLine("\n \tError Message", "Category");
            Debug.WriteLine("\n \tError Message", ListFrontpages[1].Product.ProductName);

            SaveWorkCommand = new RelayCommand(TempMethod);


        }

        private void TempMethod()
        {

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
