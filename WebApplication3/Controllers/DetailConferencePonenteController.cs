using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    public class DetailConferencePonenteController : ApiController
    {
        private static testdbEntities testdb = new testdbEntities();
        public IEnumerable<detaillsponenteconferency> Get()
        {
            return testdb.detaillsponenteconferency.ToList();
        }
        public detaillsponenteconferency GET(int id)
        {
            return testdb.detaillsponenteconferency.Where(a => a.id == id).FirstOrDefault();
        }
        public detaillsponenteconferency Post(detaillsponenteconferency invitation)
        {
            //validacion
            testdb.detaillsponenteconferency.Add(invitation);
            testdb.SaveChanges();
            return invitation;
        }
    }
}
