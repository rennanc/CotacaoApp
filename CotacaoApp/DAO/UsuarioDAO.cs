using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using CotacaoApp.Models;
using System.Web.UI.WebControls;

namespace CotacaoApp.DAO
{
    public class UsuarioDAO
    {

        public void getById(int id)
        {

        }

        public Usuario getByLogin(String usuario, String senha)
        {

            var session = new DBSession();
            Query query = session.CreateQuery("select * from usuarios where username=@usuario and senha=@senha");
            query.SetParameter("usuario", usuario);
            query.SetParameter("senha", senha);
            DbDataReader reader = query.ExecuteQuery();
            Usuario user = null;
            if (reader.Read())
            {
                user = new Usuario
                {
                    Login = reader.GetString(reader.GetOrdinal("username")),
                    Senha = reader.GetString(reader.GetOrdinal("senha"))
                };
            }
            return user;
        }
    }
}