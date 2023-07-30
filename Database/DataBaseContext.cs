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
        public DataBaseContext()
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<SavingSudoku> SavingSudokus { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=den1.mssql7.gear.host;
                Initial Catalog=sudokudatabase1;
                User ID=sudokudatabase1;
                Password=Fv6n33Ynq~-N;
                Connect Timeout=30;
                Encrypt=False;
                Trust Server Certificate=False;
                Application Intent=ReadWrite;
                Multi Subnet Failover=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SavingSudoku>().HasOne(s => s.User).WithMany(u => u.SavingSudokus).HasForeignKey(s => s.IdUser);
        }
    }
}
