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
        
        public ActionResult Yelp()
        {
            return View();
        }

        public JsonResult Search()
        {
            Debug.WriteLine("SearchForm() Method!");

            //Get College Scorecard API Key
            //string CSC_APIKey = System.Web.Configuration.WebConfigurationManager.AppSettings["CollegeScoreCardAPIKey"];
            string schoolName = Request.QueryString["school.name"];
            string state = Request.QueryString["school.state"];
            string city = Request.QueryString["school.city"];
            string accreditor = Request.QueryString["school.accreditor"];
            string ownership = Request.QueryString["school.ownership"];

            var college = new College();
            college.CollegeName = schoolName;
            college.StateName = state;
            college.CityName = city;
            college.Accreditor = accreditor;
            //college.Ownership = ownership;

            var values = "school.state=" + state;
            if(schoolName != "")
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
            //var values = "school.name=" + schoolName + "&school.state=" + state + "&school.city=" + city +
            //    "&school.accreditor=" + accreditor + "&school.ownership=" + ownership;
            var APIKey = "&api_key=nKOePpukW43MVyeCch1t7xAFZxR2g0EFS3sHNkQ4"; //API Key
            var fields = "&_fields=school.name,school.state,school.city,school.accreditor,school.ownership,school.tuition_revenue_per_fte"; //Fields 

            //URL to College Scorecard
            string url = source + values + APIKey + fields;
            //Replace spaces with %20 
            url = url.Trim();
            url = url.Replace(" ", "%20");

            // build a WebRequest
            WebRequest request = WebRequest.Create(url);
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

            //Save data in DB
            //if (ModelState.IsValid)
            //{
            //    var college = new College();
            //    college.CollegeName = data.results[0]["school.name"];
            //    college.StateName = Request.QueryString["state.name"];
            //}


            //return CollegeSearch(college);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult CollegeSearch()
        //{
        //    var college = new College();
        //    college.CollegeName = Request.QueryString["school.name"];
        //    college.StateName = Request.QueryString["state.name"];

        //    return View(college);
        //}




        //public JsonResult YelpSearch()
        //{
        //    Debug.WriteLine("YelpSearch() Method!");

        //    //Get Yelp API Key
        //    string YelpAPIKey = System.Web.Configuration.WebConfigurationManager.AppSettings["YelpAPIKey"]; 
        //    //Get Location
        //    string location = Request.QueryString["location"];
        //    //Get Term
        //    string term = Request.QueryString["term"];
        //    //Parameters
        //    string param = "term=" + term + "&location=" + location + "&limit=10&sort_by=distance";
        //    //URL Endpoint
        //    var url = "https://api.yelp.com/v3/businesses/search?" + param; 

        //    //URL GET Request
        //    Debug.WriteLine("URL: " + url);

        //    // build a WebRequest
        //    WebRequest request = WebRequest.Create(url);
        //    request.Headers.Add("Authorization", "Bearer " + YelpAPIKey);
        //    WebResponse response = request.GetResponse();
        //    Stream dataStream = response.GetResponseStream();
        //    StreamReader reader = new StreamReader(response.GetResponseStream());

        //    // Read the content.  
        //    string responseFromServer = reader.ReadToEnd();

        //    // Clean up the streams and the response.  
        //    reader.Close();
        //    response.Close();

        //    // Create a JObject, using Newtonsoft NuGet package
        //    JObject json = JObject.Parse(responseFromServer);

        //    // Create a serializer to deserialize the string response (string in JSON format)
        //    JavaScriptSerializer serializer = new JavaScriptSerializer();

        //    // Store JSON results in results to be passed back to client (javascript)
        //    var data = serializer.DeserializeObject(responseFromServer);

        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}


        public JsonResult YelpSearch()
        {
            Debug.WriteLine("YelpSearch() Method!");

            //Get Yelp API Key
            string YelpAPIKey = System.Web.Configuration.WebConfigurationManager.AppSettings["YelpAPIKey"];
            YelpAPIKey = IsAPIKey(YelpAPIKey);
            //Get Location
            string location = GetLocation(Request.QueryString["location"]);
            //Get Term
            string term = GetTerm(Request.QueryString["term"]);
            //Set Parameters
            string param = SetParam(location, term);
            //URL Endpoint
            var url = SetURL(param);

            //URL GET Request
            Debug.WriteLine("URL: " + url);

            // build a WebRequest
            WebRequest request = WebRequest.Create(url);
            request.Headers.Add("Authorization", "Bearer " + YelpAPIKey);
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

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public string IsAPIKey(string key)
        {
            if(key.Length <= 5)
            {
                key = "NoKey";
            }
            return key;
        }

        public string GetLocation(string location)
        {
            if(location == null)
            {
                Debug.WriteLine("No Location");
            }
            return location;
        }

        public string GetTerm(string term)
        {
            if (term == null)
            {
                term = "";
            }
            return term;
        }

        public string SetParam(string location, string term)
        {
            return "term=" + term + "&location=" + location + "&limit=10&sort_by=distance";
        }

        public string SetURL(string param)
        {
            return "https://api.yelp.com/v3/businesses/search?" + param;
        }
    }
}