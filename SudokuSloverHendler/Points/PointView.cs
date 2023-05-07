using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SudokuSloverHendler.Points
{
    [AddINotifyPropertyChangedInterface]
    public partial class Point
    {
        public bool IsSelected { get; set; }
        public SolidColorBrush Selected => IsSelected ? new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)) : new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        //public string Value => (value > 0) ? value.ToString() : "";
        public string Value => value.ToString();
        //public SolidColorBrush Color => value > 0 ? new SolidColorBrush(Color.)
    }
}
