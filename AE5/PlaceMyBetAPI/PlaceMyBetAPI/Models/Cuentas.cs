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
    }
}