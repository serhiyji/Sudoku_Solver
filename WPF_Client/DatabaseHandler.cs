﻿using SudokuSloverHendler.BetterMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_Client.DBContexts;

namespace WPF_Client
{
    public class DatabaseHandler : Expansion.SingletonClass<DatabaseHandler>
    {
        private DataBaseContext db;
        private int IdUser;
        private bool IsLogined;
        private bool IsLoginContains(string login) => db.Users.Select(i => i.Login).Contains(login);
        public DatabaseHandler()
        {
            this.IsLogined = false;
            this.IdUser = -1;
            this.db = new DataBaseContext();
        }
        public bool SaveSudoku(int IdUser, ref BetterMatrix matrix)
        {
            // ...
            return false;
        }
        public bool SaveSudoku(int IdUser, int IdSudoku, ref BetterMatrix matrix)
        {
            // ...
            return false;
        }
        public bool LoadSudoku(int IdUser, int IdSudoku, ref BetterMatrix matrix)
        {
            // ...
            return false;
        }
        public bool Login(string login, string password)
        {
            IEnumerable<int> users = db.Users.Where(i => i.Login == login && i.Password == password).Select(i => i.ID);
            if (users.Count() == 1)
            {
                this.IsLogined = true;
                this.IdUser = users.First();
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
                }
                return true;
            }
            catch (Exception) { }
            return false;
        }
        public void LogOut()
        {
            this.IsLogined = false;
        }
        public IEnumerable<(int id, string name)> GetSudokuByUser()
        {
            return (IEnumerable<(int id, string name)>)this.db.SavingSudokus.Where(s => s.IdUser == IdUser).Select(i => new { id = i.ID, name = i.Name });
        }
    }
}
