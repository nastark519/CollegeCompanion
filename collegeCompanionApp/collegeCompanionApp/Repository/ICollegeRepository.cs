using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;
using collegeCompanionApp.Models.ViewModel;

namespace collegeCompanionApp.Repository
{
    public interface ICollegeRepository
    {

        void AddCollege(SearchResult college);

        void DeleteCollege(SearchResult college);

        void SaveCollege(SearchResult college);

        string GetCity(SearchResult college);

        string GetState(SearchResult college);

        int GetCollege(string collegeName, int companionID);

        IEnumerable<SearchResult> GetSavedColleges(string logIn);

        SearchResult FindCollege(int id);

        IEnumerable<CompanionUser> GetAllUsers();

        FormdataDB GetFormData();

        LifeStyle GetLifeStyleVM();
    }
}