using System.ComponentModel;
using System.Runtime.CompilerServices;
using UniBase.Annotations;

namespace UniBase.Model.Login
{
    public class Users : INotifyPropertyChanged
    {
        #region Field

        private int _userId;
        private string _name;
        private string _imageSource;
        private string _password;
        private string _telephoneNo;
        private string _email;
        private bool _administratorStatus;

        public Users()
        {
            
        }

        public Users(int user_ID, string name, string email, string telephone_No, string password, string imageSource, bool administratorStatus)
        {
            User_ID = user_ID;
            Name = name;
            Email = email;
            Telephone_No = telephone_No;
            Password = password;
            ImageSource = imageSource;
            AdministratorStatus = administratorStatus;
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

        public bool AdministratorStatus
        {
            get { return _administratorStatus; }
            set { _administratorStatus = value; }
        }

        #endregion

        public override bool Equals(object obj)
        {
            Users userToCompare = obj as Users;
            if (obj == null)
            {
                return false;
            }
            return userToCompare.User_ID == User_ID && 
                   userToCompare.Password == Password &&
                   userToCompare.Email == Email && 
                   userToCompare.Name == Name &&
                   userToCompare.Telephone_No == Telephone_No;
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
