using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    [Serializable]
    public class PessoaFisica
    {

        [Display(Name = "Codigo")]
        [Column("CD_CONDUTOR")]
        public int Id { get; set; }

        [Key]
        [Required]
        [Display(Name = "CPF")]
        [Column("CD_CPF")]
        public string CodigoCpf { get; set; }

        [Display(Name = "Nome")]
        [Column("NM_NOME")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Column("DT_NASCIMENTO")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Sexo")]
        [Column("IE_SEXO")]
        public string IESexo { get; set; }

        [Display(Name = "EstadoCivel")]
        [Column("NM_ESTADOCIVIL")]
        public int IEEstadoCivil { get; set; }

        [Display(Name = "Possui Outros Carros")]
        [Column("IE_POSSUIOUTROSCARROS")]
        public int IEPossuiOutrosCarros { get; set; }

        [Display(Name = "Quantidade de Carros")]
        [Column("IE_QTDCARROS")]
        public int IEQuantidadeCarro { get; set; }

        [Display(Name = "Anos de CNH")]
        [Column("NR_ANOSCNH")]
        public int AnosDeCNH { get; set; }

        [Display(Name = "É o proprietario do veiculo")]
        [Column("IE_PROPRIETARIOVEICULO")]
        public int IEProprietarioVeiculo { get; set; }

        [Display(Name = "Relaxao com o proprietario")]
        [Column("IE_RELACAOPROPRIETARIO")]
        public int IERelacaoProprietario { get; set; }

        [Display(Name = "é o Condutor Principal")]
        //[Column("IE_CONDPRINCIPAL")]
        public int IECondutorPrincipal { get; set; }

        [Display(Name = "Numero Cep")]
        [Column("NR_CEP")]
        public int NumeroCep { get; set; }

        /*********** PASSO-4 : CONDUTORES ************/

        [Display(Name = "tipo de residencia")]
        [Column("IE_CONDPRINCIPAL")]
        public int IETipoResidencia { get; set; }

        [Display(Name = "Profissao")]
        [Column("DS_PROFISSAO")]
        public string Profissao { get; set; }

        [Display(Name = "Roubado em 24 meses")]
        [Column("IE_ROUBADOEM24MESES")]
        public int IERoubadoEm24Meses { get; set; }

        [Display(Name = "Algum Condutor Estuda")]
        [Column("IE_ALGUMCONDUTORESTUDA")]
        public int IEAlgumCondutorEstuda { get; set; }

        /*********** PASSO-5 : CONCLUSÃO ************/

        [Display(Name = "Email")]
        [Column("NM_EMAIL")]
        public string Email { get; set; }

        [Display(Name = "Noticias por Email")]
        [Column("IE_NOTICIASEMAIL")]
        public bool IENoticiasEmail { get; set; }


        //Vantagens
        [Display(Name = "Cliente Itaú Personalité")]
        [Column("IE_ITAUPERSONALITE")]
        public bool IEItauPersonalite { get; set; }

        [Display(Name = "Cartão Porto Seguro Visa")]
        [Column("IE_CARTAOPORTOSEGUROVISA")]
        public bool IECartaoPortoSeguroVisa { get; set; }
    }
}