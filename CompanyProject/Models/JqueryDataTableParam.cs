using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyProject.Models
{
    public class JqueryDataTableParam
    {
            public string sEcho { get; set; }
            public string sSearch { get; set; }
            public int iDisplayLength { get; set; }
            public int iDisplayStart { get; set; }        
    }
}