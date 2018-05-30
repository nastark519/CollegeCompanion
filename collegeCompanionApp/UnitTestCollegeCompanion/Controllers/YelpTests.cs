using NUnit.Framework;
using collegeCompanionApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYelp.Tests
{
    [TestFixture()]
    public class YelpTests
    {
        [Test()]
        public void KeyTest_ReturnsNoKey()
        {
            // Arrange
            var homeController = new HomeController();
            var key = "HI19";
            // Act
            var result = homeController.IsAPIKey(key);
            // Assert
            Assert.IsTrue(result == "NoKey");
        }

        [Test()]
        public void KeyTest_NotNull()
        {
            // Arrange
            var homeController = new HomeController();
            var key = "HI19";
            // Act
            var result = homeController.IsAPIKey(key);
            // Assert
            Assert.NotNull(result);
        }

        [Test()]
        public void KeyTest_ResultsAsExpected()
        {
            // Arrange
            var homeController = new HomeController();
            var key = "BB8R2D2";
            // Act
            var result = homeController.IsAPIKey(key);
            // Assert
            Assert.IsTrue(result == "BB8R2D2");
        }

        [Test()]
        public void LocationTest_ResultsAsExpected()
        {
            // Arrange
            var homeController = new HomeController();
            var location = "97361";
            // Act
            var result = homeController.GetLocation(location);
            // Assert
            Assert.IsTrue(result == "97361");
        }

        [Test()]
        public void LocationTest_NotNull()
        {
            // Arrange
            var homeController = new HomeController();
            var location = "97361";
            // Act
            var result = homeController.GetLocation(location);
            // Assert
            Assert.NotNull(result);
        }

        [Test()]
        public void TermTest_NotNull()
        {
            // Arrange
            var homeController = new HomeController();
            var term = "Store";
            // Act
            var result = homeController.GetTerm(term);
            // Assert
            Assert.NotNull(result);
        }

        [Test()]
        public void TermTest_IsNull()
        {
            // Arrange
            var homeController = new HomeController();
            string term = null;
            var actualResult = "";
            // Act
            var result = homeController.GetTerm(term);
            // Assert
            Assert.IsTrue(result == actualResult);
        }

        [Test()]
        public void ParamTest_NotNull()
        {
            // Arrange
            var homeController = new HomeController();
            var location = "97361";
            var term = "Store";
            var isOpen = "Open";
            // Act
            var param = homeController.SetParam(location, term, isOpen);
            // Assert
            Assert.NotNull(param);
        }

        [Test()]
        public void ParamTest_ResultsAsExpected()
        {
            // Arrange
            var homeController = new HomeController();
            var location = "97361";
            var term = "Store";
            var isOpen = "Open";
            var actualResult = "term=Store&location=97361&limit=12&sort_by=distance&open_now=true";
            // Act
            var param = homeController.SetParam(location, term, isOpen);
            // Assert
            Assert.IsTrue(param == actualResult);
        }

        [Test()]
        public void URLTest_NotNull()
        {
            // Arrange
            var homeController = new HomeController();
            var param = "97361";
            // Act
            var url = homeController.SetURL(param);
            // Assert
            Assert.NotNull(url);
        }

        [Test()]
        public void URLTest_ResultsAsExpected()
        {
            // Arrange
            var homeController = new HomeController();
            var param = "97361";
            var actualResult = "https://api.yelp.com/v3/businesses/search?97361";
            // Act
            var url = homeController.SetURL(param);
            // Assert
            Assert.IsTrue(url == actualResult);
        }
    }
}