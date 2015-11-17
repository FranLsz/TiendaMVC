using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMVC.Models;

namespace TiendaMVC.Controllers
{
    public class ProductoAjaxController : Controller
    {
        Tienda15Entities db = new Tienda15Entities();


        // GET: ProductoAjax
        public ActionResult Index()
        {


            return View(db.Producto);
        }

        [OutputCache(Duration = 0, VaryByParam = "*")]
        public ActionResult Buscar(String nombre)
        {
            var data = db.Producto.Where(o => o.nombre.Contains(nombre));

            return PartialView("_listadoProducto", data);

        }


        [HttpPost]
        public ActionResult Alta(Producto model)
        {
            db.Producto.Add(model);
            db.SaveChanges();
            return Json(model);
        }
    }
}