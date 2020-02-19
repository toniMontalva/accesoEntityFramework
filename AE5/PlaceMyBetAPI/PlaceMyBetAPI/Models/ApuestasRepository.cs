using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class ApuestasRepository
    {
        public ApuestaDTO ToDTO(Apuesta apuesta)
        {
            int eventoId;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventoId = context.Mercados.FirstOrDefault(m => m.MercadoId == apuesta.MercadoId).EventoId;
            }

            return new ApuestaDTO(apuesta.UsuarioId, eventoId, apuesta.Cuota, apuesta.Cantidad, apuesta.Tipo, apuesta.Mercado);
        }

        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> apuestas = new List<Apuesta>();

            using(PlaceMyBetContext context = new PlaceMyBetContext())
            {
                //apuestas = context.Apuestas.ToList();
                apuestas = context.Apuestas.Include(p => p.Mercado).ToList();
            }

            return apuestas;
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();

            using(PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(p => p.Mercado).Select(p => ToDTO(p)).ToList();
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