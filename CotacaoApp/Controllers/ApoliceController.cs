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
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            List<Apolice> apolices = db.Apolice.ToList();
            foreach (Apolice apolice in apolices)
            {
                PropostaDAO propostaDao = new PropostaDAO();
                propostaDao.GetProposta(apolice.CodigoProposta);
                apolice.Proposta = propostaDao.GetProposta(apolice.CodigoProposta);
                apolice.Comissao = db.Comissao.Find(apolice.CodigoComissao);
                apolice.Seguradora = db.Seguradora.Find(apolice.CodigoSeguradora);
            }
            return View(apolices);
            //TODO
            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.StatusSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            //ViewBag.NomeSeguradoSortParm = String.IsNullOrEmpty(sortOrder) ? "nomeSegurado_desc" : "nomeSegurado";
            //ViewBag.SeguradoraSortParm = String.IsNullOrEmpty(sortOrder) ? "seguradora_desc" : "seguradora";
            //ViewBag.VeiculoSortParm = String.IsNullOrEmpty(sortOrder) ? "veiculo_desc" : "veiculo";
            //ViewBag.ValorPremioLiquidoVeiculoSortParm = String.IsNullOrEmpty(sortOrder) ? "valorPremioLiquido_desc" : "valorPremioLiquido";

            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            //ViewBag.CurrentFilter = searchString;


            //List<Apolice> apolices = db.Apolice.ToList();
            //List<Proposta> ApolicesCompletas = new List<Proposta>();
            //PropostaDAO propostaDAO = new PropostaDAO();
            //foreach (Proposta proposta in propostas)
            //{
            //    propostasCompleta.Add(propostaDAO.GetProposta(proposta.Id));
            //}

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    propostasCompleta = propostasCompleta.Where(s => s.Segurado.Nome.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            //}
            //switch (sortOrder)
            //{
            //    case "nome_desc":
            //        propostasCompleta = propostasCompleta.OrderByDescending(p => p.Segurado.Nome).ToList();
            //        break;
            //    case "cpf":
            //        propostasCompleta = propostasCompleta.OrderBy(p => p.Segurado.CodigoCpf).ToList();
            //        break;
            //    case "cpf_desc":
            //        propostasCompleta = propostasCompleta.OrderByDescending(p => p.Segurado.CodigoCpf).ToList();
            //        break;
            //    default:  // Name ascending 
            //        propostasCompleta = propostasCompleta.OrderBy(p => p.Segurado.Nome).ToList();
            //        break;
            //}
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //PagedList<Proposta> propostaList = new PagedList<Proposta>(propostasCompleta, pageNumber, pageSize);
            //return View(propostaList);

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
            apolice.ValorContrato = 0;
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

            PropostaDAO propostaDao = new PropostaDAO();
            Proposta proposta = propostaDao.GetProposta(apolice.CodigoProposta);

            //criando valor da proposta do condutor
            ValorProposta valorProposta = new ValorProposta();
            valorProposta.Valor = apolice.ValorContrato;
            valorProposta.CodigoCondutor = proposta.Segurado.Id;
            valorProposta.DataVencimento = new DateTime(2015, 10, 10);
            valorProposta.CodigoApolice = apolice.Id;

            db.ValorProposta.Add(valorProposta);
            db.SaveChanges();
            //}

            Usuario usuario = (Usuario)Session["UsuarioLogado"];
            //PREPARANDO EMAIL
            apolice.formularioApoliceHtml = apolice.formularioApoliceHtml.Replace("#valorContratoEmail", apolice.ValorContrato.ToString());
            apolice.formularioApoliceHtml = apolice.formularioApoliceHtml.Replace("#corretorEmail", "Joao - " + usuario.Nome);
            apolice.formularioApoliceHtml = apolice.formularioApoliceHtml.Replace("#EnderecoConfirmaEmail", "http://buscaseguros.azurewebsites.net/Proposta/AceitarProposta?" +
                                                                                                            "email=" + proposta.Segurado.Email + 
                                                                                                            "&codigoProposta=" + apolice.CodigoProposta + 
                                                                                                            "&codigoApolice=" + apolice.Id);


            UtilEmailMessage utilEmail = new UtilEmailMessage();
            utilEmail.EnviarEmail("Proposta de Cotação de Seguro", proposta.Segurado.Email, apolice.formularioApoliceHtml);

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
        public ActionResult Edit(Apolice apolice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apolice).State = EntityState.Modified;

                //Criacao de endosso
                Endosso endosso = new Endosso();
                endosso.DataEndosso = DateTime.Now;
                endosso.CodApolice = apolice.Id;

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