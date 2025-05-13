using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Bill
    {
        public int Bill_ID { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Room_Cost { get; set; }
        public decimal? Test_Cost { get; set; }
        public decimal? Other_Charges { get; set; }
        public decimal? M_Cost { get; set; }
        public int Patient_ID { get; set; }
        public decimal? Remaining_Balance { get; set; }
        public string Policy_Number { get; set; }
    }
}
