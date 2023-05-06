using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChanged;
using SudokuSloverHendler.Coordinates;

namespace SudokuSloverHendler.Matrix
{
    [AddINotifyPropertyChangedInterface]
    public class Matrix<T> where T : new()
    {
        public T[,] matrix { get; set; }
        public const int size = 9;
        public Matrix(bool IsSetDefaultValues = true)
        {
            this.matrix = new T[size, size];
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
