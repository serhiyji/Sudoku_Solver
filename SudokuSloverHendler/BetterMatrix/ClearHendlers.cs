using System;
using SudokuSloverHendler.Collections;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Matrix;
using SudokuSloverHendler.Points;
using System.Linq;

namespace SudokuSloverHendler.BetterMatrix
{
    public partial class BetterMatrix : Matrix<Point>
    {
        private bool ClearValueInSetInRange(PosPoint pos1, PosPoint pos2, int value, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        {
            arr = (arr is null) ? new Arrange<PosPoint>() : arr;
            bool total = false;
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if ((this.matrix[i, j].value == 0) && !(arr.Contains(new PosPoint(i, j))))
                    {
                        int size_start = this.matrix[i, j].set.Count();
                        this.matrix[i, j].set -= new Set<int>(value);
                        if (size_start != this.matrix[i, j].set.Count())
                        {
                            total = true;
                        }
                    }
                }
            }
            return total;
        }
        private bool ClearValuesInSetInRange(PosPoint pos1, PosPoint pos2, Set<int> values, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        {
            bool total = false;
            for (int i = 0; i < values.Count(); i++)
            {
                total = this.ClearValueInSetInRange(pos1, pos2, values[i], arr) || total;
            }
            return total;
        }

        public bool ClearValueInSetInHorizontalLine(int index, int value, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValueInSetInRange(new PosPoint(index, 0), new PosPoint(index, size - 1), value, arr); }
        public bool ClearValueInSetInVerticalLine(int index, int value, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValueInSetInRange(new PosPoint(0, index), new PosPoint(size - 1, index), value, arr); }
        public bool ClearValueInSetInSquare(PosSquare pos_s, int value, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValueInSetInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2), value, arr); }
        public bool ClearValueInPosPoint(PosPoint pos_p, int value)
        { return this.ClearValueInSetInRange(pos_p, pos_p, value); }

        public bool ClearValuesInSetInHorizontalLine(int index, Set<int> values, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValuesInSetInRange(new PosPoint(index, 0), new PosPoint(index, size - 1), values, arr); }
        public bool ClearValuesInSetInVerticalLine(int index, Set<int> values, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValuesInSetInRange(new PosPoint(0, index), new PosPoint(size - 1, index), values, arr); }
        public bool ClearValuesInSetInSquare(PosSquare pos_s, Set<int> values, Arrange<PosPoint> arr = default(Arrange<PosPoint>))
        { return this.ClearValuesInSetInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2), values, arr); }
        public bool ClearValuesInSetInPosPoint(PosPoint pos_p, Set<int> values)
        { return this.ClearValuesInSetInRange(pos_p, pos_p, values); }
    }
}
