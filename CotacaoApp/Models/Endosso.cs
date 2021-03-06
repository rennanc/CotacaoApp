﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CotacaoApp.Models
{
    [Serializable]
    public class Endosso
    {
        [Key]
        [Display(Name = " Código Endosso")]
        [Column("CD_ENDOSSO")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Código Apolice")]
        [Column("CD_APOLICE")]
        public int CodApolice { get; set; }

        [NotMapped]
        public Apolice Apolice { get; set; }

        [Required]
        [Display(Name = "Código Apolice Antigo")]
        [Column("CD_APOLICEOLD")]
        public int CodApoliceAntigo { get; set; }

        [Required]
        [Display(Name = "Data Endosso")]
        [Column("DT_ENDOSSO")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataEndosso { get; set; }
        
    }
}