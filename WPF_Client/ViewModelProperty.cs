using PropertyChanged;
using SudokuSloverHendler.BetterMatrix;
using SudokuSloverHendler.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client
{
    [AddINotifyPropertyChangedInterface]
    public partial class ViewModel
    {
        private int _count_filled;
        private int _count;
        private int _count_not_filled;
        private BetterMatrix matrix;
        private PosPoint CursorPosition;
    }
}
