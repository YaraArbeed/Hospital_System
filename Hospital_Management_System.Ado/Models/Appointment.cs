using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Appointment
    {
        public int Appt_ID { get; set; }
        public DateTime Scheduled_On { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Time { get; set; }
        public int Doctor_ID { get; set; }
        public int Patient_ID { get; set; }
    }
}
