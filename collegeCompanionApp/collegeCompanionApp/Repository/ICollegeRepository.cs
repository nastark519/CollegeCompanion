using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;

namespace collegeCompanionApp.Repository
{
    public interface ICollegeRepository : IRepository<College>
    {
        string GetCity(College college);

        string GetState(College college);

        College GetCollege(string collegeName);

        IEnumerable<College> GetSavedColleges(string logIn);
    }
}