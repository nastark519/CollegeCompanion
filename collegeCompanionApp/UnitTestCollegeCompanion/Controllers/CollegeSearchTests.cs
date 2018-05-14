using NUnit.Framework;
using collegeCompanionApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CollegeSearchTests.Tests
{
    [TestFixture()]
    public class CollegeSearchTests
    {
        [Test()]
        public void CollegeURLTest()
        {
            // Arrange
            var homeController = new HomeController();
            var school = "";
            var state = "Oregon OR";
            var city = "";
            var accreditor = "";
            var owernership = "1";
            var finance = "0..";
            var acceptRate = "0.5..";
            var degree = "education";
            var degreeType = "bachelors";
            var acualResult = "https://api.data.gov/ed/collegescorecard/v1/schools?school.ownership=1&2015.admissions.admission_rate.overall__range=0.5..&school.tuition_revenue_per_fte__range=0..&_sort=school.tuition_revenue_per_fte:desc&school.state=Oregon%20OR&2015.academics.program.bachelors.education__range=1..&api_key=&_fields=school.name,school.state,school.city,school.accreditor,school.ownership,school.tuition_revenue_per_fte,2015.admissions.admission_rate.overall,school.school_url,2015.academics.program.bachelors.education";

            // Act
            var result = homeController.CreateURL(school, state, city, accreditor, owernership, finance, acceptRate, degree, degreeType);
            // Assert
            Assert.That(result == acualResult);
        }

        [Test()]
        public void CollegeValuesTest()
        {
            // Arrange
            var homeController = new HomeController();
            var owernership = "1";
            var finance = "1000..10000";
            var acceptRate = "0.5..";
            var acualResult = "school.ownership=1&2015.admissions.admission_rate.overall__range=0.5..&school.tuition_revenue_per_fte__range=1000..10000&_sort=school.tuition_revenue_per_fte:desc";
            // Act
            var result = homeController.SetCollegeValues(owernership, acceptRate, finance);
            // Assert
            Assert.That(result == acualResult);
        }

        [Test()]
        public void CollegeSetDegreeTest()
        {
            // Arrange
            var homeController = new HomeController();
            var degree = "health";
            var degreeType = "bachelors";
            var acualResult = "2015.academics.program.bachelors.health";
            // Act
            var result = homeController.SetDegree(degreeType,degree);
            // Assert
            Assert.That(result == acualResult);
        }

        [Test()]
        public void CollegeDegreeValueTest()
        {
            // Arrange
            var homeController = new HomeController();
            var theDegree = "2015.academics.program.bachelors.health";
            var acualResult = "&2015.academics.program.bachelors.health__range=1..";
            // Act
            var result = homeController.AddDegreeValue(theDegree);
            // Assert
            Assert.That(result == acualResult);
        }

        [Test()]
        public void CollegeDegreeFieldTest()
        {
            // Arrange
            var homeController = new HomeController();
            var theDegree = "2015.academics.program.bachelors.health";
            var acualResult = ",2015.academics.program.bachelors.health";
            // Act
            var result = homeController.AddDegreeField(theDegree);
            // Assert
            Assert.That(result == acualResult);
        }
    }

}

