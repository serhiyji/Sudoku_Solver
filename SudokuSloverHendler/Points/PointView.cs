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
        public string Value => value.ToString();
        //public SolidColorBrush Color => value > 0 ? new SolidColorBrush(Color.)
    }
}
