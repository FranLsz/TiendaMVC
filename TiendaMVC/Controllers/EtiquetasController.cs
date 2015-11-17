using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMVC.Filters;
using TiendaMVC.Models;

namespace TiendaMVC.Controllers
{
    public class EtiquetasController : BaseController
    {
        Tienda15Entities db = new Tienda15Entities();

        //[FiltroTiempo]
        // GET: Etiquetas
        public ActionResult Index()
        {
            var data = db.Etiqueta;

            ViewBag.Almacenes = db.Almacen;
            return View(data);
        }
    }
}