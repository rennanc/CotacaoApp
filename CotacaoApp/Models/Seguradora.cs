using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace CotacaoApp.Models
{
    [Serializable]
    public class Seguradora
    {
        [Key]
        [Display(Name = "Seguradora")]
        [Column("CD_SEGURADORA")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome da Seguradora")]
        [Column("NM_SEGURADORA")]
        public string NomeSeguradora { get; set; }

    }
}