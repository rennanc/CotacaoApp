using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CotacaoApp.Models;
using CotacaoApp.DAO;
using CotacaoApp.Filters;

namespace CotacaoApp.Controllers
{
    [AutorizacaoFilter]
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
            ValorProposta valorProposta = db.ValorProposta.Find(id);
            if (valorProposta == null)
            {
                return HttpNotFound();
            }
            return View(valorProposta);
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
        public ActionResult Create([Bind(Include = "Id,CodigoCondutor,CodigoApolice,Descricao,Tipo,DataVencimento,Valor")] ValorProposta valorProposta)
        {
            if (ModelState.IsValid)
            {
                db.ValorProposta.Add(valorProposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valorProposta);
        }

        // GET: ValorProposta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorProposta valorProposta = db.ValorProposta.Find(id);
            if (valorProposta == null)
            {
                return HttpNotFound();
            }
            return View(valorProposta);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoCondutor,CodigoApolice,Descricao,Tipo,DataVencimento,Valor")] ValorProposta valorProposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valorProposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valorProposta);
        }

        // GET: ValorProposta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorProposta valorProposta = db.ValorProposta.Find(id);
            if (valorProposta == null)
            {
                return HttpNotFound();
            }
            return View(valorProposta);
        }

        // POST: ValorProposta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValorProposta valorProposta = db.ValorProposta.Find(id);
            db.ValorProposta.Remove(valorProposta);
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