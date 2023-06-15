using Microsoft.EntityFrameworkCore;
using SudokuSloverHendler.BetterMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku_Slover.DBContexts.Entities;

namespace Sudoku_Slover.DBContexts
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<SavingSudoku> SavingSudokus { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source = den1.mssql8.gear.host;
                                        Initial Catalog = sudokudatabase74;
                                        Integrated Security = false; 
                                        User ID = sudokudatabase74; 
                                        Password = Td710y~?BE6J;
                                        Connect Timeout = 5; Encrypt = False;
                                        TrustServerCertificate = False;
                                        ApplicationIntent = ReadWrite;
                                        MultiSubnetFailover = False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SavingSudoku>().HasOne(s => s.User).WithMany(u => u.SavingSudokus).HasForeignKey(s => s.IdUser);
        }
    }
}
