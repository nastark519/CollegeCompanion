﻿using collegeCompanionApp.Models;
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
using Microsoft.AspNet.Identity;
using System.Web.Http;
using System.Web.Http.Description;
using System.Windows.Forms;


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

        public ActionResult DegreeQuiz()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Travel()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(db.SearchResults.ToList());
            }
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


        // DELETE: api/SearchResults/5
        [ResponseType(typeof(SearchResult))]
        public ActionResult Delete(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                SearchResult searchResult = db.SearchResults.Find(id);
                if (searchResult == null)
                {
                    Debug.WriteLine("Error for Delete() method.");
                    return RedirectToAction("SaveDataList", "Home");
                }

                db.SearchResults.Remove(searchResult);
                db.SaveChanges();

                return RedirectToAction("SaveDataList", "Home");
            } else
            {
                return RedirectToAction("Register", "Account");
            }
        }

    public ActionResult SaveDataList()
        {
            if (User.Identity.IsAuthenticated)
            {
                Debug.WriteLine("SaveDataList() Method!");

                if (ModelState.IsValid)
                { 
                    return View(db.SearchResults.Where(c => c.CompanionUser.Email == User.Identity.Name).ToList());
                }
                else
                {
                    Debug.WriteLine("Error for SaveDataList() method.");
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }

        }
		
		
		//****************************************************WalkScore*******************************************************//
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


        //****************************************************College Search*******************************************************//

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

            var collegeList = db.SearchResults.Where(n => n.Name == name).ToList();

            if (collegeList.Count == 0) { 
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

                        System.Windows.Forms.MessageBox.Show("You Have Successfully Saved This College");
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
            else
            {
                System.Windows.Forms.MessageBox.Show("You Have Already Saved This College");
                return RedirectToAction("SaveDataList", "Home");
                
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
            return "&_fields=school.name,school.state,school.city,school.accreditor,school.ownership,school.tuition_revenue_per_fte,2015.admissions.admission_rate.overall,school.school_url,school.zip";
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


        //****************************************************Yelp*******************************************************//

        public ActionResult Yelp()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(db.SearchResults.ToList());
            }
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
            //Get IsOpen
            string isOpen = Request.QueryString["isOpen"];
            //Set Parameters
            string param = SetParam(location, term, isOpen);
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

        public string SetParam(string location, string term, string isOpen)
        {
            var param = "term=" + term + "&location=" + location + "&limit=12&sort_by=distance&open_now=";

            if(isOpen == "Open")
            {
                param = param + "true";
            }
            else
            {
                param = param + "false";
            }

            return param;
        }

        public string SetURL(string param)
        {
            return "https://api.yelp.com/v3/businesses/search?" + param;
        }

        

        //****************************************************Demographic*******************************************************//

        public ActionResult Demographic()
        {
            var userId = User.Identity.GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                FormdataDB formdb = new FormdataDB();
                LifeStyle lifeStyle = new LifeStyle();
                lifeStyle.SearchResults = db.SearchResults;
                lifeStyle.DemoAges = formdb.DemoAges;
                lifeStyle.DemoRaces = formdb.DemoRaces;
                //if (lifeStyle.SearchResults == null)
                //{
                //    Debug.WriteLine("LifeSyle is NULL!");
                //    return RedirectToAction("SearchesMenu");
                //}
                //FormdataDB formdb = new FormdataDB();
                //Debug.Assert(formdb != null, "Database has the wrong connection.");
                //return View(formdb);
                return View(lifeStyle);
            }
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