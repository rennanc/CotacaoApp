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
    public class ComissaoController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Comissao
        public ActionResult Index()
        {
            return View(db.Comissao.ToList());
        }

        // GET: ValorProposta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comissao comissao = db.Comissao.Find(id);
            if (comissao == null)
            {
                return HttpNotFound();
            }
            return View(comissao);
        }

        // GET: Comissao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CodigoUsuario,ValorPremioLiquido,ValorPercentualLiquido,ValorComissaoLiquida,ValorPercentualCiss,ValorPercentualCir")] Comissao comissao)
        {
            if (ModelState.IsValid)
            {
                db.Comissao.Add(comissao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comissao);
        }

        // GET: Comissao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comissao comissao = db.Comissao.Find(id);
            if (comissao == null)
            {
                return HttpNotFound();
            }
            return View(comissao);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CodigoUsuario,ValorPremioLiquido,ValorPercentualLiquido,ValorComissaoLiquida,ValorPercentualCiss,ValorPercentualCir")] Comissao comissao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comissao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comissao);
        }

        // GET: ValorProposta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comissao comissao = db.Comissao.Find(id);
            if (comissao == null)
            {
                return HttpNotFound();
            }
            return View(comissao);
        }

        // POST: Comissao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comissao comissao = db.Comissao.Find(id);
            db.Comissao.Remove(comissao);
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