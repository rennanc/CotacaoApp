using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Common;
using CotacaoApp.Models;
using System.Web.UI.WebControls;
using CotacaoApp.Enumerations;
using System.Data.SqlClient;

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
            reader.Close();
            conexao.Close();
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

        public void Editar(Condutor condutor)
        {
            var conexao = new DBConnection();
            QuerySql query = conexao.CreateQuery("UPDATE condutor SET "+
                                                 "  CD_SEGURADO = @CD_SEGURADO," +
                                                 "  CD_CPF = @CD_CPF," +
                                                 "  NM_NOME = @NM_NOME," +
                                                 "  DT_NASCIMENTO = @DT_NASCIMENTO," +
                                                 "  IE_SEXO = @IE_SEXO," +
                                                 "  NM_ESTADOCIVIL = @NM_ESTADOCIVIL," +
                                                 "  NR_CEP = @NR_CEP," +
                                                 "  IE_POSSUIOUTROSCARROS = @IE_POSSUIOUTROSCARROS," +
                                                 "  IE_QTDCARROS = @IE_QTDCARROS," +
                                                 "  NR_ANOSCNH = @NR_ANOSCNH," +
                                                 "  NM_EMAIL = @NM_EMAIL," +
                                                 "  IE_PROPRIETARIOVEICULO = @IE_PROPRIETARIOVEICULO," +
                                                 "  IE_RELACAOPROPRIETARIO = @IE_RELACAOPROPRIETARIO," +
                                                 "  IE_CONDPRINCIPAL = @IE_CONDPRINCIPAL," +
                                                 "  IE_TIPORESIDENCIA = @IE_TIPORESIDENCIA," +
                                                 "  DS_PROFISSAO = @DS_PROFISSAO," +
                                                 "  IE_ROUBADOEM24MESES = @IE_ROUBADOEM24MESES," +
                                                 "  IE_ALGUMCONDUTORESTUDA = @IE_ALGUMCONDUTORESTUDA," +
                                                 "  IE_NOTICIASEMAIL = @IE_NOTICIASEMAIL," +
                                                 "  IE_ITAUPERSONALITE = @IE_ITAUPERSONALITE," +
                                                 "  IE_CARTAOPORTOSEGUROVISA = @IE_CARTAOPORTOSEGUROVISA" +
                                                 "  WHERE CD_CONDUTOR = @CD_CONDUTOR; ");


            query.SetParameter("CD_CONDUTOR", condutor.Id);
            query.SetParameter("CD_SEGURADO", condutor.codigoSegurado);
            query.SetParameter("CD_CPF", condutor.CodigoCpf);

            query.SetParameter("NM_NOME", condutor.Nome);
            query.SetParameter("DT_NASCIMENTO", condutor.DataNascimento);
            query.SetParameter("IE_SEXO", condutor.IESexo);
            query.SetParameter("NM_ESTADOCIVIL", condutor.IEEstadoCivil);
            query.SetParameter("NR_CEP", condutor.NumeroCep);
            query.SetParameter("IE_POSSUIOUTROSCARROS", condutor.IEPossuiOutrosCarros);
            query.SetParameter("IE_QTDCARROS", condutor.IEQuantidadeCarro);
            query.SetParameter("NR_ANOSCNH", condutor.AnosDeCNH);
            query.SetParameter("NM_EMAIL", condutor.Email);
            query.SetParameter("IE_PROPRIETARIOVEICULO", condutor.IEProprietarioVeiculo);
            query.SetParameter("IE_RELACAOPROPRIETARIO", condutor.IERelacaoProprietario);
            query.SetParameter("IE_CONDPRINCIPAL", condutor.IECondutorPrincipal);
            query.SetParameter("IE_TIPORESIDENCIA", condutor.IETipoResidencia);
            query.SetParameter("DS_PROFISSAO", condutor.Profissao);
            query.SetParameter("IE_ROUBADOEM24MESES", condutor.IERoubadoEm24Meses);
            query.SetParameter("IE_ALGUMCONDUTORESTUDA", condutor.IEAlgumCondutorEstuda);
            query.SetParameter("IE_NOTICIASEMAIL", condutor.IENoticiasEmail);
            query.SetParameter("IE_ITAUPERSONALITE", condutor.IEItauPersonalite);
            query.SetParameter("IE_CARTAOPORTOSEGUROVISA", condutor.IECartaoPortoSeguroVisa);


            DbDataReader reader = query.ExecuteQuery();
            conexao.Close();
        }

        public Condutor ObterPorIdSeguradoETipo(int id, int tipo)
        {
            var conexao = new DBConnection();

            string queryString = "SELECT * FROM condutor "+
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

            Condutor condutor = new Condutor();
            if (reader.Read())
            {

                condutor.Id = reader.GetInt16(reader.GetOrdinal("CD_CONDUTOR"));
                condutor.codigoSegurado = reader.GetInt16(reader.GetOrdinal("CD_SEGURADO"));
                condutor.CodigoCpf = reader.GetStringOrNull(reader.GetOrdinal("CD_CPF"));
                condutor.Nome = reader.GetStringOrNull(reader.GetOrdinal("NM_NOME"));
                condutor.DataNascimento = DateTime.Parse(reader.GetStringOrNull(reader.GetOrdinal("DT_NASCIMENTO")));
                condutor.IESexo = (IESexo)reader.GetInt16(reader.GetOrdinal("IE_SEXO"));
                condutor.IEEstadoCivil = (IEEstadoCivil)reader.GetInt16(reader.GetOrdinal("NM_ESTADOCIVIL"));
                condutor.NumeroCep = reader.GetStringOrNull(reader.GetOrdinal("NR_CEP"));
                condutor.IEPossuiOutrosCarros = (IEPossuiOutrosCarros)reader.GetInt16(reader.GetOrdinal("IE_POSSUIOUTROSCARROS"));
                condutor.IEQuantidadeCarro = (IEQuantidadeCarro)reader.GetInt16(reader.GetOrdinal("IE_QTDCARROS"));
                condutor.AnosDeCNH = reader.GetInt16(reader.GetOrdinal("NR_ANOSCNH"));
                condutor.IEProprietarioVeiculo = (IEProprietarioVeiculo)reader.GetInt16(reader.GetOrdinal("IE_PROPRIETARIOVEICULO"));
                condutor.IERelacaoProprietario = (IERelacaoProprietario)reader.GetInt16(reader.GetOrdinal("IE_RELACAOPROPRIETARIO"));
                condutor.IECondutorPrincipal = (IECondutorPrincipal)reader.GetInt16(reader.GetOrdinal("IE_CONDPRINCIPAL"));
                condutor.IETipoResidencia = (IETipoResidencia)reader.GetInt16(reader.GetOrdinal("IE_TIPORESIDENCIA"));
                condutor.Profissao = reader.GetStringOrNull(reader.GetOrdinal("DS_PROFISSAO"));
                condutor.IERoubadoEm24Meses = (IERoubadoEm24Meses)reader.GetInt16(reader.GetOrdinal("IE_ROUBADOEM24MESES"));
                condutor.IEAlgumCondutorEstuda = (IEAlgumCondutorEstuda)reader.GetInt16(reader.GetOrdinal("IE_ALGUMCONDUTORESTUDA"));
                condutor.Email = reader.GetStringOrNull(reader.GetOrdinal("NM_EMAIL"));
                condutor.IENoticiasEmail = reader.GetBoolean(reader.GetOrdinal("IE_NOTICIASEMAIL"));
                condutor.IECartaoPortoSeguroVisa = reader.GetBoolean(reader.GetOrdinal("IE_CARTAOPORTOSEGUROVISA"));
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