using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace CotacaoApp.Models
{
    public class Seguradora
    {
        [Key]
        [Display(Name = "Seguradora")]
        [Column("CD_SEGURADORA")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sinistro Auto")]
        [Column("CD_SINISTROAUTO")]
        public string SinistroAuto { get; set; }

        [Required]
        [Display(Name = "Recepção")]
        [Column("DS_RECEPCAO")]
        public string Recepcao { get; set; }

        [Required]
        [Display(Name = "Produção")]
        [Column("DS_PRODUCAO")]
        public string Producao { get; set; }

        [Required]
        [Display(Name = "Assistencia 24 Horas")]
        [Column("DS_ASS24H")]
        public string Assistencia { get; set; }
        
        [Required]
        [Display(Name = "Outros")]
        [Column("DS_OUTROS")]
        public string Outros { get; set; }

        [Required]
        [Display(Name = "Cálculos")]
        [Column("VL_CALCULOS")]
        [Range(0, double.MaxValue, ErrorMessage = "Valor não Válido")] //só numeros
        public double Calculos { get; set; } 


    }
}