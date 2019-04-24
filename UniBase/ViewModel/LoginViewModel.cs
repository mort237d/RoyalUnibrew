using GalaSoft.MvvmLight.Command;
using UniBase.Model;

namespace UniBase.ViewModel
{
    class LoginViewModel
    {
        public ManageLogin ManageLogin { get; set; } = ManageLogin.Instance;
        public RelayCommand LoginRelayCommand { get; set; }
        public RelayCommand GetDataRelayCommand { get; set; }

        public LoginViewModel()
        {
            LoginRelayCommand = new RelayCommand(ManageLogin.Instance.CheckLogin);
            //GetDataRelayCommand = new RelayCommand();
        }
    }
}
