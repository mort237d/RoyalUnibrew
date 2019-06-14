using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UniBase.Annotations;
using UniBase.Model.K2;
using UniBase.View;

namespace UniBase.Model
{
    public class ManageLogin : INotifyPropertyChanged
    {
        #region Fields
        public string PassWord { get; set; }
        private string _wrongLogin, _wrongLoginColor;
        private ManageUser _manageUser = ManageUser.Instance;
        private bool _progressActive;

        #endregion
        
        public ManageLogin()
        {
            WrongLogin = null;
        }

        #region Properties

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

        public bool ProgressActive
        {
            get { return _progressActive; }
            set
            {
                _progressActive = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region RelayCommandMethods

        /// <summary>
        /// A method to log out of the current user, we simply navigate back to the LoginPage.
        /// </summary>
        public void LogOffMethod()
        {
            WrongLogin = null;
            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame?.Navigate(typeof(LoginPage));
        }

        /// <summary>
        /// A method to check if your login credentials are correct. Here we only use the password because P.O. requested a system to be able to log in fast so the production was not halted. We navigate from the LoginPage to the WorkPage.
        /// </summary>
        public async void CheckLogin()
        {
            ProgressActive = true;
            WrongLogin = null;
            bool temp = false;
            _manageUser.UsersList = await ModelGenerics.GetAll(new Users());

            foreach (var user in _manageUser.UsersList)
            {
                if (user.Password == PassWord)
                {
                    _manageUser.CurrentUsers = user;

                    PassWord = null;
                    WrongLogin = null;
                    temp = true;
                    break;
                }
            }

            if (temp)
            {
                Frame currentFrame = Window.Current.Content as Frame;
                currentFrame?.Navigate(typeof(WorkPage));
                ProgressActive = false;
            }
            else
            {
                WrongLogin = "Kodeord stemmer ikke overens";
                ProgressActive = false;
            }
        }

        #endregion

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
