﻿using CotacaoApp.Models;
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

        public void Salvar(ValorProposta valorProposta)
        {
            var conexao = new DBConnection();

            QuerySql query = conexao.CreateQuery("UPDATE valorproposta " +
                                                  "  SET " +
                                                  "  DS_DESCRICAO = @DS_DESCRICAO, " +
                                                  "  DS_TIPO = @DS_TIPO, " +
                                                  "  DT_DATA_VENCIMENTO = @DT_DATA_VENCIMENTO, " +
                                                  "  VL_VALOR = @VL_VALOR " +
                                                  "  WHERE CD_VALORPROPOSTA = @CD_VALORPROPOSTA ");

            query.SetParameter("DS_DESCRICAO", valorProposta.Descricao);
            query.SetParameter("DS_TIPO", valorProposta.Tipo);
            query.SetParameter("DT_DATA_VENCIMENTO", valorProposta.DataVencimento);
            query.SetParameter("VL_VALOR", valorProposta.Valor);
            query.SetParameter("CD_VALORPROPOSTA", valorProposta.Id);

            DbDataReader reader = query.ExecuteQuery();
            reader.Close();
            conexao.Close();
        }
    }
}
