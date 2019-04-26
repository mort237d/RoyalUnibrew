using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
        private string test = "hej";
        public List<string> Strings { get; set; } = new List<string>{"Du dør", "død"};
        public List<Frontpages> ListFrontpages { get; set; } = new List<Frontpages>{new Frontpages(2, 2, 2, 2, 2, 2, 2, DateTime.Today, "Hej", 2, 2, new Products()), new Frontpages(1, 1, 1, 1, 1, 1, 1, DateTime.Today, "Test", 2, 2, new Products()) };
        public RelayCommand SaveWorkCommand { get; set; }
        ManageTables mngTables = ManageTables.Instance;

        public WorkViewModel()
        {
            Administrator a = new Administrator("Morten", "d","31223437","Hej","?");
            Debug.WriteLine("\n \t" + a.Name, "Admin");
            Debug.WriteLine("\n \tError Message", "Category");
            for (int i = 0; i < 50; i++)
            {
                Strings.Add(i.ToString());
            }
            SaveWorkCommand = new RelayCommand(TempMethod);
        }

        private void TempMethod()
        {

        }

        public string Test
        {
            get => test;
            set
            {
                test = value; 
                OnPropertyChanged();
            }
        }

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
