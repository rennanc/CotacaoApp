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

            var conexao = new DBConnection();
            QuerySql query = conexao.CreateQuery("select * from Usuario where NM_EMAIL=@usuario and NM_SENHA=@senha");
            query.SetParameter("usuario", usuario);
            query.SetParameter("senha", senha);
            DbDataReader reader = query.ExecuteQuery();
            Usuario user = null;
            if (reader.Read())
            {
                user = new Usuario
                {
                    Email = reader.GetString(reader.GetOrdinal("NM_EMAIL")),
                    Senha = reader.GetString(reader.GetOrdinal("NM_SENHA"))
                };
            }
            return user;
        }
    }
}