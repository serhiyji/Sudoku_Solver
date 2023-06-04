using SudokuSloverHendler.BetterMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client
{
    public class SudokuSavingHandler : Expansion.SingletonClass<SudokuSavingHandler>
    {
        public bool IsSudokuFromFile { get; private set; }
        public string PathToFile { get; private set; }
        public string NameFile { get; private set; }
        public bool IsSudokuFromDatabase { get; private set; }
        
        public SudokuSavingHandler()
        {
            this.IsSudokuFromFile = false;
            this.PathToFile = null;
            this.NameFile = null;
            this.IsSudokuFromDatabase = false;   
        }
        public void SaveAsSudokuInFile(ref BetterMatrix matrix)
        {

        }
        public void SaveSudokuInFile()
        {

        }
        public void LoadSudokuFromFile()
        {

        }
        public void SaveAsSudokuInDataBase()
        {

        }
        public void SaveSudokuInDataBase()
        {

        }
        public void LoadSudokuFromDataBase(int IsSudoku)
        {

        }


    }
}
