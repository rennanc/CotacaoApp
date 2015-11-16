using CotacaoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoApp.DAO
{
    public class ValorPropostaDAO
    {
        private DefaultConnection db = new DefaultConnection();


        //public ValorProposta Listar()
        //{
        //    var conexao = new DBConnection();

        //    QuerySql query = conexao.CreateQuery("UPDATE apolice SET " +
        //                                         " SG_STATUS=@SG_STATUS " +
        //                                         " WHERE CD_APOLICE = @CD_APOLICE " +
        //                                         " AND CD_PROPOSTA = @CD_PROPOSTA");

        //    query.SetParameter("SG_STATUS", status);
        //    query.SetParameter("CD_APOLICE", codigoApolice);
        //    query.SetParameter("CD_PROPOSTA", codigoProposta);

        //    DbDataReader reader = query.ExecuteQuery();
        //    conexao.Close();
        //}
    }
}
