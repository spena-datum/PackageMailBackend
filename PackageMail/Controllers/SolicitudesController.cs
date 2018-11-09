namespace PackageMail.Controllers
{
    using Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    public class SolicitudesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Solicitudes
        public ActionResult Index()
        {
            var solicitudes = db.Solicitudes.Include(s => s.Estados).Include(s => s.Sucursales);
            return View(solicitudes.ToList());
        }

        // GET: Solicitudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            if (solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(solicitudes);
        }

        // GET: Solicitudes/Create
        public ActionResult Create()
        {
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Estado");
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Sucursal");
            return View();
        }

        // POST: Solicitudes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SolicitudId,Fecha,Usuario,DescripcionPaquete,EstadoId,Imagen64b,SucursalId")] Solicitudes solicitudes)
        {
            if (ModelState.IsValid)
            {
                db.Solicitudes.Add(solicitudes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Estado", solicitudes.EstadoId);
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Sucursal", solicitudes.SucursalId);
            return View(solicitudes);
        }

        // GET: Solicitudes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            if (solicitudes == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Estado", solicitudes.EstadoId);
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Sucursal", solicitudes.SucursalId);
            return View(solicitudes);
        }

        // POST: Solicitudes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SolicitudId,Fecha,Usuario,DescripcionPaquete,EstadoId,Imagen64b,SucursalId")] Solicitudes solicitudes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitudes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoId = new SelectList(db.Estados, "EstadoId", "Estado", solicitudes.EstadoId);
            ViewBag.SucursalId = new SelectList(db.Sucursales, "SucursalId", "Sucursal", solicitudes.SucursalId);
            return View(solicitudes);
        }

        // GET: Solicitudes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            if (solicitudes == null)
            {
                return HttpNotFound();
            }
            return View(solicitudes);
        }

        // POST: Solicitudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitudes solicitudes = db.Solicitudes.Find(id);
            db.Solicitudes.Remove(solicitudes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
