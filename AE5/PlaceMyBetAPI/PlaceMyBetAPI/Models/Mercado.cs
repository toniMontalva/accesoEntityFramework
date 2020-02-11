using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class Mercado
    {
        public int MercadoId { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public string TipoMercado { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }

        public int EventoId { get; set; }
        public Evento Evento { get; set; }
        
        public List<Apuesta> Apuestas { get; set; }

        public Mercado(int mercadoId, double cuotaOver, double cuotaUnder, string tipoMercado, double dineroOver, double dineroUnder, int eventoId)
        {
            MercadoId = mercadoId;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            tipoMercado = TipoMercado;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;
            EventoId = eventoId;
        }

        public Mercado()
        {

        }        
    }

    public class MercadoDTO
    {
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }
        public string TipoMercado { get; set; }

        public MercadoDTO(double cuotaUnder, double cuotaOver, string tipoMercado)
        {
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            TipoMercado = tipoMercado;
        }        
    }
}