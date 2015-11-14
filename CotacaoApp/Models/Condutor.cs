using CotacaoApp.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    [Serializable]
    public class Condutor
    {

        [Key]
        [Display(Name = "Codigo")]
        [Column("CD_CONDUTOR")]
        public int Id { get; set; }

        [Display(Name = "Codigo Segurado")]
        [Column("CD_SEGURADO")]
        public int codigoSegurado { get; set; }

        //pessoa fisica

        [Display(Name = "CPF")]
        [Column("CD_CPF")]
        public string CodigoCpf { get; set; }

        [Display(Name = "Nome")]
        [Column("NM_NOME")]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Column("DT_NASCIMENTO")]
        //[DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Sexo*")]
        [Column("IE_SEXO")]
        public IESexo IESexo { get; set; }

        [Display(Name = "Estado Civil*")]
        [Column("NM_ESTADOCIVIL")]
        public IEEstadoCivil IEEstadoCivil { get; set; }

        [Display(Name = "Numero Cep")]
        [Column("NR_CEP")]
        public string NumeroCep { get; set; }

        [Display(Name = "Além desse carro, o segurado possui outros carros em sua residência ? *")]
        [Column("IE_POSSUIOUTROSCARROS")]
        public IEPossuiOutrosCarros IEPossuiOutrosCarros { get; set; }

        [Display(Name = "Quantos mais?*")]
        [Column("IE_QTDCARROS")]
        public IEQuantidadeCarro IEQuantidadeCarro { get; set; }

        [Display(Name = "Anos de CNH")]
        [Column("NR_ANOSCNH")]
        public int AnosDeCNH { get; set; }

        [Display(Name = "O segurado é proprietário(a) do carro?*")]
        [Column("IE_PROPRIETARIOVEICULO")]
        public IEProprietarioVeiculo IEProprietarioVeiculo { get; set; }

        [Display(Name = "Relação entre PROPRIETÁRIO e SEGURADO*")]
        [Column("IE_RELACAOPROPRIETARIO")]
        public IERelacaoProprietario IERelacaoProprietario { get; set; }

        [Display(Name = "é o Condutor Principal")]
        [Column("IE_CONDPRINCIPAL")]
        public IECondutorPrincipal IECondutorPrincipal { get; set; }



        /*********** PASSO-4 : CONDUTORES ************/

        [Display(Name = "tipo de residencia")]
        [Column("IE_TIPORESIDENCIA")]
        public IETipoResidencia IETipoResidencia { get; set; }

        [Display(Name = "Profissao")]
        [Column("DS_PROFISSAO")]
        public string Profissao { get; set; }

        [Display(Name = "Roubado em 24 meses")]
        [Column("IE_ROUBADOEM24MESES")]
        public IERoubadoEm24Meses IERoubadoEm24Meses { get; set; }

        [Display(Name = "Algum Condutor Estuda")]
        [Column("IE_ALGUMCONDUTORESTUDA")]
        public IEAlgumCondutorEstuda IEAlgumCondutorEstuda { get; set; }

        /*********** PASSO-5 : CONCLUSÃO ************/

        [NotMapped]
        [Display(Name = "Segurado")]
        public List<Telefone> Telefones { get; set; }

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