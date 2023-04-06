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
        public BetterMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = new Point { value = 0, set = new Set<int>() };
                }
            }
        }
        public void SetValue(PosPoint pos_p, int value)
        {
            this.matrix[pos_p.i, pos_p.j].value = value;
            this.matrix[pos_p.i, pos_p.j].set.Clear();
            this.ClearValueInSetInHorizontalLine(pos_p.i, value);
            this.ClearValueInSetInVerticalLine(pos_p.j, value);
            this.ClearValueInSetInSquare(new PosSquare(pos_p), value);
        }
        public void Fill(ref Matrix<int> mat)
        {
            for (int i = 0; i < mat.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < mat.matrix.GetLength(1); j++)
                {
                    this.matrix[i, j].value = (int)mat.matrix[i, j];
                }
            }
        }
    }
}
