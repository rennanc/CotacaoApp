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
    public class CondutorDAO
    {
        private DefaultConnection db = new DefaultConnection();

        public void InsertAndGetId(Condutor condutor)
        {
            var conexao = new DBConnection();

            QuerySql query = conexao.CreateQuery("SELECT * FROM usuario WHERE NM_LOGIN=@usuario AND NM_SENHA=@senha");

            query.SetParameter("CD_CPF", condutor.CodigoCpf);
            query.SetParameter("IE_SEGURADO", condutor.IsSegurado);
            query.SetParameter("NM_NOME", condutor.Nome);
            query.SetParameter("DT_NASCIMENTO", condutor.Nome);
            DbDataReader reader = query.ExecuteQuery();
            //Condutor condutor = null;
            //if (reader.Read())
            //{
            //    condutor = new Condutor
            //    {
            //        I = reader.GetInt16(reader.GetOrdinal("IE_SEGURADO")),
            //        Senha = reader.GetString(reader.GetOrdinal("NM_SENHA")),
            //        Permissao = 0
            //    };
            //}
            //return condutor;
        }
    }
}