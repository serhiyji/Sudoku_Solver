using SudokuSloverHendler.BetterMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client
{
    public partial class ViewModel
    {
        public ViewModel()
        {
            _count_filled = 0;
            _count = 81;
            _count_not_filled = 81;
            matrix = new BetterMatrix();
        }
    }
}
