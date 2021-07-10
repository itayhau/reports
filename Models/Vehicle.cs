using System;
using System.Collections.Generic;
using System.Text;

namespace CORD.Models
{
    public class Vehicle
    {
        public long Vehicle_Id { get; set; }
        public List<VehicleEvent> Vehicle_Events { get; set; }
    }
}
