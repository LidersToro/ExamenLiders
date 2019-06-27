
namespace ExamlidersToro.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModels : BaseViewModel
    {
        #region Atributos
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Propiedades
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsRememberme
        {
            get;
            set;
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion
        #region Commandos
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }



        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese su E-Mail",
                    "Aceptar"
                    );
                return;
            }
          
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese su Password",
                    "Aceptar"
                    );
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;
            if (this.Email != "liderz250@gmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Ingrese su E-Mail o Password son incorrectos",
                   "Aceptar"
                   );
                this.Password = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;
            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModels.GetInstance().Lands = new LandsViewModels();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        }
        #endregion
        #region Constructores
        public LoginViewModels()
        {
            this.IsRememberme = true;
            this.IsEnabled = true;
            this.Email = "liderz250@gmail.com";
            this.Password = "1234";
        }
        #endregion
    }
}
