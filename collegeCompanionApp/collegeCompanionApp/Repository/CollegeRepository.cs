using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;
using collegeCompanionApp.Repository;
using System.Data.Entity;

namespace collegeCompanionApp.Repository
{
    public class CollegeRepository : Repository<College>, ICollegeRepository
    {
        public CollegeRepository(CompanionContext compContex)
        : base(compContex) { }

        // Casting the Contex that we have inharited from our
        // repo in be a CompanionContext.
        public CompanionContext CompanionContext
        {
            get { return Context as CompanionContext; }
        }

        public string GetCity(College college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            var city = Context.Colleges.Where(n => n.CollegeID == college.CollegeID)
                                           .Select(n => n.City)
                                           .SingleOrDefault()
                                           .ToString();
            return city;
        }

        public College GetCollege(string collegeName)
        {
            College college = Context.Colleges.Where(n => n.Name == collegeName).SingleOrDefault();
            return college;
        }

        public IEnumerable<College> GetSavedColleges(string logIn)
        {
            string user = Context.CompanionUsers.Where(n => n.Email == logIn)
                                  .Select(n => n.CompanionID)
                                  .SingleOrDefault().ToString();

            var savedColleges = Context.College_User_Relations.Where(r => r.CompanionID == user && r.Saved).ToList();
            List<College> savedCollegeList = new List<College>();
            foreach (College_User_Relations item in savedColleges)
            {
                savedCollegeList.Add(Context.Colleges.Where(c => c.CollegeID == item.CollegeID).FirstOrDefault());
            }
            if (user != null)
            {
                return savedCollegeList;
            }
            else
            {
                throw new NullReferenceException("No Saved Values Found for This User.");
            }
        }

        public string GetState(College college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            var state = Context.Colleges.Where(n => n.CollegeID == college.CollegeID)
                                           .Select(n => n.StateName)
                                           .SingleOrDefault()
                                           .ToString();
            return state;
        }
    }
}