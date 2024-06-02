using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Migrations;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.Entity.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAboutDal:GenericRespository<About>,IAboutDal
    {
        public EfAboutDal(HotelContext context) : base(context)
        {

        }

        public void AddStaffCount(int staffCount)  
        {
            var context = new HotelContext();
            var values = context.Abouts.FirstOrDefault();
            values.StaffCount = staffCount;
            context.SaveChanges();
        }

        public void AddRoomCount(int roomCount)
        {
            var context = new HotelContext();
            var values = context.Abouts.FirstOrDefault();
            values.RoomCount = roomCount;
            context.SaveChanges();
        }
    }
}
