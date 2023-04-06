using SudokuSloverHendler.Collections;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Matrix;
using SudokuSloverHendler.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSloverHendler.BetterMatrix
{
    public partial class BetterMatrix : Matrix<Point>
    {
        public void SetPossibleValues()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (this.matrix[i, j].value == 0)
                    {
                        this.matrix[i, j].set = this.GetPossibleValuesInPosPoint(new PosPoint(i, j));
                    }
                }
            }
        }
        private Set<int> GetPossibleValuesInPosPoint(PosPoint pos_p)
        {
            Set<int> set1 = new Set<int>(this.GetSetHorizontalLine(pos_p.i));
            Set<int> set2 = new Set<int>(this.GetSetVerticalLine(pos_p.j));
            Set<int> set3 = new Set<int>(this.GetSetSquare(new PosSquare(pos_p)));
            return (new Set<int>(1, 2, 3, 4, 5, 6, 7, 8, 9) - (set1 + set2 + set3));
        }
        private Set<int> GetSetInRange(PosPoint pos1, PosPoint pos2)
        {
            Set<int> set = new Set<int>();
            for (int i = pos1.i; i <= pos2.i; i++)
            {
                for (int j = pos1.j; j <= pos2.j; j++)
                {
                    if (matrix[i, j].value != 0)
                    {
                        set.Add(matrix[i, j].value);
                    }
                }
            }
            return set;
        }
        private Set<int> GetSetHorizontalLine(int index)
        { return this.GetSetInRange(new PosPoint(index, 0), new PosPoint(index, size - 1)); }
        private Set<int> GetSetVerticalLine(int index)
        { return this.GetSetInRange(new PosPoint(0, index), new PosPoint(size - 1, index)); }
        private Set<int> GetSetSquare(PosSquare pos_s)
        { return this.GetSetInRange(new PosPoint(pos_s.i * 3, pos_s.j * 3), new PosPoint(pos_s.i * 3 + 2, pos_s.j * 3 + 2)); }
    }
}
