using System;
using SudokuSloverHendler.Coordinates;

namespace SudokuSloverHendler.Matrix
{
    public class Matrix<T> where T : new()
    {
        public T[,] matrix = new T[9, 9];
        public const int size = 9;
        public Matrix(bool IsSetDefaultValues = true)
        {
            if (IsSetDefaultValues)
            {
                SetDelfaultValues();
            }
        }
        public void SetDelfaultValues()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    System.Reflection.ConstructorInfo constructor = typeof(T).GetConstructor(Type.EmptyTypes);
                    T obj = ReferenceEquals(constructor, null) ? default : (T)constructor.Invoke(new object[0]);
                    matrix[i, j] = obj;
                }
            }
        }
        public void SetValue(PosPoint pos, T value)
        {
            matrix[pos.i, pos.j] = value;
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    res += matrix[i, j].ToString() + "  ";
                }
                res += "\n";
            }
            return res;
        }
    }
}
