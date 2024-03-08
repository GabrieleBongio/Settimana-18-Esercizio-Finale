using System.Web;
using System.Web.Mvc;

namespace Settimana_18_Esercizio_Finale
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
