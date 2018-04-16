using NUnit.Framework;
using collegeCompanionApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace collegeCompanionApp.Controllers.Tests
{
    [TestFixture()]
    public class HomeControllerTests
    {
        [Test()]
        public void CreateURLTest_FinLimit12()
        {
            HomeController c = new HomeController();
            string schoolName = "school";
            string stateName = "state";
            string cityName = "city";
            string accreditor = "accreditor";
            string ownership = "2";
            string finLimit = "10000..20000";
            string acceptRate = "0.1..1";

            string expectedResult = "https://api.data.gov/ed/collegescorecard/v1/schools?school.state=state&school.name=school&school.city=city&school.accreditor=accreditor&school.tuition_revenue_per_fte_range=10000..20000&2015.admissions.admission_rate.overall__range=0.1..1&school.ownership=2&api_key=nKOePpukW43MVyeCch1t7xAFZxR2g0EFS3sHNkQ4&_fields=school.name,school.state,school.city,school.accreditor,school.ownership,school.tuition_revenue_per_fte,2015.admissions.admission_rate.overall";
            string actualResult = c.CreateURL(schoolName, stateName, cityName, accreditor, ownership, finLimit, acceptRate);
            Debug.WriteLine(expectedResult);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}