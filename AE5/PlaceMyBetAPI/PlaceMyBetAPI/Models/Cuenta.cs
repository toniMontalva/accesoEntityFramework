using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public string NombreBanco { get; set; }
        public string NumeroTarjeta  { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        public Cuenta(int cuentaId, string nombreBanco, string numeroTarjeta, int usuarioId)
        {
            CuentaId = cuentaId;
            NombreBanco = nombreBanco;
            NumeroTarjeta = numeroTarjeta;
            UsuarioId = usuarioId;
        }

        public Cuenta()
        {

        }
    }
}