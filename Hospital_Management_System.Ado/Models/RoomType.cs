using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Models
{
    public class RoomType
    {
        public int Room_Type_ID { get; set; }
        public string Room_Desc { get; set; }
        public decimal Room_Cost { get; set; }
    }
}
