using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CotacaoApp.Models
{
    public class Proposta
    {

        [Key]
        [Display(Name = "Codigo")]
        [Column("CD_PROPOSTA")]
        public int Id { get; set; }

        [Display(Name = "Email")]
        [Column("CD_SEGURADO")]
        public int Nome { get; set; }

        [Required]
        [Display(Name = "Condutor")]
        [Column("DT_INICIO_VIGENCIA")]
        public string Condutor { get; set; }

        [Required]
        [Display(Name = "Condutor")]
        [Column("DT_INICIO_VIGENCIA")]
        [DataType(DataType.Date)]
        public string dataInicioVigencia { get; set; }


        [Required]
        [Display(Name = "Condutor")]
        [Column("DT_INICIO_VIGENCIA")]
        [DataType(DataType.Date)]
        public string dataFimVigencia { get; set; }

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

        [Display(Name = "Veiculo")]
        [Column("NM_VEICULO")]
        public string NomeVeiculo { get; set; }

        [Display(Name = "Veiculo Financiado")]
        [Column("IE_VEICULOFINANCIADO")]
        public string IEVeiculoFinanciado { get; set; }

        [Display(Name = "Marca do Carro")]
        [Column("NM_MARCA")]
        public string NomeMarca { get; set; }

        [Display(Name = "Data Fabricacao")]
        [Column("DT_FABRICACAO")]
        [DataType(DataType.Date)]
        public string DataFabricacao { get; set; }

        [Display(Name = "Data Veiculo")]
        [Column("DT_VEICULO")]
        [DataType(DataType.Date)]
        public string DataVeiculo { get; set; }

        [Display(Name = "Status")]
        [Column("IE_STATUS")]
        public string IEStatus { get; set; }

        [Display(Name = "Status")]
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
        public string DataBlindagem { get; set; }

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

    }
}