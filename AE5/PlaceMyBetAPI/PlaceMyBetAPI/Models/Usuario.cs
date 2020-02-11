using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Edad { get; set; }
        public double Saldo { get; set; }
        public Cuenta Cuenta { get; set; }
        public List<Apuesta> Apuestas { get; set; }

        public Usuario()
        {

        }

        public Usuario(int usuarioId, string nombre, string apellidos, string email, string password, int edad, double saldo)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellidos = apellidos;
            Email = email;
            Password = password;
            Edad = edad;
            Saldo = saldo;
        }
    }
}