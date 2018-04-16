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
        public void KeyTest()
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
        public void LocationTest()
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
        public void TermTest()
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
        public void ParamTest()
        {
            // Arrange
            var homeController = new HomeController();
            var location = "97361";
            var term = "Store";
            // Act
            var param = homeController.SetParam(location,term);
            // Assert
            Assert.NotNull(param);
        }

        [Test()]
        public void URLTest()
        {
            // Arrange
            var homeController = new HomeController();
            var param = "97361";
            // Act
            var url = homeController.SetURL(param);
            // Assert
            Assert.NotNull(url);
        }
    }
}