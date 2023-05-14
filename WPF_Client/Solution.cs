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
    public class Solution : SingletonClass<Solution>
    {
        public Intersections Intersection { get; set; }
        public bool IsExecute { get; set; }
        public Solution()
        {
            this.Intersection = new Intersections();
            IsExecute = false;
        }
    }
}
