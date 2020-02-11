using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class MercadosRepository
    {
        internal List<Mercado> Retrieve()
        {
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.ToList();
            }

            return mercados;
        }

        internal Mercado BuscarMercadoPorID(int id)
        {
            Mercado mercado;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados
                    .Where(s => s.MercadoId == id)
                    .FirstOrDefault();
            }

            return mercado;
        }

        internal void Save(Mercado m)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Mercados.Add(m);
            context.SaveChanges();
        }

        internal Mercado QueMercadoEsLaApuesta(Apuesta apuesta)
        {
            return BuscarMercadoPorID(apuesta.MercadoId);
        }

        internal Mercado RecalculoCuotas(Mercado mercado, Apuesta apuesta)
        {
            double probabilidadOver = 0.0;
            double probabilidadUnder = 0.0;
            string tipoApuesta = apuesta.Tipo.ToLower();
            if (tipoApuesta.Contains("over"))
            {
                mercado.DineroOver += apuesta.Cantidad;
            }
            else
            {
                mercado.DineroUnder += apuesta.Cantidad;
            }
            probabilidadOver = mercado.DineroOver / (mercado.DineroOver + mercado.DineroUnder);
            probabilidadUnder = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder);

            mercado.CuotaOver = Math.Round(1 / probabilidadOver * 0.95, 2);
            mercado.CuotaUnder = Math.Round(1 / probabilidadUnder * 0.95, 2);

            return mercado;            
        }

        internal void UpdateMercadoExistente(int id, Apuesta apuesta)
        {           
            Mercado mercado = QueMercadoEsLaApuesta(apuesta);
            mercado = RecalculoCuotas(mercado, apuesta);

            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Mercados.Update(mercado);
            context.SaveChanges();
        }        
    }
}