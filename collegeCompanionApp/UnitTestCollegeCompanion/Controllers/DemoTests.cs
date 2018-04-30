using NUnit.Framework;
using collegeCompanionApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemographicTests.Tests
{
    [TestFixture()]
    public class DemoTests
    {
        [Test()]
        public void AddCommaTest()
        {
            // Arrange
            var homeController = new HomeController();
            var lat = "44.2382";
            var lon = "-123.9283";
            // Act
            var result = homeController.GetCoordinates(lat, lon);
            // Assert
            Assert.That(result == "44.2382,-123.9283");
        }

        [Test()]
        public void DemoParamsTest()
        {
            // Arrange
            var homeController = new HomeController();
            var coordinates = "44.2382,-123.9283";
            var variables = "stotpop,smedage";
            // Act
            var result = homeController.SetDemoParams(coordinates, variables);
            // Assert
            Assert.That(result == "44.2382,-123.9283/stotpop,smedage");
        }

        [Test()]
        public void DemoURLTest()
        {
            // Arrange
            var homeController = new HomeController();
            var param = "44.2382,-123.9283/stotpop,smedage";
            var actualResult = "https://mapfruition-demoinquiry.p.mashape.com/inquirebypoint/44.2382,-123.9283/stotpop,smedage";
            // Act
            var result = homeController.SetDemoURL(param);
            // Assert
            Assert.That(result == actualResult);
        }

        [Test()]
        public void SetDemoURLTest()
        {
            // Arrange
            var homeController = new HomeController();
            var lat = "44.2382";
            var lon = "-123.9283";
            var variables = "stotpop,smedage";          
            var expectedResult = "https://mapfruition-demoinquiry.p.mashape.com/inquirebypoint/44.2382,-123.9283/stotpop,smedage";
            // Act
            var coordinates = homeController.GetCoordinates(lat, lon);
            var param = homeController.SetDemoParams(coordinates, variables);
            var url = homeController.SetDemoURL(param);
            // Assert
            Assert.That(url == expectedResult);
        }
    }
}