using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace CotacaoApp.DAO
{
    public class ApoliceDAO
    {
        private DefaultConnection db = new DefaultConnection();


        public void MudarStatus(int status, string email, string codigoProposta, string codigoApolice)
        {
            var conexao = new DBConnection();
            QuerySql query = conexao.CreateQuery("UPDATE apolice SET " +
                                                 " SG_STATUS=@SG_STATUS " +
                                                 " WHERE CD_APOLICE = @CD_APOLICE " +
                                                 " AND CD_PROPOSTA = @CD_PROPOSTA");

            query.SetParameter("SG_STATUS", status);
            query.SetParameter("CD_APOLICE", codigoApolice);
            query.SetParameter("CD_PROPOSTA", codigoProposta);
            
            DbDataReader reader = query.ExecuteQuery();
            reader.Close();
            conexao.Close();
        }

        public string ObterEmailDoCorretorEValidarEmail(string email, string codigoProposta, string codigoApolice)
        {
            var conexao = new DBConnection();

            QuerySql query = conexao.CreateQuery("SELECT usuario.NM_USUARIO NM_USUARIO " +
                                                  " FROM condutor " +
                                                  " INNER JOIN proposta ON proposta.CD_CONDUTOR = condutor.CD_CONDUTOR " +
                                                  " INNER JOIN apolice ON apolice.CD_PROPOSTA = proposta.CD_PROPOSTA " +
                                                  " INNER JOIN usuario ON apolice.CD_USUARIO = CD_USUARIO " +
                                                  " WHERE NM_EMAIL = @NM_EMAIL " +
                                                  " AND proposta.CD_PROPOSTA = @CD_PROPOSTA " +
                                                  " AND apolice.CD_APOLICE = @CD_APOLICE");

            query.SetParameter("NM_EMAIL", email);
            query.SetParameter("CD_APOLICE", codigoApolice);
            query.SetParameter("CD_PROPOSTA", codigoProposta);

            DbDataReader reader = query.ExecuteQuery();
            string emailCondutor = null;
            if (reader.Read())
            {
                emailCondutor = reader.GetString(reader.GetOrdinal("NM_USUARIO"));
            }

            reader.Close();
            conexao.Close();
            return emailCondutor;

        }

        public void ExcluirApolicesRejeitadas(string codigoProposta, string codigoApoliceExcesao)
        {
            var conexao = new DBConnection();

            QuerySql query = conexao.CreateQuery("DELETE " +
                                                 " FROM apolice " +
                                                 " WHERE CD_APOLICE != @CD_APOLICE " +
                                                 " AND CD_PROPOSTA = @CD_PROPOSTA ");

            query.SetParameter("CD_APOLICE", codigoApoliceExcesao);
            query.SetParameter("CD_PROPOSTA", codigoProposta);

            DbDataReader reader = query.ExecuteQuery();

            reader.Close();
            conexao.Close();
        }

        public void MudarParaModificado(int codigoApolice)
        {
            var conexao = new DBConnection();
            QuerySql query = conexao.CreateQuery("UPDATE apolice SET " +
                                            " FL_MODIFICADA=1 " +
                                            " WHERE CD_APOLICE = @CD_APOLICE ");

            query.SetParameter("CD_APOLICE", codigoApolice);

            DbDataReader reader = query.ExecuteQuery();
            reader.Close();
            conexao.Close();
        }
    }
}