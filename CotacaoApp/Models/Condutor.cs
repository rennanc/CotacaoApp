using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    public class Condutor
    {

        [Key]
        [Display(Name = "Codigo")]
        [Column("CD_CONDUTOR")]
        public int Id { get; set; }

        [Display(Name = "Codigo Segurado")]
        [Column("CD_SEGURADO")]
        public int codigoSegurado { get; set; }

        [Display(Name = "O condutor é o segurado?")]
        [Column("IE_SEGURADO")]
        public int IsSegurado { get; set; }

        [Display(Name = "Tipo Pessoa")]
        public bool IETipo { get; set; }

        [Display(Name = "Pessoa Fisica")]
        public PessoaFisica PessoaFisica { get; set; }

        [Display(Name = "Pessoa Juridica")]
        public PessoaJuridica PessoaJuridica { get; set; }

    }
}