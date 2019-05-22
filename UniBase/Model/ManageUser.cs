﻿using System.Collections.ObjectModel;
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

        public readonly string StandardImage = "Images/User.png";

        private string _nameTb, _emailTb, _telephoneNumberTb, _passwordTb, _confirmPasswordTb;
        private string _imageTb = "";

        private static string _currentUserName;

        private string _visible;

        private ObservableCollection<Users> _usersList;
        private static Users _selectedUsers, _currentUsers;

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
                FillTbWithSelectedUserInfo();

                OnPropertyChanged();
            }
        }

        private void FillTbWithSelectedUserInfo()
        {
            NameTb = SelectedUsers.Name;
            EmailTb = SelectedUsers.Email;
            TelephoneNumberTb = SelectedUsers.Telephone_No;
            PasswordTb = SelectedUsers.Password;
            ConfirmPasswordTb = SelectedUsers.Password;
            ImageTb = SelectedUsers.ImageSource;
        }

        public void ClearTb()
        {
            NameTb = null;
            EmailTb = null;
            TelephoneNumberTb = null;
            PasswordTb = null;
            ConfirmPasswordTb = null;
            ImageTb = null;
        }

        public Users CurrentUsers
        {
            get { return _currentUsers; }
            set
            {
                _currentUsers = value;
                CurrentUserName = "  Bruger: " + _currentUsers.Name;
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
            Load();

            _message = new Message(this);
        }

        private async void Load()
        {
            UsersList = await ModelGenerics.GetAll(new Users());
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

        public string CurrentUserName
        {
            get { return _currentUserName; }
            set
            {
                _currentUserName = value;
            }
        }

        #endregion



        #region ButtonMethods

        public async void BrowseImageButton()
        {
            //ImageTb = await _browseImages.BrowseImageWindow("UserImages/");
        }
        /// <summary>
        /// Adds user to local list and then adds to the database with the ModelGenerics class.
        /// </summary>
        public async void AddUser()
        {
            bool passwordExists = false;
            foreach (var user in UsersList)
            {
                if (PasswordTb == user.Password)
                {
                    passwordExists = true;
                    break;
                }
            }

            if ((NameTb ?? EmailTb ?? TelephoneNumberTb ?? PasswordTb) != null)
            {
                if (!passwordExists)
                {
                    if (EmailTb.Contains(".dk") || EmailTb.Contains(".com"))
                    {
                        if (int.TryParse(TelephoneNumberTb, out _) && TelephoneNumberTb.Length == 8)
                        {
                            if (PasswordTb == ConfirmPasswordTb)
                            {
                                if (string.IsNullOrEmpty(ImageTb))
                                {
                                    UsersList.Add(new Users(_usersList.Last().User_ID, NameTb, EmailTb, TelephoneNumberTb, PasswordTb, StandardImage));
                                    ModelGenerics.CreateByObject(new Users(_usersList.Last().User_ID, NameTb, EmailTb, TelephoneNumberTb, PasswordTb, StandardImage));
                                }
                                else
                                {
                                    UsersList.Add(new Users(_usersList.Last().User_ID, NameTb, EmailTb, TelephoneNumberTb, PasswordTb, ImageTb));
                                    ModelGenerics.CreateByObject(new Users(_usersList.Last().User_ID, NameTb, EmailTb, TelephoneNumberTb, PasswordTb, ImageTb));
                                }
                                NameTb = EmailTb = TelephoneNumberTb = ImageTb = PasswordTb = ConfirmPasswordTb = null;
                            }
                            else await _message.Error("Uoverensstemmelser","kodeord stemmer ikke overens med bekræft kodeord");
                        }
                        else await _message.Error("Forkert input", "Telefonnummert skal være et tal på 8 cifre.");
                    }
                    else await _message.Error("Forkert email", "Du skal bruge en \".dk\" eller en \".com\" mail.");
                }
                else await _message.Error("Kodeordet eksisterer allerede", "Vælg et andet kodeord");
            }
            else await _message.Error("Manglende input", "Tekstfelter mangler at blive udfyldt");
        }
        
        /// <summary>
        /// Removes the user from the database and then from the local list via the Message class.
        /// </summary>
        public async void RemoveUser()
        {
            if (_selectedUsers != null)
            {
                if (!_selectedUsers.Equals(_currentUsers))
                {
                    string temp = SelectedUsers.Name;
                    await _message.YesNo("Slet bruger", "Er du sikker på at du vil slette " + temp + "?");
                }
                else await _message.Error("Fejl", "Du kan ikke slette dig selv");
            }
            else await _message.Error("Ingen bruger valgt", "Vælg venligst en bruger.");
        }

        /// <summary>
        /// Updates the user in the database and then from the local list.
        /// </summary>
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
