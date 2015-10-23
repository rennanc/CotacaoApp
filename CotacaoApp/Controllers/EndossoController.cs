using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CotacaoApp.Models;
using CotacaoApp.DAO;
using CotacaoApp.Filters;

namespace CotacaoApp.Controllers
{
    [AutorizacaoFilter]
    public class EndossoController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Endosso
        public ActionResult Index()
        {
            return View(db.Endosso.ToList());
        }

        // GET: Endosso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endosso endosso = db.Endosso.Find(id);
            if (endosso == null)
            {
                return HttpNotFound();
            }
            return View(endosso);
        }

        // GET: Endosso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodApolice,dataAlteracaoEndosso,DataEndosso")] Endosso endosso)
        {
            if (ModelState.IsValid)
            {
                db.Endosso.Add(endosso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(endosso);
        }

        // GET: Endosso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endosso endosso = db.Endosso.Find(id);
            if (endosso == null)
            {
                return HttpNotFound();
            }
            return View(endosso);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodApolice,dataAlteracaoEndosso,DataEndosso")] Endosso endosso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endosso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(endosso);
        }

        // GET: Endosso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endosso endosso = db.Endosso.Find(id);
            if (endosso == null)
            {
                return HttpNotFound();
            }
            return View(endosso);
        }

        // POST: Endosso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endosso endosso = db.Endosso.Find(id);
            db.Endosso.Remove(endosso);
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