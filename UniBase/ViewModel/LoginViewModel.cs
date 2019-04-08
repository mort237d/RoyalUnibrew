using GalaSoft.MvvmLight.Command;

namespace UniBase.ViewModel
{
    class LoginViewModel
    {
        public RelayCommand GetDataRelayCommand { get; set; }

        public LoginViewModel()
        {
            //GetDataRelayCommand = new RelayCommand();
        }
    }
}
