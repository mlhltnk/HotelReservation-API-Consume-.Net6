using HotelProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IAboutService:IGenericService<About>
    {
        void AddStafCountAsAbout(int stafCount);

        void AddRoomCountAsAbout(int roomCount);
    }
}
