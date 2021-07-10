using System;
using System.Collections.Generic;
using System.Text;
using CORD.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CORD.Models
{
    public class DataHolder
    {
        public List<Stop> Stops { get; set; }
        public List<Trip> Trips { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<Duty> Duties { get; set; }      
    }
}
