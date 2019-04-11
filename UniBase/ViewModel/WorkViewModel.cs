using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using ModelLibrary;
using UniBase.Annotations;

namespace UniBase.ViewModel
{
    class WorkViewModel : INotifyPropertyChanged
    {
        private string test = "hej";

        public WorkViewModel()
        {
            Products testProduct = new Products(222222, "TesttProduct", 222222);
            Products changedProduct = new Products(1, "Royal Beer", 10);

            ModelGenerics.CreateByObject(testProduct);
            List<Products> v = ModelGenerics.GetAll(new Products());
            foreach (var va in v)
            {
                Debug.WriteLine(va.ProductName);
            }
            


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
