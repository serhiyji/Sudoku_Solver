using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities;

namespace Database
{
    public class DataBaseContext : DbContext
    {
        private readonly string connstr;
        public DataBaseContext(string connstr)
        {
            this.connstr = connstr;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<SavingSudoku> SavingSudokus { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connstr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SavingSudoku>().HasOne(s => s.User).WithMany(u => u.SavingSudokus).HasForeignKey(s => s.IdUser);
        }
    }
}
