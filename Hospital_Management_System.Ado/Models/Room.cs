using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class Room
    {
        public int Room_ID { get; set; }
        public int Room_Type_ID { get; set; }
        public int Patient_ID { get; set; }
    }
}
