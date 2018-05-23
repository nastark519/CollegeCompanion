using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;
using collegeCompanionApp.Repository;
using System.Data.Entity;

namespace collegeCompanionApp.Repository
{
    public class CollegeRepository : Repository<SearchResult>, ICollegeRepository
    {
        public CollegeRepository(CompanionContext compContex)
        : base(compContex) { }

        // Casting the Contex that we have inharited from our
        // repo in be a CompanionContext.
        public CompanionContext CompanionContext
        {
            get { return Context as CompanionContext; }
        }

        public string GetCity(SearchResult college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            var city = Context.SearchResults.Where(n => n.SearchResultsID == college.SearchResultsID)
                                           .Select(n => n.City)
                                           .SingleOrDefault()
                                           .ToString();
            return city;
        }

        public SearchResult GetCollege(string collegeName)
        {
            SearchResult college = Context.SearchResults.Where(n => n.Name == collegeName).SingleOrDefault();
            return college;
        }

        public IEnumerable<SearchResult> GetSavedColleges(string logIn)
        {
            int user = Context.CompanionUsers.Where(n => n.Email == logIn)
                                  .Select(n => n.CompanionID)
                                  .SingleOrDefault();

            var savedColleges = Context.SearchResults.Where(r => r.CompanionID == user  /*&& r.Saved*/).ToList();
            List<SearchResult> savedCollegeList = new List<SearchResult>();
            foreach (SearchResult item in savedColleges)
            {
                savedCollegeList.Add(Context.SearchResults.Where(c => c.SearchResultsID == item.SearchResultsID).FirstOrDefault());
            }
            return savedCollegeList;
        }

        public string GetState(SearchResult college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            string state = Context.SearchResults.Where(n => n.SearchResultsID == college.SearchResultsID)
                                           .Select(n => n.StateName)
                                           .SingleOrDefault();
            return state;
        }
    }
}