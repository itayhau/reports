using System;
using System.Collections.Generic;
using System.Text;

namespace CORD.Models
{
    public class VehicleEvent
    {
        private string m_start_time;
        private string m_end_time;
        public int Vehicle_Event_Sequence { get; set; }
        public string Vehicle_Event_Type { get; set; }
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
        public long Duty_Id { get; set; }
        public long Trip_Id { get; set; }
        public int Sub_Trip_Index { get; set; }
    }
}
