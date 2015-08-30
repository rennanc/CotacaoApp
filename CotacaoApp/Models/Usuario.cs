using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CotacaoApp.Models
{
    public class Usuario
    {

        [Key]
        [Display(Name = "Codigo")]
        [Column("CD_USUARIO")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        [Column("NM_EMAIL")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [Column("NM_SENHA")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}