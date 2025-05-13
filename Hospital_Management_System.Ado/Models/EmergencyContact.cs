using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class EmergencyContact
    {
        public int Contact_ID { get; set; }
        public string Contact_Name { get; set; }
        public string Phone { get; set; }
        public string Relation { get; set; }
        public int Patient_ID { get; set; }
    }
}
