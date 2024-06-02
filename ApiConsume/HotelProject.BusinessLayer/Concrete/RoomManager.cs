using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.Entity.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class RoomManager:IRoomService
    {
        private readonly IRoomDal _roomDal;
        private readonly IAboutService _aboutService;

        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void TInsert(Room t)
        {
            _roomDal.Insert(t);
            var a = TGetList().Count();
            _aboutService.AddRoomCountAsAbout(a);

        }

        public void TDelete(Room t)
        {
            _roomDal.Delete(t);
        }

        public void TUpdate(Room t)
        {
            _roomDal.Update(t);
        }

        public List<Room> TGetList()
        {
            return _roomDal.GetList();
        }

        public Room TGetByID(int id)
        {
            return _roomDal.GetByID(id);
        }
    }
}
