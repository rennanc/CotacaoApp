using CotacaoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CotacaoApp.DAO
{
    public class PropostaDAO
    {
        private DefaultConnection db = new DefaultConnection();

        public void Insert(Proposta proposta)
        {
 
            //Adicionando Segurado
            db.Condutor.Add(proposta.Segurado);
            db.SaveChanges();

            //Adicionando telefones do segurado
            List<Telefone> telefonesCorretos = new List<Telefone>();
            foreach(Telefone telefone in proposta.Segurado.Telefones)
            {
                if(telefone.NumeroTelefone != null)
                {
                    telefone.CodigoCondutor = proposta.Segurado.Id;
                    telefonesCorretos.Add(telefone);
                }
                
            }
            db.Telefone.AddRange(telefonesCorretos);

            //Adicionando Proprietario
            if (proposta.Proprietario.CodigoCpf != null)
            {
                proposta.Proprietario.codigoSegurado = proposta.Segurado.Id;
                db.Condutor.Add(proposta.Proprietario);
            }

            //Adicionando Outro Condutor
            if (proposta.OutroCondutor.CodigoCpf != null)
            {
                proposta.OutroCondutor.codigoSegurado = proposta.Segurado.Id;
                db.Condutor.Add(proposta.OutroCondutor);
            }

            //Adicionando Proposta
            proposta.codigoSegurado = proposta.Segurado.Id;
            db.Proposta.Add(proposta);

            db.SaveChanges();

            //correção provisoria
            if(proposta.CodigoCobertura == 0)
            {
                proposta.CodigoCobertura = 1;
            }
            db.SaveChanges();
            db.Dispose();
        }


        public void Save(Proposta proposta)
        {


            //SALVANDO Segurado
            CondutorDAO condutorDao = new CondutorDAO();
            condutorDao.Editar(proposta.Segurado);

            //SALVANDO telefones do segurado
            List<Telefone> telefonesCorretos = new List<Telefone>();
            TelefoneDAO telefoneDao = new TelefoneDAO();
            if (proposta.Segurado.Telefones != null)
            {
                foreach (Telefone telefone in proposta.Segurado.Telefones)
                {
                    if (telefone.NumeroTelefone != null)
                    {
                        telefone.CodigoCondutor = proposta.Segurado.Id;
                        telefonesCorretos.Add(telefone);
                        telefoneDao.Editar(telefone);
                    }

                }
            }

            //SALVANDO Proprietario
            if (proposta.Proprietario.CodigoCpf != null)
            {
                proposta.Proprietario.codigoSegurado = proposta.Segurado.Id;
                condutorDao.Editar(proposta.Proprietario);
            }

            //SALVANDO Outro Condutor
            if (proposta.OutroCondutor.CodigoCpf != null)
            {
                proposta.OutroCondutor.codigoSegurado = proposta.Segurado.Id;
                condutorDao.Editar(proposta.OutroCondutor);
            }


            db.SaveChanges();
            proposta.codigoSegurado = proposta.Segurado.Id;
            Editar(proposta);
            //Insert(proposta);
            //Delete(proposta);



        }

        public void Editar(Proposta proposta)
        {
            var conexao = new DBConnection();
            QuerySql query = conexao.CreateQuery("UPDATE proposta  " +
                                                  "SET" +
                                                  " CD_CONDUTOR = @CD_CONDUTOR," +
                                                  " CD_COBERTURA = @CD_COBERTURA," +
                                                  " NM_MARCAVEICULO = @NM_MARCAVEICULO," +
                                                  "  NR_ANOFABVEICULO = @NR_ANOFABVEICULO," +
                                                  "  NR_ANOMODELOVEICULO = @NR_ANOMODELOVEICULO," +
                                                  "  IE_ZEROKM = @IE_ZEROKM," +
                                                  "  NM_VEICULO = @NM_VEICULO," +
                                                  "  IE_FINANCIADOVEICULO = @IE_FINANCIADOVEICULO," +
                                                  "  IE_TIPOVEICULO_TAXI = @IE_TIPOVEICULO_TAXI," +
                                                  "  IE_TIPOVEICULO_DEFICIENTE = @IE_TIPOVEICULO_DEFICIENTE," +
                                                  "  IE_TIPOVEICULO_KITGAS = @IE_TIPOVEICULO_KITGAS," +
                                                  "  IE_TIPOVEICULO_BLINDADO = @IE_TIPOVEICULO_BLINDADO," +
                                                  "  IE_TIPOVEICULO_PESSOAJURIDICA = @IE_TIPOVEICULO_PESSOAJURIDICA," +
                                                  "  IE_ALARMEVEICULO = @IE_ALARMEVEICULO," +
                                                  "  IE_TIPOESTACION = @IE_TIPOESTACION," +
                                                  "  IE_TIPOPORTAO = @IE_TIPOPORTAO," +
                                                  "  NR_CEPESTACION = @NR_CEPESTACION," +
                                                  "  NR_CEPDESLOC = @NR_CEPDESLOC," +
                                                  "  IE_UTILIZACAOVEICULO_LAZER = @IE_UTILIZACAOVEICULO_LAZER," +
                                                  "  IE_UTILIZACAOVEICULO_TRABALHO = @IE_UTILIZACAOVEICULO_TRABALHO," +
                                                  "  IE_UTILIZACAOVEICULO_ESTUDO = @IE_UTILIZACAOVEICULO_ESTUDO," +
                                                  "  IE_UTILIZACAOVEICULO_INSTRUMENTO = @IE_UTILIZACAOVEICULO_INSTRUMENTO," +
                                                  "  IE_TIPOGARAGEMTRABALHO = @IE_TIPOGARAGEMTRABALHO," +
                                                  "  IE_DISTANCIATRABVEICULO = @IE_DISTANCIATRABVEICULO," +
                                                  "  IE_TIPOGARAGEMESTUDO = @IE_TIPOGARAGEMESTUDO," +
                                                  "  IE_UTILIZACAOVEICULO_INSTRUMENTOFORMA = @IE_UTILIZACAOVEICULO_INSTRUMENTOFORMA," +
                                                  "  IE_MEDIAKMVEICULO = @IE_MEDIAKMVEICULO," +
                                                  "  IE_MOTIVO_COTACAO = @IE_MOTIVO_COTACAO," +
                                                  "  IE_PRIMEIROSEGURO = @IE_PRIMEIROSEGURO," +
                                                  "  IE_SEGUROATUAL_QUERMAISOPCOES = @IE_SEGUROATUAL_QUERMAISOPCOES," +
                                                  "  IE_SEGUROATUAL_MELHORATENDIMENTO = @IE_SEGUROATUAL_MELHORATENDIMENTO," +
                                                  "  IE_SEGUROATUAL_NAOSATISFEITO = @IE_SEGUROATUAL_NAOSATISFEITO," +
                                                  "  NM_SEGURADORAATUAL = @NM_SEGURADORAATUAL," +
                                                  "  DT_VENC_SEGUROATUAL = @DT_VENC_SEGUROATUAL," +
                                                  "  IE_BONUSAPOLICEATUAL_SEMSINISTRO = @IE_BONUSAPOLICEATUAL_SEMSINISTRO," +
                                                  "  IE_BONUSAPOLICEATUAL_COMSINISTRO = @IE_BONUSAPOLICEATUAL_COMSINISTRO," +
                                                  "  NR_APOLICE = @NR_APOLICE," +
                                                  "  NR_CI = @NR_CI," +
                                                  "  NR_PLACAVEICULO = @NR_PLACAVEICULO," +
                                                  "  NR_CHASSIVEICULO = @NR_CHASSIVEICULO" +
                                                  "  WHERE CD_PROPOSTA = @CD_PROPOSTA");


            query.SetParameter("CD_PROPOSTA", proposta.Id);
            query.SetParameter("CD_CONDUTOR", proposta.codigoSegurado);
            query.SetParameter("CD_COBERTURA", proposta.CodigoCobertura);

            query.SetParameter("NM_MARCAVEICULO", proposta.NomeMarcaVeiculo);
            query.SetParameter("NR_ANOFABVEICULO", proposta.AnoFabricacaoVeiculo);
            query.SetParameter("NR_ANOMODELOVEICULO", proposta.AnoModeloVeiculo);
            query.SetParameter("IE_ZEROKM", proposta.IEZeroKM);
            query.SetParameter("NM_VEICULO", proposta.NomeVeiculo);
            query.SetParameter("IE_FINANCIADOVEICULO", proposta.IEFinanciadoVeiculo);
            query.SetParameter("IE_TIPOVEICULO_TAXI", proposta.IETipoVeiculoTaxi);
            query.SetParameter("IE_TIPOVEICULO_DEFICIENTE", proposta.IETipoVeiculoDeficiente);
            query.SetParameter("IE_TIPOVEICULO_KITGAS", proposta.IETipoVeiculoKitGas);
            query.SetParameter("IE_TIPOVEICULO_BLINDADO", proposta.IETipoVeiculoBlindado);
            query.SetParameter("IE_TIPOVEICULO_PESSOAJURIDICA", proposta.IETipoVeiculoPessoaJuridica);
            query.SetParameter("IE_ALARMEVEICULO", proposta.IEAlarmeVeiculo);
            query.SetParameter("IE_TIPOESTACION", proposta.IETipoEstacionamento);
            query.SetParameter("IE_TIPOPORTAO", proposta.IETipoPortao);
            query.SetParameter("NR_CEPESTACION", proposta.CepEstacionamento);
            query.SetParameter("NR_CEPDESLOC", proposta.CepDeslocamento);
            query.SetParameter("IE_UTILIZACAOVEICULO_LAZER", proposta.IEUtilizacaoVeiculoLazer);
            query.SetParameter("IE_UTILIZACAOVEICULO_TRABALHO", proposta.IEUtilizacaoVeiculoTrabalho);
            query.SetParameter("IE_UTILIZACAOVEICULO_ESTUDO", proposta.IEUtilizacaoVeiculoEstudo);
            query.SetParameter("IE_UTILIZACAOVEICULO_INSTRUMENTO", proposta.IEUtilizacaoVeiculoInstrumento);
            query.SetParameter("IE_TIPOGARAGEMTRABALHO", proposta.IELocalGaragemTrabalho);
            query.SetParameter("IE_DISTANCIATRABVEICULO", proposta.IEDistanciaParaTrabalhoVeiculo);
            query.SetParameter("IE_TIPOGARAGEMESTUDO", proposta.IELocalGaragemEstudo);
            query.SetParameter("IE_UTILIZACAOVEICULO_INSTRUMENTOFORMA", proposta.IEUtilizacaoVeiculoInstrumentoForma);
            query.SetParameter("IE_MEDIAKMVEICULO", proposta.IEKmEmMedia);
            query.SetParameter("IE_MOTIVO_COTACAO", proposta.IEMotivoCotacao);
            query.SetParameter("IE_PRIMEIROSEGURO", proposta.IEPrimeiroSeguro);
            query.SetParameter("IE_SEGUROATUAL_QUERMAISOPCOES", proposta.IESeguroAtualQuerMaisOpcoes);
            query.SetParameter("IE_SEGUROATUAL_MELHORATENDIMENTO", proposta.IESeguroAtualMelhorAtendimento);
            query.SetParameter("IE_SEGUROATUAL_NAOSATISFEITO", proposta.IESeguroAtualNaoSatisfeito);
            query.SetParameter("NM_SEGURADORAATUAL", proposta.NomeSeguradoraAtual);
            query.SetParameter("DT_VENC_SEGUROATUAL", proposta.DataApoliceAtualVencimento);
            query.SetParameter("IE_BONUSAPOLICEATUAL_SEMSINISTRO", proposta.IEBonusSeguroAtualSemSinistro);
            query.SetParameter("IE_BONUSAPOLICEATUAL_COMSINISTRO", proposta.IEBonusSeguroAtualComSinistro);
            query.SetParameter("NR_APOLICE", proposta.NumeroApoliceAntiga);
            query.SetParameter("NR_CI", proposta.NumeroCIAntiga);
            query.SetParameter("NR_PLACAVEICULO", proposta.NumeroPlaca);
            query.SetParameter("NR_CHASSIVEICULO", proposta.NumeroChassi);


            DbDataReader reader = query.ExecuteQuery();
            reader.Close();
            conexao.Close();
            db.Dispose();
        }

        public void Delete(Proposta proposta)
        {
            GetProposta(proposta.Id);

        }

        public Proposta GetProposta(int? id)
        {
            Proposta proposta = db.Proposta.Find(id);
            proposta.Cobertura = db.Cobertura.Find(proposta.CodigoCobertura);
            proposta.Segurado = db.Condutor.Find(proposta.codigoSegurado);

            //obtendo telefone
            TelefoneDAO telefoneDao = new TelefoneDAO();
            proposta.Segurado.Telefones = telefoneDao.ObterTodosPorIdCondutor(proposta.Segurado.Id);

            CondutorDAO condutorDao = new CondutorDAO();
            if (proposta.Segurado.IEProprietarioVeiculo == 0)
            {
                proposta.Proprietario = condutorDao.ObterPorIdSeguradoETipo(proposta.Segurado.Id, 1);
            }
            if (proposta.Segurado.IECondutorPrincipal == 0)
            {
                proposta.OutroCondutor = condutorDao.ObterPorIdSeguradoETipo(proposta.Segurado.Id, 2);
            }

            return proposta;
        }

    }
}