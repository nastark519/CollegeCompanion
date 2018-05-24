using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;
using Moq;

namespace collegeCompanionApp.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CompanionContext Context;

        public Repository(CompanionContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Adds a College to the CollegeDb.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        public void AddCollege(TEntity college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            Context.Set<TEntity>().Add(college);
        }

        /// <summary>
        /// Removes a College to the CollegeDb.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        public void DeleteCollege(TEntity college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            Context.Set<TEntity>().Remove(college);
        }

        /// <summary>
        /// Saves a college to the database.
        /// </summary>
        /// <param name="college">Takes a database.</param>
        public void SaveCollege(TEntity college)
        {
            if (college == null)
            {
                throw new ArgumentNullException(nameof(college));
            }
            Context.SaveChanges();
        }
    }
}