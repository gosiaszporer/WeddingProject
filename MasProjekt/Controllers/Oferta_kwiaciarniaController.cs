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
    public class Oferta_kwiaciarniaController : Controller
    {
        private MASEntities db = new MASEntities();

        // GET: Oferta_kwiaciarnia
        public ActionResult Index()
        {
            var oferta_kwiaciarnia = db.Oferta_kwiaciarnia.Include(o => o.Podwykonawca);
            return View(oferta_kwiaciarnia.ToList());
        }

        // GET: Oferta_kwiaciarnia/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta_kwiaciarnia oferta_kwiaciarnia = db.Oferta_kwiaciarnia.Find(id);
            if (oferta_kwiaciarnia == null)
            {
                return HttpNotFound();
            }
            return View(oferta_kwiaciarnia);
        }

        // GET: Oferta_kwiaciarnia/Create
        public ActionResult Create()
        {
            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa");
            return View();
        }

        // POST: Oferta_kwiaciarnia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nazwa,Dominujacy_kwiat,Cena,Oferta_kwiaciarnia_ID,Podwykonawca_Podwykonawca_ID")] Oferta_kwiaciarnia oferta_kwiaciarnia)
        {
            if (ModelState.IsValid)
            {
                db.Oferta_kwiaciarnia.Add(oferta_kwiaciarnia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa", oferta_kwiaciarnia.Podwykonawca_Podwykonawca_ID);
            return View(oferta_kwiaciarnia);
        }

        // GET: Oferta_kwiaciarnia/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta_kwiaciarnia oferta_kwiaciarnia = db.Oferta_kwiaciarnia.Find(id);
            if (oferta_kwiaciarnia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa", oferta_kwiaciarnia.Podwykonawca_Podwykonawca_ID);
            return View(oferta_kwiaciarnia);
        }

        // POST: Oferta_kwiaciarnia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nazwa,Dominujacy_kwiat,Cena,Oferta_kwiaciarnia_ID,Podwykonawca_Podwykonawca_ID")] Oferta_kwiaciarnia oferta_kwiaciarnia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oferta_kwiaciarnia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Podwykonawca_Podwykonawca_ID = new SelectList(db.Podwykonawcas, "Podwykonawca_ID", "Nazwa", oferta_kwiaciarnia.Podwykonawca_Podwykonawca_ID);
            return View(oferta_kwiaciarnia);
        }

        // GET: Oferta_kwiaciarnia/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oferta_kwiaciarnia oferta_kwiaciarnia = db.Oferta_kwiaciarnia.Find(id);
            if (oferta_kwiaciarnia == null)
            {
                return HttpNotFound();
            }
            return View(oferta_kwiaciarnia);
        }

        // POST: Oferta_kwiaciarnia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Oferta_kwiaciarnia oferta_kwiaciarnia = db.Oferta_kwiaciarnia.Find(id);
            db.Oferta_kwiaciarnia.Remove(oferta_kwiaciarnia);
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
