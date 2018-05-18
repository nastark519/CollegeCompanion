using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using collegeCompanionApp.Models;

namespace collegeCompanionApp.Views
{
    public class SearchResultsController : Controller
    {
        private CompanionContext db = new CompanionContext();

        // GET: SearchResults
        public ActionResult Index()
        {
            var searchResults = db.SearchResults.Include(s => s.CompanionUser);
            return View(searchResults.ToList());
        }

        // GET: SearchResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchResult searchResult = db.SearchResults.Find(id);
            if (searchResult == null)
            {
                return HttpNotFound();
            }
            return View(searchResult);
        }

        // GET: SearchResults/Create
        public ActionResult Create()
        {
            ViewBag.CompanionID = new SelectList(db.CompanionUsers, "CompanionID", "Email");
            return View();
        }

        // POST: SearchResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SearchResultsID,CompanionID,Name,StateName,City,Accreditor,Ownership,Cost,ZipCode,Degree,DegreeType")] SearchResult searchResult)
        {
            if (ModelState.IsValid)
            {
                db.SearchResults.Add(searchResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanionID = new SelectList(db.CompanionUsers, "CompanionID", "Email", searchResult.CompanionID);
            return View(searchResult);
        }

        // GET: SearchResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchResult searchResult = db.SearchResults.Find(id);
            if (searchResult == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanionID = new SelectList(db.CompanionUsers, "CompanionID", "Email", searchResult.CompanionID);
            return View(searchResult);
        }

        // POST: SearchResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SearchResultsID,CompanionID,Name,StateName,City,Accreditor,Ownership,Cost,ZipCode,Degree,DegreeType")] SearchResult searchResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(searchResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanionID = new SelectList(db.CompanionUsers, "CompanionID", "Email", searchResult.CompanionID);
            return View(searchResult);
        }

        // GET: SearchResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SearchResult searchResult = db.SearchResults.Find(id);
            if (searchResult == null)
            {
                return HttpNotFound();
            }
            return View(searchResult);
        }

        // POST: SearchResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SearchResult searchResult = db.SearchResults.Find(id);
            db.SearchResults.Remove(searchResult);
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
