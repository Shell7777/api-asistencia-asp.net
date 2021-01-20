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
    //  context.Entry(categoria).State = EntityState.Modified;
    //#[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PersonController : ApiController
    {
        private static testdbEntities testdb = new testdbEntities();
                      
        public IHttpActionResult Get ()
        {
            return Ok(testdb.Personal.Where(a=>a.hidden == false).ToList());
        }
        public IHttpActionResult GET(int id )
        {
            if (id <= 0) return BadRequest("Not a valid student id");
            var personal = testdb.Personal.Where(a => a.id == id && a.hidden == false).FirstOrDefault();
            if (personal == null) return NotFound();
            return Ok(personal);
        }
        public IHttpActionResult Post(Personal personal  ) 
        {
            //validacion
            personal.hidden = false;
            testdb.Personal.Add(personal);
            testdb.SaveChanges();
            return Ok(personal);
        }
        [Route("api/invitation/personalNotInvited/{idconfereny}")]
        [HttpGet]
        public IHttpActionResult personalNotInvited(int idconfereny)
        {
            var personas = testdb.Personal.Where(a=>a.hidden==false).ToList() ;
            var personas2 = testdb.Personal.Where(a => a.hidden == false).ToList();
            foreach (Personal p in personas)
            {
                foreach (Invitation item in p.Invitation)
                {
                    if (item.idconferency == idconfereny)
                    {
                        personas2.Remove(p);
                    }   
                }
            }
            return Ok (personas2);
            //validacion
           // return Ok(testdb.Invitation.Where(a => a.Conference.id != idconfereny).ToList());
        }


        public IHttpActionResult Put(Personal personal)
        {
            //validacion

            var person = testdb.Personal.Where(a=>a.id == personal.id).FirstOrDefault();
            if (person == null) return NotFound();
            person.nombre = personal.nombre;
            person.apellido= personal.apellido;
            person.username = personal.username;
            person.edad = personal.edad;
            person.genero= personal.genero;
            testdb.SaveChanges();
            return Ok(personal);
        }
        public IHttpActionResult Delete( int id )
        {
            if (id <= 0) return BadRequest("Not a valid student id");
            
            var person = testdb.Personal.Where(a => a.id == id).FirstOrDefault();
            person.hidden = true;
            testdb.SaveChanges();
            return Ok(person);
        }
    }
    
}
