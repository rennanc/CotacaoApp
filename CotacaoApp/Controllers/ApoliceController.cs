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
using CotacaoApp.Enumerations;
using PagedList;
using Microsoft.Web.Mvc;

namespace CotacaoApp.Controllers
{
    [AutorizacaoFilter]
    public class ApoliceController : Controller
    {
        private DefaultConnection db = new DefaultConnection();


        private Apolice _apolice;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var serialized = Request.Form["apolice"];
            if (serialized != null)
            {
                // Form was posted containing serialized data
                _apolice = (Apolice)new MvcSerializer().Deserialize(serialized);
                try
                {
                    TryUpdateModel(_apolice);
                }
                catch (Exception)
                {
                    _apolice = (Apolice)TempData["apolice"] ?? new Apolice();

                }


            }
            else
            {
                _apolice = (Apolice)TempData["apolice"] ?? new Apolice();
            }
        }

        // GET: Apolice
        public ViewResult Index(Apolice apoliceSearch, string sortOrder, string currentFilter, int? page)
        {
            string searchString = "";
            //List<Apolice> apolices = db.Apolice.ToList();
            //foreach (Apolice apolice in apolices)
            //{
            //    PropostaDAO propostaDao = new PropostaDAO();
            //    propostaDao.GetProposta(apolice.CodigoProposta);
            //    apolice.Proposta = propostaDao.GetProposta(apolice.CodigoProposta);
            //    apolice.Comissao = db.Comissao.Find(apolice.CodigoComissao);
            //    apolice.Seguradora = db.Seguradora.Find(apolice.CodigoSeguradora);
            //}
            //return View(apolices);
            //TODO
            ViewBag.CurrentSort = sortOrder;
            ViewBag.StatusSortParm = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";
            ViewBag.NomeSeguradoSortParm = String.IsNullOrEmpty(sortOrder) ? "nomeSegurado_desc" : "nomeSegurado";
            ViewBag.SeguradoraSortParm = String.IsNullOrEmpty(sortOrder) ? "seguradora_desc" : "seguradora";
            ViewBag.VeiculoSortParm = String.IsNullOrEmpty(sortOrder) ? "veiculo_desc" : "veiculo";
            ViewBag.ValorPremioLiquidoVeiculoSortParm = String.IsNullOrEmpty(sortOrder) ? "valorPremioLiquido_desc" : "valorPremioLiquido";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            //TODO: Fazer uma consulta só
            List<Apolice> apolices = db.Apolice.ToList();
            foreach (Apolice apolice in apolices)
            {
                PropostaDAO propostaDao = new PropostaDAO();
                apolice.Proposta = propostaDao.GetProposta(apolice.CodigoProposta);
                apolice.Comissao = db.Comissao.Find(apolice.CodigoComissao);
                apolice.Seguradora = db.Seguradora.Find(apolice.CodigoSeguradora);
            }

            //buscas
            if (Status.NENHUM != apoliceSearch.Status)
            {
                apolices = apolices.Where(a => (int)a.Status == (int)apoliceSearch.Status).ToList();
            }
            if(apoliceSearch.Proposta != null && apoliceSearch.Proposta.Segurado != null && apoliceSearch.Proposta.Segurado.Nome != null)
            {
                apolices = apolices.Where(a => a.Proposta.Segurado.Nome.IndexOf(apoliceSearch.Proposta.Segurado.Nome, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
                
                

            //ordenação
            switch (sortOrder)
            {
                case "status_desc":
                    apolices = apolices.OrderByDescending(a => (int)a.Status).ToList();
                    break;
                case "nomeSegurado":
                    apolices = apolices.OrderBy(a => a.Proposta.Segurado.Nome).ToList();
                    break;
                case "nomeSegurado_desc":
                    apolices = apolices.OrderByDescending(a => a.Proposta.Segurado.Nome).ToList();
                    break;
                case "seguradora":
                    apolices = apolices.OrderBy(a => a.Seguradora.NomeSeguradora).ToList();
                    break;
                case "seguradora_desc":
                    apolices = apolices.OrderByDescending(a => a.Seguradora.NomeSeguradora).ToList();
                    break;
                case "veiculo":
                    apolices = apolices.OrderBy(a => a.Proposta.NomeVeiculo).ToList();
                    break;
                case "veiculo_desc":
                    apolices = apolices.OrderByDescending(a => a.Proposta.NomeVeiculo).ToList();
                    break;
                case "valorPremioLiquido":
                    apolices = apolices.OrderBy(a => a.Proposta.NomeVeiculo).ToList();
                    break;
                case "valorPremioLiquido_desc":
                    apolices = apolices.OrderByDescending(a => a.Comissao.ValorComissaoLiquida).ToList();
                    break;
                default:  // Status ascending 
                    apolices = apolices.OrderBy(a => (int)a.Status).ToList();
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            PagedList<Apolice> apoliceList = new PagedList<Apolice>(apolices, pageNumber, pageSize);
            return View(apoliceList);

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

            //Mudando Status para fins de organização
            propostaDao.MudarStatus(proposta.Id, (int)StatusProposta.ATENDIDO);

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
            apolice.formularioApoliceHtml = apolice.formularioApoliceHtml.Replace("#corretorEmail", "Seu Corretor - " + usuario.Nome);
            string url = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath,"");
            apolice.formularioApoliceHtml = apolice.formularioApoliceHtml.Replace("#EnderecoConfirmaEmail", url + "/Proposta/AceitarProposta?" +
                                                                                                            "email=" + proposta.Segurado.Email + 
                                                                                                            "&codigoProposta=" + apolice.CodigoProposta + 
                                                                                                            "&codigoApolice=" + apolice.Id);


            UtilEmailMessage utilEmail = new UtilEmailMessage();
            utilEmail.EnviarEmail("[BUSCA SEGUROS] Sua Proposta de Cotação de Seguro", proposta.Segurado.Email, apolice.formularioApoliceHtml);

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
            apolice.Proposta.Coberturas = db.Cobertura.ToList();
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
        [ValidateInput(false)]
        public ActionResult Edit(Apolice apolice)
        {
            apolice = _apolice;
            //if (ModelState.IsValid)
            //{
                //modificando a antiga para Flag de modificada
                ApoliceDAO apoliceDao = new ApoliceDAO();
                apoliceDao.MudarParaModificado(apolice.Id);


                //Inserindo nova proposta do Endosso
                PropostaDAO propostaDao = new PropostaDAO();
                apolice.Proposta.FlagEndosso = true;
                apolice.Proposta.Id = propostaDao.InsertForEndosso(apolice.Proposta);

                //Criacao de endosso
                Endosso endosso = new Endosso();
                //salvando codigo antigo da apolice
                endosso.CodApoliceAntigo = apolice.Id;
                endosso.DataEndosso = DateTime.Now;
                
                //Mudança de Status da Apolice ao Criar um Endosso
                apolice.Status = Status.ENVIADO;

                //criando nova Apolice 
                apolice = db.Apolice.Add(apolice);

                //adicionando Id da apolice Nova
                endosso.CodApolice = apolice.Id;

                //Salvando Endosso e Apolice nova
                db.Endosso.Add(endosso);
                db.SaveChanges();


                //Enviando Email de endosso para o Cliente
                Usuario usuario = (Usuario)Session["UsuarioLogado"];
                //PREPARANDO EMAIL
                apolice.formularioApoliceHtml = apolice.formularioApoliceHtml.Replace("#valorContratoEmail", apolice.ValorContrato.ToString());
                apolice.formularioApoliceHtml = apolice.formularioApoliceHtml.Replace("#corretorEmail", "Seu Corretor - " + usuario.Nome);
                string url = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "");
                apolice.formularioApoliceHtml = apolice.formularioApoliceHtml.Replace("#EnderecoConfirmaEmail", url + "/Proposta/AceitarProposta?" +
                                                                                                                "email=" + apolice.Proposta.Segurado.Email +
                                                                                                                "&codigoProposta=" + apolice.CodigoProposta +
                                                                                                                "&codigoApolice=" + apolice.Id);
                UtilEmailMessage utilEmail = new UtilEmailMessage();
                utilEmail.EnviarEmail("[BUSCA SEGUROS] Endosso de Sua Proposta de Cotação de Seguro", apolice.Proposta.Segurado.Email, apolice.formularioApoliceHtml);



            return RedirectToAction("Index");
            //}
            //return View(apolice);
        }

        [HttpPost]
        public ActionResult Review(Apolice apolice)
        {
            apolice.Seguradoras = db.Seguradora.ToList();
            _apolice = apolice;
            return View(_apolice);
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