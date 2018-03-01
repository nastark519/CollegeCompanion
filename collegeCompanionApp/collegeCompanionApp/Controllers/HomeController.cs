using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

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

        public ActionResult StateSearch()
        {
            return View();
        }

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

        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
    }
}