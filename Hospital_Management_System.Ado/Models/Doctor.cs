using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Doctor
    {
        public int Doctor_ID { get; set; }
        public string Qualifications { get; set; }
        public int Emp_ID { get; set; }
        public string Specialization { get; set; }
        public int Dept_ID { get; set; }
    }
}
