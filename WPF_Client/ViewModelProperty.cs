using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using SudokuSloverHendler;
using SudokuSloverHendler.BetterMatrix;
using SudokuSloverHendler.Coordinates;
using WPF_Client.Expansion;

namespace WPF_Client
{
    [AddINotifyPropertyChangedInterface]
    public partial class ViewModel
    {
        // Matrix
        private CursorPosition cursorPosition;
        private BetterMatrix matrix;
        private SudokuSlover slover;
        public Intersections Intersection => Solution.Instance.Intersection;
        public bool IsExecute => Solution.Instance.IsExecute;
        public ObservableCollection<SudokuSloverHendler.Points.Point> points { get; set; }
        public IEnumerable<SudokuSloverHendler.Points.Point> Points => points;

        // SudokusList
        private ObservableCollection<string> sudokus { get; set; }
        public IEnumerable<string> Sudokus => sudokus;

        // Buttons
        public bool IsOpenSignInOrSignUp => DatabaseHandler.Instance.IsLogined;

        private RelayCommand SignInCommand;
        private RelayCommand SignUpCommand;
        private RelayCommand SignOutCommand;
        private RelayCommand NextHintCommand;
        private RelayCommand ExecuteCommand;
        private RelayCommand SloveUpToCommand;
        private RelayCommand CancelCommand;

        public ICommand NextHintCmd => NextHintCommand;
        public ICommand ExecuteCmd => ExecuteCommand;
        public ICommand SloveUpToCmd => SloveUpToCommand;
        public ICommand Cancel => CancelCommand;
        public ICommand SignInCmd => SignInCommand;
        public ICommand SignUpCmd => SignUpCommand;
        public ICommand SignOutCmd => SignOutCommand;

        private RelayCommand UpCommand;
        private RelayCommand DownCommand;
        private RelayCommand LeftCommand;
        private RelayCommand RightCommand;

        public ICommand UpCmd => UpCommand;
        public ICommand DownCmd => DownCommand;
        public ICommand LeftCmd => LeftCommand;
        public ICommand RightCmd => RightCommand;

        private RelayCommand NumPad0Command;
        private RelayCommand NumPad1Command;
        private RelayCommand NumPad2Command;
        private RelayCommand NumPad3Command;
        private RelayCommand NumPad4Command;
        private RelayCommand NumPad5Command;
        private RelayCommand NumPad6Command;
        private RelayCommand NumPad7Command;
        private RelayCommand NumPad8Command;
        private RelayCommand NumPad9Command;

        public ICommand NumPad0Cmd => NumPad0Command;
        public ICommand NumPad1Cmd => NumPad1Command;
        public ICommand NumPad2Cmd => NumPad2Command;
        public ICommand NumPad3Cmd => NumPad3Command;
        public ICommand NumPad4Cmd => NumPad4Command;
        public ICommand NumPad5Cmd => NumPad5Command;
        public ICommand NumPad6Cmd => NumPad6Command;
        public ICommand NumPad7Cmd => NumPad7Command;
        public ICommand NumPad8Cmd => NumPad8Command;
        public ICommand NumPad9Cmd => NumPad9Command;
    }
}
