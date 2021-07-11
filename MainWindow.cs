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
        private List<ReportTemplate> m_reportTemplates;

        public MainWindow()
        {
            InitializeComponent();
            m_reportTemplates = new List<ReportTemplate>();
            m_reportTemplates.Add(
            new ReportTemplate
            {
                Funcs = new Dictionary<string, Func<DataHolder, Duty, string>>()
                {
                    { "Duty Id", (data, duty) => duty.Duty_Id.ToString() } ,
                    { "Start Time",
                    (data, duty) => {
                        if (duty.Duty_Events[0].StartTime != DateTime.MinValue)
                        {
                            return duty.Duty_Events[0].StartTime.ToString("HH:mm");
                        }
                        else if (duty.Duty_Events[0].Vehicle_Id != 0)
                        {
                            Vehicle vehicle = data.Vehicles.Find((x) => x.Vehicle_Id == duty.Duty_Events[0].Vehicle_Id);
                            VehicleEvent firstEvent = vehicle.Vehicle_Events.First(x => x.Duty_Id == duty.Duty_Id);
                            return firstEvent.StartTime.ToString("HH:mm");
                        }
                        return null;
                    } },
                    { "End Time",
                    (data, duty) => {
                        if (duty.Duty_Events[duty.Duty_Events.Count - 1].EndTime != DateTime.MinValue)
                        {
                            return duty.Duty_Events[duty.Duty_Events.Count - 1].EndTime.ToString("HH:mm");
                        }
                        else if (duty.Duty_Events[duty.Duty_Events.Count - 1].Vehicle_Id != 0)
                        {
                            Vehicle vehicle = data.Vehicles.Find((x) => x.Vehicle_Id == duty.Duty_Events[duty.Duty_Events.Count - 1].Vehicle_Id);
                            VehicleEvent lastEvent = vehicle.Vehicle_Events.Last(x => x.Duty_Id == duty.Duty_Id);
                            return lastEvent.EndTime.ToString("HH:mm");
                        }
                        return null;
                        }
                    } },
                    ColumnNames = new List<string>()
                    { "Duty Id", "Start Time", "End Time" }}
                );
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
            ReportStep1 report = new ReportStep1(DataContext, m_reportTemplates[0]);
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
