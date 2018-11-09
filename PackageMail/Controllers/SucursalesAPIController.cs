namespace PackageMail.Controllers
{
    using PackageMail.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;
    public class SucursalesAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SucursalesAPI
        public IQueryable<Sucursales> GetSucursales()
        {
            return db.Sucursales;
        }

        // GET: api/SucursalesAPI/5
        [ResponseType(typeof(Sucursales))]
        public IHttpActionResult GetSucursales(int id)
        {
            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            return Ok(sucursales);
        }

        // PUT: api/SucursalesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSucursales(int id, Sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursales.SucursalId)
            {
                return BadRequest();
            }

            db.Entry(sucursales).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalesExists(id))
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

        // POST: api/SucursalesAPI
        [ResponseType(typeof(Sucursales))]
        public IHttpActionResult PostSucursales(Sucursales sucursales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursales.Add(sucursales);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sucursales.SucursalId }, sucursales);
        }

        // DELETE: api/SucursalesAPI/5
        [ResponseType(typeof(Sucursales))]
        public IHttpActionResult DeleteSucursales(int id)
        {
            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return NotFound();
            }

            db.Sucursales.Remove(sucursales);
            db.SaveChanges();

            return Ok(sucursales);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SucursalesExists(int id)
        {
            return db.Sucursales.Count(e => e.SucursalId == id) > 0;
        }
    }
}