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
            return BuscarMercadoPorID(apuesta.Mercado.MercadoId);
        }

        internal Mercado RecalculoCuotas(Mercado mercado, Apuesta apuesta)
        {
            /*
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
            */
            return null;
        }

        internal void UpdateMercadoExistente(int id, Apuesta apuesta)
        {
            /*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            Mercado mercado = QueMercadoEsLaApuesta(apuesta);
            mercado = RecalculoCuotas(mercado, apuesta);

            // Esto no
            command.CommandText = "UPDATE mercados SET id=@id, id_evento=@id_evento, cuota_over=@cuota_over, cuota_under=@cuota_under, dinero_over=@dinero_over," +
                "dinero_under=@dinero_under, tipo_mercado=@tipo_mercado WHERE id=@id";

            command.Parameters.AddWithValue("@id", mercado.MercadoId);
            command.Parameters.AddWithValue("@id_evento", mercado.EventoId);
            command.Parameters.AddWithValue("@cuota_over", mercado.CuotaOver);
            command.Parameters.AddWithValue("@cuota_under", mercado.CuotaUnder);
            command.Parameters.AddWithValue("@dinero_over", mercado.DineroOver);
            command.Parameters.AddWithValue("@dinero_under", mercado.DineroUnder);
            command.Parameters.AddWithValue("@tipo_mercado", mercado.TipoMercado);

            // Tampoco hasta aqui
            

            command.CommandText = "UPDATE mercados SET cuota_over=@cuota_over, cuota_under=@cuota_under, dinero_over=@dinero_over," +
                "dinero_under=@dinero_under WHERE id=@id";

            command.Parameters.AddWithValue("@id", mercado.MercadoId);
            command.Parameters.AddWithValue("@cuota_over", mercado.CuotaOver);
            command.Parameters.AddWithValue("@cuota_under", mercado.CuotaUnder);
            command.Parameters.AddWithValue("@dinero_over", mercado.DineroOver);
            command.Parameters.AddWithValue("@dinero_under", mercado.DineroUnder);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                con.Close();
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
            }
            */
        }        
    }
}