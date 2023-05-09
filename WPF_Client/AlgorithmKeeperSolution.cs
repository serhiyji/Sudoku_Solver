using PropertyChanged;
using SudokuSloverHendler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client
{
    [AddINotifyPropertyChangedInterface]
    public class AlgorithmKeeperSolution : SingletonClass<AlgorithmKeeperSolution>
    {
        public Intersections Intersection { get; set; }
        public AlgorithmKeeperSolution()
        {
            Intersection = null;
        }
    }
}
