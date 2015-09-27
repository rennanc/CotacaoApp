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
    public class SinistroController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(db.Sinistro.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura sinistro = db.Sinistro.Find(id);
            if (sinistro == null)
            {
                return HttpNotFound();
            }
            return View(sinistro);
        }

        // GET: Sinistro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,DataSinistro,LocalSinistro,DescricaoSinistro,SituacaoSinistro,ObservacaoSinistro")] Cobertura sinistro)
        {
            if (ModelState.IsValid)
            {
                db.Sinistro.Add(sinistro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sinistro);
        }

        // GET: Sinistro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura sinistro = db.Sinistro.Find(id);
            if (sinistro == null)
            {
                return HttpNotFound();
            }
            return View(sinistro);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,DataSinistro,LocalSinistro,DescricaoSinistro,SituacaoSinistro,ObservacaoSinistro")] Cobertura sinistro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinistro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sinistro);
        }

        // GET: Sinistro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cobertura sinistro = db.Sinistro.Find(id);
            if (sinistro == null)
            {
                return HttpNotFound();
            }
            return View(sinistro);
        }

        // POST: Sinistro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cobertura sinistro = db.Sinistro.Find(id);
            db.Sinistro.Remove(sinistro);
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