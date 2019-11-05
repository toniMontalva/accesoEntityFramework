using PlaceMyBetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetAPI.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestasRepository();
            //List<Apuesta> apuestas = repo.Retrieve();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO();

            return apuestas;
        }

        // GET: api/Apuestas/5
        public List<Apuesta> Get(int id)
        {
            return null;
        }

        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestasRepository();
            repo.Save(apuesta);
            var repoUpdate = new MercadosRepository();
            repoUpdate.UpdateMercadoExistente(apuesta.MercadoId, apuesta);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
