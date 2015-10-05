using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CotacaoApp.Models;
using CotacaoApp.DAO;

namespace CotacaoApp.Controllers
{
    public class CoberturaController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Cobertura
        public ActionResult Index()
        {
            return View(db.Cobertura.ToList());
        }

        // GET: Cobertura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = db.Cobertura.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        // GET: Cobertura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NomeCobertura,Tipo,DescricaoCobertura")] Cobertura cobertura)
        {
            if (ModelState.IsValid)
            {
                db.Cobertura.Add(cobertura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cobertura);
        }

        // GET: Cobertura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = db.Cobertura.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NomeCobertura,Tipo,DescricaoCobertura")] Cobertura cobertura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cobertura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cobertura);
        }

        // GET: Cobertura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura cobertura = db.Cobertura.Find(id);
            if (cobertura == null)
            {
                return HttpNotFound();
            }
            return View(cobertura);
        }

        // POST: Cobertura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cobertura cobertura = db.Cobertura.Find(id);
            db.Cobertura.Remove(cobertura);
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