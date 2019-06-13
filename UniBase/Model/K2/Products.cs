using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class Products : INotifyPropertyChanged
    {
        #region Fields

        private int _finishedProductNo;
        private string _productName;
        private int _bestBeforeDateLength;

        #endregion

        #region Constructors

        public Products()
        {
            
        }

        public Products(int finishedProduct_No, string productName, int bestBeforeDateLength)
        {
            FinishedProduct_No = finishedProduct_No;
            ProductName = productName;
            BestBeforeDateLength = bestBeforeDateLength;
        }

        #endregion

        #region Properties

        public int FinishedProduct_No
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

        #endregion

        #region INotify
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
