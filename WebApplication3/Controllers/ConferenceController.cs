using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    public class ConferenceController : ApiController
    {
        private static testdbEntities testdb = new testdbEntities();
        public IHttpActionResult Get()
        {
            return Ok(testdb.Conference.Where(a => a.hidden == false).ToList());
        }
        public IHttpActionResult GET(int id)
        {
            if (id <= 0) return BadRequest("Not a valid student id");
            var personal = testdb.Conference.Where(a => a.id == id && a.hidden == false).FirstOrDefault();
            if (personal == null) return NotFound();
            return Ok(personal);
        }
        public IHttpActionResult Post(Conference conference)
        {
            //validacion
            conference.hidden = false; 
            testdb.Conference.Add(conference);
            testdb.SaveChanges();
            return Ok(conference);
        }

        public IHttpActionResult Put(Conference conference)
        {
            //validacion

            var conferencedb = testdb.Conference.Where(a => a.id == conference.id).First();
            conferencedb.name = conference.name;
            conferencedb.fecha = conference.fecha;
            conferencedb.hour_end = conference.hour_end;
            conferencedb.hour_start = conference.hour_start;
            conferencedb.lugar = conference.lugar;
            conferencedb.aforo= conference.aforo;
            conference.description = conference.description;
            testdb.SaveChanges();
            return Ok( conference);
        }
    }
}
