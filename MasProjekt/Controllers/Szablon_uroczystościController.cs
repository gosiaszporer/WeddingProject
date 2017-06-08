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
    public class Szablon_uroczystościController : Controller
    {
        private MASEntities db = new MASEntities();

        public decimal wyliczCene(Szablon_uroczystości szablon_uroczystości)
        {
            //Szablon_uroczystości szablon_uroczystości = new Szablon_uroczystości();
            szablon_uroczystości.Cena = szablon_uroczystości.Oferta_catering.Cena + szablon_uroczystości.Oferta_cukiernik.Cena + szablon_uroczystości.Oferta_kwiaciarnia.Cena;

            return szablon_uroczystości.Cena;
        }

        // GET: Szablon_uroczystości
        public ActionResult Index()
        {
            var szablon_uroczystości = db.Szablon_uroczystości.Include(s => s.Oferta_catering).Include(s => s.Oferta_cukiernik).Include(s => s.Oferta_kwiaciarnia);
            return View(szablon_uroczystości.ToList());
        }

        // GET: Szablon_uroczystości/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Szablon_uroczystości szablon_uroczystości = db.Szablon_uroczystości.Find(id);

            szablon_uroczystości.Cena = szablon_uroczystości.Oferta_catering.Cena + szablon_uroczystości.Oferta_cukiernik.Cena + szablon_uroczystości.Oferta_kwiaciarnia.Cena;
            db.SaveChanges();

            if (szablon_uroczystości == null)
            {
                return HttpNotFound();
            }
            return View(szablon_uroczystości);
        }

        // GET: Szablon_uroczystości/Create
        public ActionResult Create()
        {
            ViewBag.Oferta_catering_Oferta_catering_ID = new SelectList(db.Oferta_catering, "Oferta_catering_ID", "Nazwa");
            ViewBag.Oferta_cukiernik_Oferta_cukiernik_ID = new SelectList(db.Oferta_cukiernik, "Oferta_cukiernik_ID", "Nazwa");
            ViewBag.Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID = new SelectList(db.Oferta_kwiaciarnia, "Oferta_kwiaciarnia_ID", "Nazwa");
            return View();
        }

        // POST: Szablon_uroczystości/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nazwa,Cena,Szablon_uroczystości_ID,Oferta_catering_Oferta_catering_ID,Oferta_cukiernik_Oferta_cukiernik_ID,Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID")] Szablon_uroczystości szablon_uroczystości)
        {
            

            if (ModelState.IsValid)
            {
                //szablon_uroczystości.Cena = szablon_uroczystości.Oferta_catering.Cena + szablon_uroczystości.Oferta_cukiernik.Cena + szablon_uroczystości.Oferta_kwiaciarnia.Cena;
                db.Szablon_uroczystości.Add(szablon_uroczystości);
                db.SaveChanges();
                //+ szablon_uroczystości.Oferta_cukiernik.Cena + szablon_uroczystości.Oferta_kwiaciarnia.Cena;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Oferta_catering_Oferta_catering_ID = new SelectList(db.Oferta_catering, "Oferta_catering_ID", "Nazwa", szablon_uroczystości.Oferta_catering_Oferta_catering_ID);
            ViewBag.Oferta_cukiernik_Oferta_cukiernik_ID = new SelectList(db.Oferta_cukiernik, "Oferta_cukiernik_ID", "Nazwa", szablon_uroczystości.Oferta_cukiernik_Oferta_cukiernik_ID);
            ViewBag.Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID = new SelectList(db.Oferta_kwiaciarnia, "Oferta_kwiaciarnia_ID", "Nazwa", szablon_uroczystości.Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID);
            
            return View(szablon_uroczystości);
        }

        // GET: Szablon_uroczystości/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Szablon_uroczystości szablon_uroczystości = db.Szablon_uroczystości.Find(id);

            if (szablon_uroczystości == null)
            {
                return HttpNotFound();
            }
            ViewBag.Oferta_catering_Oferta_catering_ID = new SelectList(db.Oferta_catering, "Oferta_catering_ID", "Nazwa", szablon_uroczystości.Oferta_catering_Oferta_catering_ID);
            ViewBag.Oferta_cukiernik_Oferta_cukiernik_ID = new SelectList(db.Oferta_cukiernik, "Oferta_cukiernik_ID", "Nazwa", szablon_uroczystości.Oferta_cukiernik_Oferta_cukiernik_ID);
            ViewBag.Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID = new SelectList(db.Oferta_kwiaciarnia, "Oferta_kwiaciarnia_ID", "Nazwa", szablon_uroczystości.Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID);
            return View(szablon_uroczystości);
        }

        // POST: Szablon_uroczystości/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nazwa,Cena,Szablon_uroczystości_ID,Oferta_catering_Oferta_catering_ID,Oferta_cukiernik_Oferta_cukiernik_ID,Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID")] Szablon_uroczystości szablon_uroczystości)
        {
            if (ModelState.IsValid)
            {
                db.Entry(szablon_uroczystości).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Oferta_catering_Oferta_catering_ID = new SelectList(db.Oferta_catering, "Oferta_catering_ID", "Nazwa", szablon_uroczystości.Oferta_catering_Oferta_catering_ID);
            ViewBag.Oferta_cukiernik_Oferta_cukiernik_ID = new SelectList(db.Oferta_cukiernik, "Oferta_cukiernik_ID", "Nazwa", szablon_uroczystości.Oferta_cukiernik_Oferta_cukiernik_ID);
            ViewBag.Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID = new SelectList(db.Oferta_kwiaciarnia, "Oferta_kwiaciarnia_ID", "Nazwa", szablon_uroczystości.Oferta_kwiaciarnia_Oferta_kwiaciarnia_ID);
            return View(szablon_uroczystości);
        }

        // GET: Szablon_uroczystości/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Szablon_uroczystości szablon_uroczystości = db.Szablon_uroczystości.Find(id);
            if (szablon_uroczystości == null)
            {
                return HttpNotFound();
            }
            return View(szablon_uroczystości);
        }

        // POST: Szablon_uroczystości/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Szablon_uroczystości szablon_uroczystości = db.Szablon_uroczystości.Find(id);
            db.Szablon_uroczystości.Remove(szablon_uroczystości);
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
