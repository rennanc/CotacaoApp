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
using CotacaoApp.Util;
using CotacaoApp.Filters;

namespace CotacaoApp.Controllers
{
    [AutorizacaoFilter]
    public class ApoliceController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Apolice
        public ActionResult Index()
        {
            List<Apolice> apolices = db.Apolice.ToList();
            foreach(Apolice apolice in apolices)
            {
                PropostaDAO propostaDao = new PropostaDAO();
                propostaDao.GetProposta(apolice.CodigoProposta);
                apolice.Proposta = propostaDao.GetProposta(apolice.CodigoProposta);
                apolice.Comissao = db.Comissao.Find(apolice.CodigoComissao);
                apolice.Seguradora = db.Seguradora.Find(apolice.CodigoSeguradora);
            }
            return View(apolices);
        }

        // GET: Apolice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apolice apolice = db.Apolice.Find(id);
            PropostaDAO propostaDao = new PropostaDAO();
            propostaDao.GetProposta(apolice.CodigoProposta);
            apolice.Proposta = propostaDao.GetProposta(apolice.CodigoProposta);
            apolice.Comissao = db.Comissao.Find(apolice.CodigoComissao);
            apolice.Seguradora = db.Seguradora.Find(apolice.CodigoSeguradora);
            if (apolice == null)
            {
                return HttpNotFound();
            }
            return View(apolice);
        }

        // GET: Apolice/Create
        public ActionResult Create(int? propostaId)
        {

            Apolice apolice = new Apolice();

            PropostaDAO propostaDao = new PropostaDAO();
            apolice.Proposta = propostaDao.GetProposta(propostaId);
            apolice.Seguradoras = db.Seguradora.ToList();
            return View(apolice);
        }

        //// GET: Apolice/Create
        //public ActionResult Create(int? propostaId)
        //{

        //    Apolice apolice = new Apolice();

        //    PropostaDAO propostaDao = new PropostaDAO();
        //    apolice.Proposta = propostaDao.GetProposta(propostaId);
        //    apolice.Seguradoras = db.Seguradora.ToList();
        //    return View(apolice);
        //}

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult SendForm(Apolice apolice)
        {
            //if (ModelState.IsValid)
            //{
                db.Comissao.Add(apolice.Comissao);
                db.SaveChanges();
                apolice.CodigoComissao = apolice.Comissao.Id;
                db.Apolice.Add(apolice);
                db.SaveChanges();
            //}
            UtilEmailMessage utilEmail = new UtilEmailMessage();
            utilEmail.EnviarEmail(apolice.formularioApoliceHtml);

            return View(apolice);
        }

        // GET: Apolice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apolice apolice = db.Apolice.Find(id);
            PropostaDAO propostaDao = new PropostaDAO();
            apolice.Proposta = propostaDao.GetProposta(apolice.CodigoProposta);
            apolice.Seguradoras = db.Seguradora.ToList();
            apolice.Comissao = db.Comissao.Find(apolice.CodigoComissao);
            if (apolice == null)
            {
                return HttpNotFound();
            }
            return View(apolice);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Proposta,Comissao,Segurdora,Contrato,Status")] Apolice apolice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apolice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apolice);
        }

        // GET: Apolice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apolice apolice = db.Apolice.Find(id);
            if (apolice == null)
            {
                return HttpNotFound();
            }
            return View(apolice);
        }

        // POST: Apolice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apolice apolice = db.Apolice.Find(id);
            db.Apolice.Remove(apolice);
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