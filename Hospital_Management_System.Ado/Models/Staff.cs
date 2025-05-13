using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Staff
    {
        public int Emp_ID { get; set; }
        public string Emp_FName { get; set; }
        public string Emp_LName { get; set; }
        public DateTime? Date_Joining { get; set; }
        public DateTime? Date_Seperation { get; set; }
        public string Emp_Type { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Dept_ID { get; set; }
        public int SSN { get; set; }
    }
}
