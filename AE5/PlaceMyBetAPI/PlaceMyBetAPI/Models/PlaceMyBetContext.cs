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
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
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
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=EntityFrameworkTest;Uid=root;Pwd=''; SslMode = none");
            }
        }

        //Inserció inicial de dades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CultureInfo culInfo = new CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;



            Usuario usuario = new Usuario(1, "User1", "Apellidos", "user1@user.com", "password", 20, 150);

            Cuenta cuenta = new Cuenta(1, "BBVA", "1234", usuario.UsuarioId);

            Evento evento1 = new Evento(1, "Valencia", "Madrid", DateTime.Today);
            Evento evento2 = new Evento(2, "Barcelona", "Madrid", DateTime.Today);

            Mercado mercado1 = new Mercado(1, 1.80, 1.57, "1.5", 100, 100, evento1.EventoId);
            Mercado mercado2 = new Mercado(2, 1.70, 1.35, "3.5", 150, 180, evento2.EventoId);

            Apuesta apuesta = new Apuesta(1, 1.8, 50, "over 1.5", usuario.UsuarioId, mercado1.MercadoId);

            modelBuilder.Entity<Apuesta>().HasData(apuesta);
            modelBuilder.Entity<Cuenta>().HasData(cuenta);
            modelBuilder.Entity<Evento>().HasData(evento1);
            modelBuilder.Entity<Evento>().HasData(evento2);
            modelBuilder.Entity<Mercado>().HasData(mercado1);
            modelBuilder.Entity<Mercado>().HasData(mercado2);
            modelBuilder.Entity<Usuario>().HasData(usuario);
        }
    }
}