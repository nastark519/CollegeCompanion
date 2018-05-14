using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using collegeCompanionApp.Models;

namespace collegeCompanionApp.Repository
{
    public interface IRepository
    {

        IEnumerable<College> Colleges { get; }

        void AddCollege(College college);

        void DeleteCollege(College college);

        void SaveCollege(College college);

        IEnumerable<College> GetSavedColleges(string logIn);

        //int GetZipCode(College college);

        string GetState(College college);

        string GetCity(College college);

        College GetCollege(string collegeName);
    }
}