using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Payroll
    {
        public string Account_No { get; set; }
        public decimal Salary { get; set; }
        public decimal? Bonus { get; set; }
        public int Emp_ID { get; set; }
        public string IBAN { get; set; }
    }
}
