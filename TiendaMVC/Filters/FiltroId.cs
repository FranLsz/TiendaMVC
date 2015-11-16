using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaMVC.Filters
{
    public class FiltroId : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String id = null;
            try
            {
                id = filterContext.ActionParameters["id"].ToString();
            }
            catch (Exception)
            {
                //Console.WriteLine();
            }
            var pet = filterContext.ActionDescriptor.ActionName;
            if (id == null && pet != "Index")
            {
                //Se redirige a una pagina vacia pero se puede 
                //poner donde nosotros queramos.
                filterContext.Result = new EmptyResult();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}