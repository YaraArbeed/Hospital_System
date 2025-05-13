using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Prescription
    {
        public int Prescription_ID { get; set; }
        public int Patient_ID { get; set; }
        public int Medicine_ID { get; set; }
        public DateTime? Date { get; set; }
        public int? Dosage { get; set; }
        public int Doctor_ID { get; set; }
    }
}
