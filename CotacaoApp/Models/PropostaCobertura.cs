using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CotacaoApp.Models
{
    [Serializable]
    [Table("proposta_cobertura")]
    public class PropostaCobertura
    {

        [Key, Column(Order = 0)]
        [Display(Name = "Codigo Proposta")]
        //[Column("CD_PROPOSTA")]
        public int CodigoProposta { get; set; }

        [Key, Column(Order = 1)]
        [Display(Name = "Codigo Cobertura")]
        //[Column("CD_COBERTURA")]
        public int CodigoCobertura { get; set; }
    }
}