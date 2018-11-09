namespace PackageMail.Controllers
{
    using PackageMail.Models;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    public class EstadosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Estados
        public ActionResult Index()
        {
            return View(db.Estados.ToList());
        }

        // GET: Estados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados estados = db.Estados.Find(id);
            if (estados == null)
            {
                return HttpNotFound();
            }
            return View(estados);
        }

        // GET: Estados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstadoId,Estado")] Estados estados)
        {
            if (ModelState.IsValid)
            {
                db.Estados.Add(estados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estados);
        }

        // GET: Estados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados estados = db.Estados.Find(id);
            if (estados == null)
            {
                return HttpNotFound();
            }
            return View(estados);
        }

        // POST: Estados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstadoId,Estado")] Estados estados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estados);
        }

        // GET: Estados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estados estados = db.Estados.Find(id);
            if (estados == null)
            {
                return HttpNotFound();
            }
            return View(estados);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estados estados = db.Estados.Find(id);
            db.Estados.Remove(estados);
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
