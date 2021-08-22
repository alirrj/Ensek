using ENSEK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENSEK.DataAccess
{
    public class EnsekDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EnsekDb;Trusted_Connection=True;");
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<MeterReader> MeterReader { get; set; }
    }
}
