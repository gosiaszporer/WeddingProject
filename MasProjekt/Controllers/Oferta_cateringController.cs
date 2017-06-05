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
    public class Oferta_cateringController : Controller
    {
        private MASEntities db = new MASEntities();

        // GET: Oferta_catering
        public ActionResult Index()
        {
            var oferta_catering = db.Oferta_catering.Include(o => o.Podwykonawca);
            return View(oferta_catering.ToList());
        }

        // GET: Oferta_catering/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta_catering oferta_catering = db.Oferta_catering.Find(id);
            if (oferta_catering == null)
            {
                return HttpNotFound();
            }
            return View(oferta_catering);
        }

        // GET: Oferta_catering/Create
        public ActionResult Create()
        {
            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa");
            return View();
        }

        // POST: Oferta_catering/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nazwa,Opis,Cena,Ilosc_dan,Oferta_catering_ID,Podwykonawca_Podwykonawca_ID")] Oferta_catering oferta_catering)
        {
            if (ModelState.IsValid)
            {
                db.Oferta_catering.Add(oferta_catering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa", oferta_catering.Podwykonawca_Podwykonawca_ID);
            return View(oferta_catering);
        }

        // GET: Oferta_catering/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta_catering oferta_catering = db.Oferta_catering.Find(id);
            if (oferta_catering == null)
            {
                return HttpNotFound();
            }
            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa", oferta_catering.Podwykonawca_Podwykonawca_ID);
            return View(oferta_catering);
        }

        // POST: Oferta_catering/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nazwa,Opis,Cena,Ilosc_dan,Oferta_catering_ID,Podwykonawca_Podwykonawca_ID")] Oferta_catering oferta_catering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferta_catering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa", oferta_catering.Podwykonawca_Podwykonawca_ID);
            return View(oferta_catering);
        }

        // GET: Oferta_catering/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta_catering oferta_catering = db.Oferta_catering.Find(id);
            if (oferta_catering == null)
            {
                return HttpNotFound();
            }
            return View(oferta_catering);
        }

        // POST: Oferta_catering/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Oferta_catering oferta_catering = db.Oferta_catering.Find(id);
            db.Oferta_catering.Remove(oferta_catering);
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
