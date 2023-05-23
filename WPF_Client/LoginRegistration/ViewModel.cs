using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WPF_Client.Expansion;
using WPF_Client.DBContexts;
using System.Windows.Input;

namespace WPF_Client.LoginRegistration
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        private RelayCommand LoginCommand;
        private RelayCommand RegistrationCommand;
        public ICommand LoginCmd => LoginCommand;
        public ICommand RegistrationCmd => RegistrationCommand;

        public ViewModel()
        {
            this.LoginCommand = new RelayCommand((i) => this.LoginBtnClick(), (i) => true);
            this.RegistrationCommand = new RelayCommand((i) => this.RegistrationBtnClick(), (i) => true);
        }
        #region Buttons Handlers
        private void LoginBtnClick()
        {
            
        }
        private void RegistrationBtnClick()
        {
            // ....
        }
        #endregion
        public void CloseWindow(object sender = null, EventArgs e = null)
        {

        }
    }
}
