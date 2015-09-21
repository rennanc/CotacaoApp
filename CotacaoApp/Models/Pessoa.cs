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

        [Display(Name = "Segurado")]
        public Endereco Endereco { get; set; }

    }
}