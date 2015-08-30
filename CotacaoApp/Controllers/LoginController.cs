using CotacaoApp.DAO;
using CotacaoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CotacaoApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autenticar(string login, string senha)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            Usuario usuario = usuarioDao.getByLogin(login, senha);
            
            if( usuario != null)
            {
                Session["UsuarioLogado"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public ActionResult Logout()
        {
            Session.Remove("UsuarioLogado");
            return RedirectToAction("Index", "Login");
        }
    }
}