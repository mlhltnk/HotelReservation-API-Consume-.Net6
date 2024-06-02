using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Entity.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IAboutDal:IGenericDal<About>
    {
       void AddStaffCount(int staffCount);

       void AddRoomCount(int roomCount);
    }
}
