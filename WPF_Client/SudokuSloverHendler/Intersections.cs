﻿using System;
using Microsoft.VisualBasic;
using PropertyChanged;
using SudokuSloverHendler.Collections;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Points;

namespace SudokuSloverHendler
{
    [AddINotifyPropertyChangedInterface]
    public partial class Intersections
    {
        public string NameMethodSlover { get; set; }
        public bool IsSingleValue { get; set; }
        // 
        public byte NewValue { get; set; }
        public PosPoint PosPointNewValue { get; set; }
        // 


        public Arrange<PosPoint> PosPoints { get; set; }
        public Set<byte> values { get; set; }

        public Intersections()
        {
            SetDefoltValues();
        }
        public Intersections(string nameMethodSlover = "", bool isSingleValue = false,
            byte newValue = 0, PosPoint posPointNewValue = null,
            Arrange<PosPoint> posPoints = null, Set<byte> values = null) : this()
        {
            NameMethodSlover = nameMethodSlover;
            IsSingleValue = isSingleValue;
            NewValue = newValue;
            PosPointNewValue = posPointNewValue;
            PosPoints = posPoints;
            this.values = values;
        }

        public Intersections(Arrange<PosPoint> ArrPos, Set<byte> SetValues) : this()
        {
            this.PosPoints = ArrPos;
            this.values = SetValues;
        }

        public void SetDefoltValues()
        {
            NameMethodSlover = "";
            IsSingleValue = false;
            NewValue = 0;
            PosPointNewValue = new PosPoint();
            PosPoints = new Arrange<PosPoint>();
            values = new Set<byte>();
        }
        public void SetValues(Intersections intersection)
        {
            this.NameMethodSlover = intersection.NameMethodSlover;
            this.IsSingleValue = intersection.IsSingleValue;
            this.NewValue = intersection.NewValue;
            this.PosPointNewValue.i = intersection.PosPointNewValue.i;
            this.PosPointNewValue.j = intersection.PosPointNewValue.j;
            this.PosPoints = intersection.PosPoints;
            this.values = intersection.values;
        }
        public bool IsValid(BetterMatrix.BetterMatrix matrix)
        {
            if (!this.IsSingleValue)
            {
                if(this.PosPoints.Count == 0) { return false; }
                byte count = (byte)this.PosPoints.Count;
                bool hl = SudokuSlover.IsPosPointsInHorizontalLine(this.PosPoints), 
                    vl = SudokuSlover.IsPosPointsInVerticalLine(this.PosPoints), 
                    sq = SudokuSlover.IsOneSquareInArrPospoint(this.PosPoints);
                foreach (byte item in this.values)
                {
                    if (hl && matrix.GetCountPossiblePosPointInHorizontalLine(PosPoints[0].i, item) > count)
                    {
                        return true;
                    }
                    else if (vl && matrix.GetCountPossiblePosPointInVerticalLine(PosPoints[0].j, item) > count)
                    {
                        return true;
                    }
                    else if (sq && matrix.GetCountPossiblePosPointInSquare(new PosSquare(this.PosPoints[0]), item) > count)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool operator ==(Intersections inter1, Intersections inter2)
        {
            if (inter1 is null || inter2 is null) { return false; }
            return inter1.Equals(inter2);
        }
        public static bool operator !=(Intersections inter1, Intersections inter2)
        {
            if (inter1 is null || inter2 is null) { return false; }
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
}
