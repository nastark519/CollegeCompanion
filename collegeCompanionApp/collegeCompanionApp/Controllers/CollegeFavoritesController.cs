using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using collegeCompanionApp.Models;

namespace collegeCompanionApp.Controllers
{
    public class CollegeFavoritesController : Controller
    {
        private CompanionContext db = new CompanionContext();

        // GET: CollegeFavorites
        public ActionResult Index()
        {
            var collegeFavorites = db.CollegeFavorites.Include(c => c.College).Include(c => c.Party);
            return View(collegeFavorites.ToList());
        }

        // GET: CollegeFavorites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollegeFavorite collegeFavorite = db.CollegeFavorites.Find(id);
            if (collegeFavorite == null)
            {
                return HttpNotFound();
            }
            return View(collegeFavorite);
        }

        // GET: CollegeFavorites/Create
        public ActionResult Create()
        {
            ViewBag.CollegeID = new SelectList(db.Colleges, "CollegeID", "CityName");
            ViewBag.PartyID = new SelectList(db.Parties, "PartyID", "PartyName");
            return View();
        }

        // POST: CollegeFavorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CollegeFavoriteID,CollegeID,PartyID")] CollegeFavorite collegeFavorite)
        {
            if (ModelState.IsValid)
            {
                db.CollegeFavorites.Add(collegeFavorite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CollegeID = new SelectList(db.Colleges, "CollegeID", "CityName", collegeFavorite.CollegeID);
            ViewBag.PartyID = new SelectList(db.Parties, "PartyID", "PartyName", collegeFavorite.PartyID);
            return View(collegeFavorite);
        }

        // GET: CollegeFavorites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollegeFavorite collegeFavorite = db.CollegeFavorites.Find(id);
            if (collegeFavorite == null)
            {
                return HttpNotFound();
            }
            ViewBag.CollegeID = new SelectList(db.Colleges, "CollegeID", "CityName", collegeFavorite.CollegeID);
            ViewBag.PartyID = new SelectList(db.Parties, "PartyID", "PartyName", collegeFavorite.PartyID);
            return View(collegeFavorite);
        }

        // POST: CollegeFavorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CollegeFavoriteID,CollegeID,PartyID")] CollegeFavorite collegeFavorite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collegeFavorite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CollegeID = new SelectList(db.Colleges, "CollegeID", "CityName", collegeFavorite.CollegeID);
            ViewBag.PartyID = new SelectList(db.Parties, "PartyID", "PartyName", collegeFavorite.PartyID);
            return View(collegeFavorite);
        }

        // GET: CollegeFavorites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CollegeFavorite collegeFavorite = db.CollegeFavorites.Find(id);
            if (collegeFavorite == null)
            {
                return HttpNotFound();
            }
            return View(collegeFavorite);
        }

        // POST: CollegeFavorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CollegeFavorite collegeFavorite = db.CollegeFavorites.Find(id);
            db.CollegeFavorites.Remove(collegeFavorite);
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
