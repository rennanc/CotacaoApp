using CotacaoApp.Filters;
using System.Web;
using System.Web.Mvc;


//Filtros Globais da apliciação
namespace CotacaoApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AutorizacaoFilterAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
