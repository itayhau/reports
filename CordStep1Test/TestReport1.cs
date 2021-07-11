using CORD.Models;
using CORD.Reports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;

namespace CordStep1Test
{
    [TestClass]
    public class TestReport1
    {
        [TestMethod]
        public void Test_Report_Step1()
        {
            StreamReader reader = new StreamReader("mini_json_dataset.json");
            string json = reader.ReadToEnd();
            DataHolder data = JsonConvert.DeserializeObject<DataHolder>(json);
            ReportGenerator reportGenerator = new ReportGenerator(SystemReports.ReportTemplates[0].Funcs);

            var reportStep1 = reportGenerator.CreateReport(data);
            var jsons_result = JsonConvert.SerializeObject(reportStep1);

            reader = new StreamReader("report1.json");
            string json_string_expected_result = reader.ReadToEnd();

            Assert.AreEqual(jsons_result, json_string_expected_result);
        }
    }
}
