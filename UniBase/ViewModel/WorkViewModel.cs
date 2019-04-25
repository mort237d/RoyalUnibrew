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
        public RelayCommand SaveWorkCommand { get; set; }
        

        public WorkViewModel()
        {
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
