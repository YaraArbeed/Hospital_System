using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Nurse
    {
        public int Nurse_ID { get; set; }
        public int Patient_ID { get; set; }
        public int Emp_ID { get; set; }
        public int Dept_ID { get; set; }
    }
}
