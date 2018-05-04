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
        public void AddCollegeTest_SuccessfullyAddsCollege()
        {
            //Arrange
            College newCollege = new College
            {
                Name = "Stuff",
                StateName = "OR",
                City = "Place",
                Ownership = "1",
                Accreditor = "Them",
                Cost = 1000
            };
            Mock<IRepository> mockRepo = new Mock<IRepository>(MockBehavior.Strict);

            //Act
            mockRepo.AddCollege(newCollege);
            //Assert


        }
    }
}