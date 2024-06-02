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
    public class BookingManager:IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }


        public void TInsert(Booking t)
        {
           _bookingDal.Insert(t);
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public void TUpdate(Booking t)
        {
           _bookingDal.Update(t);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public Booking TGetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }



        public void TBookingStatusChangeApproved(int id)  
        {
            _bookingDal.BookingStatusChangeApproved(id);
        }
    }
}
