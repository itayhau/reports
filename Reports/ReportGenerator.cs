using CORD.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORD.Reports
{
    class ReportGenerator
    {
        private Dictionary<string, Func<DataHolder, Duty, string>> m_funcs;

        public ReportGenerator(Dictionary<string, Func<DataHolder, Duty, string>> funcs)
        {
            m_funcs = funcs;
        }

        public List<Dictionary<string, string>> CreateReport(DataHolder data)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            foreach (var duty in data.Duties)
            {
                Dictionary<string, string> row = new Dictionary<string, string>();
                foreach (var map_func in m_funcs)
                {
                    row.Add(map_func.Key, map_func.Value.Invoke(data, duty));
                }
                result.Add(row);
            }
            return result;
        }
    }
}
