using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;
using collegeCompanionApp.Repository;

namespace collegeCompanionApp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanionContext _context;

        public UnitOfWork(CompanionContext context)
        {
            _context = context;
            College = new CollegeRepository(_context);
        }

        public ICollegeRepository College { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}