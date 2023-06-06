using PropertyChanged;
using SudokuSloverHendler.BetterMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using WPF_Client.DBContexts;

namespace WPF_Client
{
    [AddINotifyPropertyChangedInterface]
    public class DatabaseHandler : Expansion.SingletonClass<DatabaseHandler>
    {
        private DataBaseContext db;
        public int IdUser { get;private set; }
        public string NameUser { get;private set; }
        public bool IsLogined { get; private set; }
        private bool IsLoginContains(string login) => db.Users.Select(i => i.Login).Contains(login);
        private bool IsSudokuContains(int IdSudoku) => db.SavingSudokus.Select(i => i.ID).Contains(IdSudoku);
        public DatabaseHandler()
        {
            this.IsLogined = false;
            this.IdUser = -1;
            this.NameUser = "";
            this.db = new DataBaseContext();
        }
        public int SaveSudoku(string nameSudoku, ref BetterMatrix matrix)
        {
            if (!IsLogined) { return -1; }
            try
            {
                db.SavingSudokus.Add(new DBContexts.Entities.SavingSudoku(){
                    Name = nameSudoku,
                    IdUser = this.IdUser,
                    Data = matrix.SaveSudoku(),
                    Time = DateTime.Now,
                });
                db.SaveChanges();
                return db.SavingSudokus.Where(s => s.IdUser == this.IdUser && s.Name == nameSudoku).First().ID;
            }
            catch (Exception)
            {
                return -1;
            }
            return -1;

        }
        public bool SaveSudoku(int IdSudoku, ref BetterMatrix matrix)
        {
            if (!IsLogined) { return false; }
            try
            {
                if (!IsSudokuContains(IdSudoku)) { return false; }
                var sud = db.SavingSudokus.Where(i => i.ID == IdSudoku);
                if (sud.Count() == 1)
                {
                    sud.First().Data = matrix.SaveSudoku();
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        public bool LoadSudoku(int IdSudoku, ref BetterMatrix matrix)
        {
            try
            {
                if (!IsSudokuContains(IdSudoku)) { return false; }
                var sud = db.SavingSudokus.Where(i => i.ID == IdSudoku);
                if (sud.Count() == 1)
                {
                    matrix.LoadSudoku(sud.First().Data);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
        public bool Login(string login, string password)
        {
            IEnumerable<DBContexts.Entities.User> users = db.Users.Where(i => i.Login == login && i.Password == password);
            if (users.Count() == 1)
            {
                this.IsLogined = true;
                this.IdUser = users.First().ID;
                this.NameUser = users.First().Login;
                return true;
            }
            return false;
        }
        public bool Registration(string login, string password, string email)
        {
            try
            {
                if (!IsLoginContains(login))
                {
                    this.db.Users.Add(new DBContexts.Entities.User()
                    {
                        Login = login,
                        Password = password,
                        Email = email,
                    });
                    db.SaveChanges();
                    return this.Login(login, password);
                }
            }
            catch (Exception) { }
            return false;
        }
        public void LogOut()
        {
            this.IsLogined = false;
            this.IdUser = -1;
            this.NameUser = "";
        }
        public IEnumerable<DBContexts.Entities.SavingSudoku> GetSudokuByUser()
        {
            return IsLogined ? this.db.SavingSudokus.Where(s => s.IdUser == IdUser) : new List<DBContexts.Entities.SavingSudoku>();
        }
    }
}
