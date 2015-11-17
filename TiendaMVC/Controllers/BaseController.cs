using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaMVC.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
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