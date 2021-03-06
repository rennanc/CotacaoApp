﻿using CotacaoApp.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    [Serializable]
    public class ValorProposta
    {

        [Key]
        [Display(Name = "Valor Proposta")]
        [Column("CD_VALORPROPOSTA")]
        public int Id { get; set; }

        [Display(Name = "Condutor")]
        [Column("CD_CONDUTOR")]
        public int CodigoCondutor { get; set; }

        [Display(Name = "Apólice")]
        [Column("CD_APOLICE")]
        public int CodigoApolice { get; set; }

        [Display(Name = "Descrição")]
        [Column("DS_DESCRICAO")]
        public string Descricao { get; set; }

        [Display(Name = "Situação")]
        [Column("DS_TIPO")]
        public StatusPagamento Tipo { get; set; }

        [Display(Name = "Data Vencimento")]
        [Column("DT_DATA_VENCIMENTO")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "Valor*")]
        [Column("VL_VALOR")]
        public decimal Valor { get; set; }

        [NotMapped]
        public Condutor Condutor { get; set; }
    }
}