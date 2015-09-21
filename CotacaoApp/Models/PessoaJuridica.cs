using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    public class PessoaJuridica
    {

        [Key]
        [ForeignKey("CD_PESSOA")]
        [Display(Name = "Codigo")]
        [Column("CD_PESSOA")]
        public int Id { get; set; }

        [Key]
        [Required]
        [Display(Name = "CPF")]
        [Column("CD_CPF")]
        public int CodigoCpf { get; set; }

        [Display(Name = "Nome")]
        [Column("NM_NOME")]
        public string Nome { get; set; }

        [Display(Name = "Data Expedicao")]
        [Column("DT_DATA_EXPEDICAO")]
        public DateTime DataExpedicao { get; set; }

        [Display(Name = "Orgão Emissor")]
        [Column("SG_ORGAO")]
        public string SiglaOrgao { get; set; }

        [Display(Name = "Identidade")]
        [Column("NR_RG")]
        public int NumeroRg { get; set; }

        [Display(Name = "Sexo")]
        [Column("IE_SEXO")]
        public int IESexo { get; set; }

        [Display(Name = "EstadoCivel")]
        [Column("NM_ESTADOCIVIL")]
        public string NomeEstadoCivil { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Column("DT_NASCIMENTO")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Email")]
        [Column("NM_EMAIL")]
        public DateTime NomeEmail { get; set; }

        [Display(Name = "Banco")]
        [Column("NM_BANCO")]
        public DateTime NomeBanco { get; set; }


    }
}