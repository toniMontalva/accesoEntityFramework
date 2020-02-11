﻿using PlaceMyBetAPI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetAPI.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados?id=valor1&tMercado=valor2&cuotaOver=valor3&cuotaUnder=valor4
        public List<Mercado> GetMercados(int idE, double tM, double cOver, double cUnder)
        {
            /*CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            var repo = new MercadosRepository();
            List<Mercado> mercados = repo.MercadosQuery(idE, tM, cOver, cUnder);

            return mercados;*/
            return null;

        }

        // POST: api/Mercados
        public void Post([FromBody]Mercado mercado)
        {
            var repo = new MercadosRepository();

            repo.Save(mercado);
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]Mercado mercado)
        {
            
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
