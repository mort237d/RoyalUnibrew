using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UniBase.Annotations;
using UniBase.View;

namespace UniBase.Model
{
    class ManageLogin : INotifyPropertyChanged
    {
        #region Field
        public string PassWord { get; set; }
        private string _wrongLogin, _wrongLoginColor;
        private ManageUser _manageUser = ManageUser.Instance;

        #endregion

        #region Props

        public string WrongLogin
        {
            get => _wrongLogin;
            set
            {
                _wrongLogin = value;
                OnPropertyChanged();
            }
        }

        public string WrongLoginColor
        {
            get => _wrongLoginColor;
            set
            {
                _wrongLoginColor = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private ManageLogin()
        {

        }

        #region Singleton

        private static ManageLogin _instance;
        public static ManageLogin Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManageLogin();
                }
                return _instance;
            }
        }

        #endregion

        #region ButtonMethods

        public void LogOffMethod()
        {
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame?.Navigate(typeof(LoginPage));
        }

        public void CheckLogin()
        {
            bool temp = false;
            foreach (var user in _manageUser.Users)
            {
                if (user.Password == PassWord)
                {
                    _manageUser.CurrentUser = user;

                    _manageUser.ButtonVisibility(user);

                    PassWord = null;

                    temp = true;
                    break;
                }
            }
            if (temp)
            {
                Frame currentFrame = Window.Current.Content as Frame;
                currentFrame?.Navigate(typeof(WorkPage));
            }
            else
            {
                WrongLogin = "Kodeord stemmer ikke overens";
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
