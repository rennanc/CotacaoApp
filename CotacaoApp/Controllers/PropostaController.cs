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
using PagedList;

namespace CotacaoApp.Controllers
{
    
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

        public JsonResult ObterCobertura(Cobertura cobertura)
        {
            if(cobertura.Id == 0)
            {
                return null;
            }
            cobertura = db.Cobertura.Find(cobertura.Id);
            return Json(cobertura.DescricaoCobertura, JsonRequestBehavior.AllowGet);
        }




        // GET: Proposta
        [AutorizacaoFilter]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewBag.CpfSortParm = String.IsNullOrEmpty(sortOrder) ? "cpf_desc" : "cpf";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            //old
            List<Proposta> propostas = db.Proposta.ToList();
            List<Proposta> propostasCompleta = new List<Proposta>();
            PropostaDAO propostaDAO = new PropostaDAO();
            foreach (Proposta proposta in propostas)
            {
                propostasCompleta.Add(propostaDAO.GetProposta(proposta.Id));
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                propostasCompleta = propostasCompleta.Where(s => s.Segurado.Nome.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            switch (sortOrder)
            {
                case "nome_desc":
                    propostasCompleta = propostasCompleta.OrderByDescending(p => p.Segurado.Nome).ToList();
                    break;
                case "cpf":
                    propostasCompleta = propostasCompleta.OrderBy(p => p.Segurado.CodigoCpf).ToList();
                    break;
                case "cpf_desc":
                    propostasCompleta = propostasCompleta.OrderByDescending(p => p.Segurado.CodigoCpf).ToList();
                    break;
                default:  // Name ascending 
                    propostasCompleta = propostasCompleta.OrderBy(p => p.Segurado.Nome).ToList();
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            PagedList<Proposta> propostaList = new PagedList<Proposta>(propostasCompleta, pageNumber, pageSize);
            return View(propostaList);
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
        [AutorizacaoFilter]
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
        [AutorizacaoFilter]
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
        [AutorizacaoFilter]
        public ActionResult Edit(Proposta proposta)
        {

            db.Entry(proposta).State = EntityState.Modified;
            PropostaDAO propostaDao = new PropostaDAO();
            propostaDao.Save(proposta);
            return RedirectToAction("Index");
        }


        // GET: Proposta/Delete/5
        [AutorizacaoFilter]
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
        [AutorizacaoFilter]
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