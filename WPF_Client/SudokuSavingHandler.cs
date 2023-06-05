using Microsoft.Win32;
using SudokuSloverHendler.BetterMatrix;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Client
{
    public class SudokuSavingHandler : Expansion.SingletonClass<SudokuSavingHandler>
    {
        public bool IsSudokuFromFile { get; private set; }
        public string FullPath { get; set; }
        public bool IsSudokuFromDatabase { get; private set; }
        
        public SudokuSavingHandler()
        {
            this.IsSudokuFromFile = false;
            this.FullPath = "";
            this.IsSudokuFromDatabase = false;   
        }
        public void SaveAsSudokuInFile(ref BetterMatrix matrix)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            bool? result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                this.FullPath = saveFileDialog.FileName;
                this.SaveToFile(this.FullPath, matrix.SaveSudoku());
                this.IsSudokuFromFile = true;
                this.IsSudokuFromDatabase = false;
            }
        }
        public void SaveSudokuInFile(ref BetterMatrix matrix)
        {
            this.SaveToFile(this.FullPath, matrix.SaveSudoku());
        }
        public void LoadSudokuFromFile(ref BetterMatrix matrix)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            bool? result = openFileDialog.ShowDialog();
            if (result == true)
            {
                this.FullPath = openFileDialog.FileName;
                string fileContent = File.ReadAllText(this.FullPath);
                matrix.LoadSudoku(fileContent);
                this.IsSudokuFromFile = true;
                this.IsSudokuFromDatabase = false;
            }
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
        private void SaveToFile(string filePath, string data)
        {
            try
            {
                File.WriteAllText(filePath, data);
            }
            catch (Exception)
            {

            }
        }
    }
}
