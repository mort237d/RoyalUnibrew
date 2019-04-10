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
            Product testProduct = new Product(){BedstBeforeDateLength = 2222, ProductName = "TestProduct", FinishedProduct_No = 2222};
            Product changedProduct = new Product() { BedstBeforeDateLength = 1111, ProductName = "TestProduct", FinishedProduct_No = 2222 };

            ModelGenerics.CreateByObject(testProduct);
            Product v = ModelGenerics.GetById(new Product(), 2222);
            Debug.WriteLine(v.ProductName);

            //ModelGenerics.UpdateByObjectAndId(2222, changedProduct);
            //v = ModelGenerics.GetById(new Product(), 2222);
            //Debug.WriteLine(v.ProductName);

            //ModelGenerics.DeleteById(new Product(), 2222);
            //v = ModelGenerics.GetById(new Product(), 2222);
            //Debug.WriteLine(v.ProductName);

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
