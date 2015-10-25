using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CotacaoApp.Models;
using CotacaoApp.DAO;
using Microsoft.Web.Mvc;
using System.Data.Entity.Validation;
using CotacaoApp.Filters;
using System.Collections.Generic;

namespace CotacaoApp.Controllers
{
    [AutorizacaoFilter]
    public class PropostaController : Controller
    {

        private DefaultConnection db = new DefaultConnection();

        private Proposta _proposta;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var serialized = Request.Form["proposta"];
            if (serialized != null)
            {
                // Form was posted containing serialized data
                _proposta = (Proposta)new MvcSerializer().Deserialize(serialized);
                try
                {
                    TryUpdateModel(_proposta);
                }
                catch(Exception)
                {
                    _proposta = (Proposta)TempData["proposta"] ?? new Proposta();

                }
                

            }
            else
            {
                _proposta = (Proposta)TempData["proposta"] ?? new Proposta();
            }
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Result is RedirectToRouteResult)
            {
                TempData["proposta"] = _proposta;
            }
        }


        // GET: Proposta
        public ActionResult Index()
        {
            List<Proposta> propostas = db.Proposta.ToList();
            List<Proposta> propostasCompleta = new List<Proposta>();
            PropostaDAO propostaDAO = new PropostaDAO();
            foreach (Proposta proposta in propostas)
            {
                propostasCompleta.Add(propostaDAO.GetProposta(proposta.Id));
            }

            return View(propostasCompleta);
        }


        public ActionResult Passo1(Proposta proposta, string btnVoltar, string btnAvancar)
        {
            if (btnAvancar != null)
            {
                return RedirectToAction("Passo2");
            }
            _proposta.Coberturas = db.Cobertura.ToList();
            return View(_proposta);
        }

 
        public ActionResult Passo2(string btnVoltar, string btnAvancar)
        {
            if (btnVoltar != null)
            {
                return RedirectToAction("Passo1");
            }
            if (btnAvancar != null )
            {
                return RedirectToAction("Passo3");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(_proposta);

        }

        public ActionResult Passo3(string btnVoltar, string btnAvancar)
        {
            if (btnVoltar != null)
            {
                return RedirectToAction("Passo2");
            }
            else if (btnAvancar != null)
            {
                return RedirectToAction("Passo4");
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(_proposta);

        }

        public ActionResult Passo4(string btnVoltar, string btnAvancar)
        {
            if (btnVoltar != null)
            {
                return RedirectToAction("Passo3");
            }
            else if (btnAvancar != null)
            {
                return RedirectToAction("Passo5");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(_proposta);

        }

        public ActionResult Passo5(string btnVoltar, string btnAvancar)
        {
            if (btnVoltar != null)
            {
                return RedirectToAction("Passo4");
            }
            else if (btnAvancar != null && ModelState.IsValid)
            {
                try
                {
                    PropostaDAO propostaDAO = new PropostaDAO();
                    propostaDAO.Insert(_proposta);
                    return RedirectToAction("Passo6");

                }
                catch (DbEntityValidationException ex) { 
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("; ", errorMessages);

                    // Combine the original exception message with the new one.
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }catch(Exception e)
                {
                    
                    throw new Exception("stack" + e.StackTrace);
                }
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(_proposta);

        }

        public ActionResult Passo6(string btnVoltar, string btnAvancar)
        {
            return View(_proposta);
            //return RedirectToAction("Details");
        }

        // GET: Proposta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Proposta proposta = db.Proposta.Find(id);
            PropostaDAO propostaDao = new PropostaDAO();
            Proposta proposta = propostaDao.GetProposta(id);
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

            PropostaDAO propostaDao = new PropostaDAO();
            Proposta proposta = propostaDao.GetProposta(id);
            proposta.Coberturas = db.Cobertura.ToList();

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