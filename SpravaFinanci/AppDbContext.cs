using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpravaFinanci
{
    internal class AppDbKontext : DbContext
    {
        public DbSet<FinancniZaznam> Zaznamy { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mojeFinance.db");
        }
    }
}

