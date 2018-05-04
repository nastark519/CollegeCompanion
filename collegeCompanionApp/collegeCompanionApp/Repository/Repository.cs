using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;
using Moq;

namespace collegeCompanionApp.Repository
{
    public class Repository : IRepository
    {
        public IEnumerable<College> Colleges => companiondb.Colleges;
        private CompanionContext companiondb = new CompanionContext();

        public Repository( CompanionContext context)
        {
            this.companiondb = context;
        }

        /// <summary>
        /// Adds a College to the CollegeDb.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        public void AddCollege(College college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            companiondb.Colleges.Add(college);
        }

        /// <summary>
        /// Removes a College to the CollegeDb.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        public void DeleteCollege(College college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            companiondb.Colleges.Remove(college);
        }

        /// <summary>
        /// Saves a college to the database.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        public void SaveCollege(College college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            companiondb.SaveChanges();
        }

        /// <summary>
        /// Adds a College to the CollegeDb.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        /// <returns>
        /// The city of the college specificed as a string.
        /// </returns>
        public string GetCity(College college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            var city = companiondb.Colleges.Where(n => n.CollegeID == college.CollegeID)
                                           .Select(n => n.City)
                                           .SingleOrDefault()
                                           .ToString();
            return city;
        }

        /// <summary>
        /// Gets a college back from the database.
        /// </summary>
        /// <param name="college">Takes a name to query the database.</param>
        /// <returns>
        /// The desired college from the database.
        /// </returns>
        public College GetCollege(string collegeName)
        {
            College college = companiondb.Colleges.Where(n => n.Name == collegeName).SingleOrDefault();
            return college;
        }

        /// <summary>
        /// Gets the state of a given college.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        /// <returns>
        /// Returns the specificed college's state field. 
        /// </returns>
        public string GetState(College college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            var state = companiondb.Colleges.Where(n => n.CollegeID == college.CollegeID)
                                           .Select(n => n.StateName)
                                           .SingleOrDefault()
                                           .ToString();
            return state;
        }

        /// <summary>
        /// Gets the zipcode of a given college.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        /// <returns>
        /// Returns the specificed college's zipcode field.
        /// </returns>
        public int GetZipCode(College college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            var zipCode = companiondb.Colleges.Where(n => n.CollegeID == college.CollegeID)
                                           .Select(n => n.ZipCode) //Requires Database Updated for ZipCode Field!
                                           .SingleOrDefault()
                                           .ToString();
            return zipCode;
        }

        /// <summary>
        /// Gets a list of all the users saved colleges based on log in.
        /// </summary>
        /// <param name="longInName">Takes a string that is the user's log in email.</param>
        /// <returns>
        /// An IEnumerable list of colleges that are the user's saved colleges.
        /// </returns>
        public IEnumerable<College> GetSavedColleges(string logIn)
        {
            string user = companiondb.CompanionUsers.Where(n => n.Email == logIn)
                                  .Select(n => n.CompanionID)
                                  .SingleOrDefault().ToString();

            var savedColleges = companiondb.College_User_Relations.Where(r => r.CompanionID == user && r.Saved).ToList();
            List<College> savedCollegeList = new List<College>();
            foreach(College_User_Relations item in savedColleges)
            {
                savedCollegeList.Add(companiondb.Colleges.Where(c => c.CollegeID == item.CollegeID).FirstOrDefault());
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
    }
}