using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WPF_Client.Expansion;
using WPF_Client.DBContexts;

namespace WPF_Client.LoginRegistration
{
    [AddINotifyPropertyChangedInterface]
    public class ViewModel
    {
        public int IdUser { get; set; }
        //private DataBaseContext db;
        public ViewModel()
        {

        }
    }
}
