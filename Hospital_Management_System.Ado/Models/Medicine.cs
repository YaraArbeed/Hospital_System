using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Medicine
    {
        public int Medicine_ID { get; set; }
        public string M_Name { get; set; }
        public int M_Quantity { get; set; }
        public decimal M_Cost { get; set; }
    }
}
