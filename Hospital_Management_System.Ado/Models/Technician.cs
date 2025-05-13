using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Technician
    {
        public int Technician_ID { get; set; }
        public string Tech_FName { get; set; }
        public string Tech_LName { get; set; }
        public string Qualification { get; set; }
    }
}
