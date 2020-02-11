using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class UsuariosRepository
    {
        /*
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=acceso_datos;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);

            return con;
        }
        */

        internal List<Usuario> Retrieve()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                usuarios = context.Usuarios.ToList();
            }

            return usuarios;
            /*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuario";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Usuario us = null;
                List<Usuario> usuarios = new List<Usuario>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetString(3) + " " + res.GetString(4) + " " + res.GetInt32(5) + " " + res.GetDouble(6));
                    us = new Usuario(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetInt32(5), res.GetDouble(6));
                    usuarios.Add(us);
                }

                con.Close();                
                return usuarios;
            } catch(MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
            */
            return null;            
        }

        internal Usuario Retrieve(int id)
        {
            Usuario usuario;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                usuario = context.Usuarios
                    .Where(s => s.UsuarioId == id)
                    .FirstOrDefault();
            }

            return usuario;
        }

        internal void Save(Usuario u)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Usuarios.Add(u);
            context.SaveChanges();
        }

    }
}