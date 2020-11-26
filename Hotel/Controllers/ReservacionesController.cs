using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Data;
using Hotel.Domain;

namespace Hotel.Controllers
{
    public class ReservacionesController : Controller
    {
        private HotelContext db = new HotelContext();

        // GET: Reservaciones
        public ActionResult Index()
        {
            return View(db.Reservaciones.ToList());
        }

        // GET: Reservaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            return View(reservaciones);
        }

        // GET: Reservaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Reserva,Email_R,Nombre_R,Apellidos_R,Fecha_Entrada_R,Fecha_Salida_R,Telefono_R,Habitacion_R,Especificaion_R")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                db.Reservaciones.Add(reservaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservaciones);
        }

        // GET: Reservaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            return View(reservaciones);
        }

        // POST: Reservaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Reserva,Email_R,Nombre_R,Apellidos_R,Fecha_Entrada_R,Fecha_Salida_R,Telefono_R,Habitacion_R,Especificaion_R")] Reservaciones reservaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservaciones);
        }

        // GET: Reservaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            if (reservaciones == null)
            {
                return HttpNotFound();
            }
            return View(reservaciones);
        }

        // POST: Reservaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservaciones reservaciones = db.Reservaciones.Find(id);
            db.Reservaciones.Remove(reservaciones);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
