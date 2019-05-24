using GalaSoft.MvvmLight.Command;
using UniBase.Model;

namespace UniBase.ViewModel
{
    class LoginViewModel
    {
        public ManageLogin ManageLogin { get; set; } = ManageLogin.Instance;
        public RelayCommand LoginRelayCommand { get; set; }

        public LoginViewModel()
        {
            LoginRelayCommand = new RelayCommand(ManageLogin.Instance.CheckLogin);

            Windows.UI.Xaml.Window.Current.CoreWindow.KeyDown += (sender, arg) => { if (arg.VirtualKey == Windows.System.VirtualKey.Enter) ManageLogin.Instance.CheckLogin(); };
        }
    }
}
