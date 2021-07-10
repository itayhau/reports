using CORD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace CORD
{
    public partial class ReportStep2 : Form
    {
        public ReportStep2(DataHolder data)
        {
            InitializeComponent();

            PopulateReportTable(data);
        }

        private void PopulateReportTable(DataHolder data)
        {
            reportsGridView.DataSource = "";

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Duty Id");
            dataTable.Columns.Add("Start Time");
            dataTable.Columns.Add("End Time");
            dataTable.Columns.Add("Start Stop Description");
            dataTable.Columns.Add("End Stop Description");

            reportsGridView.DataSource = dataTable;

            foreach (Duty duty in data.Duties)
            {
                DataRow row = dataTable.NewRow();
                row["Duty Id"] = duty.Duty_Id;

                // getting start time

                if (duty.Duty_Events[0].StartTime != DateTime.MinValue)
                {
                    row["Start Time"] = duty.Duty_Events[0].StartTime.ToString("HH:mm");
                }
                else if (duty.Duty_Events[0].Vehicle_Id != 0)
                {
                    Vehicle vehicle = data.Vehicles.Find((x) => x.Vehicle_Id == duty.Duty_Events[0].Vehicle_Id);
                    VehicleEvent firstEvent = vehicle.Vehicle_Events.First(x => x.Duty_Id == duty.Duty_Id);
                    row["Start Time"] = firstEvent.StartTime.ToString("HH:mm");
                }

                // getting end time

                if (duty.Duty_Events[duty.Duty_Events.Count - 1].EndTime != DateTime.MinValue)
                {
                    row["End Time"] = duty.Duty_Events[duty.Duty_Events.Count - 1].EndTime.ToString("HH:mm");
                }
                else if (duty.Duty_Events[duty.Duty_Events.Count - 1].Vehicle_Id != 0)
                {
                    Vehicle vehicle = data.Vehicles.Find((x) => x.Vehicle_Id == duty.Duty_Events[duty.Duty_Events.Count - 1].Vehicle_Id);
                    VehicleEvent lastEvent = vehicle.Vehicle_Events.Last(x => x.Duty_Id == duty.Duty_Id);
                    row["End Time"] = lastEvent.EndTime.ToString("HH:mm");
                }

                List<DutyEvent> dutyEventsWithVehicles = duty.Duty_Events.FindAll(x => x.Vehicle_Id != 0);

                // getting first service trip stop

                Vehicle firstVehicle = data.Vehicles.Find(x => x.Vehicle_Id == dutyEventsWithVehicles[0].Vehicle_Id);
                VehicleEvent firstVehicleEventWithTrip = firstVehicle.Vehicle_Events.FindAll(x => x.Trip_Id != 0 && x.Duty_Id == duty.Duty_Id)[0];
                Trip firstTrip = data.Trips.Find(x => x.Trip_Id == firstVehicleEventWithTrip.Trip_Id);
                row["Start Stop Description"] = firstTrip.Origin_Stop_Id;

                // getting last service trip stop

                Vehicle lastVehicle = data.Vehicles.Find(x=>x.Vehicle_Id==dutyEventsWithVehicles[dutyEventsWithVehicles.Count-1].Vehicle_Id);
                VehicleEvent lastVehicleEventWithTrip = lastVehicle.Vehicle_Events.FindLast(x => x.Trip_Id != 0 && x.Duty_Id == duty.Duty_Id);
                Trip lastTrip = data.Trips.Find(x => x.Trip_Id == lastVehicleEventWithTrip.Trip_Id);
                row["End Stop Description"] = lastTrip.Destination_Stop_Id;

                dataTable.Rows.Add(row);
            }

            dataTable.AcceptChanges();

            reportsGridView.DataSource = dataTable;
        }
    }
}
