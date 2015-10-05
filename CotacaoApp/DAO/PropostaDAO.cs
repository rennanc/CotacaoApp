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
            

            
            Condutor segurado = new Condutor();
            Condutor proprietario = new Condutor();
            Condutor outroCondutor = new Condutor();

            //Adicionando Segurado
            db.Condutor.Add(proposta.Segurado);
            db.SaveChanges();

            //Adicionando telefones do segurado
            foreach(Telefone telefone in proposta.Segurado.Telefones)
            {
                telefone.Id = proposta.Segurado.Id;
            }
            db.Telefone.AddRange(proposta.Segurado.Telefones);

            //Adicionando Proprietario
            if (proposta.Proprietario != null)
            {
                proposta.Proprietario.codigoSegurado = proposta.Segurado.Id;
                db.Condutor.Add(proposta.Proprietario);
            }

            //Adicionando Outro Condutor
            if (proposta.OutroCondutor != null)
            {
                proposta.OutroCondutor.codigoSegurado = proposta.Segurado.Id;
                db.Condutor.Add(proposta.OutroCondutor);
            }

            //Adicionando Proposta
            proposta.codigoSegurado = proposta.Segurado.Id;
            db.Proposta.Add(proposta);

            db.SaveChanges();
        }

    }
}