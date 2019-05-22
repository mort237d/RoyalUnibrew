using System;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.UI.Popups;

namespace UniBase.Model
{
    class Message
    {
        #region Field

        private static ManageUser _manageUser;
        

        #endregion

        public Message(ManageUser manageUser)
        {
            _manageUser = manageUser;
        }

        public Message()
        {
            
        }

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

        #region Methods

        public async Task Error(string title, string content)
        {
            await new MessageDialog(content, title).ShowAsync();
        }

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
                    ModelGenerics.DeleteById(_manageUser.SelectedUser, _manageUser.SelectedUser.User_ID);
                    ShowToastNotification("Slettet", _manageUser.SelectedUser.Name + " er blevet slettet.");
                    _manageUser.UsersList.Remove(_manageUser.SelectedUser);
                }

                
            }
            else if (command == noCommand)
            {
            }
        }

        public void ShowToastNotification(string title, string stringContent)
        {
            ToastNotifier toastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(4);
            toastNotifier.Show(toast);
        }

        #endregion
    }
}
