using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //public string Value => value.ToString();
        public string Value => (value == 0) ? "" : value.ToString();
        public SolidColorBrush Selected => IsSelected ? new SolidColorBrush(Color.FromArgb(255, 255, 0, 0)) : new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        public string Val1 => (/*value == 0 &&*/ this.set.Contains(1)) ? "1" : "";
        public string Val2 => (/*value == 0 &&*/ this.set.Contains(2)) ? "2" : "";
        public string Val3 => (/*value == 0 &&*/ this.set.Contains(3)) ? "3" : "";
        public string Val4 => (/*value == 0 &&*/ this.set.Contains(4)) ? "4" : "";
        public string Val5 => (/*value == 0 &&*/ this.set.Contains(5)) ? "5" : "";
        public string Val6 => (/*value == 0 &&*/ this.set.Contains(6)) ? "6" : "";
        public string Val7 => (/*value == 0 &&*/ this.set.Contains(7)) ? "7" : "";
        public string Val8 => (/*value == 0 &&*/ this.set.Contains(8)) ? "8" : "";
        public string Val9 => (/*value == 0 &&*/ this.set.Contains(9)) ? "9" : "";
        private void SetViewProp()
        {
            this.IsSelected = false;
        }
    }
}
