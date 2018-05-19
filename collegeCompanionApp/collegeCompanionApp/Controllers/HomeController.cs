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
using Geocoding;
using System.Web.UI.WebControls;

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
        string degree = "";
        string degreeType = "";
        int storedLimit = 0;

        //Adding in the repository pattern connection

        //private CompanionContext db;
        
        // We can do everything that the constructer method was doing here in one line of code.
        ICollegeRepository _repository = new CollegeRepository(new CompanionContext());
        CompanionContext db = new CompanionContext();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Travel()
        {
            //Check that they have a saved list item, else ask them to save a college
            //Check that they are signed in user (to see what that code might look like, look at the code on the
            //bottom of SearchResults.cshtml) show by college name
            //Call the Repo/DB Context
            //Do a LINQ Query for the saved colleges as a list.
            //Save that LINQ Query to a variable that is .ToList()
            //Inside the "return View(); returnt the variable
            //Inside the pages View.html you will add an @model IEnumerable<collegeCompanionApp.Models.SearchResults>
            //Then, where you want to present the list view (in this case, in a selector) you would call:
            //@foreach(var item in Model){ @item....}
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
            return View(db.CompanionUsers.ToList());
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

            //Get Data from Current URL
            schoolName = Request.QueryString["school.name"];
            state = Request.QueryString["school.state"];
            city = Request.QueryString["school.city"];
            accreditor = Request.QueryString["school.accreditor"];
            ownership = Request.QueryString["school.ownership"];
            finLimit = Request.QueryString["school.tuition"];
            acceptRate = Request.QueryString["school.admission_rate"];
            degree = Request.QueryString["school.degree"];
            degreeType = Request.QueryString["school.degreeType"];

            // build a WebRequest
            WebRequest request = WebRequest.Create(CreateURL(schoolName, state, city, accreditor, ownership, finLimit, acceptRate, degree, degreeType));
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
        public ActionResult SaveData()
        {
            int userID = Int32.Parse(Request.QueryString["UserID"]);
            string name = Request.QueryString["Name"];
            string stateName = Request.QueryString["StateName"];
            string city = Request.QueryString["City"];
            int zipCode = Int32.Parse(Request.QueryString["ZipCode"]);
            string accreditor = Request.QueryString["Accreditor"];
            string degree = Request.QueryString["Degree"];
            string degreeType = Request.QueryString["DegreeType"];
            int ownership = Int32.Parse(Request.QueryString["Ownership"]);
            int cost;

            int.TryParse(Request.QueryString["Cost"], out cost);

            SearchResult college = new SearchResult {
                                                        CompanionID = userID,
                                                        Name = name,
                                                        StateName = stateName,
                                                        City = city,
                                                        ZipCode = zipCode,
                                                        Accreditor = accreditor,
                                                        Degree = degree,
                                                        DegreeType = degreeType,
                                                        Ownership = ownership,
                                                        Cost = cost
            };

            if (User.Identity.IsAuthenticated)
            {
                Debug.WriteLine("saveData() Method!");

                if (ModelState.IsValid)
                {
                    _repository.AddCollege(college);

                    _repository.SaveCollege(college);
                    return View(college);
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
        }

        /// <summary>
        /// Creats a URL for the API search based on User Input.
        /// </summary>
        /// <returns>
        /// A URL string.
        /// </returns>
        public string CreateURL(string schoolName, string stateName, string cityName, string accreditor, string ownership, string finLimit, string acceptRate, string degree, string degreeType)
        {
            Debug.WriteLine("createURL() Method!");

            var source = "https://api.data.gov/ed/collegescorecard/v1/schools?"; // Source, Endpoint
            var APIKey = "&api_key=" + System.Web.Configuration.WebConfigurationManager.AppSettings["CollegeScoreCardAPIKey"]; // CollegeScoreCard API Key           
            var fields = SetCollegeFields(); // Set Fields
            var values = SetCollegeValues(ownership, acceptRate, finLimit); // Set Values, Parameters

            // Checks for Empty Values
            // If not empty, add to parameters
            if (schoolName != "")
            {
                values = values + "&school.name=" + schoolName;
            }
            if (stateName != "")
            {
                values = values + "&school.state=" + stateName;
            }
            if (cityName != "")
            {
                values = values + "&school.city=" + cityName;
            }
            if (cityName != "")
            {
                values = values + "&school.city=" + cityName;
            }
            if (accreditor != "")
            {
                values = values + "&school.accreditor=" + accreditor;
            }
            if (degree != "" && degree != "Any")
            {
                string theDegree = SetDegree(degreeType, degree); // Set up Degree value
                values = values + AddDegreeValue(theDegree); // Add Degree to Parameters
                fields = fields + AddDegreeField(theDegree); // Add Degree to Fields
            }

            //Set up GET URL to College Scorecard
            string url = source + values + APIKey + fields;
            //Replace spaces with %20 
            url = url.Trim();
            url = url.Replace(" ", "%20");
            Debug.WriteLine("URL: " + url);

            return url;
        }

        public string SetCollegeFields()
        {
            // Default Fields to get
            return "&_fields=school.name,school.state,school.city,school.accreditor,school.ownership,school.tuition_revenue_per_fte,2015.admissions.admission_rate.overall,school.school_url";
        }

        public string SetCollegeValues(string ownership, string acceptRate, string finLimit)
        {
            string collegeValues = "school.ownership=" + ownership + "&2015.admissions.admission_rate.overall__range=" + acceptRate
                + "&school.tuition_revenue_per_fte__range=" + finLimit + "&_sort=school.tuition_revenue_per_fte:desc"; // Default Parameters
            return collegeValues;
        }

        public string AddDegreeField(string theDegree)
        {
            string field = "," + theDegree; // Add Degree to fields
            return field;
        }

        public string AddDegreeValue(string theDegree)
        {
            string val = "&" + theDegree + "__range=1.."; // Add Degree to parameters
            return val;
        }

        public string SetDegree(string degreeType, string degree)
        {
            string aDegree = "2015.academics.program." + degreeType + "." + degree; // Degree to Search
            return aDegree;
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
            FormdataDB formdb = new FormdataDB();
            Debug.Assert(formdb != null, "Database has the wrong connection.");
            return View(formdb);
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