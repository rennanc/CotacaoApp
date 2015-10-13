using System;
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

        [Required]
        [Display(Name = "Data Alteração Endosso")]
        [Column("DT_ALTERACAO_ENDOSSO")]
        public DateTime DataAlteracaoEndosso { get; set; }

        [Required]
        [Display(Name = "Data Endosso")]
        [Column("DT_ENDOSSO")]
        public DateTime DataEndosso { get; set; }
    }
}