namespace PackageMail.Controllers
{
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    public class SolicitudesAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SolicitudesAPI
        public IQueryable<Solicitudes> GetSolicitudes()
        {
            return db.Solicitudes;
        }

        // GET: api/SolicitudesAPI/5
        [ResponseType(typeof(Solicitudes))]
        public IHttpActionResult GetSolicitudes(int id)
        {
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            if (solicitudes == null)
            {
                return NotFound();
            }

            return Ok(solicitudes);
        }

        // PUT: api/SolicitudesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSolicitudes(int id, Solicitudes solicitudes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solicitudes.SolicitudId)
            {
                return BadRequest();
            }

            db.Entry(solicitudes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SolicitudesAPI
        [ResponseType(typeof(Solicitudes))]
        public IHttpActionResult PostSolicitudes(Solicitudes solicitudes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Solicitudes.Add(solicitudes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = solicitudes.SolicitudId }, solicitudes);
        }

        // DELETE: api/SolicitudesAPI/5
        [ResponseType(typeof(Solicitudes))]
        public IHttpActionResult DeleteSolicitudes(int id)
        {
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            if (solicitudes == null)
            {
                return NotFound();
            }

            db.Solicitudes.Remove(solicitudes);
            db.SaveChanges();

            return Ok(solicitudes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolicitudesExists(int id)
        {
            return db.Solicitudes.Count(e => e.SolicitudId == id) > 0;
        }
    }
}