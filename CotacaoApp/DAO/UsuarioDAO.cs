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
            //string sSQL = "select * from Usuarios where NM_USUARIO="+ usuario + " and NM_SENHA=" + senha + " ";
            QuerySql query = conexao.CreateQuery("select * from Usuarios where NM_NOME=@usuario and NM_SENHA=@senha");
            query.SetParameter("usuario", usuario);
            query.SetParameter("senha", senha);
            DbDataReader reader = query.ExecuteQuery();
            Usuario user = null;
            if (reader.Read())
            {
                user = new Usuario
                {
                    Login = reader.GetString(reader.GetOrdinal("NM_NOME")),
                    Senha = reader.GetString(reader.GetOrdinal("NM_SENHA"))
                };
            }
            return user;
        }
    }
}