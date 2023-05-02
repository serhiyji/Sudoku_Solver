using SudokuSloverHendler.BetterMatrix;
using SudokuSloverHendler.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Threading;

namespace WPF_Client
{
    public partial class ViewModel
    {
        public ViewModel(ref UniformGrid uniformGrid)
        {
            this._count_filled = 0;
            this._count = 81;
            this._count_not_filled = 81;
            this.matrix = new BetterMatrix();
            this.CursorPosition = new PosPoint(4, 4);
            BindGridToBetterMatrix(ref uniformGrid);
        }
        private void BindGridToBetterMatrix(ref UniformGrid grid)
        {
            //grid = new UniformGrid();
            grid.Columns = 9;
            grid.Rows = 9;
            for (int i = 0; i < 9; i++) // row
            {
                Grid.SetRow(grid, i);
                for (int j = 0; j < 9; j++) // collom
                {
                    Grid.SetColumn(grid, j);

                    Binding binding = new Binding()
                    {
                        Path = new PropertyPath($"value"),
                        Source = matrix.matrix[i, j],
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };
                    TextBlock textBlock = new TextBlock();
                    textBlock.SetBinding(TextBlock.TextProperty, binding);
                    grid.Children.Add(textBlock);
                }
            }
        }
    }
}
