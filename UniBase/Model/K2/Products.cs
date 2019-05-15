using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class Products : INotifyPropertyChanged
    {
        private int _finishedProductNo;
        private string _productName;
        private int _bestBeforeDateLength;

        public Products(int finishedProductNo, string productName, int bestBeforeDateLength)
        {
            FinishedProductNo = finishedProductNo;
            ProductName = productName;
            BestBeforeDateLength = bestBeforeDateLength;
        }

        public Products()
        {
            
        }

        public int FinishedProductNo
        {
            get => _finishedProductNo;
            set
            {
                if (value == _finishedProductNo) return;
                _finishedProductNo = value;
                OnPropertyChanged();
            }
        }

        public string ProductName
        {
            get => _productName;
            set
            {
                if (value == _productName) return;
                _productName = value;
                OnPropertyChanged();
            }
        }

        public int BestBeforeDateLength
        {
            get => _bestBeforeDateLength;
            set
            {
                if (value == _bestBeforeDateLength) return;
                _bestBeforeDateLength = value;
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
