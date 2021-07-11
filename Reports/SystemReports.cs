using CORD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CORD.Reports
{
    public static class SystemReports
    {
        public static List<ReportTemplate> ReportTemplates
        {
            get;
            set;
        }
        static SystemReports()
        {
            ReportTemplates = new List<ReportTemplate>();
            ReportTemplates.Add(
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
                    { "Duty Id", "Start Time", "End Time" }
                    }
                );
        }
    }
}
