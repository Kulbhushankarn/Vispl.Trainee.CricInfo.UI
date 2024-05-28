using System.Web;
using System.Web.Mvc;

namespace Vispl.Trainee.CricInfo.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
