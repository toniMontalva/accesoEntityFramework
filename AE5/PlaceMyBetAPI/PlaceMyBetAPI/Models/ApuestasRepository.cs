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
    }
}