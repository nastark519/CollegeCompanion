using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using collegeCompanionApp.Models;
using collegeCompanionApp.Repository;

namespace collegeCompanionApp.Repository
{
    interface IUnitOfWork : IDisposable
    {
        ICollegeRepository College { get; }

        int Complete();
    }
}
