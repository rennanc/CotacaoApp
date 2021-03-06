﻿using CotacaoApp.DAO;
using CotacaoApp.Models;
using CotacaoApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CotacaoApp.Controllers
{
    public class LoginController : Controller
    {
        private DefaultConnection db = new DefaultConnection();

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
                //ModelState.AddModelError("", "Invalid login attempt.");
                ViewBag.Error = "Usuário ou Senha Inválido";
                return View("Index");

            }
        }


        public ActionResult Logout()
        {
            Session.Remove("UsuarioLogado");
            return RedirectToAction("Index", "Login");
        }

        public ActionResult RecuperaSenha()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmailRecuperacao(Usuario usuario)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            usuario = usuarioDao.ObterSenhaPorLogin(usuario.Login);
            UtilEmailMessage utilEmail = new UtilEmailMessage();
            utilEmail.EnviarEmail("[Busca Seguros] Recuperação de Senha",usuario.Login,"Sua Senha de Acesso ao Busca Seguros é: " + usuario.Senha);
            return View();
        }
    }
}