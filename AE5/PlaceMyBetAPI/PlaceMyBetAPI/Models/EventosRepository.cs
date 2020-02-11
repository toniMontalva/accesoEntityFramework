﻿using MySql.Data.MySqlClient;
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
    }
}