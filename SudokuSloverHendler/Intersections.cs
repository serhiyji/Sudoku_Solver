using System;
using SudokuSloverHendler.Collections;
using SudokuSloverHendler.Coordinates;

namespace SudokuSloverHendler
{
    public partial class Intersections
    {
        


        public Arrange<PosPoint> PosPoints = new Arrange<PosPoint>();
        public Set<byte> values = new Set<byte>();
        public Intersections() { }
        public Intersections(Arrange<PosPoint> ArrPos, Set<byte> SetValues)
        {
            this.PosPoints = ArrPos;
            this.values = SetValues;
        }
        public Intersections(Intersections other)
        {
            this.PosPoints = other.PosPoints;
            this.values = other.values;
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
            Intersections inter = (Intersections)obj;
            return this.PosPoints == inter.PosPoints && this.values == inter.values;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    // For view
    public partial class Intersections
    {

    }
}
