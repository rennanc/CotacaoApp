using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CotacaoApp.Enumerations
{
    public class EnumValorProposta
    {
    }

    public enum StatusPagamento
    {
        //opções do radio button
        [Display(Name = "Pendente")]
        PENDENTE = 0,
        [Display(Name = "Pago")]
        PAGO = 1
    }
}