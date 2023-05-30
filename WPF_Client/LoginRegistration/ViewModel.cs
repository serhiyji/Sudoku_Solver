using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WPF_Client.Expansion;
using WPF_Client.DBContexts;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;

namespace WPF_Client.LoginRegistration
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        
        #region Props
        private static SolidColorBrush CORRECT = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private static SolidColorBrush DONT_CORRECT = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        
        public bool IsLoginValid => Login != null && Login.Count() >= 5 && Login.Count() <= 64;
        public bool IsPasswordValid => Password != null && Password.Count() >= 5 && Password.Count() <= 64;
        public bool IsEmailValid => Email != null && new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(Email).Success;
        
        public SolidColorBrush LoginLine => IsLoginValid ? CORRECT : DONT_CORRECT;
        public SolidColorBrush PasswordLine => IsPasswordValid ? CORRECT : DONT_CORRECT;
        public SolidColorBrush EmailLine => IsEmailValid ? CORRECT : DONT_CORRECT;
        
        private RelayCommand LoginCommand;
        private RelayCommand RegistrationCommand;
        public ICommand LoginCmd => LoginCommand;
        public ICommand RegistrationCmd => RegistrationCommand;
        
        public event EventHandler OnClosedWindow;
        #endregion

        public ViewModel()
        {
            this.Login = "";
            this.Password = "";
            this.Email = "";
            this.LoginCommand = new RelayCommand((i) => this.LoginBtnClick(), (i) => IsLoginValid && IsPasswordValid);
            this.RegistrationCommand = new RelayCommand((i) => this.RegistrationBtnClick(), (i) => IsLoginValid && IsPasswordValid && IsEmailValid);
        }

        #region Buttons Handlers
        private void LoginBtnClick()
        {
            if (DatabaseHandler.Instance.Login(this.Login, this.Password))
            {
                this.CloseWindow();
            }
            else
            {
                MessageBox.Show("Invalid login or/and password");
            }
        }
        private void RegistrationBtnClick()
        {
            if (DatabaseHandler.Instance.Registration(this.Login, this.Password, this.Email))
            {
                this.CloseWindow();
            }
            else
            {
                // ...
            }
        }
        #endregion

        public void CloseWindow()
        {
            this.OnClosedWindow(null, new EventArgs());
        }
    }
}
