using PropertyChanged;
using SudokuSloverHendler.BetterMatrix;
using SudokuSloverHendler.Coordinates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client
{
    [AddINotifyPropertyChangedInterface]
    public partial class ViewModel
    {
        private BetterMatrix matrix;
        private PosPoint CursorPosition;
        public ObservableCollection<SudokuSloverHendler.Points.Point> points { get; set; }
        public IEnumerable<SudokuSloverHendler.Points.Point> Points => points;
    }
}
