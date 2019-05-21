using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Windows.Web.Http.Headers;
using UniBase.Annotations;
using UniBase.Model.Login;

namespace UniBase.Model
{
    class ManageUser : INotifyPropertyChanged
    {
        #region Field

        private static Message _message;
        //BrowseImage _browseImages = new BrowseImage();

        public readonly string StandardImage = "UserImages/Profile-icon.png";

        private string _nameTb, _emailTb, _telephoneNumberTb, _passwordTb, _confirmPasswordTb;
        private string _imageTb = "";

        private string _visible;

        private ObservableCollection<Users> _usersList;
        private Users _selectedUsers, _currentUsers;

        #endregion

        #region Props

        public string NameTb
        {
            get => _nameTb;
            set
            {
                _nameTb = value;
                OnPropertyChanged();
            }
        }

        public string EmailTb
        {
            get => _emailTb;
            set
            {
                _emailTb = value;
                OnPropertyChanged();
            }
        }

        public string TelephoneNumberTb
        {
            get => _telephoneNumberTb;
            set
            {
                _telephoneNumberTb = value;
                OnPropertyChanged();
            }
        }

        public string ImageTb
        {
            get { return _imageTb; }
            set
            {
                _imageTb = value;
                OnPropertyChanged();
            }
        }

        public string PasswordTb
        {
            get => _passwordTb;
            set
            {
                _passwordTb = value;
                OnPropertyChanged();
            }
        }

        public string ConfirmPasswordTb
        {
            get => _confirmPasswordTb;
            set
            {
                _confirmPasswordTb = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Users> UsersList
        {
            get => _usersList;
            set
            {
                _usersList = value;
                OnPropertyChanged();
            }
        }

        public Users SelectedUsers
        {
            get => _selectedUsers;
            set
            {
                _selectedUsers = value;
                OnPropertyChanged();
            }
        }

        public Users CurrentUsers
        {
            get { return _currentUsers; }
            set
            {
                _currentUsers = value;
                OnPropertyChanged();
            }
        }

        public string Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ManageUser()
        {
            UsersList = ModelGenerics.GetAll(new Users());

            _message = new Message(this);
        }

        #region Singleton

        private static ManageUser _instance;

        public static ManageUser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ManageUser();
                }
                return _instance;
            }
        }

        #endregion



        #region ButtonMethods

        public async void BrowseImageButton()
        {
            //ImageTb = await _browseImages.BrowseImageWindow("UserImages/");
        }

        public async void AddUser()
        {
            if ((NameTb ?? EmailTb ?? TelephoneNumberTb ?? PasswordTb) != null)
            {
                //if ()
                //{
                    
                //}
                if (EmailTb.Contains(".dk") || EmailTb.Contains(".com"))
                {
                    if (int.TryParse(TelephoneNumberTb, out _) && TelephoneNumberTb.Length == 8)
                    {
                        if (PasswordTb == ConfirmPasswordTb)
                        {
                                UsersList.Add(new Users(_usersList.Last().User_ID + 1, NameTb, EmailTb, TelephoneNumberTb, PasswordTb, ImageTb));
                                ModelGenerics.CreateByObject(new Users(_usersList.Last().User_ID + 1, NameTb, EmailTb, TelephoneNumberTb, PasswordTb,
                                    "e"));

                            NameTb = EmailTb = TelephoneNumberTb = ImageTb = PasswordTb = ConfirmPasswordTb = null;
                        }
                        else await _message.Error("Uoverensstemmelser", "kodeord stemmer ikke overens med bekræft kodeord");
                    }
                    else await _message.Error("Forkert input", "Telefonnummert skal være et tal på 8 cifre.");
                }
                else await _message.Error("Forkert email", "Du skal bruge en \".dk\" eller en \".com\" mail.");
            }
            else await _message.Error("Manglende input", "Tekstfelter mangler at blive udfyldt");
        }

        public async void RemoveUser()
        {
            if (SelectedUsers != CurrentUsers)
            {
                if (SelectedUsers != null)
                {
                    string hje = SelectedUsers.Name;
                    await _message.YesNo("Slet bruger", "Er du sikker på at du vil slette " + hje + "?");
                }
                else await _message.Error("Ingen bruger valgt", "Vælg venligst en bruger.");
            }
        }

        public async void ChangeSelectedUser()
        {
            if (SelectedUsers.Name == NameTb || SelectedUsers.Email == EmailTb ||
                SelectedUsers.Telephone_No == TelephoneNumberTb || SelectedUsers.ImageSource == ImageTb ||
                SelectedUsers.Password == PasswordTb)
            {
                if (PasswordTb == ConfirmPasswordTb)
                {
                    ModelGenerics.UpdateByObjectAndId(_selectedUsers.User_ID, _selectedUsers);
                    SelectedUsers.Name = NameTb;
                    SelectedUsers.Email = EmailTb;
                    SelectedUsers.Telephone_No = TelephoneNumberTb;
                    SelectedUsers.ImageSource = ImageTb;
                    SelectedUsers.Password = PasswordTb;
                }
                else await _message.Error("Forkert kodeord", "kodeord stemmer ikke overens");
            }
             else await _message.Error("Fejl", "Intet er ændret prøv igen");
        }

        public void ButtonVisibility(Users usersToCheck)
        {
            Visible = usersToCheck is Administrator ? "Visible" : "Collapsed";
        }

        public async void ChangeAdmin()
        {
            if (SelectedUsers != null) await _message.YesNo("Giv admin videre", "Er du sikker på at du vil give admin videre til " + SelectedUsers.Name + "?");
            else await _message.Error("Ingen bruger valgt", "Vælg venligst en bruger.");
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
