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
using System.Xml;

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

        
        
        public JsonResult Search()
        {
            Debug.WriteLine("SearchForm() Method!");

            //Get College Scorecard API
            //string key = System.Web.Configuration.WebConfigurationManager.AppSettings["CollegeScoreCardAPIKey"];
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

        //working on getting the xml from zillow's api to work.
        //may end up not needing this code.
        //public ActionResult CollegeRentsInArea()
        //{
        //    XmlDocument xmlDoc = new XmlDocument();

        //}
        
        //public ActionResult CollegeSearch()
        //{
        //    var college = new College();
        //    college.CollegeName = Request.QueryString["school.name"];
        //    college.StateName = Request.QueryString["state.name"];

        //    return View(college);
        //}

        //[Route("Home/Search")]
        //public JsonResult Search()
        //{
        //    Console.WriteLine("In the Search method in Home Controller");

        //    //Get College Scorecard API
        //    string key = System.Web.Configuration.WebConfigurationManager.AppSettings["CollegeScoreCardAPIKey"];
        //    //School Name
        //    string schoolName = Request.QueryString["schoolName"];
        //    HttpUtility.UrlPathEncode(schoolName);//Adds %20 to spaces


        //    //URL to College Scorecard
        //    string url = "https://api.data.gov/ed/collegescorecard/v1/schools?api_key=" + 
        //        key + "&school.name=" + schoolName + "&_fields=school.name,id";


        //    //Sends request to College Scorecard to get JSon
        //    WebRequest request = WebRequest.Create(url);
        //    request.Credentials = CredentialCache.DefaultCredentials;
        //    WebResponse response = request.GetResponse(); //The Response            
        //    Stream dataStream = response.GetResponseStream(); //Start Data Stream from Server.            
        //    string reader = new StreamReader(dataStream).ReadToEnd(); //Data Stream to a reader string


        //    //JSon string to a JSon object             
        //    var serializer = new JavaScriptSerializer();
        //    var data = serializer.DeserializeObject(reader); //Deserialize string into JSon Object


        //    //Clean/Close Up
        //    response.Close();
        //    dataStream.Close();
        //}

    }
}