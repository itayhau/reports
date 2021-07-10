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
    public partial class ReportStep3 : Form
    {
        DataHolder data;

        public ReportStep3(DataHolder data)
        {
            InitializeComponent();

            this.data = data;

            PopulateReportTable();
        }

        private void PopulateReportTable()
        {
            reportsGridView.DataSource = "";

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Duty Id");
            dataTable.Columns.Add("Start Time");
            dataTable.Columns.Add("End Time");
            dataTable.Columns.Add("Start Stop Description");
            dataTable.Columns.Add("End Stop Description");
            dataTable.Columns.Add("Break Start Time");
            dataTable.Columns.Add("Break Duration");
            dataTable.Columns.Add("Break Stop Name");

            reportsGridView.DataSource = dataTable;

            foreach (Duty duty in data.Duties)
            {
                long _dutyId;
                string _startTime = "";
                string _endTime = "";
                string _startStopDescription = "";
                string _endStopDescription = "";

                _dutyId = duty.Duty_Id;

                // getting start time

                if (duty.Duty_Events[0].StartTime != DateTime.MinValue)
                {
                    _startTime = duty.Duty_Events[0].StartTime.ToString("HH:mm");
                }
                else if (duty.Duty_Events[0].Vehicle_Id != 0)
                {
                    Vehicle vehicle = data.Vehicles.Find((x) => x.Vehicle_Id == duty.Duty_Events[0].Vehicle_Id);
                    VehicleEvent firstEvent = vehicle.Vehicle_Events.First(x => x.Duty_Id == duty.Duty_Id);
                    _startTime = firstEvent.StartTime.ToString("HH:mm");
                }

                // getting end time

                if (duty.Duty_Events[duty.Duty_Events.Count - 1].EndTime != DateTime.MinValue)
                {
                    _endTime = duty.Duty_Events[duty.Duty_Events.Count - 1].EndTime.ToString("HH:mm");
                }
                else if (duty.Duty_Events[duty.Duty_Events.Count - 1].Vehicle_Id != 0)
                {
                    Vehicle vehicle = data.Vehicles.Find((x) => x.Vehicle_Id == duty.Duty_Events[duty.Duty_Events.Count - 1].Vehicle_Id);
                    VehicleEvent lastEvent = vehicle.Vehicle_Events.First(x => x.Duty_Id == duty.Duty_Id);
                    _endTime = lastEvent.EndTime.ToString("HH:mm");
                }

                List<DutyEvent> dutyEventsWithVehicles = duty.Duty_Events.FindAll(x => x.Vehicle_Id != 0);

                // getting first service trip stop

                Vehicle firstVehicle = data.Vehicles.Find(x => x.Vehicle_Id == dutyEventsWithVehicles[0].Vehicle_Id);
                VehicleEvent firstVehicleEventWithTrip = firstVehicle.Vehicle_Events.FindAll(x => x.Trip_Id != 0 && x.Duty_Id == duty.Duty_Id)[0];
                Trip firstTrip = data.Trips.Find(x => x.Trip_Id == firstVehicleEventWithTrip.Trip_Id);
                _startStopDescription = firstTrip.Origin_Stop_Id;

                // getting last service trip stop

                Vehicle lastVehicle = data.Vehicles.Find(x=>x.Vehicle_Id==dutyEventsWithVehicles[dutyEventsWithVehicles.Count-1].Vehicle_Id);
                VehicleEvent lastVehicleEventWithTrip = lastVehicle.Vehicle_Events.FindLast(x => x.Trip_Id != 0 && x.Duty_Id == duty.Duty_Id);
                Trip lastTrip = data.Trips.Find(x => x.Trip_Id == lastVehicleEventWithTrip.Trip_Id);
                _endStopDescription = lastTrip.Destination_Stop_Id;

                // getting breaks over 15 minutes

                for(int i=0; i<duty.Duty_Events.Count-1; i++)
                {
                    if (IsSubTripOrSplit(duty.Duty_Events[i]))
                    {
                        continue;
                    }

                    DateTime eventEndTime = GetDutyEventEndTime(duty.Duty_Events[i]);
                    DateTime nextEventStartTime = GetDutyEventStartTime(duty.Duty_Events[i + 1]);

                    TimeSpan breakTime = nextEventStartTime - eventEndTime;

                    if (breakTime > new TimeSpan(1,30,0))
                    {
                        continue;
                    }

                    if (breakTime > new TimeSpan(0,15,00))
                    {
                        DataRow row = dataTable.NewRow();

                        row["Duty Id"] = duty.Duty_Id;
                        row["Start Time"] = _startTime;
                        row["End Time"] = _endTime;
                        row["Start Stop Description"] = _startStopDescription;
                        row["End Stop Description"] = _endStopDescription;
                        row["Break Start Time"] = eventEndTime.ToString("HH:mm");
                        row["Break Duration"] = breakTime.ToString();
                        row["Break Stop Name"] = GetDutyEventDestinationLocation(duty.Duty_Events[i]);

                        dataTable.Rows.Add(row);
                    }
                }
            }

            dataTable.AcceptChanges();

            reportsGridView.DataSource = dataTable;
        }

        private DateTime GetDutyEventEndTime(DutyEvent dutyEvent)
        {
            if (dutyEvent.EndTime != DateTime.MinValue)
            {
                return dutyEvent.EndTime;
            }
            if (dutyEvent.Vehicle_Id != 0)
            {
                Vehicle vehicle = data.Vehicles.Find(x => x.Vehicle_Id == dutyEvent.Vehicle_Id);
                VehicleEvent vehicleEvent = vehicle.Vehicle_Events.Find(x => x.Vehicle_Event_Sequence == dutyEvent.Vehicle_Event_Sequence);
                if (vehicleEvent.EndTime != DateTime.MinValue)
                {
                    return vehicleEvent.EndTime;
                }
                if (vehicleEvent.Trip_Id != 0)
                {
                    Trip trip = data.Trips.Find(x => x.Trip_Id == vehicleEvent.Trip_Id);
                    return trip.ArrivalTime;
                }
            }
            return new DateTime();
        }

        private DateTime GetDutyEventStartTime(DutyEvent dutyEvent)
        {
            if (dutyEvent.StartTime != DateTime.MinValue)
            {
                return dutyEvent.StartTime;
            }
            if (dutyEvent.Vehicle_Id != 0)
            {
                Vehicle vehicle = data.Vehicles.Find(x => x.Vehicle_Id == dutyEvent.Vehicle_Id);
                VehicleEvent vehicleEvent = vehicle.Vehicle_Events.Find(x => x.Vehicle_Event_Sequence == dutyEvent.Vehicle_Event_Sequence);
                if (vehicleEvent.StartTime != DateTime.MinValue)
                {
                    return vehicleEvent.StartTime;
                }
                if (vehicleEvent.Trip_Id != 0)
                {
                    Trip trip = data.Trips.Find(x => x.Trip_Id == vehicleEvent.Trip_Id);
                    return trip.DepartureTime;
                }
            }
            return new DateTime();
        }
        private string GetDutyEventDestinationLocation(DutyEvent dutyEvent)
        {
            if (!String.IsNullOrEmpty(dutyEvent.Destination_Stop_Id))
            {
                return dutyEvent.Destination_Stop_Id;
            }
            if (dutyEvent.Vehicle_Id != 0)
            {
                Vehicle vehicle = data.Vehicles.Find(x => x.Vehicle_Id == dutyEvent.Vehicle_Id);
                VehicleEvent vehicleEvent = vehicle.Vehicle_Events.Find(x => x.Vehicle_Event_Sequence == dutyEvent.Vehicle_Event_Sequence);

                if (!String.IsNullOrEmpty(vehicleEvent.Destination_Stop_Id))
                {
                    return vehicleEvent.Destination_Stop_Id;
                }
                if (vehicleEvent.Trip_Id != 0)
                {
                    Trip trip = data.Trips.Find(x => x.Trip_Id == vehicleEvent.Trip_Id);
                    return trip.Destination_Stop_Id;
                }
            }
            return String.Empty;
        }

        private bool IsSubTripOrSplit(DutyEvent dutyEvent)
        {          
            if (dutyEvent.Vehicle_Id != 0)
            {
                Vehicle vehicle = data.Vehicles.Find(x => x.Vehicle_Id == dutyEvent.Vehicle_Id);
                VehicleEvent vehicleEvent = vehicle.Vehicle_Events.Find(x => x.Vehicle_Event_Sequence == dutyEvent.Vehicle_Event_Sequence);
                
                // checking for sub trip scenario
                if (vehicleEvent.Sub_Trip_Index == 1)
                {
                    return true;
                }

                // checking for split (depot pull in) scenario
                if (vehicleEvent.Vehicle_Event_Type == "depot_pull_in")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
