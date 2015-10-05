using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CotacaoApp.Models
{
    [Serializable]
    public class Telefone
    {
        [Key]
        [Display(Name = "Codigo")]
        [Column("CD_TELEFONE")]
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        [Column("CD_CONDUTOR")]
        public int CodigoCondutor { get; set; }

        [Display(Name = "Telefone")]
        [Column("NR_TELEFONE")]
        public string NumeroTelefone { get; set; }
    }
}