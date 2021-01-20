using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication3.Controllers
{
    
    public class PonenteController : ApiController
    {
        private static testdbEntities testdb = new testdbEntities();
        public IHttpActionResult Get()
        {
            return Ok(testdb.Ponente.ToList());
        }
        public IHttpActionResult GET(int id)
        {
            return Ok (testdb.Ponente.Where(a => a.id == id).FirstOrDefault());
        }
        public IHttpActionResult Post(Ponente ponente)
        {
            //validacion
            testdb.Ponente.Add(ponente);
            testdb.SaveChanges();
            return Ok(ponente);
        }
            
    }
}
