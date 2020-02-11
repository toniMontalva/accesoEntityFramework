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
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public Mercado Mercado { get; set; }
        public int MercadoId { get; set; }

        public Apuesta(int apuestaId, double cuota, double cantidad, string tipo, int usuarioId, int eventoId, int mercadoId)
        {
            ApuestaId = apuestaId;
            Cuota = cuota;
            Cantidad = cantidad;
            UsuarioId = usuarioId;
            //EventoId = eventoId;
            MercadoId = mercadoId;
            Tipo = tipo;
        }

        public Apuesta()
        {

        }
    }
}