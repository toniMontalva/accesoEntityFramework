using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class EventosRepository
    {
        internal List<Evento> Retrieve()
        {
            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }

            return eventos;
        }

        internal Evento Retrieve(int id)
        {
            Evento evento;

            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                evento = context.Eventos
                    .Where(s => s.EventoId == id)
                    .FirstOrDefault();
            }
            
            return evento;
        }

        internal void Save(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Eventos.Add(evento);
            context.SaveChanges();
        }

        internal void Update(Evento evento, string equipoLocal, string equipoVisitante)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            evento.EquipoLocal = equipoLocal;
            evento.EquipoVisitante = equipoVisitante;

            context.Eventos.Update(evento);
            context.SaveChanges();
        }

        internal void Delete(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Remove(evento);
            context.SaveChanges();
        }
    }
}