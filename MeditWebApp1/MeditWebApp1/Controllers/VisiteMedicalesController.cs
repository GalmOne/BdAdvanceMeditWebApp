using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeditWebApp1.Models;

namespace MeditWebApp1.Controllers
{
    public class VisiteMedicalesController : Controller
    {
        private MeditEntities db = new MeditEntities();

        // GET: VisiteMedicales
        public ActionResult Index()
        {
            var visiteMedicales = db.VisiteMedicales.Include(v => v.Emploi).Include(v => v.MedecinResponsable).Include(v => v.TypeLieu);
            return View(visiteMedicales.ToList());
        }

        // GET: VisiteMedicales/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisiteMedicale visiteMedicale = db.VisiteMedicales.Find(id);
            if (visiteMedicale == null)
            {
                return HttpNotFound();
            }
            return View(visiteMedicale);
        }

        // GET: VisiteMedicales/Create
        public ActionResult Create()
        {
            ViewBag.codeEmploi = new SelectList(db.Emplois, "codeEmploi", "Profession");
            

            var personnes = db.Personnes.ToList();
            var medecins = personnes.Where(e => e.idPersonne >= 10006);
           
            ViewBag.idPersonne = new SelectList(medecins, "idPersonne", "nom");

            ViewBag.idType = new SelectList(db.TypeLieux, "idType", "description");

            VisiteMedicale visit = new VisiteMedicale();
            DateTime date = DateTime.Now;
            long id = date.Year * 10000000000 + date.Month * 100000000 + date.Day * 1000000 + date.Hour*10000 + date.Minute*100 + date.Second;
            visit.idVisite = id;
            visit.dateVisite = date;

            return View(visit);
            
        }

        // POST: VisiteMedicales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVisite,dateVisite,codeEmploi,idType,idPersonne")] VisiteMedicale visiteMedicale)
        {
            if (ModelState.IsValid)
            {
                db.VisiteMedicales.Add(visiteMedicale);
                db.SaveChanges();
                return RedirectToAction("Create", "ExamenPratiques");
            }

            ViewBag.codeEmploi = new SelectList(db.Emplois, "codeEmploi", "Profession", visiteMedicale.codeEmploi);
            ViewBag.idPersonne = new SelectList(db.MedecinResponsables, "idPersonne", "idPersonne", visiteMedicale.idPersonne);
            ViewBag.idType = new SelectList(db.TypeLieux, "idType", "description", visiteMedicale.idType);
            return View(visiteMedicale);
        }

        // GET: VisiteMedicales/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisiteMedicale visiteMedicale = db.VisiteMedicales.Find(id);
            if (visiteMedicale == null)
            {
                return HttpNotFound();
            }
            ViewBag.codeEmploi = new SelectList(db.Emplois, "codeEmploi", "Profession", visiteMedicale.codeEmploi);
            ViewBag.idPersonne = new SelectList(db.MedecinResponsables, "idPersonne", "idPersonne", visiteMedicale.idPersonne);
            ViewBag.idType = new SelectList(db.TypeLieux, "idType", "description", visiteMedicale.idType);
            return View(visiteMedicale);
        }

        // POST: VisiteMedicales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVisite,dateVisite,codeEmploi,idType,idPersonne")] VisiteMedicale visiteMedicale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visiteMedicale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codeEmploi = new SelectList(db.Emplois, "codeEmploi", "Profession", visiteMedicale.codeEmploi);
            ViewBag.idPersonne = new SelectList(db.MedecinResponsables, "idPersonne", "idPersonne", visiteMedicale.idPersonne);
            ViewBag.idType = new SelectList(db.TypeLieux, "idType", "description", visiteMedicale.idType);
            return View(visiteMedicale);
        }

        // GET: VisiteMedicales/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisiteMedicale visiteMedicale = db.VisiteMedicales.Find(id);
            if (visiteMedicale == null)
            {
                return HttpNotFound();
            }
            return View(visiteMedicale);
        }

        // POST: VisiteMedicales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            VisiteMedicale visiteMedicale = db.VisiteMedicales.Find(id);
            db.VisiteMedicales.Remove(visiteMedicale);
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
