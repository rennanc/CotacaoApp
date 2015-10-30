using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CotacaoApp.Enumerations
{
    public class EnumApolice
    {
    }


    public enum Status
    {
        //opções do radio button
        [Display(Name = "Elaboração")]
        NENHUM = 0,
        [Display(Name = "Enviado")]
        ENVIADO = 1,
        [Display(Name = "Aprovado Pelo Cliente")]
        APROVADO = 2,
        [Display(Name = "Contrato Reprovado pela Seguradora")]
        REPROVADOSEGURADORA = 3,
        [Display(Name = "Contrato Aprovado pela Seguradora")]
        APROVADOSEGURADORA = 4,
        [Display(Name = "Contrato Cancelado")]
        CONTRATOCANCELADO = 5,
        [Display(Name = "Contrato Aprovado")]
        CONTRATOAPROVADO = 6

    }

}