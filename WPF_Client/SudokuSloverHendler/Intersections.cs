using System;
using PropertyChanged;
using SudokuSloverHendler.Collections;
using SudokuSloverHendler.Coordinates;

namespace SudokuSloverHendler
{
    public partial class Intersections
    {
        public string NameMethodSlover { get; set; }
        public bool IsSingleValue { get; set; }
        // 
        public byte NewValue { get; set; }
        public PosPoint PosPointNewValue { get; set; }
        // 
        

        public Arrange<PosPoint> PosPoints = new Arrange<PosPoint>();
        public Set<byte> values = new Set<byte>();
        public Intersections() 
        {
            NameMethodSlover = "";
            IsSingleValue = false;
            NewValue = 0;
            PosPointNewValue = new PosPoint();
        }
        public Intersections(Arrange<PosPoint> ArrPos, Set<byte> SetValues) : this()
        {
            this.PosPoints = ArrPos;
            this.values = SetValues;
        }
        public static bool operator ==(Intersections inter1, Intersections inter2)
        {
            return inter1.Equals(inter2);
        }

        public static bool operator !=(Intersections inter1, Intersections inter2)
        {
            return !inter1.Equals(inter2);
        }
        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            if (!(obj is Intersections)) { return false; }
            return true;
            //Intersections inter = (Intersections)obj;
            //return this.PosPoints == inter.PosPoints && this.values == inter.values;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    // For view
    [AddINotifyPropertyChangedInterface]
    public partial class Intersections
    {
        public string Description => $"{this.NameMethodSlover}\n{IsSingleValue}";
    }
}
