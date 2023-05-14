﻿using PropertyChanged;
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
        private static SolidColorBrush EmptyColor = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        private static SolidColorBrush SelectedColor = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));

        public bool IsSelected { get; set; }
        public string Value => (value == 0) ? "" : value.ToString();
        public SolidColorBrush Selected => IsSelected ? SelectedColor : EmptyColor;
        public string Val1 => (this.set.Contains(1)) ? "1" : "";
        public string Val2 => (this.set.Contains(2)) ? "2" : "";
        public string Val3 => (this.set.Contains(3)) ? "3" : "";
        public string Val4 => (this.set.Contains(4)) ? "4" : "";
        public string Val5 => (this.set.Contains(5)) ? "5" : "";
        public string Val6 => (this.set.Contains(6)) ? "6" : "";
        public string Val7 => (this.set.Contains(7)) ? "7" : "";
        public string Val8 => (this.set.Contains(8)) ? "8" : "";
        public string Val9 => (this.set.Contains(9)) ? "9" : "";
        private void SetViewProp()
        {
            this.IsSelected = false;
        }
    }
}