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

        public bool ValidarEmailProposta(string email, string codigoProposta, string codigoApolice)
        {
            var conexao = new DBConnection();

            QuerySql query = conexao.CreateQuery("SELECT COUNT(*) COUNT " +
                                                  " FROM condutor " +
                                                  " INNER JOIN proposta ON proposta.CD_CONDUTOR = condutor.CD_CONDUTOR " +
                                                  " INNER JOIN apolice ON apolice.CD_PROPOSTA = proposta.CD_PROPOSTA " +
                                                  " WHERE NM_EMAIL = @NM_EMAIL " +
                                                  " AND proposta.CD_PROPOSTA = @CD_PROPOSTA " +
                                                  " AND apolice.CD_APOLICE = @CD_APOLICE");

            query.SetParameter("NM_EMAIL", email);
            query.SetParameter("CD_APOLICE", codigoApolice);
            query.SetParameter("CD_PROPOSTA", codigoProposta);

            DbDataReader reader = query.ExecuteQuery();
            int result = 0;
            if (reader.Read())
            {
                result = reader.GetInt16(reader.GetOrdinal("COUNT"));
            }

            reader.Close();
            conexao.Close();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}