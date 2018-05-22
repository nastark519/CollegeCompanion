using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;

namespace collegeCompanionApp.Models.ViewModel
{
    public class LifeStyle
    {
        public IEnumerable<DemoAge> DemoAges { get; set; }
        public IEnumerable<DemoRace> DemoRaces { get; set; }
        public IEnumerable<SearchResult> SearchResults { get; set; }
    }
}