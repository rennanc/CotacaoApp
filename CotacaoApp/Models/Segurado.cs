using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    public class Segurado
    {

        [Key]
        [Display(Name = "Codigo")]
        [Column("CD_SEGURADO")]
        public int Id { get; set; }

        [Display(Name = "Pessoa")]
        public Pessoa Pessoa { get; set; }

    }
}