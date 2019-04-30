using System;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace UniBase.Model
{
    class Message
    {
        #region Field

        private ManageUser _manageUser;


        #endregion

        public Message(ManageUser manageUser)
        {
            _manageUser = manageUser;
        }


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
                
                if (title == "Slet bruger") _manageUser.Users.Remove(_manageUser.SelectedUser);
                
            }
            else if (command == noCommand)
            {
            }
        }

        #endregion
    }
}
