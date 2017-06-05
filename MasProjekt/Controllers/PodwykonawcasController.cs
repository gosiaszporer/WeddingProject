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
    public class PodwykonawcasController : Controller
    {
        private MASEntities db = new MASEntities();

        // GET: Podwykonawcas
        public ActionResult Index()
        {
            return View(db.Podwykonawcas.ToList());
        }

        // GET: Podwykonawcas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podwykonawca podwykonawca = db.Podwykonawcas.Find(id);
            if (podwykonawca == null)
            {
                return HttpNotFound();
            }
            return View(podwykonawca);
        }

        // GET: Podwykonawcas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Podwykonawcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nazwa,Adres,Nr_telefonu,Podwykonawca_ID")] Podwykonawca podwykonawca)
        {
            if (ModelState.IsValid)
            {
                db.Podwykonawcas.Add(podwykonawca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(podwykonawca);
        }

        // GET: Podwykonawcas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podwykonawca podwykonawca = db.Podwykonawcas.Find(id);
            if (podwykonawca == null)
            {
                return HttpNotFound();
            }
            return View(podwykonawca);
        }

        // POST: Podwykonawcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nazwa,Adres,Nr_telefonu,Podwykonawca_ID")] Podwykonawca podwykonawca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(podwykonawca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(podwykonawca);
        }

        // GET: Podwykonawcas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Podwykonawca podwykonawca = db.Podwykonawcas.Find(id);
            if (podwykonawca == null)
            {
                return HttpNotFound();
            }
            return View(podwykonawca);
        }

        // POST: Podwykonawcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Podwykonawca podwykonawca = db.Podwykonawcas.Find(id);
            db.Podwykonawcas.Remove(podwykonawca);
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
