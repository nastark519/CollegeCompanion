using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;
using collegeCompanionApp.Repository;
using System.Data.Entity;
using collegeCompanionApp.Models.ViewModel;

namespace collegeCompanionApp.Repository
{
    public class CollegeRepository : ICollegeRepository
    {

        //Create a normal context connection
        CompanionContext Context = new CompanionContext();
        FormdataDB ContextForm = new FormdataDB();
        LifeStyle ContextLS = new LifeStyle();

        /// <summary>
        /// Adds a College to the CollegeDb.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        public void AddCollege(SearchResult college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            Context.Set<SearchResult>().Add(college);
        }

        /// <summary>
        /// Removes a College to the CollegeDb.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        public void DeleteCollege(SearchResult college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            Context.Set<SearchResult>().Remove(college);
        }

        /// <summary>
        /// Saves a college to the database.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        public void SaveCollege(SearchResult college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            Context.SaveChanges();
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

        public FormdataDB GetFormData()
        {
            return ContextForm;
        }

        public LifeStyle GetLifeStyleVM()
        {
            return ContextLS;
        }

        public int GetCollege(string collegeName, int companionID)
        {
            return Context.SearchResults.Where(n => n.Name == collegeName && n.CompanionID == companionID).ToList().Count;
        }


        public SearchResult FindCollege(int id)
        {
            SearchResult college = Context.SearchResults.Where(n => n.SearchResultsID == id).SingleOrDefault();
            return college;
        }

        public IEnumerable<SearchResult> GetSavedColleges(string logIn)
        {
            return Context.SearchResults.Where(c => c.CompanionUser.Email == logIn).ToList();
        }

        public IEnumerable<CompanionUser> GetAllUsers()
        {
            return Context.CompanionUsers.ToList();
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