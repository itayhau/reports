using CORD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORD.Reports
{
    public class ReportTemplate
    {
        public Dictionary<string, Func<DataHolder, Duty, string>> Funcs
        {
            get;
            set;
        }
        
        public List<string> ColumnNames
        {
            get;
            set;
        }
    }
}
