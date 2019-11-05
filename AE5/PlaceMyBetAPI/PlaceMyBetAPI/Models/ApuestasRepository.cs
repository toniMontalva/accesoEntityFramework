using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class ApuestasRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=acceso_datos;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);

            return con;
        }

        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta ap = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetString(3) + " " + res.GetInt32(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                    ap = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetString(3), res.GetInt32(4), res.GetInt32(5), res.GetInt32(6));
                    apuestas.Add(ap);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from usuario, apuestas WHERE usuario.id = apuestas.id_usuario";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                ApuestaDTO ap = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3) + " " + res.GetString(4) + " " 
                        + res.GetInt32(5) + " " + res.GetDouble(6) + " " + res.GetInt32(7) + " " + res.GetDouble(8) + " " + res.GetDouble(9) + res.GetString(10) + " " + res.GetInt32(11));
                    string tipoMercado = res.GetString(10).ToLower();
                    string overUnder = "";
                    string mercadoUnderOver = "";
                    if (tipoMercado.Contains("over"))
                    {
                        overUnder = tipoMercado.Substring(0, 4);
                        mercadoUnderOver = tipoMercado.Substring(5);
                    } else if (tipoMercado.Contains("under"))
                    {
                        overUnder = tipoMercado.Substring(0, 5);
                        mercadoUnderOver = tipoMercado.Substring(6);
                    }
                    else
                    {
                        string usageText = "Error al declarar la apuesta como under/over";
                        TextWriter errorWriter = Console.Error;
                        errorWriter.WriteLine(usageText);
                    }
                    ap = new ApuestaDTO(res.GetString(3), mercadoUnderOver, res.GetDouble(8), overUnder, res.GetDouble(9));
                    apuestas.Add(ap);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        internal void Save(Apuesta apuesta)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();

            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            command.CommandText = "INSERT into apuestas(id, cuota, cantidad, tipo, id_usuario, id_evento, id_mercado) values ('" + apuesta.ApuestaId + "','" + apuesta.Cuota + "','" + apuesta.Cantidad +
                "','" + apuesta.Tipo + "','" + apuesta.UsuarioId + "','" + apuesta.EventoId + "','" + apuesta.MercadoId + "')";
            Debug.WriteLine("comando " + command.CommandText);
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e) {
                Debug.WriteLine("Se ha producido un error de conexión");
            }
        }

        internal List<Apuesta> ObtenerApuestasPorEmailQuery(string email, List<Usuario> users)
        {
            int idUser = -1;
            foreach(Usuario user in users)
            {
                if (user.Email.Equals(email))
                {
                    idUser = user.UsuarioId;
                    break;
                }
            }

            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas where id_usuario=@idUser";
            command.Parameters.AddWithValue("@idUser", idUser);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta ap = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetString(3) + " " + res.GetInt32(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                    ap = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetString(3), res.GetInt32(4), res.GetInt32(5), res.GetInt32(6));
                    apuestas.Add(ap);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        internal List<Apuesta> ObtenerApuestasPorMercadoIdQuery(int id)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuestas where id_mercado=@id";
            command.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Apuesta ap = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetString(3) + " " + res.GetInt32(4) + " " + res.GetInt32(5) + " " + res.GetInt32(6));
                    ap = new Apuesta(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetString(3), res.GetInt32(4), res.GetInt32(5), res.GetInt32(6));
                    apuestas.Add(ap);
                }

                con.Close();
                return apuestas;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }
    }
}