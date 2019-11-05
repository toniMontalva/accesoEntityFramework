using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class Mercado
    {
        public int MercadoId { get; set; }
        public int EventoId { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double TipoMercado { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }

        public Mercado(int mercadoId, int eventId, double cuotaOver, double cuotaUnder, double tMercado, double dineroOver, double dineroUnder)
        {
            MercadoId = mercadoId;
            EventoId = eventId;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            tMercado = TipoMercado;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
        }
    }

    public class MercadoDTO
    {
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double TipoMercado { get; set; }

        public MercadoDTO(double cuotaOver, double cuotaUnder, double tMercado)
        {
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            TipoMercado = tMercado;
        }
    }
}