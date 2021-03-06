﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CotacaoApp.Models
{
    [Serializable]
    public class Comissao
    {
        [Key]
        [Display(Name = "Codigo Comissao")]
        [Column("CD_COMISSAO")]
        public int Id { get; set; }


        [Display(Name = "Codigo Usuario")]
        [Column("CD_USUARIO")]
        public int CodigoUsuario { get; set; }


        [Display(Name = "Valor Premio Liquido:*")]
        [Column("VR_PREMIO_LIQUIDO")]
        public decimal ValorPremioLiquido { get; set; }

        [Display(Name = "Valor Comissao :*")]
        [Column("VR_COMISSAO_LIQUIDO")]
        public decimal ValorComissaoLiquida { get; set; }

        [Display(Name = "Valor Percentual Comissão:*")]
        [Column("VR_PERC_COMISSAO")]
        public decimal ValorPercentualComissao { get; set; }

        [Display(Name = "Valor Percentual Liquido:*")]
        [Column("VR_PERC_COMISSAO_LIQUIDO")]
        public decimal ValorPercentualComissaoLiquido { get; set; }

        [Display(Name = "Valor Percentual do Imposto Sobre a Renda:*")]
        [Column("VR_PERCIR")]
        public decimal ValorPercentualImpostoSobreRenda { get; set; }
    }
}