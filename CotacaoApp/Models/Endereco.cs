using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    public class Endereco
    {

        [Key]
        [ForeignKey("CD_PESSOA")]
        [Display(Name = "Codigo")]
        [Column("CD_PESSOA")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        [Column("NM_CIDADE")]
        public string NomeCidade { get; set; }

        [Required]
        [Display(Name = "UF")]
        [Column("SG_UF")]
        public string SiglaUF { get; set; }

        [Required]
        [Display(Name = "Numero Cep")]
        [Column("NR_CEP")]
        public int NumeroCep { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        [Column("NM_BAIRRO")]
        public string NomeBairro { get; set; }

        [Required]
        [Display(Name = "Rua")]
        [Column("NM_Rua")]
        public string NomeRua { get; set; }

        [Required]
        [Display(Name = "Rua")]
        [Column("NR_NUMERO")]
        public int NumeroLocal { get; set; }

        [Required]
        [Display(Name = "Complemento")]
        [Column("NM_COMPLEMENTO")]
        public string NomeComplemento { get; set; }

        //Adicionar no banco
        [Display(Name = "Numero do Cep de maior Deslocamento")]
        //[Column("NR_CEPDESLOCAMENTO")]
        public int NumeroCepFrequente { get; set; }

    }
}