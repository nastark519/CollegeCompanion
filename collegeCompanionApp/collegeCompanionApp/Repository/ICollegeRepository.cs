using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;

namespace collegeCompanionApp.Repository
{
    public interface ICollegeRepository : IRepository<SearchResult>
    {
        string GetCity(SearchResult college);

        string GetState(SearchResult college);

        SearchResult GetCollege(string collegeName);

        IEnumerable<SearchResult> GetSavedColleges(string logIn);
    }
}