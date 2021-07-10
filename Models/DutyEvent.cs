using System;
using System.Collections.Generic;
using System.Text;

namespace CORD.Models
{
    public class DutyEvent
    {
        /*
         *  DutyEventSequence = dutyEvent["duty_event_sequence"].ToObject<int>(),
                        DutyEventType = dutyEvent["duty_event_type"].ToObject<string>(),
                        VehicleEventSequence = dutyEvent["vehicle_event_sequence"] == null ? 0 : dutyEvent["vehicle_event_sequence"].ToObject<int>(),
                        VehicleId = dutyEvent["vehicle_id"] == null ? 0 : dutyEvent["vehicle_id"].ToObject<long>(),
                        StartTime = dutyEvent["start_time"] == null ? new DateTime() : Utility.ConvertToDateTime(dutyEvent["start_time"].ToString()),
                        EndTime = dutyEvent["end_time"] == null ? new DateTime() : Utility.ConvertToDateTime(dutyEvent["end_time"].ToString()),
                        OriginStopId = dutyEvent["origin_stop_id"] == null ? null : dutyEvent["origin_stop_id"].ToString(),
                        DestinationStopId = dutyEvent["destination_stop_id"] == null ? null : dutyEvent["destination_stop_id"].ToString()
        */
        private string m_start_time;
        private string m_end_time;
        public int Duty_Event_Sequence { get; set; }
        public string Duty_Event_Type { get; set; }
        public int Vehicle_Event_Sequence { get; set; }
        public long Vehicle_Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Start_Time
        {
            get
            {
                return m_start_time;
            }
            set
            {
                m_start_time = value;
                StartTime = Utility.ConvertToDateTime(value);
            }
        }
        public string End_Time
        {
            get
            {
                return m_end_time;
            }
            set
            {
                m_end_time = value;
                EndTime = Utility.ConvertToDateTime(value);
            }
        }
        public string Origin_Stop_Id { get; set; }
        public string Destination_Stop_Id { get; set; }
    }
}
