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
    public class KonsultantsController : Controller
    {
        private MASEntities db = new MASEntities();

        // GET: Konsultants
        public ActionResult Index()
        {
            return View(db.Osobas.ToList());
        }

        // GET: Konsultants/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konsultant konsultant = (Konsultant)db.Osobas.Find(id);
            if (konsultant == null)
            {
                return HttpNotFound();
            }
            return View(konsultant);
        }

        // GET: Konsultants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Konsultants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Osoba_ID,Imie,Nazwisko,Data_zatrudnienia,Prowizja")] Konsultant konsultant)
        {
            if (ModelState.IsValid)
            {
                db.Osobas.Add(konsultant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(konsultant);
        }

        // GET: Konsultants/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konsultant konsultant = (Konsultant)db.Osobas.Find(id);
            if (konsultant == null)
            {
                return HttpNotFound();
            }
            return View(konsultant);
        }

        // POST: Konsultants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Osoba_ID,Imie,Nazwisko,Data_zatrudnienia,Prowizja")] Konsultant konsultant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(konsultant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(konsultant);
        }

        // GET: Konsultants/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Konsultant konsultant = (Konsultant)db.Osobas.Find(id);
            if (konsultant == null)
            {
                return HttpNotFound();
            }
            return View(konsultant);
        }

        // POST: Konsultants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Konsultant konsultant = (Konsultant)db.Osobas.Find(id);
            db.Osobas.Remove(konsultant);
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
