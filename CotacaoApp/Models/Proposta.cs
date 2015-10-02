﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


        /*********** PASSO-1 : SEU CARRO ************/
        [Display(Name = "Marca do Carro")]
        [Column("NM_MARCAVEICULO")]
        public string NomeMarcaVeiculo { get; set; }

        [Display(Name = "Ano de fabricação:*")]
        [Column("NR_ANOFABVEICULO")]
        [Required]
        public int AnoFabricacaoVeiculo { get; set; }

        [Display(Name = "Ano do modelo:*")]
        [Column("NR_ANOMODELOVEICULO")]
        [Required]
        public int AnoModeloVeiculo { get; set; }

        [Display(Name = "O carro é 0 KM?*")]
        [Column("IE_ZEROKM")]
        [Required]
        public bool IEZeroKM { get; set; }

        [Display(Name = "Qual o seu veiculo?*")]
        [Column("NM_VEICULO")]
        [Required]
        public string NomeVeiculo { get; set; }

        [Display(Name = "O carro é financiado?*")]
        [Column("IE_FINANCIADOVEICULO")]
        [Required]
        public int IEFinanciadoVeiculo { get; set; }


        //tipo veiculo
        [Display(Name = "Taxi")]
        [Column("IE_TIPOVEICULO_TAXI")]
        public bool IETipoVeiculoTaxi { get; set; }

        [Display(Name = "Adaptado para deficiente físico")]
        [Column("IE_TIPOVEICULO_DEFICIENTE")]
        public bool IETipoVeiculoDeficiente { get; set; }

        [Display(Name = "Tem Kit Gás")]
        [Column("IE_TIPOVEICULO_KITGAS")]
        public bool IETipoVeiculoKitGas { get; set; }

        [Display(Name = "É Blindado")]
        [Column("IE_TIPOVEICULO_BLINDADO")]
        public bool IETipoVeiculoBlindado { get; set; }

        [Display(Name = "É para Pessoa Jurídica")]
        [Column("IE_TIPOVEICULO_PESSOAJURIDICA")]
        public bool IETipoVeiculoPessoaJuridica { get; set; }
        //tipo veiculo

        [Display(Name = "Possui alarme ou algum dispositivo antifurto?*")]
        [Column("IE_ALARMEVEICULO")]
        [Required]
        public int IEAlarmeVeiculo { get; set; }

        /*********** PASSO-2 : LOCALIZAÇÃO ************/

        [Display(Name = "Onde o carro fica estacionado à noite?*")]
        [Column("IE_TIPOESTACION")]
        [Required]
        public int IETipoEstacionamento { get; set; }

        [Display(Name = "Tipo de portão:*")]
        [Column("IE_TIPOPORTAO")]
        public int IETipoPortao { get; set; }

        [Display(Name = "Qual o CEP do local onde ele fica estacionado à noite?*")]
        [Column("NR_CEPESTACION")]
        [DataType(DataType.PostalCode)]
        [Required]
        public string CepEstacionamento { get; set; }

        [Display(Name = "Qual o CEP para onde o carro mais se desloca?*")]
        [Column("NR_CEPDESLOC")]
        [DataType(DataType.PostalCode)]
        [Required]
        public string CepDeslocamento { get; set; }

        //Utilização do veiculo

        [Display(Name = "Para Lazer")]
        [Column("IE_UTILIZACAOVEICULO_LAZER")]
        public bool IEUtilizacaoVeiculoLazer { get; set; }

        [Display(Name = "Para Trabalhar")]
        [Column("IE_UTILIZACAOVEICULO_TRABALHO")]
        public bool IEUtilizacaoVeiculoTrabalho { get; set; }

            [Display(Name = "O veículo permanece em garagem ou estacionamento protegido no local de trabalho? *")]
            [Column("IE_TIPOGARAGEMTRABALHO")]
            public int IELocalGaragemTrabalho { get; set; }

            [Display(Name = "Distância percorrida do local estacionado à noite até o local de trabalho*")]
            [Column("IE_DISTANCIATRABVEICULO")]
            public int IEDistanciaParaTrabalhoVeiculo { get; set; }

        [Display(Name = "Ir ao Colégio/Faculdade/Pós-Graduação")]
        [Column("IE_UTILIZACAOVEICULO_ESTUDO")]
        public bool IEUtilizacaoVeiculoEstudo { get; set; }

            [Display(Name = "O veículo permanece em garagem ou estacionamento protegido no local de estudo ? *")]
            [Column("IE_TIPOGARAGEMESTUDO")]
            public int IELocalGaragemEstudo { get; set; }

        [Display(Name = "Usa o carro como instrumento de trabalho? Ex.: Representante comercial, entregador delivery etc.* ")]
        [Column("IE_UTILIZACAOVEICULO_INSTRUMENTO")]
        [Required]
        public bool IEUtilizacaoVeiculoInstrumento { get; set; }

            [Display(Name = "Como o veículo é utilizado?*")]
            [Column("IE_UTILIZACAOVEICULO_INSTRUMENTOFORMA")]
            public int IEUtilizacaoVeiculoInstrumentoForma { get; set; }

        [Display(Name = "Quantos km roda em média ? *")]
        [Column("IE_MEDIAKMVEICULO")]
        public int IEKmEmMedia { get; set; }

        /*********** PASSO-3 : SEGURADO ************/

        [Display(Name = "Segurado")]
        public Condutor Segurado { get; set; }

        [Display(Name = "Proprietario")]
        public Condutor Proprietario { get; set; }

        [Display(Name = "Motivo da cotação")]
        [Column("IE_MOTIVO_COTACAO")]
        public int IEMotivoCotacao { get; set; }


            [Display(Name = "primeiro seguro")]
            [Column("IE_PRIMEIROSEGURO")]
            public int IEPrimeiroSeguro { get; set; }

            //seguro atual - caso ja tenha
            [Display(Name = "Seguro Atual - quer mais opções")]
            [Column("IE_SEGUROATUAL_QUERMAISOPCOES")]
            public bool IESeguroAtualQuerMaisOpcoes { get; set; }

            [Display(Name = "Seguro Atual - quer melhor atendimento")]
            [Column("IE_SEGUROATUAL_MELHORATENDIMENTO")]
            public bool IESeguroAtualMelhorAtendimento { get; set; }

            [Display(Name = "Seguro Atual - Não está satisfeito")]
            [Column("IE_SEGUROATUAL_NAOSATISFEITO")]
            public bool IESeguroAtualNaoSatisfeito { get; set; }

            [Display(Name = "Nome da Seguradora Atual")]
            [Column("NM_SEGURADORAATUAL")]
            public string NomeSeguradoraAtual { get; set; }

            [Display(Name = "Fim da Vigencia da Apolice atual")]
            [Column("DT_VENC_APOLICEATUAL")]
            [DataType(DataType.Date)]
            public DateTime DataApoliceAtualVencimento { get; set; }

            [Display(Name = "BonusSeguro  Atual Sem Sinistro")]
            [Column("IE_BONUSAPOLICEATUAL_SEMSINISTRO")]
            public int IEBonusSeguroAtualSemSinistro { get; set; }

            [Display(Name = "Bonus Seguro Atual Com Sinistro")]
            [Column("IE_BONUSAPOLICEATUAL_COMSINISTRO")]
            public int IEBonusSeguroAtualComSinistro { get; set; }


            [Display(Name = "Apolice Antiga")]
            [Column("NR_APOLICE")]
            public int NumeroApoliceAntiga { get; set; }

            [Display(Name = "CI Antiga")]
            [Column("NR_CI")]
            public int NumeroCIAntiga { get; set; }

        /*********** PASSO-4 : CONDUTORES ************/

        [Display(Name = "OutroCondutor")]
        public Condutor OutroCondutor { get; set; }


        /*********** PASSO-5 : CONCLUSÃO ************/

        //usar entidade do segurado para email, telefone e vantagens

        [Display(Name = "Placa")]
        [Column("NR_PLACAVEICULO")]
        public string NumeroPlaca { get; set; }

        [Display(Name = "Placa")]
        [Column("NR_CHASSIVEICULO")]
        public string NumeroChassi { get; set; }

        //Auxiliares
        //[Display(Name = "Marca", Prompt = "Marca", Description = "Escolha a Marca do Veículo")]
        //public IList<SelectListItem> NomeMarcaLista { get; set; }

    }
}