using CotacaoApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
            foreach(Telefone telefone in proposta.Segurado.Telefones)
            {
                telefone.CodigoCondutor = proposta.Segurado.Id;
            }
            db.Telefone.AddRange(proposta.Segurado.Telefones);

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

            //Salvando PropostaCobertura
            PropostaCobertura propostaCobertura = new PropostaCobertura();
            if(proposta.CodigoCobertura == 0)
            {
                proposta.CodigoCobertura = 1;
            }
            //propostaCobertura.CodigoCobertura = proposta.CodigoCobertura;
            //propostaCobertura.CodigoProposta = proposta.Id;
            //db.PropostaCobertura.Add(propostaCobertura);
            db.SaveChanges();
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