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
            Products v = ModelGenerics.GetById(new Products(), 222222);
            Debug.WriteLine(v.ProductName);
            test = v.ProductName;
            //ModelGenerics.UpdateByObjectAndId(1, changedProduct);
            // v = ModelGenerics.GetById(new Product(), 1);
            //test = v.BedstBeforeDateLength.ToString();
            //v = ModelGenerics.GetById(new Product(), 2222);
            //Debug.WriteLine(v.ProductName);

            ModelGenerics.DeleteById(new Products(), 2222);
            v = ModelGenerics.GetById(new Products(), 2222);
            Debug.WriteLine(v.ProductName);

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
