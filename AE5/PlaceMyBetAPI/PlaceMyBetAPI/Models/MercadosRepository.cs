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
        /*
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=acceso_datos;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);

            return con;
        }
        */

        internal List<Mercado> Retrieve()
        {
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Discos.ToList();
            }

            return mercados;

            /*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado mer = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(6) + " " + res.GetDouble(4) + " " + res.GetDouble(5));
                    mer = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3), res.GetString(6), res.GetDouble(4), res.GetDouble(5));
                    mercados.Add(mer);
                }

                con.Close();
                return mercados;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
            */
            return null;
        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            /*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO mer = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(6) + " " + res.GetDouble(4) + " " + res.GetDouble(5));
                    mer = new MercadoDTO(res.GetDouble(2), res.GetDouble(3), res.GetString(6));
                    mercados.Add(mer);
                }

                con.Close();
                return mercados;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
            */
            return null;
        }

        /*internal void SaveMercadoNuevo(Mercado mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert";
        }*/

        internal List<Mercado> MercadosQuery(int id, double tM, double cO, double cU)
        {
            /*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            command.CommandText = "select * from mercados where id_evento=@id and tipo_mercado=@tM and cuota_over=@cO and cuota_under=@cU";
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@tM", tM);
            command.Parameters.AddWithValue("@cO", cO);
            command.Parameters.AddWithValue("@cU", cU);

            List<Mercado> mercados = new List<Mercado>();

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado mer = null;
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(6) + " " + res.GetDouble(4) + " " + res.GetDouble(5));
                    mer = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3), res.GetString(6), res.GetDouble(4), res.GetDouble(5));
                }

                mercados.Add(mer);
                con.Close();
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
            return mercados;
            */
            return null;
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
            /*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados where id=@id";
            command.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado mer = null;
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetString(6) + " " + res.GetDouble(4) + " " + res.GetDouble(5));
                    mer = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3), res.GetString(6), res.GetDouble(4), res.GetDouble(5));
                }

                con.Close();
                return mer;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
            */
            return null;
        }

        internal Mercado QueMercadoEsLaApuesta(Apuesta apuesta)
        {
            return BuscarMercadoPorID(apuesta.MercadoId);
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

        internal void Save(Mercado m)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Mercados.Add(m);
            context.SaveChanges();
        }
    }
}