﻿using PropertyChanged;
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
        public string Login_L { get; set; }
        public string Login_R { get; set; }
        public string Password_L { get; set; }
        public string Password_R { get; set; }
        public string Email_R { get; set; }
        
        public bool IsLoginValid_L => Login_L != null && Login_L.Count() >= 5 && Login_L.Count() <= 64;
        public bool IsLoginValid_R => Login_R != null && Login_R.Count() >= 5 && Login_R.Count() <= 64;
        public bool IsPasswordValid_L => Password_L != null && Password_L.Count() >= 5 && Password_L.Count() <= 64;
        public bool IsPasswordValid_R => Password_R != null && Password_R.Count() >= 5 && Password_R.Count() <= 64;
        public bool IsEmailValid_R => Email_R != null && new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(Email_R).Success;
        
        public SolidColorBrush LoginLine_L => IsLoginValid_L ? CORRECT : DONT_CORRECT;
        public SolidColorBrush LoginLine_R => IsLoginValid_R ? CORRECT : DONT_CORRECT;
        public SolidColorBrush PasswordLine_L => IsPasswordValid_L ? CORRECT : DONT_CORRECT;
        public SolidColorBrush PasswordLine_R => IsPasswordValid_R ? CORRECT : DONT_CORRECT;
        public SolidColorBrush EmailLine_R => IsEmailValid_R ? CORRECT : DONT_CORRECT;
        
        private RelayCommand LoginCommand;
        private RelayCommand RegistrationCommand;
        public ICommand LoginCmd => LoginCommand;
        public ICommand RegistrationCmd => RegistrationCommand;
        
        public event EventHandler OnClosedWindow;
        #endregion

        public ViewModel()
        {
            this.Login_L = "qwerty";
            this.Login_R = "";
            this.Password_L = "qwerty";
            this.Password_R = "";
            this.Email_R = "";
            this.LoginCommand = new RelayCommand((i) => this.LoginBtnClick(), (i) => IsLoginValid_L && IsPasswordValid_L);
            this.RegistrationCommand = new RelayCommand((i) => this.RegistrationBtnClick(), (i) => IsLoginValid_R && IsPasswordValid_R && IsEmailValid_R);
        }

        #region Buttons Handlers
        private void LoginBtnClick()
        {
            if (DatabaseHandler.Instance.Login(this.Login_L, this.Password_L))
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
            if (DatabaseHandler.Instance.Registration(this.Login_R, this.Password_R, this.Email_R))
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
