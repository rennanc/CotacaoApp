using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    [Serializable]
    public class Cobertura
    {
        [Key]
        [Display(Name = "Sinistro")]
        [Column("CD_COBERTURA")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome da Cobertura")]
        [Column("NM_COBERTURA")]
        public string NomeCobertura { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        [Column("SG_TIPO")]
        public string Tipo { get; set; }

        [Required]
        [Display(Name = "Descrição Cobertura")]
        [Column("DS_COBERTURA")]
        public string DescricaoCobertura { get; set; }
        
        
    }
}