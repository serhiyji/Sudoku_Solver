using PropertyChanged;
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

using SudokuSloverHendler;
using SudokuSloverHendler.BetterMatrix;
using SudokuSloverHendler.Coordinates;
using SudokuSloverHendler.Points;
using WPF_Client.Expansion;

namespace WPF_Client
{
    public partial class ViewModel
    {
        public ViewModel()
        {
            this.IsOpenSignInOrSignUp = false;
            this.IsSignIn = false;
            this.UserId = null;

            this.matrix = new BetterMatrix();
            this.slover = new SudokuSlover(ref this.matrix);
            this.cursorPosition = new CursorPosition(ref matrix, 4, 4);
            this.points = new ObservableCollection<SudokuSloverHendler.Points.Point>();

            this.BindingButtons();
            this.BindGridToBetterMatrix();
        }

        private void BindingButtons()
        {
            this.SignInCommand = new RelayCommand((i) => this.SignInBtnClick(), (i) => !IsOpenSignInOrSignUp);
            this.SignUpCommand = new RelayCommand((i) => this.SignUpBtnClick(), (i) => !IsOpenSignInOrSignUp);
            this.SignOutCommand = new RelayCommand((i) => this.SignOutBtnClick(), (i) => true);

            this.NextHintCommand = new RelayCommand((i) => NextHintBtnClick(), (i) => !this.IsExecute);
            this.ExecuteCommand = new RelayCommand((i) => ExecuteBtnClick(), (i) => this.IsExecute);
            this.SloveUpToCommand = new RelayCommand((i) => SloveUpToBtnClick(), (i) => true);
            this.CancelCommand = new RelayCommand((i) => CancelBtnClick(), (i) => this.IsExecute);

            this.UpCommand = new RelayCommand((i) => UpBtnClick(), (i) => true);
            this.DownCommand = new RelayCommand((i) => DownBtnClick(), (i) => true);
            this.LeftCommand = new RelayCommand((i) => LeftBtnClick(), (i) => true);
            this.RightCommand = new RelayCommand((i) => RightBtnClick(), (i) => true);

            this.NumPad0Command = new RelayCommand((i) => this.SetValue(0), (i) => !this.IsExecute);
            this.NumPad1Command = new RelayCommand((i) => this.SetValue(1), (i) => !this.IsExecute);
            this.NumPad2Command = new RelayCommand((i) => this.SetValue(2), (i) => !this.IsExecute);
            this.NumPad3Command = new RelayCommand((i) => this.SetValue(3), (i) => !this.IsExecute);
            this.NumPad4Command = new RelayCommand((i) => this.SetValue(4), (i) => !this.IsExecute);
            this.NumPad5Command = new RelayCommand((i) => this.SetValue(5), (i) => !this.IsExecute);
            this.NumPad6Command = new RelayCommand((i) => this.SetValue(6), (i) => !this.IsExecute);
            this.NumPad7Command = new RelayCommand((i) => this.SetValue(7), (i) => !this.IsExecute);
            this.NumPad8Command = new RelayCommand((i) => this.SetValue(8), (i) => !this.IsExecute);
            this.NumPad9Command = new RelayCommand((i) => this.SetValue(9), (i) => !this.IsExecute);
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

        private async void SignInBtnClick()
        {
            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    this.IsOpenSignInOrSignUp = true;
                    WPF_Client.LoginRegistration.LoginRegistration loginWindow = new WPF_Client.LoginRegistration.LoginRegistration();
                    loginWindow.Show();
                    loginWindow.Closed += (s, e) =>
                    {
                        // ...
                        this.IsOpenSignInOrSignUp = false;
                    };
                });
            });
        }


        private void SignUpBtnClick()
        {

        }
        private void SignOutBtnClick()
        {

        }
        private void NextHintBtnClick()
        {
            Intersections intersection = this.slover.NextSlover();
            if (!(intersection is null))
            {
                Solution.Instance.IsExecute = true;
                Solution.Instance.Intersection.SetValues(intersection);
            }
        }
        private void ExecuteBtnClick()
        {
            Solution.Instance.IsExecute = false;
            bool res = this.slover.Intersections_Handler(Solution.Instance.Intersection);
            MessageBox.Show(res.ToString());
            Solution.Instance.Intersection.SetDefoltValues();
        }
        private void SloveUpToBtnClick()
        {
            while(true)
            {
                Intersections intersection = this.slover.NextSlover();
                if (!(intersection is null))
                {
                    this.slover.Intersections_Handler(intersection);
                }
                else
                {
                    break;
                }
            };
        }
        private void CancelBtnClick()
        {
            Solution.Instance.IsExecute = false;
            Solution.Instance.Intersection.SetDefoltValues();
        }
        #endregion
    }
}
