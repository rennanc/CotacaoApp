﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    public class Cobertura
    {
        [Key]
        [Display(Name = "Sinistro")]
        [Column("CD_COBERTURA")]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Tipo")]
        [Column("SG_TIPO")]
        public string Tipo { get; set; }


        [Required]
        [Display(Name = "Data Hora Sinistro")]
        [Column("DT_DATAHORA_SINISTRO")]
        [DataType(DataType.Date)]
        public string DataSinistro  { get; set; }

        [Required]
        [Display(Name = "Local Sinistro")]
        [Column("DS_LOCAL_SINISTRO")]
        public string LocalSinistro { get; set; }

        [Required]
        [Display(Name = "Descrição Sinistro")]
        [Column("DS_SINISTRO")]
        public string DescricaoSinistro { get; set; }

        [Required]
        [Display(Name = "Situação Sinistro")]
        [Column("SG_SITUACAO_SINISTRO")]
        public string SituacaoSinistro { get; set; }

        [Required]
        [Display(Name = "Observação Sinistro")]
        [Column("DS_OBSERVACAO_SINISTRO")]
        public string ObservacaoSinistro { get; set; }
        
    }
}