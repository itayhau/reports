using CORD.Models;
using CORD.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CORD
{
    public partial class MainWindow : Form
    {
        public DataHolder DataContext { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadJsonBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "JSON Files|*.json";
            fileDialog.FileOk += (s, args) => {
                LoadDataFromJsonFile(fileDialog.FileName);
            };
            fileDialog.ShowDialog();
        }

        private void LoadDataFromJsonFile(string fileName)
        {
            try
            {
                StreamReader reader = new StreamReader(fileName);
                string json = reader.ReadToEnd();
                DataContext = JsonConvert.DeserializeObject<DataHolder>(json);
                report1btn.Enabled = true;
                report2btn.Enabled = true;
                report3btn.Enabled = true;
            }
            catch (Exception ex) when (ex is JsonSerializationException || ex is KeyNotFoundException)
            {
                MessageBox.Show($"An error occured while processing the file. \n {ex.Message}");
            }
        }

        private void Report1btn_Click(object sender, EventArgs e)
        {
            ReportStep1 report = new ReportStep1(DataContext, SystemReports.ReportTemplates[0]);
            report.ShowDialog();
        }

        private void Report2btn_Click(object sender, EventArgs e)
        {
            ReportStep2 report = new ReportStep2(DataContext);
            report.ShowDialog();
        }

        private void Report3btn_Click(object sender, EventArgs e)
        {
            ReportStep3 report = new ReportStep3(DataContext);
            report.ShowDialog();
        }
    }
}
