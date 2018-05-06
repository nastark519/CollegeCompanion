using NUnit.Framework;
using collegeCompanionApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using collegeCompanionApp.Controllers;
using collegeCompanionApp.Models;

namespace collegeCompanionApp.Repository.Tests
{
    [TestFixture()]
    public class RepositoryTests
    {
        [Test()]
        public string GetCity_SuccessfullyReturnsCity(College college, string expectedResult)
        {
            //Arrange
            Mock<IRepository> mockRepo = new Mock<IRepository>(MockBehavior.Strict);
            IRepository repo = mockRepo.Object;

            //Act
            mockRepo.Setup(m => m.GetCity(college)).Returns(expectedResult);

            //Assert
            Assert.AreEqual(expectedResult, college.City); // Verify it is the right city

            return college.City;
        }
    }
}