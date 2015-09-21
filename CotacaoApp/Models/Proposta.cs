using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace CotacaoApp.Models
{
    [Serializable]
    public class Proposta
    {
        //public Proposta()
        //{
        //    NomeMarcaLista = new List<SelectListItem>();
        //    NomeMarcaLista.Add(new SelectListItem { Value = "1", Text = "Fiat" });
        //    NomeMarcaLista.Add(new SelectListItem { Value = "2", Text = "Volkswagen" });
        //}

        [Key]
        [Display(Name = "Codigo")]
        [Column("CD_PROPOSTA")]
        public int Id { get; set; }

        [Display(Name = "Segurado")]
        public Segurado Segurado { get; set; }

        [Required]
        [Display(Name = "Condutor")]
        [Column("NM_CONDUTOR")]
        public string Condutor { get; set; }

        [Required]
        [Display(Name = "Inicio da Vigencia")]
        [Column("DT_INICIO_VIGENCIA")]
        [DataType(DataType.Date)]
        public DateTime dataInicioVigencia { get; set; }

        [Required]
        [Display(Name = "Fim da Vigencia")]
        [Column("DT_FIM_VIGENCIA")]
        [DataType(DataType.Date)]
        public DateTime dataFimVigencia { get; set; }

        [Display(Name = "Renovação de Seguro")]
        [Column("IE_RENV_SEGURO")]
        public int IERenvSeguro { get; set; }

        [Display(Name = "Acionou Seguro")]
        [Column("IE_ACIONOU_SEGURO")]
        public int IEAcionouSeguro { get; set; }

        [Display(Name = "Acionou Seguro")]
        [Column("IE_POSSUI_VEICULO")]
        public int IEPossuiVeiculo { get; set; }

        [Display(Name = "Nome da Seguradora Atual")]
        [Column("NM_SEGURADORA_ATUAL")]
        public string NomeSeguradoraAtual { get; set; }

        [Display(Name = "Placa")]
        [Column("NM_PLACA")]
        public string NomePlaca { get; set; }

        [Display(Name = "Qual o Seu Veículo?")]
        [Column("NM_VEICULO")]
        public string NomeVeiculo { get; set; }

        [Display(Name = "O Carro É Financiado?")]
        [Column("IE_VEICULOFINANCIADO")]
        public int IEVeiculoFinanciado { get; set; }

        [Display(Name = "Marca do Carro")]
        [Column("NM_MARCA")]
        public string NomeMarca { get; set; }

        [Display(Name = "Data Fabricacao")]
        [Column("DT_FABRICACAO")]
        public string DataFabricacao { get; set; }

        [Display(Name = "Data Veiculo")]
        [Column("DT_VEICULO")]
        public string DataVeiculo { get; set; }

        [Display(Name = "Status")]
        [Column("IE_STATUS")]
        public string IEStatus { get; set; }

        [Display(Name = "Descrição")]
        [Column("DS_OBJSEGURADO")]
        public string DescricaoObjSegurado { get; set; }

        [Display(Name = "Valor Bonus")]
        [Column("VL_BONUS")]
        public decimal ValorBonus { get; set; }

        [Display(Name = "Zero KM")]
        [Column("IE_ZEROKM")]
        public int IEZeroKM { get; set; }

        [Display(Name = "Anti furto de fábrica")]
        [Column("IE_ANTIFURTOFABRICA")]
        public int IEAntiFurtoFabrica { get; set; }

        [Display(Name = "Rastreador")]
        [Column("IE_RASTREADOR")]
        public int IERastreador { get; set; }

        [Display(Name = "Pinagem")]
        [Column("IE_PINAGEM")]
        public int IEPinagem { get; set; }

        [Display(Name = "AntiFurto Comum")]
        [Column("IE_ANTIFURTOCOMUM")]
        public int IEAntiFurtoComum { get; set; }

        [Display(Name = "Blindagem")]
        [Column("IE_BLINDAGEM")]
        public int IEBlindagem { get; set; }

        [Display(Name = "Data da Blindagem")]
        [Column("DT_BLINDAGEM")]
        [DataType(DataType.Date)]
        public DateTime DataBlindagem { get; set; }

        [Display(Name = "Valor da Blindagem")]
        [Column("VR_BLINDAGEM")]
        public decimal ValorBlindagem { get; set; }

        [Display(Name = "Tipo de Blindagem")]
        [Column("IE_TIPOBLINDAGEM")]
        public int IETipoBlindagem { get; set; }

        [Display(Name = "Kit Gás")]
        [Column("IE_KITGAS")]
        public int IEKitGas { get; set; }

        [Display(Name = "Cobertura Kit Gás")]
        [Column("IE_COBERTURA_KITGAS")]
        public int IECoberturaKitGas { get; set; }

        [Display(Name = "Valor Kit Gás")]
        [Column("VR_KITGAS")]
        public decimal ValorKitGas { get; set; }

        [Display(Name = "Relação Segurado Condutor")]
        [Column("IE_RELACAOSEGURADOCONDUTOR")]
        public int IERelacaoSeguradoCondutor { get; set; }

        [Display(Name = "Sexo do Condutor")]
        [Column("IE_SEXOCONDUTOR")]
        public int IESexoCondutor { get; set; }

        [Display(Name = "Estacionamento do Carro")]
        public int IEEstacionamentoCarro { get; set; }

        [Display(Name = "Tipo do Portão")]
        public int IETipoPortao { get; set; }


        //Adicionar no banco

        [Display(Name = "Para Lazer")]
        //[Column("IE_LAZER")]
        public bool IELazer { get; set; }

        [Display(Name = "Para Trabalhar")]
        //[Column("IE_LAZER")]
        public bool IEVeiculoTrabalho { get; set; }

        [Display(Name = "Local do Veiculo")]
        //[Column("IELocalVeiculo")]
        public int IELocalGaragemTrabalho { get; set; }

        [Display(Name = "Distancia percorrida para o trabalho")]
        //[Column("IELocalVeiculo")]
        public int IEDistanciaPercorridaParaTrabalho { get; set; }

        [Display(Name = "Ir ao Colégio/Faculdade/Pós")]
        //[Column("IELocalVeiculo")]
        public bool IEVeiculoEstudo { get; set; }

        [Display(Name = "Garagem Estudo")]
        //[Column("IELocalVeiculo")]
        public int IELocalGaragemEstudo { get; set; }

        [Display(Name = "Carro Para Trabalho")]
        //[Column("IELocalVeiculo")]
        public int IECarroParaTrabalhar { get; set; }

        [Display(Name = "Como Veiculo é utilizado")]
        //[Column("IELocalVeiculo")]
        public int IEUtilizacaoVeiculo { get; set; }

        [Display(Name = "Km em Média")]
        //[Column("IELocalVeiculo")]
        public int IEKmEmMedia { get; set; }

        [Display(Name = "Motivo Cotacao")]
        //[Column("IELocalVeiculo")]
        public int IEMotivoCotacao { get; set; }

        [Display(Name = "Seguro para Carro Existente")]
        //[Column("IELocalVeiculo")]
        public int IESeguroParaCarroExistente { get; set; }

        [Display(Name = "Quero mais opções de seguradoras e coberturas")]
        //[Column("IELocalVeiculo")]
        public bool IEQuerMaisOpcoes { get; set; }

        [Display(Name = "Estou em busca de um melhor atendimento")]
        //[Column("IELocalVeiculo")]
        public bool IEQuerMelhorAtendimento { get; set; }

        [Display(Name = "IEQuerMelhorPreco")]
        //[Column("IELocalVeiculo")]
        public bool IEQuerMelhorPreco { get; set; }

        [Display(Name = "IEBonusSeguroAtualSemSinistro")]
        //[Column("IELocalVeiculo")]
        public int IEBonusSeguroAtualSemSinistro { get; set; }

        [Display(Name = "IEBonusSeguroAtualComSinistro")]
        //[Column("IELocalVeiculo")]
        public int IEBonusSeguroAtualComSinistro { get; set; }

        [Display(Name = "Apolice Antiga")]
        //[Column("IELocalVeiculo")]
        public int NumeroApoliceAntiga { get; set; }

        [Display(Name = "CI Antiga")]
        //[Column("IELocalVeiculo")]
        public int NumeroCIAntiga { get; set; }


        //Auxiliares
        //[Display(Name = "Marca", Prompt = "Marca", Description = "Escolha a Marca do Veículo")]
        //public IList<SelectListItem> NomeMarcaLista { get; set; }

    }
}