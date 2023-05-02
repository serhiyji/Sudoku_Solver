using PropertyChanged;
using SudokuSloverHendler.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace WPF_Client
{
    [AddINotifyPropertyChangedInterface]
    public class ViewPoint
    {
        private SudokuSloverHendler.Points.Point main_point;

        //public string Value => (main_point.value == 0) ? "-" : main_point.value.ToString();
        public int Value => main_point.value;
        //public Brush ColorValue { get; set; } = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));

        public ViewPoint(ref SudokuSloverHendler.Points.Point point)
        {
            this.main_point = point;
        }
    }
}
