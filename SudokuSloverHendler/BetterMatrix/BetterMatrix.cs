using System;
using System.Linq;
using SudokuSloverHendler.Collections;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Matrix;
using SudokuSloverHendler.Points;

namespace SudokuSloverHendler.BetterMatrix
{
    public partial class BetterMatrix : Matrix<Point>
    {
        public BetterMatrix() : base()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = new Point() { value = 0, set = new Set<byte>() };
                }
            }
        }
        public void SetValue(PosPoint pos_p, byte value)
        {
            byte last_value = matrix[pos_p.i, pos_p.j].value;
            if (value == 0)
            {
                if (last_value != 0)
                {
                    this.matrix[pos_p.i, pos_p.j].value = 0;
                    this.SettingPosibleValue(pos_p, last_value);
                }
            }
            else
            {
                if (this.matrix[pos_p.i, pos_p.j].value == 0)
                {
                    if (this.matrix[pos_p.i, pos_p.j].set.Contains(value))
                    {
                        this.matrix[pos_p.i, pos_p.j].value = value;
                        this.matrix[pos_p.i, pos_p.j].set -= new Set<byte>(1 , 2, 3, 4, 5, 6, 7, 8, 9);
                        this.ClearValueInSetInHorizontalLine(pos_p.i, value);
                        this.ClearValueInSetInVerticalLine(pos_p.j, value);
                        this.ClearValueInSetInSquare(new PosSquare(pos_p), value);
                    }
                }
                else
                {
                    this.SetValue(pos_p, 0);
                    this.SetValue(pos_p, value);
                }
            }
        }
        public void Fill(ref Matrix<int> mat)
        {
            for (int i = 0; i < mat.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < mat.matrix.GetLength(1); j++)
                {
                    this.matrix[i, j].value = (byte)mat.matrix[i, j];
                }
            }
        }
    }
}
