using System.ComponentModel;
using System.Runtime.CompilerServices;
using ModelLibrary;
using UniBase.Annotations;

namespace UniBase.ViewModel
{
    class WorkViewModel : INotifyPropertyChanged
    {
        private string test= "hej";

        public WorkViewModel()
        {
            Product v = ModelGenerics.GetById(new Product(), 1);

            test = v.ProductName;
        }
        
        public string Test
        {
            get { return test; }
            set
            {
                test = value; 
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
