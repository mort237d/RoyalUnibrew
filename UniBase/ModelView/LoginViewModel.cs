using GalaSoft.MvvmLight.Command;

namespace UniBase.ModelView
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
