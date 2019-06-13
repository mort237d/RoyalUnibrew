using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    public class ConstantValue : INotifyPropertyChanged
    {
        private string _name;
        private double _minimum;
        private double _maximum;

        public string Name
        {
            get => _name;
            set
            {
                _name = value; 
                OnPropertyChanged();
            }
        }

        public double Minimum
        {
            get => _minimum;
            set
            {
                _minimum = value;
                OnPropertyChanged();
            }
        }

        public double Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value; 
                OnPropertyChanged();
            }
        }


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
