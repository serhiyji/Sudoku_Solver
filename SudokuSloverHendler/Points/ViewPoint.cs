using SudokuSloverHendler.Collections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSloverHendler.Points
{
    public partial class Point
    {
        public List<Color> ColorsSet { get; set; } = Enumerable.Repeat(Color.FromArgb(0, 0, 0, 0), 9).ToList();
        public Color ColorValue { get; set; } = Color.FromArgb(0, 0, 0, 0);
        public void ClearColorsSet()
        {
            this.ColorsSet = Enumerable.Repeat(Color.FromArgb(0, 0, 0, 0), 9).ToList();
        }
    }
}
