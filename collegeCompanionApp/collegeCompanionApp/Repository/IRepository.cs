using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using collegeCompanionApp.Models;
using System.Threading.Tasks;

namespace collegeCompanionApp.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {

        //IEnumerable<TEntity> Colleges { get; }

        void AddCollege(TEntity college);

        void DeleteCollege(TEntity college);

        void SaveCollege(TEntity college);

        //IEnumerable<TEntity> GetSavedColleges(string logIn);

        //int GetZipCode(College college);

        //string GetState(TEntity college);

        //string GetCity(TEntity college);

        //TEntity GetCollege(string collegeName);
    }
}