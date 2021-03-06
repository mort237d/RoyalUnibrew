﻿using System;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.UI.Popups;

namespace UniBase.Model
{
    class Message
    {
        private static ManageUser _manageUser;

        public Message()
        {
            
        }
        
        public Message(ManageUser manageUser)
        {
            _manageUser = manageUser;
        }

        #region Methods
        /// <summary>
        /// Displays an error message if the content is not written correct or the user makes an error which they should not.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task Error(string title, string content)
        {
            await new MessageDialog(content, title).ShowAsync();
        }

        /// <summary>
        /// Displays a dialog box where it asks you if are sure you want to do that action because the action is often irreversible.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task YesNo(string title, string content)
        {
            var yesCommand = new UICommand("Ja", cmd => { });
            var noCommand = new UICommand("Nej", cmd => { });

            var dialog = new MessageDialog(content, title) { Options = MessageDialogOptions.None };
            dialog.Commands.Add(yesCommand);

            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 0;

            if (noCommand != null)
            {
                dialog.Commands.Add(noCommand);
                dialog.CancelCommandIndex = (uint)dialog.Commands.Count - 1;
            }

            var command = await dialog.ShowAsync();

            if (command == yesCommand)
            {
                if (title == "Slet bruger")
                {
                    ModelGenerics.DeleteById(_manageUser.SelectedUser, _manageUser.SelectedUser.User_ID, "User_ID", "Bruger ID");
                    ShowToastNotification("Slettet", _manageUser.SelectedUser.Name + " er blevet slettet.");
                    _manageUser.UsersList.Remove(_manageUser.SelectedUser);
                }
            }
            else if (command == noCommand)
            {
            }
        }

        /// <summary>
        /// Method to show different Toastnotifications various places in the program when an action i succesfull. Usually used where some sort of CRUD is used.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="stringContent"></param>
        public void ShowToastNotification(string title, string stringContent)
        {
            ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(2);
            toastNotifier.Show(toast);
        }
        #endregion

        #region Singleton

        private static Message _instance;

        public static Message Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Message();
                }
                return _instance;
            }
        }

        #endregion
    }
}