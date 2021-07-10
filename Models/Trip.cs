using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORD.Models
{
    public class Trip
    {
        private string m_arrival_time;
        private string m_departure_time;
        public long Trip_Id { get; set; }
        public int Route_Number { get; set; }
        public string Origin_Stop_Id { get; set; }
        public string Destination_Stop_Id { get; set; }
        public string Departure_Time
        {
            get
            {
                return m_departure_time;
            }
            set
            {
                m_departure_time = value;
                DepartureTime = Utility.ConvertToDateTime(value);
            }
        }
        public string Arrival_Time
        {
            get
            {
                return m_arrival_time;
            }
            set
            {
                m_arrival_time = value;
                ArrivalTime = Utility.ConvertToDateTime(value);
            }
        }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
