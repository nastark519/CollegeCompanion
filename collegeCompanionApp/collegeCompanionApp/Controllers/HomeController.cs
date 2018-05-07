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
using System.Data.Linq;
using System.Text;
using collegeCompanionApp.Repository;
using Ninject;

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
        string acceptRate = "";
        int storedLimit = 0;

        //Adding in the repository pattern connection
        private IRepository _repository;

        public HomeController(IRepository repo)
        {
            _repository = repo;
        }

        public HomeController(){}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Travel()
        {
            return View();
        }

        public ActionResult SearchesMenu()
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

        public ActionResult Test()
        {
            return View();
        }

        /// <summary>
        /// Searches for ratings of Walking, Transit & Bike for a given city using Walk Score API.
        /// </summary>
        /// <param name="location">A string from the user provided variable "locationInput" in TravelSearch.js</param>
        /// <returns>
        /// A "Content" result of JSON String with ratings within the requested city.
        /// </returns>
        public ActionResult WalkScoreSearch()
        {
            //Get user input data from Javascript file "TravelSearch.js"
            var street = Request.QueryString["addressInput"];
            var city = Request.QueryString["cityInput"];
            var state = Request.QueryString["stateInput"];
            var zipcode = Request.QueryString["zipInput"];
            var lat = Request.QueryString["latitude"];
            var lon = Request.QueryString["longitude"];
            var location = street + city + state + zipcode;

            location = location.Replace(" ", "%20");

            //User Stringbuilder to make a URL for the request.
            StringBuilder sb = new StringBuilder();
            sb.Append("http://api.walkscore.com/score?format=json&");
            sb.Append("&address=" + location);
            sb.Append("&lon=" + lon);
            sb.Append("&lat=" + lat);
            sb.Append("&transit=1&bike=1");
            sb.Append("&wsapikey=");
            sb.Append(System.Web.Configuration.WebConfigurationManager.AppSettings["WalkScoreAPIKey"]);
            Debug.WriteLine(sb.ToString());

            // Make a web request to get the list of classes.
            WebRequest request = HttpWebRequest.Create(sb.ToString()); //Takes an arguement of the URL of the webserver being targeted.
            // Using a web response process the file returned from the API.
            WebResponse response = request.GetResponse();

            string resultString;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                // Get the data from the stream reader to parse data into usable format
                resultString = reader.ReadToEnd();
            }
            //Note: This is completed without a JSON parse action so don't treat it like the other methods! lol
            return Content(resultString, "application/json");
        }

        public ActionResult SearchForm()
        {
            FormdataDB formdb = new FormdataDB();
            Debug.Assert(formdb != null, "Database has the wrong connection.");
            return View(formdb);
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
            schoolName = Request.QueryString["school.name"];
            state = Request.QueryString["school.state"];
            city = Request.QueryString["school.city"];
            accreditor = Request.QueryString["school.accreditor"];
            ownership = Request.QueryString["school.ownership"];
            finLimit = Request.QueryString["school.tuition_revenue_per_fte"];
            acceptRate = Request.QueryString["2015.admissions.admission_rate.overall__range"];

            // build a WebRequest
            WebRequest request = WebRequest.Create(CreateURL(schoolName, state, city, accreditor, ownership, finLimit, acceptRate));
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
        public ActionResult SaveData([Bind(Include = "CollegeID,Name,StateName,City,Accreditor,Ownership,Cost")]College college)
        {
            if (User.Identity.IsAuthenticated)
            {
                Debug.WriteLine("saveData() Method!");

                if (ModelState.IsValid)
                {
                    _repository.AddCollege(college);

                    _repository.SaveCollege(college);
                    return View();
                }
                else
                {
                    Debug.WriteLine("Error for SaveData() method.");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Register","Account");
            }
            //College db = new College
            //{
            // Name = schoolName,
            //StateName = stateName,
            //City = cityName,
            //Accreditor = accreditor,
            //Focus = Request.QueryString["degreeInput"],
            //Ownership = ownership,
            //Cost = cost,
            //AdmissionRate = acceptRate
            //};
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
        public string CreateURL(string schoolName, string stateName, string cityName, string accreditor, string ownership, string finLimit, string acceptRate)
        {
            Debug.WriteLine("createURL() Method!");

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
            if (finLimit != null && finLimit != "" && finLimit != "..")
            {
                if (finLimit.Length == 12)
                {
                    //storedLimit = Convert.ToInt32(finLimit.Substring(0, 5));
                    values = values + "&school.tuition_revenue_per_fte__range=" + finLimit;
                    //Debug.WriteLine("Stored Limit: " + storedLimit);
                    Debug.WriteLine("Fin Limit: " + finLimit);
                }
                else if (finLimit.Length == 10)
                {
                    //storedLimit = Convert.ToInt32(finLimit.Substring(0, 3));
                    values = values + "&school.tuition_revenue_per_fte__range=" + finLimit;
                    //Debug.WriteLine("Stored Limit: " + storedLimit);
                    Debug.WriteLine("Fin Limit: " + finLimit);
                }
                else
                {
                    //storedLimit = Convert.ToInt32(finLimit);  // get substring of val. and convert to integer. sp4 **************
                    values = values + "&school.tuition_revenue_per_fte=" + finLimit;
                    //Debug.WriteLine("Stored Limit: " + storedLimit);
                    Debug.WriteLine("Fin Limit: " + finLimit);
                }
            }
            //values = values + "&2015.admissions.admission_rate.overall__range=" + acceptRate;
            values = values + "&school.ownership=" + ownership;

            var source = "https://api.data.gov/ed/collegescorecard/v1/schools?"; //Source
            var APIKey = "&api_key=" + System.Web.Configuration.WebConfigurationManager.AppSettings["CollegeScoreCardAPIKey"]; //API Key
            var fields = "&_fields=school.name,school.state,school.city,school.accreditor,school.ownership,school.tuition_revenue_per_fte,2015.admissions.admission_rate.overall";
            //Fields 
            //URL to College Scorecard
            string url = source + values + APIKey + fields;
            //Replace spaces with %20 
            url = url.Trim();
            url = url.Replace(" ", "%20");
            Debug.WriteLine("URL: " + url);

            return url;
        }

        public String CheckFinLimit(String finLimit)

        {

            return finLimit;

        }



        public ActionResult Yelp()
        {

            return View();

        }


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

		
        /// Yelp NUnit Testing
        public string IsAPIKey(string key)
        {
            if (key.Length <= 5)
            {
                key = "NoKey";
            }
            return key;
        }

        public string GetLocation(string location)
        {
            if (location == null)
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


        //working on getting the xml from zillow's api to work.
        //may end up not needing this code.
        //public XmlDocument CollegeRentsInArea()
        //{


        //I have put this at the end so I can just append to the div I want to.
        // a url for the zillow calls.
        //string theZillowApiUrl =
        //"http://www.zillow.com/webservice/GetRegionChildren.htm?zws-id={theAPIKeyHere}&state=" + state + "&city=" + city;

        //string collegeRentsUrl = "CollegeRentsInArea?school.state=" + state + "&school.city=" + city;

        //WebRequest request = WebRequest.Create(theZillowApiUrl);
        //Stream stream = request.GetResponse().GetResponseStream();

        //XmlDocument xmlDoc = new XmlDocument();

        //stream.Close();

        //return xmlDoc;
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



        public ActionResult Demographic()
        {
            return View();
        }

        public JsonResult DemographicSearch()
        {
            Debug.WriteLine("DemographicSearch() Method!");

            //Get Demographic API Key
            string DemoAPIKey = System.Web.Configuration.WebConfigurationManager.AppSettings["DemographicAPIKey"];
            //Gets the latitude & longitude
            string coordinates = GetCoordinates(Request.QueryString["latitude"], Request.QueryString["longitude"]);
            //Set parameters with coordinates & variables
            string param = SetDemoParams(coordinates, Request.QueryString["variables"]);// + "/" + variables);
            //Endpoint Description Link: https://market.mashape.com/mapfruition/demographicinquiry#inquire-by-point
            //Set up url endpoint with parameters
            var url = SetDemoURL(param);

            //URL GET Request
            Debug.WriteLine("JSon URL Call: " + url);

            // build a WebRequest
            WebRequest request = WebRequest.Create(url);
            //Add Header with API Key
            request.Headers.Add("X-Mashape-Key", DemoAPIKey);
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


        //Demographic NUnit Tests
        public string SetDemoURL(string param)
        {
            string url = "https://mapfruition-demoinquiry.p.mashape.com/inquirebypoint/" + param;

            return url;
        }

        public string SetDemoParams(string coordinates, string variables)
        {
            string param = coordinates + "/" + variables;

            return param;
        }

        public string GetCoordinates(string lat, string lon)
        {
            string cord = lat + "," + lon;

            return cord;
        }
    }
}