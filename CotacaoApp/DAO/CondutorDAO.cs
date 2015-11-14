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
    public class CondutorDAO
    {
        private DefaultConnection db = new DefaultConnection();

        public void InsertAndGetId(Condutor condutor)
        {
            var conexao = new DBConnection();

            QuerySql query = conexao.CreateQuery("SELECT * FROM usuario WHERE NM_LOGIN=@usuario AND NM_SENHA=@senha");

            query.SetParameter("CD_CPF", condutor.CodigoCpf);
            //query.SetParameter("IE_SEGURADO", condutor.IsSegurado);
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

        public Condutor ObterPorIdSeguradoETipo(int id, int tipo)
        {
            var conexao = new DBConnection();

            string queryString = "SELECT * FROM condutor "+
                                                "INNER JOIN telefone ON "+
                                                "condutor.CD_CONDUTOR = telefone.CD_CONDUTOR "+
                                                "WHERE CD_SEGURADO=@seguradoId ";


            //IE_PROPRIETARIOVEICULO
            if (tipo == 1)
            {
                queryString = queryString + "AND IE_PROPRIETARIOVEICULO=1";
            }
            else if(tipo == 2)
            {
                queryString = queryString + "AND IE_CONDPRINCIPAL=1";
            }


            QuerySql query = conexao.CreateQuery(queryString);
            query.SetParameter("seguradoId", id);

            DbDataReader reader = query.ExecuteQuery();

            Condutor condutor = null;
            if (reader.Read())
            {
                condutor = new Condutor
                {
                    Id = reader.GetInt16(reader.GetOrdinal("CD_CONDUTOR")),
                    codigoSegurado = reader.GetInt16(reader.GetOrdinal("CD_SEGURADO")),
                    CodigoCpf = reader.GetString(reader.GetOrdinal("CD_CPF")),
                    Nome = reader.GetString(reader.GetOrdinal("NM_NOME")),
                    DataNascimento = DateTime.Parse(reader.GetString(reader.GetOrdinal("DT_NASCIMENTO"))),
                    IESexo = (IESexo)reader.GetInt16(reader.GetOrdinal("IE_SEXO")),
                    IEEstadoCivil = (IEEstadoCivil)reader.GetInt16(reader.GetOrdinal("NM_ESTADOCIVIL")),
                    NumeroCep = reader.GetString(reader.GetOrdinal("NR_CEP")),
                    IEPossuiOutrosCarros = (IEPossuiOutrosCarros)reader.GetInt16(reader.GetOrdinal("IE_POSSUIOUTROSCARROS")),
                    IEQuantidadeCarro = (IEQuantidadeCarro)reader.GetInt16(reader.GetOrdinal("IE_QTDCARROS")),
                    AnosDeCNH = reader.GetInt16(reader.GetOrdinal("NR_ANOSCNH")),
                    IEProprietarioVeiculo = (IEProprietarioVeiculo)reader.GetInt16(reader.GetOrdinal("IE_PROPRIETARIOVEICULO")),
                    IERelacaoProprietario = (IERelacaoProprietario)reader.GetInt16(reader.GetOrdinal("IE_RELACAOPROPRIETARIO")),
                    IECondutorPrincipal = (IECondutorPrincipal)reader.GetInt16(reader.GetOrdinal("IE_CONDPRINCIPAL")),
                    IETipoResidencia = (IETipoResidencia)reader.GetInt16(reader.GetOrdinal("IE_TIPORESIDENCIA")),
                    Profissao = reader.GetString(reader.GetOrdinal("DS_PROFISSAO")),
                    IERoubadoEm24Meses = (IERoubadoEm24Meses)reader.GetInt16(reader.GetOrdinal("IE_ROUBADOEM24MESES")),
                    IEAlgumCondutorEstuda = (IEAlgumCondutorEstuda)reader.GetInt16(reader.GetOrdinal("IE_ALGUMCONDUTORESTUDA")),
                    Email = reader.GetString(reader.GetOrdinal("NM_EMAIL")),
                    IENoticiasEmail = reader.GetBoolean(reader.GetOrdinal("IE_NOTICIASEMAIL")),
                    IECartaoPortoSeguroVisa = reader.GetBoolean(reader.GetOrdinal("IE_CARTAOPORTOSEGUROVISA")),
                };
            }

            if(condutor != null)
            {
                TelefoneDAO telefoneDao = new TelefoneDAO();
                condutor.Telefones = telefoneDao.ObterTodosPorIdCondutor(condutor.Id);
            }
            
            return condutor;
        }
    }
}