using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MasProjekt;

namespace MasProjekt.Controllers
{
    public class LokalizacjasController : Controller
    {
        private MASEntities db = new MASEntities();

        // GET: Lokalizacjas
        public ActionResult Index()
        {
            return View(db.Lokalizacjas.ToList());
        }

        // GET: Lokalizacjas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokalizacja lokalizacja = db.Lokalizacjas.Find(id);
            if (lokalizacja == null)
            {
                return HttpNotFound();
            }
            return View(lokalizacja);
        }

        // GET: Lokalizacjas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lokalizacjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nazwa,Adres,Powierzchnia,Lokalizacja_ID")] Lokalizacja lokalizacja)
        {
            if (ModelState.IsValid)
            {
                db.Lokalizacjas.Add(lokalizacja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lokalizacja);
        }

        // GET: Lokalizacjas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokalizacja lokalizacja = db.Lokalizacjas.Find(id);
            if (lokalizacja == null)
            {
                return HttpNotFound();
            }
            return View(lokalizacja);
        }

        // POST: Lokalizacjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nazwa,Adres,Powierzchnia,Lokalizacja_ID")] Lokalizacja lokalizacja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lokalizacja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lokalizacja);
        }

        // GET: Lokalizacjas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lokalizacja lokalizacja = db.Lokalizacjas.Find(id);
            if (lokalizacja == null)
            {
                return HttpNotFound();
            }
            return View(lokalizacja);
        }

        // POST: Lokalizacjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Lokalizacja lokalizacja = db.Lokalizacjas.Find(id);
            db.Lokalizacjas.Remove(lokalizacja);
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
