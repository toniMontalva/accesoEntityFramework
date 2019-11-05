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
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }
        public int MercadoId { get; set; }

        public Apuesta(int apuestaId, double cuota, double cantidad, string tipo, int usrID, int evnID, int merID)
        {
            ApuestaId = apuestaId;
            Cuota = cuota;
            Cantidad = cantidad;
            Tipo = tipo;
            UsuarioId = usrID;
            EventoId = evnID;
            MercadoId = merID;
        }
    }

    public class ApuestaDTO
    {
        public string UsrEmail { get; set; }
        public string TipoMercado { get; set; }
        public double Cuota { get; set; }
        public string TipoOverUnder { get; set; }
        public double Cantidad { get; set; }            

        public ApuestaDTO(string email, string tM, double cuota, string tipoOU, double cantidad)
        {
            UsrEmail = email;
            TipoMercado = tM;
            Cuota = cuota;
            TipoOverUnder = tipoOU;
            Cantidad = cantidad;
        }
    }

}