using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    public class InvitationController : ApiController
    {
        private static testdbEntities testdb = new testdbEntities();
        public IEnumerable<Invitation> Get()
        {
            return testdb.Invitation.ToList();
        }
        public Invitation GET(int id)
        {
            return testdb.Invitation.Where(a => a.id == id).FirstOrDefault();
        }
        public IHttpActionResult Post(Invitation invitation)
        {
            //crear la invitacion
            //validacion
            try {
                invitation.asistencia = false;
                testdb.Invitation.Add(invitation);
                testdb.SaveChanges();
                return Ok(invitation);
            }
            catch 
            {
                return NotFound();
            }
         
        }
        [Route("api/invitation/calculeUserAsistidos/{id}")]
        [HttpGet]
        public int GetCalculeAsistidos(int id)
        {
            return testdb.Invitation.Where(a => a.idconferency == id && a.asistencia==true).Count();

        }
        [Route("api/invitation/getInvitados/{id}")]
        [HttpGet]
        public IHttpActionResult getInvitados(int id)
        {
            return Ok(testdb.Invitation.Where(a => a.idconferency == id ).ToList());

        }
        public Invitation Put(int?  conferenceiD, int idpersonal )
        {
            //validacion
            // comprobar que el tio fue a la conferencia

            var invitacion = testdb.Invitation.Where(a => a.idpersonal==idpersonal && a.idconferency==conferenceiD ).FirstOrDefault();
            invitacion.asistencia = true;
            return invitacion;
        }

    }
}
