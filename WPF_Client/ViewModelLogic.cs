﻿using ClientApp;
using PropertyChanged;
using SudokuSloverHendler;
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
            this.slover = new SudokuSloverHendler.SudokuSlover(ref this.matrix);
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

            this.NumPad0Command = new RelayCommand((i) => this.SetValue(0), (i) => true);
            this.NumPad1Command = new RelayCommand((i) => this.SetValue(1), (i) => true);
            this.NumPad2Command = new RelayCommand((i) => this.SetValue(2), (i) => true);
            this.NumPad3Command = new RelayCommand((i) => this.SetValue(3), (i) => true);
            this.NumPad4Command = new RelayCommand((i) => this.SetValue(4), (i) => true);
            this.NumPad5Command = new RelayCommand((i) => this.SetValue(5), (i) => true);
            this.NumPad6Command = new RelayCommand((i) => this.SetValue(6), (i) => true);
            this.NumPad7Command = new RelayCommand((i) => this.SetValue(7), (i) => true);
            this.NumPad8Command = new RelayCommand((i) => this.SetValue(8), (i) => true);
            this.NumPad9Command = new RelayCommand((i) => this.SetValue(9), (i) => true);
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

        private void SetValue(byte value)
        {
            matrix.SetValue(new PosPoint(cursorPosition.I, cursorPosition.J), value);
        }

        #region Buttons Handlers
        private void UpBtnClick() => this.cursorPosition.SetPosition(Side.Up);
        private void DownBtnClick() => this.cursorPosition.SetPosition(Side.Down);
        private void LeftBtnClick() => this.cursorPosition.SetPosition(Side.Left);
        private void RightBtnClick() => this.cursorPosition.SetPosition(Side.Right);

        private void NextHintBtnClick()
        {
            Intersections intersection = this.slover.NextSlover();
            if (!(intersection is null))
            {
                //AlgorithmKeeperSolution.Instance.Intersection = intersection;
            }
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
