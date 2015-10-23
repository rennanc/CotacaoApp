using CotacaoApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CotacaoApp.Controllers
{
    [AutorizacaoFilter]
    public class AdministracaoController : Controller
    {
        // GET: Administracao
        public ActionResult Index()
        {
            return View();
        }
    }
}