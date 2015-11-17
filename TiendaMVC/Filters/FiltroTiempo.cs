using System;
using System.Web.Mvc;

namespace TiendaMVC.Filters
{
    public class FiltroTiempo : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var hora = DateTime.Now;

            if (hora.Minute <= 30 || hora.Minute > 40)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }


            base.OnActionExecuting(filterContext);
        }
    }
}