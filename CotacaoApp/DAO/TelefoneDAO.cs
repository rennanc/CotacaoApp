using CotacaoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace CotacaoApp.DAO
{
    public class TelefoneDAO
    {

        private DefaultConnection db = new DefaultConnection();

        public List<Telefone> ObterTodosPorIdCondutor(int IdCondutor)
        {
            var conexao = new DBConnection();

            QuerySql query = conexao.CreateQuery("SELECT * FROM telefone WHERE CD_CONDUTOR=@idCondutor");

            query.SetParameter("idCondutor", IdCondutor);
            DbDataReader reader = query.ExecuteQuery();
            List<Telefone> telefones = new List<Telefone>();
            Telefone telefone = null;
            if (reader.Read())
            {
                telefone = new Telefone
                {
                    Id = reader.GetInt16(reader.GetOrdinal("CD_TELEFONE")),
                    CodigoCondutor = reader.GetInt16(reader.GetOrdinal("CD_CONDUTOR")),
                    NumeroTelefone = reader.GetString(reader.GetOrdinal("NR_TELEFONE"))
                };
                telefones.Add(telefone);
            }
            return telefones;
        }
    }
}