using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UniBase.Annotations;
using UniBase.View;

namespace UniBase.Model
{
    class ManageLogin : INotifyPropertyChanged
    {
        #region Field

        public string UserName { get; set; }
        public string PassWord { get; set; }
        private string _wrongLogin, _wrongLoginColor;
        private ManageUser _manageUser = ManageUser.Instance;
        private ObservableCollection<string> _logInLogOutList;

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

        public ObservableCollection<string> LogInLogOutList
        {
            get { return _logInLogOutList; }
            set { _logInLogOutList = value; }
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
            LogInLogOutList.Add(_manageUser.CurrentUser.Name + " logged off at " + DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy"));

            Frame currentFrame = Window.Current.Content as Frame;
            currentFrame?.Navigate(typeof(LoginPage));
        }

        public void CheckLogin()
        {
            bool temp = false;
            foreach (var user in _manageUser.Users)
            {
                if (user.UserName == UserName && user.Password == PassWord)
                {
                    _manageUser.CurrentUser = user;
                    LogInLogOutList.Add(UserName + " logged in at " + DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy"));

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
                WrongLogin = "Forkert Password eller Username";
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
