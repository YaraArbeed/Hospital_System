using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Insurance
    {
        public string Policy_Number { get; set; }
        public int Patient_ID { get; set; }
        public string Ins_Code { get; set; }
        public string End_Date { get; set; }
        public string Provider_Comp { get; set; }
        public string Plan_ { get; set; }
        public decimal Co_Pay { get; set; }
        public string Coverage { get; set; }
        public bool Maternity { get; set; }
        public bool Dental { get; set; }
        public bool Optical { get; set; }
    }
}
