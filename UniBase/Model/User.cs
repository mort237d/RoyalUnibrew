using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model
{
    class User : INotifyPropertyChanged
    {
        #region Field

        private string _name, _email, _telephoneNumber, _password, _imageSource, _admin;

        #endregion

        #region Constructors
        //TODO Admin skal ændres til en int eller andet.
        public User(string name, string email, string telephoneNumber, string password, string imageSource, string admin)
        {
            Name = name;
            Email = email;
            TelephoneNumber = telephoneNumber;
            Password = password;
            ImageSource = imageSource;
            Admin = admin;
        }

        public User()
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
        public string TelephoneNumber
        {
            get => _telephoneNumber;
            set
            {
                _telephoneNumber = value;
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

        public string Admin
        {
            get { return _admin; }
            set
            {
                _admin = value;
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
