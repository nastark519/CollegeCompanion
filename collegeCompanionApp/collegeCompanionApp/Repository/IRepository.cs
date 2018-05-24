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

        void AddCollege(TEntity college);

        void DeleteCollege(TEntity college);

        void SaveCollege(TEntity college);

    }
}