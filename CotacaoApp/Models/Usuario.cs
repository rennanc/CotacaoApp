using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column("NM_USUARIO")]
        [EmailAddress]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [Column("NM_SENHA")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Permissao")]
        [Column("FL_PERMISSAO")]
        public int Permissao { get; set; }

    }
}