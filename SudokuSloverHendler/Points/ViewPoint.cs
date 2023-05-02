using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace SudokuSloverHendler.Points
{
    [AddINotifyPropertyChangedInterface]
    public partial class Point
    {
        public string Value => (value == 0) ? "" : value.ToString();
        public List<Color> ColorsSet { get; set; } = Enumerable.Repeat(Color.FromArgb(0, 0, 0, 0), 9).ToList();
        public Brush ColorValue { get; set; } = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        public void ClearColorsSet()
        {
            this.ColorsSet = Enumerable.Repeat(Color.FromArgb(0, 0, 0, 0), 9).ToList();
        }
    }
}
