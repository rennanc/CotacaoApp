using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using CotacaoApp.Models;
using System.Web.UI.WebControls;
using CotacaoApp.Enumerations;

namespace CotacaoApp.DAO
{
    public class UsuarioDAO
    {

        public void getById(int id)
        {

        }

        public Usuario getByLogin(String login, String senha)
        {

            var conexao = new DBConnection();
            QuerySql query = conexao.CreateQuery("SELECT * FROM usuario WHERE NM_USUARIO=@usuario AND NM_SENHA=@senha");
            query.SetParameter("usuario", login);
            query.SetParameter("senha", senha);
            DbDataReader reader = query.ExecuteQuery();
            Usuario user = null;
            if (reader.Read())
            {
                user = new Usuario
                {
                    Id = reader.GetInt16(reader.GetOrdinal("CD_USUARIO")),
                    Login = reader.GetString(reader.GetOrdinal("NM_USUARIO")),
                    Nome = reader.GetString(reader.GetOrdinal("NM_NOME")),
                    Permissao = (Permissao)reader.GetInt16(reader.GetOrdinal("FL_PERMISSAO"))
                };
            }
            conexao.Close();
            return user;
        }

        internal Usuario ObterSenhaPorLogin(string login)
        {
            var conexao = new DBConnection();
            QuerySql query = conexao.CreateQuery("SELECT NM_USUARIO,NM_SENHA FROM usuario WHERE NM_USUARIO=@usuario");
            query.SetParameter("usuario", login);
            DbDataReader reader = query.ExecuteQuery();
            Usuario user = null;
            if (reader.Read())
            {
                user = new Usuario
                {
                    Login = reader.GetString(reader.GetOrdinal("NM_USUARIO")),
                    Senha = reader.GetString(reader.GetOrdinal("NM_SENHA"))
                };
            }
            conexao.Close();
            return user;
        }
    }
}