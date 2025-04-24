using System.Web;
using System.Web.Mvc;

namespace POOII_CL2_PEREYRA_GONZALO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
