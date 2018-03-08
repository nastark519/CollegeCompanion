using collegeCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using collegeCompanionApp.Models;
using collegeCompanionApp.Models.ViewModel;
using System.Diagnostics;

namespace collegeCompanionApp.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SchoolSearch()
        {
            Console.WriteLine("In the SchoolSearch method");
            return View();
        }

        public ActionResult SearchForm()
        {
            FormDataViewModel db = new FormDataViewModel();
            Debug.Assert(db.StateList != null, "Database has the wrong connection.");
            return View(db);
        }

        public ActionResult SearchResults()
        {
            return View();
        }

    }
}