using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CotacaoApp.Models
{
    public class Apolice
    {
        [Key]
        [Display(Name = "Apólice")]
        [Column("CD_APOLICE")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Proposta")]
        [Column("CD_PROPOSTA")]
        public int Proposta { get; set; }

        [Required]
        [Display(Name = "Comissão")]
        [Column("CD_COMISSAO")]
        public int Comissao { get; set; }

        [Required]
        [Display(Name = "Seguradora")]
        [Column("CD_SEGURADORA")]
        public int Segurdora { get; set; }

        [Required]
        [Display(Name = "Contrato")]
        [Column("VL_CONTRATO")]
        public string Contrato { get; set; }

        [Required]
        [Display(Name = "Status")]
        [Column("SG_STATUS")]
        public string Status { get; set; }

    }
}