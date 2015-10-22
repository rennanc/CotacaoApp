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
    public class ValorPropostaController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: ValorProposta
        public ActionResult Index()
        {
            return View(db.ValorProposta.ToList());
        }

        // GET: ValorProposta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorProposta valproposta = db.ValorProposta.Find(id);
            if (valproposta == null)
            {
                return HttpNotFound();
            }
            return View(valproposta);
        }

        // GET: ValorProposta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoCondutor,CodigoApolice,Descricao,Tipo,DataVencimento,Valor")] ValorProposta valproposta)
        {
            if (ModelState.IsValid)
            {
                db.ValorProposta.Add(valproposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valproposta);
        }

        // GET: ValorProposta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorProposta valproposta = db.ValorProposta.Find(id);
            if (valproposta == null)
            {
                return HttpNotFound();
            }
            return View(valproposta);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoCondutor,CodigoApolice,Descricao,Tipo,DataVencimento,Valor")] ValorProposta valproposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valproposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valproposta);
        }

        // GET: ValorProposta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorProposta valproposta = db.ValorProposta.Find(id);
            if (valproposta == null)
            {
                return HttpNotFound();
            }
            return View(valproposta);
        }

        // POST: ValorProposta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValorProposta valproposta = db.ValorProposta.Find(id);
            db.ValorProposta.Remove(valproposta);
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