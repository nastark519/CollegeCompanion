using System;
using System.Linq;
using System.Web;
using collegeCompanionApp.Models;
using System.Data;
using System.Collections.Generic;

namespace collegeCompanionApp.Models.ViewModel
{
    public class FormDataViewModel: FormdataDB
    {

        public IEnumerable<FinLimitList> FinLimitList { get; set; }
        public IEnumerable<PrivacyList> PrivacyList { get; set; }
        public IEnumerable<StateList> StateList { get; set; }

    }
}