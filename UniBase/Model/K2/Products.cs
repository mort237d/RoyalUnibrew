using System;
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
        
        #region Properties

        public string FinishedProduct_No
        {
            get
            {
                if (_finishedProductNo != 0) return _finishedProductNo.ToString();
                else return string.Empty;
            }
            set
            {
                _finishedProductNo = Convert.ToInt32(value);
                OnPropertyChanged();
            }
        }

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged();
            }
        }

        public string BestBeforeDateLength
        {
            get
            {
                if (_bestBeforeDateLength != 0) return _bestBeforeDateLength.ToString();
                else return string.Empty;
            }
            set
            {
                _bestBeforeDateLength = Convert.ToInt32(value);
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
