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


        /*********** PASSO-1 : SEU CARRO ************/
        [Display(Name = "Marca do Carro")]
        [Column("NM_MARCAVEICULO")]
        public string NomeMarcaVeiculo { get; set; }

        [Display(Name = "Ano Fabricacao Veiculo")]
        [Column("NR_ANOFABVEICULO")]
        public int AnoFabricacaoVeiculo { get; set; }

        [Display(Name = "Ano Modelo Veiculo")]
        [Column("NR_ANOMODELOVEICULO")]
        public int AnoModeloVeiculo { get; set; }

        [Display(Name = "Zero KM")]
        [Column("IE_ZEROKM")]
        public bool IEZeroKM { get; set; }

        [Display(Name = "Qual o Seu Veículo?")]
        [Column("NM_VEICULO")]
        public string NomeVeiculo { get; set; }

        [Display(Name = "O Carro É Financiado?")]
        [Column("IE_FINANCIADOVEICULO")]
        public int IEFinanciadoVeiculo { get; set; }


        //tipo veiculo
        [Display(Name = "Taxi")]
        [Column("IE_TIPOVEICULO_TAXI")]
        public bool IETipoVeiculoTaxi { get; set; }

        [Display(Name = "Para Deficiente")]
        [Column("IE_TIPOVEICULO_DEFICIENTE")]
        public bool IETipoVeiculoDeficiente { get; set; }

        [Display(Name = "com KitGas")]
        [Column("IE_TIPOVEICULO_KITGAS")]
        public bool IETipoVeiculoKitGas { get; set; }

        [Display(Name = "Blindado")]
        [Column("IE_TIPOVEICULO_BLINDADO")]
        public bool IETipoVeiculoBlindado { get; set; }

        [Display(Name = "Pessoa Juridica")]
        [Column("IE_TIPOVEICULO_PESSOAJURIDICA")]
        public bool IETipoVeiculoPessoaJuridica { get; set; }
        //tipo veiculo

        [Display(Name = "Alarme Veiculo ou antifurto")]
        [Column("IE_ALARMEVEICULO")]
        public int IEAlarmeVeiculo { get; set; }

        /*********** PASSO-2 : LOCALIZAÇÃO ************/

        [Display(Name = "Estacionamento do Carro")]
        [Column("IE_TIPOESTACION")]
        public int IETipoEstacionamento { get; set; }

        [Display(Name = "Tipo do Portão")]
        [Column("IE_TIPOPORTAO")]
        public int IETipoPortao { get; set; }

        [Display(Name = "Numero Cep Estacionamento")]
        [Column("NR_CEPESTACION")]
        public string CepEstacionamento { get; set; }

        [Display(Name = "Numero Cep Estacionamento")]
        [Column("NR_CEPDESLOC")]
        public string CepDeslocamento { get; set; }

        //Utilização do veiculo

        [Display(Name = "Para Lazer")]
        [Column("IE_UTILIZACAOVEICULO_LAZER")]
        public bool IEUtilizacaoVeiculoLazer { get; set; }

        [Display(Name = "Para Trabalhar")]
        [Column("IE_UTILIZACAOVEICULO_TRABALHO")]
        public bool IEUtilizacaoVeiculoTrabalho { get; set; }

            [Display(Name = "Tipo Garagem Trabalho")]
            [Column("IE_TIPOGARAGEMTRABALHO")]
            public int IELocalGaragemTrabalho { get; set; }

            [Display(Name = "Distancia percorrida para o trabalho")]
            [Column("IE_DISTANCIATRABVEICULO")]
            public int IEDistanciaParaTrabalhoVeiculo { get; set; }

        [Display(Name = "Ir ao Colégio/Faculdade/Pós")]
        [Column("IE_UTILIZACAOVEICULO_ESTUDO")]
        public bool IEUtilizacaoVeiculoEstudo { get; set; }

            [Display(Name = "Garagem Estudo")]
            [Column("IE_TIPOGARAGEMESTUDO")]
            public int IELocalGaragemEstudo { get; set; }

        [Display(Name = "Utilização do veiculo como instrumento de trabalho")]
        [Column("IE_UTILIZACAOVEICULO_INSTRUMENTO")]
        public bool IEUtilizacaoVeiculoInstrumento { get; set; }

        [Display(Name = "Forma de utilização do veiculo como instrumento de trabalho")]
        [Column("IE_UTILIZACAOVEICULO_INSTRUMENTOFORMA")]
        public int IEUtilizacaoVeiculoInstrumentoForma { get; set; }

        [Display(Name = "Km em Média")]
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
            public bool NomeSeguradoraAtual { get; set; }

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