using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CotacaoApp.Enumerations
{
    public class EnumUsuario
    {
    }

    public enum Permissao
    {
        //opções do radio button
        [Display(Name = "Administrador")]
        ADMINISTRADOR = 1,
        [Display(Name = "Corretor")]
        CORRETOR = 2
    }
}