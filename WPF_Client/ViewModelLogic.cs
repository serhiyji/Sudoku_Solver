using ClientApp;
using PropertyChanged;
using SudokuSloverHendler.BetterMatrix;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Points;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace WPF_Client
{
    public partial class ViewModel
    {
        public ViewModel()
        {
            this.DescriptionAlgorithm = "";

            this.matrix = new BetterMatrix();
            this.cursorPosition = new CursorPosition(ref matrix, 4, 4);
            this.points = new ObservableCollection<SudokuSloverHendler.Points.Point>();

            this.BindingButtons();
            this.BindGridToBetterMatrix();
        }

        private void BindingButtons()
        {
            this.NextHintCommand = new RelayCommand((i) => NextHintBtnClick(), (i) => true);
            this.ExecuteCommand = new RelayCommand((i) => ExecuteBtnClick(), (i) => true);
            this.SloveUpToCommand = new RelayCommand((i) => SloveUpToBtnClick(), (i) => true);
            this.CancelCommand = new RelayCommand((i) => CancelBtnClick(), (i) => true);

            this.UpCommand = new RelayCommand((i) => UpBtnClick(), (i) => true);
            this.DownCommand = new RelayCommand((i) => DownBtnClick(), (i) => true);
            this.LeftCommand = new RelayCommand((i) => LeftBtnClick(), (i) => true);
            this.RightCommand = new RelayCommand((i) => RightBtnClick(), (i) => true);

            this.NumPad0Command = new RelayCommand((i) => this.SetValue(0));
            this.NumPad1Command = new RelayCommand((i) => this.SetValue(1));
            this.NumPad2Command = new RelayCommand((i) => this.SetValue(2));
            this.NumPad3Command = new RelayCommand((i) => this.SetValue(3));
            this.NumPad4Command = new RelayCommand((i) => this.SetValue(4));
            this.NumPad5Command = new RelayCommand((i) => this.SetValue(4));
            this.NumPad6Command = new RelayCommand((i) => this.SetValue(6));
            this.NumPad7Command = new RelayCommand((i) => this.SetValue(7));
            this.NumPad8Command = new RelayCommand((i) => this.SetValue(8));
            this.NumPad9Command = new RelayCommand((i) => this.SetValue(9));
        }

        private void BindGridToBetterMatrix()
        {
            this.points.Clear();
            for (int i = 0; i < 9; i++) // row
            {
                for (int j = 0; j < 9; j++) // collom
                {
                    this.points.Add(matrix.matrix[i, j]);
                }
            }
        }

        private async void SetValue(int value)
        {
            //matrix.SetValue(new PosPoint(cursorPosition.I, cursorPosition.J), value);
        }

        #region Buttons Handlers
        private void UpBtnClick() => this.cursorPosition.SetPosition(Side.Up);
        private void DownBtnClick() => this.cursorPosition.SetPosition(Side.Down);
        private void LeftBtnClick() => this.cursorPosition.SetPosition(Side.Left);
        private void RightBtnClick() => this.cursorPosition.SetPosition(Side.Right);

        private void NextHintBtnClick()
        {

        }
        private void ExecuteBtnClick()
        {

        }
        private void SloveUpToBtnClick()
        {

        }
        private void CancelBtnClick()
        {

        }
        #endregion

    }
}
