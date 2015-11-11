using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TiendaMVC.Models;

namespace TiendaMVC.Controllers
{
    public class ProductoController : Controller
    {
        Tienda15Entities db = new Tienda15Entities();

        public ActionResult Index()
        {
            var data = db.Producto;

            return View(data);

        }


        [HttpGet]
        public ActionResult Alta()
        {
            return View(new Producto());
        }

        [HttpPost]
        public ActionResult Alta(Producto model)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(model);
                db.SaveChanges();

                //devuelve un objeto vacio para que se pueda crear otro nuevo
                return View(new Producto());
            }

            //devuelve el mismo objeto para que 
            //se solucionen los problemas de validacion
            return View(model);
        }

        [HttpGet]
        public ActionResult Detalle(int id)
        {
            var model = db.Producto.FirstOrDefault(o => o.id == id);

            if (model != null)
                return View(model);

            return HttpNotFound();
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = db.Producto.FirstOrDefault(o => o.id == id);

            if (model != null)
                return View(model);

            return HttpNotFound();
        }


        [HttpPost]
        public ActionResult UpdatePost(Producto model)
        {
            var m = db.Producto.FirstOrDefault(o => o.id == model.id);

            if (m == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                m.nombre = model.nombre;
                m.fabricante = model.fabricante;
                m.precioVenta = model.precioVenta;
                m.precioCoste = model.precioCoste;
                m.categoria = model.categoria;
            }

            db.SaveChanges();

            return View();
        }






        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Producto.FirstOrDefault(o => o.id == id);

            if (model != null)
            {
                db.Producto.Remove(model);
                // db.SaveChanges();
                return View();
            }

            return HttpNotFound();
        }


    }
}