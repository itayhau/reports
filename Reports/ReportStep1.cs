using CORD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using CORD.Reports;

namespace CORD
{
    public partial class ReportStep1 : Form
    {

        private List<Dictionary<string, string>> m_report_data;
        private ReportTemplate m_reportTemplate;

        public ReportStep1(DataHolder data, ReportTemplate reportTemplate)
        {
            InitializeComponent();

            m_reportTemplate = reportTemplate;

            ReportGenerator reportGenerator = new ReportGenerator(m_reportTemplate.Funcs);

            m_report_data = reportGenerator.CreateReport(data);

            PopulateReportTable();
        }

        private void PopulateReportTable()
        {
            reportsGridView.DataSource = "";

            DataTable dataTable = new DataTable();

            foreach (var item in m_reportTemplate.ColumnNames)
            {
                dataTable.Columns.Add(item);
            }

            reportsGridView.DataSource = dataTable;

            foreach (var item in m_report_data)
            {
                DataRow row = dataTable.NewRow();
                foreach (var column_name in m_reportTemplate.ColumnNames)
                {
                    row[column_name] = item[column_name];
                }
                dataTable.Rows.Add(row);
            }

            dataTable.AcceptChanges();

            reportsGridView.DataSource = dataTable;
        }
    }
}
