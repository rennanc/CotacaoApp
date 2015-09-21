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
using Microsoft.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CotacaoApp.Controllers
{
    public class PropostaController : Controller
    {

        private DefaultConnection db = new DefaultConnection();

        // GET: Proposta
        public ActionResult Index()
        {
            return View(db.Proposta.ToList());
        }

        private Proposta GetProposta()
        {
            if (Session["proposta"] == null)
            {
                Session["proposta"] = new Proposta();
            }
            return (Proposta)Session["proposta"];
        }

        public ActionResult Passo1(Proposta proposta, string btnVoltar, string btnAvancar)
        {
            if(btnAvancar != null)
            {
                    Proposta PropostaObj = GetProposta();
                    PropostaObj = proposta;
                    return RedirectToAction("Passo2");

            }
            return View();
        }

 
        public ActionResult Passo2(Proposta proposta, string btnVoltar, string btnAvancar)
        {
            Proposta PropostaObj = GetProposta();

            if (btnVoltar != null)
            {
                return RedirectToAction("Passo1", PropostaObj);
                //return RedirectToAction("Passo1", "Proposta", data);
            }
            else if(btnAvancar != null)
            {
                return RedirectToAction("Passo3", proposta);
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult Passo3(Proposta data, string btnVoltar, string btnAvancar)
        {
            if (btnVoltar != null)
            {
                return RedirectToAction("Passo2");
            }
            else if (btnAvancar != null)
            {
                return Content("é o fimmm!!!");
            }
            else
            {
                return View();
            }

        }


        // GET: Proposta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposta proposta = db.Proposta.Find(id);
            if (proposta == null)
            {
                return HttpNotFound();
            }
            return View(proposta);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proposta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Senha")] Proposta proposta)
        {
            if (ModelState.IsValid)
            {
                db.Proposta.Add(proposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proposta);
        }

        // GET: Proposta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposta proposta = db.Proposta.Find(id);
            if (proposta == null)
            {
                return HttpNotFound();
            }
            return View(proposta);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Senha")] Proposta proposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proposta);
        }


        // GET: Proposta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Proposta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proposta proposta = db.Proposta.Find(id);
            db.Proposta.Remove(proposta);
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