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
        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using(PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.ToList();
            }
            return apuestas;
        }

        internal Apuesta Retrieve(int id)
        {
            Apuesta apuestas;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas
                    .Where(s => s.ApuestaId == id)
                    .FirstOrDefault();
            }


            return apuestas;
        }

        internal void Save(Apuesta a)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Apuestas.Add(a);
            context.SaveChanges();

        }

        internal List<Apuesta> ObtenerApuestasPorEmailQuery(string email, List<Usuario> users)
        {
            /*
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
            */
            return null;
        }

        internal List<Apuesta> ObtenerApuestasPorMercadoIdQuery(int id)
        {
            /*
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
            */
            return null;
        }
    }
}