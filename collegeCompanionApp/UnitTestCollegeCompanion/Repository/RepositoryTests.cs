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
        IList<College> colleges = new List<College>
                {
                    new College { CollegeID = 1, Name = "Hero Academy", City = "Kakariko",
                        StateName = "Hyrule", Accreditor = "Zelda", Ownership = "2", Cost = 2000},
                    new College { CollegeID = 2, Name = "Resident Evil Education Services", City = "Racoon",
                        StateName = "New York", Accreditor = "Umbrella Corperation", Ownership = "3", Cost = 9000},
                    new College { CollegeID = 3, Name = "Westworld University", City = "Middeltown",
                        StateName = "Kentucky", Accreditor = "Bad Ideas Inc.", Ownership = "1", Cost = 4000}
                };

        [Test()]
        public void GetCity_SuccessfullyReturnsCity()
        {
            //Arrange
            Mock<IRepository> mockRepo = new Mock<IRepository>(MockBehavior.Strict);
            IRepository repo = mockRepo.Object;
            string expectedResult = "Kakariko";
            var college = colleges.Where(c => c.CollegeID == 1).SingleOrDefault();

            //Act
            mockRepo.Setup(m => m.GetCity(college)).Returns(expectedResult);

            //Assert
            Assert.AreEqual(expectedResult, college.City); // Verify it is the right city
        }
    }
}