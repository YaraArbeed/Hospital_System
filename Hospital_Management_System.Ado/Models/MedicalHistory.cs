using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class MedicalHistory
    {
        public int Record_ID { get; set; }
        public int Patient_ID { get; set; }
        public string Allergies { get; set; }
        public string Pre_Conditions { get; set; }
    }
}
