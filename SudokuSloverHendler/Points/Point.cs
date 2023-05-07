using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using PropertyChanged;
using SudokuSloverHendler.Collections;

namespace SudokuSloverHendler.Points
{
    public partial class Point
    {
        public int value { get; set; }
        public Set<int> set { get; set; }
        public Point() : this(0)
        {

        }
        public Point(int v)
        {
            value = v;
            set = new Set<int>();
            IsSelected = false;
        }
        public static bool operator ==(Point p1, int value)
        {
            return p1.Equals(new Point(value));
        }
        public static bool operator !=(Point p1, int value)
        {
            return !p1.Equals(new Point(value));
        }
        public override string ToString()
        {
            return $"{value}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (!(obj is Point)) { return false; }
            Point other = (Point)obj;
            return value == other.value;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
