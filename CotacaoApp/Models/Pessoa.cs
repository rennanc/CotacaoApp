using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    public class Pessoa
    {

        [Key]
        [Display(Name = "Codigo")]
        [Column("CD_PESSOA")]
        public int Id { get; set; }

        [Display(Name = "Segurado")]
        [Column("CD_SEGURADO")]
        public int codigoSegurado { get; set; }

        [Display(Name = "O proprietario é o segurado")]
        //[Column("IE_SEGURADO")]
        public bool IsSegurado { get; set; }

        [Display(Name = "Endereco")]
        public Endereco Endereco { get; set; }

        [Display(Name = "Pessoa Fisica")]
        public PessoaFisica PessoaFisica { get; set; }

        [Display(Name = "Pessoa Juridica")]
        public PessoaJuridica PessoaJuridica { get; set; }

    }
}