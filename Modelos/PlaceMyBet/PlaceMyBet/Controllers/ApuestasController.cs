﻿using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Apuestas/5
        public ApuestaDTO Get(int id)
        {
            var repo = new ApuestaRepository();
            ApuestaDTO e = repo.Retrieve();
            return e;
        }

        // POST: api/Apuestas
        public void Post([FromBody] ApuestaDTO apuesta)
        {

            var repo = new ApuestaRepository();
            var repo2 = new MercadoRepository();
            var tipo = repo.Cuota(apuesta);
            repo.Save(apuesta, tipo);
            repo2.dineroUpdate(apuesta);
            var cUpdate = repo2.cuotaUpdate();
            repo2.calc(cUpdate, apuesta);

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