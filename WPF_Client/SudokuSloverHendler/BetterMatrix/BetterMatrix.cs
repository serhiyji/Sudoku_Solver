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
        private Matrix<byte> __example = new Matrix<byte>();
        public BetterMatrix() : base(false)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = new Point(0, new PosPoint(i, j));
                }
            }
            __example.matrix = new byte[,]
            {
                { 1, 2, 3, 7, 8, 9, 4, 5, 6 },
                { 4, 5, 6, 1, 2, 3, 7, 8, 9 },
                { 7, 8, 9, 4, 5, 6, 1, 2, 3 },

                { 2, 3, 1, 8, 9, 7, 5, 6, 4 },
                { 5, 6, 4, 2, 3, 1, 8, 9, 7 },
                { 8, 9, 7, 5, 6, 4, 2, 3, 1 },

                { 3, 1, 2, 6, 4, 5, 9, 7, 8 },
                { 6, 4, 5, 9, 7, 8, 3, 1, 2 },
                { 9, 7, 8, 3, 1, 2, 6, 4, 5 }
            };
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
                        this.matrix[pos_p.i, pos_p.j].set -= new Set<byte>(1, 2, 3, 4, 5, 6, 7, 8, 9);
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
        public void GenerateNewSudoku(int interest = 70)
        {
            Random rand = new Random();
            this.ClearMatrix();
            Matrix<byte> mat = __example;
            mat.ToMixMatrix();
            for (int i = 0; i < mat.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < mat.matrix.GetLength(1); j++)
                {
                    if (rand.Next(0, 100) <= interest)
                    {
                        this.SetValue(new PosPoint(i, j), mat.matrix[i, j]);
                    }
                }
            }
            this.SetPossibleValues();
        }
        public void LoadSudoku(string data)
        {
            try
            {
                var dat = data.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (dat.Count() != size * size) return;
                int k = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        this.SetValue(new PosPoint(i, j), byte.Parse(dat[k]));
                        k++;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public string SaveSudoku()
        {
            string res = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res += matrix[i, j].value + ":";
                }
            }
            return res;
        }
    }
}
