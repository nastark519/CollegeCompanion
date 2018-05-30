using NUnit.Framework;
using collegeCompanionApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Ninject.Modules;

namespace CollegeSearchTests.Tests
{

    [TestFixture()]
    public class CollegeSearchTests
    {

        [Test()]
        public void SetCollegeValuesTest_NotNull()
        {
            //Arrange
            var hc = new HomeController();
            string ownership = "Public";
            string acceptRate = "1";
            string finLimit = "10000";
           
            //Act
            string result = hc.SetCollegeValues(ownership, acceptRate, finLimit);

            //Assert
            Assert.NotNull(result);
        }

        [Test()]
        public void SetCollegeValuesTest_ResultsAsExpected()
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
        public void CollegeSetDegreeTest_ResultsAsExpected()
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
        public void CollegeSetDegreeTest_NotNull()
        {
            // Arrange
            var homeController = new HomeController();
            var degree = "health";
            var degreeType = "bachelors";
            // Act
            var result = homeController.SetDegree(degreeType, degree);
            // Assert
            Assert.NotNull(result);
        }

        [Test()]
        public void CollegeDegreeValueTest_ResultsAsExpected()
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
        public void CollegeDegreeValueTest_NotNull()
        {
            // Arrange
            var homeController = new HomeController();
            var theDegree = "2015.academics.program.bachelors.health";
            // Act
            var result = homeController.AddDegreeValue(theDegree);
            // Assert
            Assert.NotNull(result);
        }

        [Test()]
        public void CollegeDegreeFieldTest_ResultsAsExpected()
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

        [Test()]
        public void CollegeDegreeFieldTest_NotNull()
        {
            // Arrange
            var homeController = new HomeController();
            var theDegree = "2015.academics.program.bachelors.health";
            // Act
            var result = homeController.AddDegreeField(theDegree);
            // Assert
            Assert.NotNull(result);
        }
    }

}

