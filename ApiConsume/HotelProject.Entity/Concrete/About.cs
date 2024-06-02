using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Entity.Concrete
{
    public class About
    {
        public int AboutID { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Content { get; set; }

        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
        public int CustomeCount { get; set; }
    }
}
