using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Patient
    {
        public int Patient_ID { get; set; }
        public string Patient_FName { get; set; }
        public string Patient_LName { get; set; }
        public string Phone { get; set; }
        public string Blood_Type { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Condition_ { get; set; }
        public DateTime? Admission_Date { get; set; }
        public DateTime? Discharge_Date { get; set; }
    }
}
