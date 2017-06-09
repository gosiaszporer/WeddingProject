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
    public class UmowasController : Controller
    {
        private MASEntities db = new MASEntities();

        private static int globalCount;

        public static int GlobalCount
        {
            get
            {
                return globalCount;
            }

            set
            {
                globalCount = value;
            }
        }

        // GET: Umowas
        public ActionResult Index()
        {
            return View(db.Umowas.ToList());
        }

        // GET: Umowas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Umowa umowa = db.Umowas.Find(id);
            umowa.Cena_calkowita = (umowa.Wesele.Szablon_uroczystości.Cena)*umowa.Wesele.Ilosc_gosci * (1+ ((decimal)umowa.Wesele.Konsultant.Prowizja / 100));
            db.SaveChanges();
            if (umowa == null)
            {
                return HttpNotFound();
            }
            return View(umowa);
        }

        // GET: Umowas/Create
        public ActionResult Create()
        {
            ViewBag.Status_Status_ID = new SelectList(db.Status, "Status_ID", "Nazwa");
            ViewBag.Wesele_Wesele_ID = new SelectList(db.Weseles, "Wesele_ID", "Nazwa");
            ViewBag.Klient_Osoba_Osoba_ID = new SelectList(db.Klients, "Osoba_ID", "Nazwisko");

            return View();
        }

        // POST: Umowas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Umowa_ID1,Data_podpisania,Cena_calkowita,Status_Status_ID,Wesele_Wesele_ID,Klient_Osoba_Osoba_ID")] Umowa umowa)
        {
            Random ran = new Random();
            umowa.Umowa_ID1 = ++globalCount + ran.Next(100, 500);

            if (ModelState.IsValid)
            {
                db.Umowas.Add(umowa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(umowa);
        }

        // GET: Umowas/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Status_Status_ID = new SelectList(db.Status, "Status_ID", "Nazwa");
            ViewBag.Wesele_Wesele_ID = new SelectList(db.Weseles, "Wesele_ID", "Nazwa");
            ViewBag.Klient_Osoba_Osoba_ID = new SelectList(db.Klients, "Osoba_ID", "Nazwisko");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Umowa umowa = db.Umowas.Find(id);
            if (umowa == null)
            {
                return HttpNotFound();
            }
            return View(umowa);
        }

        // POST: Umowas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Umowa_ID1,Data_podpisania,Cena_calkowita,Status_Status_ID,Wesele_Wesele_ID,Klient_Osoba_Osoba_ID")] Umowa umowa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(umowa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Status_Status_ID = new SelectList(db.Status, "Status_ID", "Nazwa");
            ViewBag.Wesele_Wesele_ID = new SelectList(db.Weseles, "Wesele_ID", "Nazwa");
            ViewBag.Klient_Osoba_Osoba_ID = new SelectList(db.Klients, "Osoba_ID", "Nazwisko");
            return View(umowa);
        }

        // GET: Umowas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Umowa umowa = db.Umowas.Find(id);
            if (umowa == null)
            {
                return HttpNotFound();
            }
            return View(umowa);
        }

        // POST: Umowas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Umowa umowa = db.Umowas.Find(id);
            db.Umowas.Remove(umowa);
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
