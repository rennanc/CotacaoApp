using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    public class PessoaJuridica
    {

        [Display(Name = "Codigo")]
        [Column("CD_CONDUTOR")]
        public int Id { get; set; }

        [Key]
        [Required]
        [Display(Name = "CGC")]
        [Column("CD_CGC")]
        public int CodigoCpf { get; set; }

        [Display(Name = "Razao Social")]
        [Column("NM_RAZAO_SOCIAL")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Column("NM_RESPONSAVEL")]
        public DateTime NomeResponsavel { get; set; }

        [Display(Name = "Banco")]
        [Column("DS_ATIVIDADE")]
        public string DescricaoAtividade { get; set; }


    }
}