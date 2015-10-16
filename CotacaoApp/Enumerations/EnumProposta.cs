using System.ComponentModel.DataAnnotations;

namespace CotacaoApp.Enumerations
{
    public class EnumProposta
    {

    }
    public enum IEFinanciadoVeiculo
    {
        [Display(Name = "Não é Financiado")]
        NAOFINANCIADO = 0,
        [Display(Name = "Sim, é Financiado")]
        SIMFINANCIADO = 1,
        [Display(Name = "Sim, é Financiado e Alienado (CDC, Financiamento Direto, Leasing, Consórcio)")]
        SIMFINANCIADOCOMALIENACAO = 2
    }

}