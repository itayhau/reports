using System;
using System.Collections.Generic;
using System.Text;

namespace CORD.Models
{
    public class Duty
    {
        public long Duty_Id { get; set; }
        public List<DutyEvent> Duty_Events { get; set; }
    }
}
