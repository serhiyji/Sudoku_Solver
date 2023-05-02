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
using System.Windows.Media;
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
            grid.Columns = 9;
            grid.Rows = 9;
            for (int i = 0; i < 9; i++) // row
            {
                Grid.SetRow(grid, i);
                for (int j = 0; j < 9; j++) // collom
                {
                    Grid.SetColumn(grid, j);

                    Border border = new Border()
                    {
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Margin = new Thickness(5),
                        Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0)),
                    };

                    Canvas canvas = new Canvas()
                    {
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                    };

                    border.Child = canvas;

                    TextBlock textBlock = new TextBlock()
                    {
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                    };

                    canvas.Children.Add(textBlock);

                    Binding BindingMainValue = new Binding()
                    {
                        Path = new PropertyPath($"value"),
                        Source = matrix.matrix[i, j],
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };

                    Binding BindingMainColor = new Binding()
                    {
                        Path = new PropertyPath($"ColorValue"),
                        Source = matrix.matrix[i, j],
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };

                    textBlock.SetBinding(TextBlock.TextProperty, BindingMainValue);
                    border.SetBinding(Border.BackgroundProperty, BindingMainColor);

                    grid.Children.Add(border);
                }
            }
        }
    }
}
