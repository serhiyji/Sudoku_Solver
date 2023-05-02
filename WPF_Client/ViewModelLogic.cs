using SudokuSloverHendler.BetterMatrix;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Points;
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
        private DispatcherTimer timer;
        public ViewModel()
        {
            this._count_filled = 0;
            this._count = 81;
            this._count_not_filled = 81;
            this.matrix = new BetterMatrix();
            this.CursorPosition = new PosPoint(4, 4);
            this.points = new System.Collections.ObjectModel.ObservableCollection<ViewPoint>();
            BindGridToBetterMatrix();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            Random random = new Random();
            matrix.matrix[random.Next(0, 9), random.Next(0, 9)].value = random.Next(1, 100);
        }
        private void BindGridToBetterMatrix()
        {
            for (int i = 0; i < 9; i++) // row
            {
                for (int j = 0; j < 9; j++) // collom
                {
                    this.points.Add(new ViewPoint(ref matrix.matrix[i, j]));
                }
            }
        }
    }
}
