namespace PackageMail.Controllers
{
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Description;

    public class EstadosAPIController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EstadosAPI
        public IQueryable<Estados> GetEstados()
        {
            return db.Estados;
        }

        // GET: api/EstadosAPI/5
        [ResponseType(typeof(Estados))]
        public IHttpActionResult GetEstados(int id)
        {
            Estados estados = db.Estados.Find(id);
            if (estados == null)
            {
                return NotFound();
            }

            return Ok(estados);
        }

        // PUT: api/EstadosAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEstados(int id, Estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estados.EstadoId)
            {
                return BadRequest();
            }

            db.Entry(estados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadosExists(id))
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

        // POST: api/EstadosAPI
        [ResponseType(typeof(Estados))]
        public IHttpActionResult PostEstados(Estados estados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Estados.Add(estados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = estados.EstadoId }, estados);
        }

        // DELETE: api/EstadosAPI/5
        [ResponseType(typeof(Estados))]
        public IHttpActionResult DeleteEstados(int id)
        {
            Estados estados = db.Estados.Find(id);
            if (estados == null)
            {
                return NotFound();
            }

            db.Estados.Remove(estados);
            db.SaveChanges();

            return Ok(estados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstadosExists(int id)
        {
            return db.Estados.Count(e => e.EstadoId == id) > 0;
        }
    }
}