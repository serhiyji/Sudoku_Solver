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
using System.Runtime.CompilerServices;

namespace WPF_Client
{
    public partial class ViewModel
    {
        public ViewModel()
        {
            this.matrix = new BetterMatrix();
            this.slover = new SudokuSlover(ref this.matrix);
            this.cursorPosition = new CursorPosition(ref matrix, 5, 4);
            this.points = new ObservableCollection<SudokuSloverHendler.Points.Point>();
            this.sudokus = new ObservableCollection<DBContexts.Entities.SavingSudoku>();

            this.BindingButtons();
            this.BindGridToBetterMatrix();
        }

        private void BindingButtons()
        {
            this.SignInUpCommand = new RelayCommand((i) => this.SignInUpBtnClick(), (i) => !DatabaseHandler.Instance.IsLogined);
            this.SignOutCommand = new RelayCommand((i) => this.SignOutBtnClick(), (i) => DatabaseHandler.Instance.IsLogined);

            this.NextHintCommand = new RelayCommand((i) => NextHintBtnClick(), (i) => !this.IsExecute);
            this.ExecuteCommand = new RelayCommand((i) => ExecuteBtnClick(), (i) => this.IsExecute);
            this.SloveUpToCommand = new RelayCommand((i) => SloveUpToBtnClick(), (i) => true);
            this.CancelCommand = new RelayCommand((i) => CancelBtnClick(), (i) => this.IsExecute);

            this.ClearMatrixCommand = new RelayCommand((i) => ClearMatrixBtnClick(), (i) => true);

            this.UpCommand = new RelayCommand((i) => this.cursorPosition.SetPosition(Side.Up), (i) => true);
            this.DownCommand = new RelayCommand((i) => this.cursorPosition.SetPosition(Side.Down), (i) => true);
            this.LeftCommand = new RelayCommand((i) => this.cursorPosition.SetPosition(Side.Left), (i) => true);
            this.RightCommand = new RelayCommand((i) => this.cursorPosition.SetPosition(Side.Right), (i) => true);

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

            this.NewRandomSudokuCommand = new RelayCommand((i) => this.NewRandomSudokuBtnClick(), (i) => true);
            this.OpenSudokuFromFileCommand = new RelayCommand((i) => this.OpenSudokuFromFileBtnClick(), (i) => true);
            this.SaveSudokuInFileCommand = new RelayCommand((i) => this.SaveSudokuInFileBtnClick(), 
                (i) => SudokuSavingHandler.Instance.IsSudokuFromFile);
            this.SaveAsSudokuInFileCommand = new RelayCommand((i) => this.SaveAsSudokuInFileBtnClick(), (i) => true);
            this.OpenSudokuFromDataBaseCommand = new RelayCommand((i) => this.OpenSudokuFromDataBaseBtnClick(), 
                (i) => DatabaseHandler.Instance.IsLogined);
            this.SaveSudokuInDataBaseCommand = new RelayCommand((i) => this.SaveSudokuInDataBaseBtnClick(), 
                (i) => DatabaseHandler.Instance.IsLogined && SudokuSavingHandler.Instance.IsSudokuFromDatabase);
            this.SaveAsSudokuInDataBaseCommand = new RelayCommand((i) => this.SaveAsSudokuInDataBaseBtnClick(), 
                (i) => DatabaseHandler.Instance.IsLogined);
            this.UpdateListSavingSudukusCommand = new RelayCommand((i) => UpdateListSavingSudukusBtnClick(), 
                (i) => DatabaseHandler.Instance.IsLogined);
            this.QuitCommand = new RelayCommand((i) => this.QuitBtnClick(), (i) => true);
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

        private async void SignInUpBtnClick()
        {
            await Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    WPF_Client.LoginRegistration.LoginRegistration loginWindow = new WPF_Client.LoginRegistration.LoginRegistration();
                    loginWindow.ShowDialog();
                });
            });
        }
        private void SignOutBtnClick()
        {
            DatabaseHandler.Instance.LogOut();
        }
        private void ClearMatrixBtnClick()
        {
            this.matrix.ClearMatrix();
        }

        #region Solution
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
            //MessageBox.Show(res.ToString());
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

        #region Menu_File
        private void NewRandomSudokuBtnClick() 
        {
            
        }
        private void OpenSudokuFromFileBtnClick()
        {
            SudokuSavingHandler.Instance.LoadSudokuFromFile(ref this.matrix);
        }
        private void SaveSudokuInFileBtnClick()
        {
            SudokuSavingHandler.Instance.SaveSudokuInFile(ref this.matrix);
        }
        private void SaveAsSudokuInFileBtnClick()
        {
            SudokuSavingHandler.Instance.SaveAsSudokuInFile(ref this.matrix);
        }
        private void OpenSudokuFromDataBaseBtnClick()
        {
            SudokuSavingHandler.Instance.LoadSudokuFromDataBase(0);
        }
        private void SaveSudokuInDataBaseBtnClick()
        {

        }
        private void SaveAsSudokuInDataBaseBtnClick()
        {

        }
        private void UpdateListSavingSudukusBtnClick()
        {
            this.sudokus.Clear();
            foreach (DBContexts.Entities.SavingSudoku sud in DatabaseHandler.Instance.GetSudokuByUser())
            {
                this.sudokus.Add(sud);
            }
        }
        private void QuitBtnClick()
        {
            this.CloseWindow(null, new EventArgs());
        }
        #endregion

        #endregion
    }
}
