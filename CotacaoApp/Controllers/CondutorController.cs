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
    public class CondutorController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

        // GET: Condutor
        public ActionResult Index()
        {
            return View(db.Condutor.ToList());
        }

        // GET: Condutor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condutor condutor = db.Condutor.Find(id);
            if (condutor == null)
            {
                return HttpNotFound();
            }
            return View(condutor);
        }

        // GET: Cobertura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,codigoSegurado,CodigoCpf,Nome,DataNascimento,IESexo,IEEstadoCivil,NumeroCep,IEPossuiOutrosCarros,IEQuantidadeCarro,AnosDeCNH,IEProprietarioVeiculo,IERelacaoProprietario,IECondutorPrincipal,IETipoResidencia,Profissao,IERoubadoEm24Meses,IEAlgumCondutorEstuda,Email,IENoticiasEmail,IEItauPersonalite,IECartaoPortoSeguroVisa")] Condutor condutor)
        {
            if (ModelState.IsValid)
            {
                db.Condutor.Add(condutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(condutor);
        }

        // GET: Condutor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condutor condutor = db.Condutor.Find(id);
            if (condutor == null)
            {
                return HttpNotFound();
            }
            return View(condutor);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,codigoSegurado,CodigoCpf,Nome,DataNascimento,IESexo,IEEstadoCivil,NumeroCep,IEPossuiOutrosCarros,IEQuantidadeCarro,AnosDeCNH,IEProprietarioVeiculo,IERelacaoProprietario,IECondutorPrincipal,IETipoResidencia,Profissao,IERoubadoEm24Meses,IEAlgumCondutorEstuda,Email,IENoticiasEmail,IEItauPersonalite,IECartaoPortoSeguroVisa")] Condutor condutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(condutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(condutor);
        }

        // GET: Condutor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Condutor condutor = db.Condutor.Find(id);
            if (condutor == null)
            {
                return HttpNotFound();
            }
            return View(condutor);
        }

        // POST: Cobertura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Condutor condutor = db.Condutor.Find(id);
            db.Condutor.Remove(condutor);
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