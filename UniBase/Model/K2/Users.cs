using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UniBase.Annotations;

namespace UniBase.Model.K2
{
    class Users : INotifyPropertyChanged
    {
        #region Field

        private int _userId;
        private string _name;
        private string _imageSource;
        private string _password;
        private string _telephoneNo;
        private string _email;

        ManageUser manageUser = ManageUser.Instance;

        public Users()
        {
            
        }

        public Users(int user_ID, string name, string email, string telephone_No, string password, string imageSource)
        {
            User_ID = user_ID;
            Name = name;
            Email = email;
            Telephone_No = telephone_No;
            Password = password;
            ImageSource = imageSource;
        }

        #endregion

        #region Properties

        public int User_ID
        {
            get => _userId;
            set
            {
                if (value == _userId) return;
                _userId = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value == _email) return;
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Telephone_No
        {
            get => _telephoneNo;
            set
            {
                if (value == _telephoneNo) return;
                _telephoneNo = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password) return;
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ImageSource
        {
            get => _imageSource;
            set
            {
                if (value == _imageSource) return;
                _imageSource = value;
                OnPropertyChanged();
            }
        }

        #endregion

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
