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
    public class SeguradoraController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Cobertura
        public ActionResult Index()
        {
            return View(db.Seguradora.ToList());
        }

        // GET: Cobertura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguradora seguradora = db.Seguradora.Find(id); 
            if (seguradora == null)
            {
                return HttpNotFound();
            }
            return View(seguradora);
        }

        // GET: Seguradora/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seguradora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SinistroAuto,Recepcao,Producao,Assistencia,Outros,Calculos")] Seguradora seguradora)
        {
            if (ModelState.IsValid)
            {
                db.Seguradora.Add(seguradora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seguradora);
        }

        // GET: Seguradora/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguradora seguradora = db.Seguradora.Find(id);
            if (seguradora == null)
            {
                return HttpNotFound();
            }
            return View(seguradora);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SinistroAuto,Recepcao,Producao,Assistencia,Outros,Calculos")] Seguradora seguradora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seguradora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seguradora);
        }

        // GET: Seguradora/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguradora seguradora = db.Seguradora.Find(id);
            if (seguradora == null)
            {
                return HttpNotFound();
            }
            return View(seguradora);
        }

        // POST: Seguradora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seguradora seguradora = db.Seguradora.Find(id);
            db.Seguradora.Remove(seguradora);
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