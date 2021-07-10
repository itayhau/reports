using System;
using System.Collections.Generic;
using System.Text;

namespace CORD.Models
{
    public class Stop
    {
        public string Stop_Id { get; set; }
        public string Stop_Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Is_Depot { get; set; }
    }
}
