using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class Cuentas
    {
        public int CuentaId { get; set; }
        public string NombreBanco { get; set; }
        public string NumeroTarjeta  { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Cuentas(int id, string nomBanco, string numTarjeta, int userId)
        {
            CuentaId = id;
            NombreBanco = nomBanco;
            NumeroTarjeta = numTarjeta;
            UsuarioId = userId;
        }
    }
}