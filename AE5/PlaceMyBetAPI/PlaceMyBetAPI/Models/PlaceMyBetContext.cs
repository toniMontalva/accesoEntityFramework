using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public PlaceMyBetContext()
        {

        }

        public PlaceMyBetContext(DbContextOptions options) 
        : base(options)
        {

        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=entity_framework;Uid=root;Pwd=''; SslMode = none");//màquina retos

            }
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            modelBuilder.Entity<Usuario>().HasData(new Usuario(1, "User1", null, null, null, 20, 10));
            modelBuilder.Entity<Cuentas>().HasData(new Cuentas(1, "BBVA", "1234", 1));
            modelBuilder.Entity<Evento>().HasData(new Evento(1, "Valencia", "Madrid"));
            modelBuilder.Entity<Evento>().HasData(new Evento(2, "Barcelona", "Madrid"));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 1, 1.80, 1.57, "1.5", 100, 100));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2, 2, 1.70, 1.35, "3.5", 150, 180));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1,1.8,50,"over 1.5",1,1,1));
        }

    }
}