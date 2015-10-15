using CotacaoApp.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CotacaoApp.Models
{
    [Serializable]
    [AutorizacaoFilter]
    public class Apolice
    {

        
        public Apolice()
        {
            CodigoComissao = 1;
        }
        [Key]
        [Display(Name = "Apólice")]
        [Column("CD_APOLICE")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Proposta")]
        [Column("CD_PROPOSTA")]
        public int CodigoProposta { get; set; }

        [NotMapped]
        public Proposta Proposta { get; set; }

        [NotMapped]
        public List<Proposta> Propostas { get; set; }

        [Required]
        [Display(Name = "Comissão")]
        [Column("CD_COMISSAO")]
        public int CodigoComissao { get; set; }

        public Comissao Comissao { get; set; }

        [Required]
        [Display(Name = "Seguradora")]
        [Column("CD_SEGURADORA")]
        public int Seguradora { get; set; }

        [NotMapped]
        public List<Seguradora> Seguradoras { get; set; }

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