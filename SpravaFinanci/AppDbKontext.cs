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
            // Zde nastavujeme, jaký databázový stroj se má použít a kde databáze leží
            // "Data Source=mojeFinance.db" je tzv. connection string (připojovací řetězec)
            optionsBuilder.UseSqlite("Data Source=mojeFinance.db");
        }
    }
}

