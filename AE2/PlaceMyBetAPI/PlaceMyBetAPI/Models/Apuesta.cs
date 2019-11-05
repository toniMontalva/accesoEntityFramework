using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class Apuesta
    {
        public int ApuestaId { get; set; }
        public double Cuota { get; set; }
        public double Cantidad { get; set; }
        public string Tipo { get; set; }

        public Apuesta(int apuestaId, double cuota, double cantidad, string tipo)
        {
            ApuestaId = apuestaId;
            Cuota = cuota;
            Cantidad = cantidad;
            Tipo = tipo;
        }
    }
}