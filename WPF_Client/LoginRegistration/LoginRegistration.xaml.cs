﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Client.LoginRegistration
{
    public partial class LoginRegistration : Window
    {
        ViewModel model;
        public LoginRegistration(int idtab)
        {
            InitializeComponent();
            this.model = new ViewModel();
            this.model.OnClosedWindow += (s, e) => { this.Close(); };
            this.DataContext = model;
        }
    }
}
