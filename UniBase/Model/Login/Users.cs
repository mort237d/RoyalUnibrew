using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.Login
{
    class Users : INotifyPropertyChanged
    {
        #region Field

        private string _name, _email, _telephoneNo, _password, _imageSource;

        #endregion

        #region Constructors
        //TODO Admin skal ændres til en int eller andet.
        public Users(string name, string email, string telephoneNo, string password, string imageSource)
        {
            Name = name;
            Email = email;
            Telephone_No = telephoneNo;
            Password = password;
            ImageSource = imageSource;
        }

        public Users()
        {

        }

        #endregion

        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
       
      
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public string Telephone_No
        {
            get => _telephoneNo;
            set
            {
                _telephoneNo = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
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
