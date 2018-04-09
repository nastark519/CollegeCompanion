using collegeCompanionApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using collegeCompanionApp.Models.ViewModel;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Data.Linq;

namespace collegeCompanionApp.Controllers
{
    public class HomeController : Controller
    {
        //Global Parameters
        string schoolName = "";
        string state = "";
        string city = "";
        string accreditor = "";
        string ownership = "";
        string finLimit = "";

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
            return View();
        }

        public ActionResult StateSearch()
        {
            return View();
        }

        public ActionResult SearchForm()
        {
            FormdataDB db = new FormdataDB();
            Debug.Assert(db != null, "Database has the wrong connection.");
            return View(db);
        }

        public ActionResult SearchResults()
        {
            return View();
        }

        /// <summary>
        /// Searches for Colleges via an API call.
        /// </summary>
        /// <returns>
        /// A JSON result of colleges within the requested confines.
        /// </returns>
        public JsonResult Search()
        {
            Debug.WriteLine("SearchForm() Method!");

            //Get College Scorecard API
            //string key = System.Web.Configuration.WebConfigurationManager.AppSettings["CollegeScoreCardAPIKey"];
            schoolName = Request.QueryString["school.name"];
            state = Request.QueryString["school.state"];
            city = Request.QueryString["school.city"];
            accreditor = Request.QueryString["school.accreditor"];
            ownership = Request.QueryString["school.ownership"];
            finLimit = Request.QueryString["school.tuition_revenue_per_fte"];

            // build a WebRequest
            WebRequest request = WebRequest.Create(createURL(schoolName, state, city, accreditor, ownership, finLimit));
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            // Read the content.  
            string responseFromServer = reader.ReadToEnd();

            // Clean up the streams and the response.  
            reader.Close();
            response.Close();

            // Create a JObject, using Newtonsoft NuGet package
            JObject json = JObject.Parse(responseFromServer);

            // Create a serializer to deserialize the string response (string in JSON format)
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            // Store JSON results in results to be passed back to client (javascript)
            var data = serializer.DeserializeObject(responseFromServer);

            //saveData(schoolName, state, city, accreditor, ownership, finLimit);

            //return CollegeSearch(college);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Saves selected data into the College Database
        /// </summary>
        /// <returns>
        /// True if data is successfully saved, False if it is not.
        /// </returns>
        /// <param name="schoolName">A string from the dataset of API results.</param>
        /// <param name="stateName">A string from the dataset of API results.</param>
        /// <param name="cityName">A string from the dataset of API results.</param>
        /// <param name="accreditor">A string from the dataset of API results.</param>
        /// <param name="ownership">An integer from the dataset of API results.</param>
        /// <param name="finLimit">An integer from the dataset of API results.</param>
        public Boolean saveData(string schoolName, string stateName, string cityName, string accreditor, int ownership, int finLimit)
        {
            Debug.WriteLine("saveData() Method!");
            if (ModelState.IsValid)
            {
                College db = new College();
                db.CollegeName = schoolName;
                db.StateName = stateName;
                db.CityName = cityName;
                db.Accreditor = accreditor;
                db.Focus = Request.QueryString["degreeInput"];
                db.Ownership = ownership;
                //db.Cost = finLimit;
                //db.CollegeFavorites = false;

                db.SaveChanges();
                return true;
            }
            else
            {
                //Retun an Error Result Here
                return false;
            }
        }

        /// <summary>
        /// Creats a URL for the API search based on User Input.
        /// </summary>
        /// <returns>
        /// A URL string.
        /// </returns>
        /// <param name="schoolName">A string from the user input on the SearchForm.</param>
        /// <param name="stateName">A string from the user input on the SearchForm.</param>
        /// <param name="cityName">A string from the user input on the SearchForm.</param>
        /// <param name="accreditor">A string from the user input on the SearchForm.</param>
        /// <param name="ownership">An string from the user input on the SearchForm.</param>
        /// <param name="finLimit">An string from the user input on the SearchForm.</param>
        public string createURL(string schoolName, string stateName, string cityName, string accreditor, string ownership, string finLimit)
        {
            Debug.WriteLine("createURL() Method!");
            var college = new College();
            college.CollegeName = schoolName;
            college.StateName = state;
            college.CityName = city;
            college.Accreditor = accreditor;
            //college.Ownership = ownership;

            var values = "school.state=" + state;
            if (schoolName != "")
            {
                values = values + "&school.name=" + schoolName;
            }
            if (city != "")
            {
                values = values + "&school.city=" + city;
            }
            if (accreditor != "")
            {
                values = values + "&school.accreditor=" + accreditor;
            }
            values = values + "&school.ownership=" + ownership;

            var source = "https://api.data.gov/ed/collegescorecard/v1/schools?"; //Source
            var APIKey = "&api_key=nKOePpukW43MVyeCch1t7xAFZxR2g0EFS3sHNkQ4"; //API Key
            var fields = "&_fields=school.name,school.state,school.city,school.accreditor,school.ownership,school.tuition_revenue_per_fte"; //Fields 
            //URL to College Scorecard
            string url = source + values + APIKey + fields;
            //Replace spaces with %20 
            url = url.Trim();
            url = url.Replace(" ", "%20");

            return url;
        }
    }
}