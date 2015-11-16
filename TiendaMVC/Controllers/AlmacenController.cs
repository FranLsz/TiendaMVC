using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMVC.Filters;
using TiendaMVC.Models;

namespace TiendaMVC.Controllers
{
    public class AlmacenController : Controller
    {
        Tienda15Entities db = new Tienda15Entities();

        // GET: Almacen
        public ActionResult Index()
        {

            return View(db.Almacen);
        }

        [HttpGet]
        public ActionResult Alta()
        {
            return View(new Almacen());
        }

        [HttpPost]
        public ActionResult Alta(Almacen model)
        {
            if (ModelState.IsValid)
            {
                db.Almacen.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            //devuelve el mismo objeto para que 
            //se solucionen los problemas de validacion
            return View(model);
        }

        [FiltroId]
        public ActionResult Delete(int id)
        {
            var model = db.Almacen.FirstOrDefault(o => o.id == id);

            if (model == null)
            {
                return HttpNotFound();
            }

            if (model.AlmacenProducto.Any())
                db.AlmacenProducto.RemoveRange(model.AlmacenProducto);

            db.Almacen.Remove(model);
           // db.SaveChanges();

            return View();
        }
        [HttpGet]
        [FiltroId]
        public ActionResult Edit(int id)
        {
            var model = db.Almacen.FirstOrDefault(o => o.id == id);

            if (model == null)
            {
                return HttpNotFound();
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Almacen model)
        {
            var m = db.Almacen.FirstOrDefault(o => o.id == model.id);

            if (m == null)
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;

                db.SaveChanges();
                return View();
            }

            return View(model);
        }



    }
}