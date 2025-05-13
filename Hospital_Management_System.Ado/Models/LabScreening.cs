using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class LabScreening
    {
        public int Lab_ID { get; set; }
        public int Patient_ID { get; set; }
        public int Technician_ID { get; set; }
        public int Doctor_ID { get; set; }
        public decimal? Test_Cost { get; set; }
        public DateTime Date { get; set; }
    }
}
