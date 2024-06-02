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
    public class StaffManager:IStaffService
    {
        private IStaffDal _staffDal;
        private IAboutService _aboutService;


        public StaffManager(IStaffDal staffDal, IAboutService aboutService)
        {
            _staffDal = staffDal;
            _aboutService = aboutService;
        }

        public void TInsert(Staff t)
        {
            _staffDal.Insert(t);
            var a = TGetList().Count();
            _aboutService.AddStafCountAsAbout(a);  

        }

        public void TDelete(Staff t)
        {
            _staffDal.Delete(t);
            var b = TGetList().Count();
            _aboutService.AddStafCountAsAbout(b);  
        }

        public void TUpdate(Staff t)
        {
           _staffDal.Update(t);
        }

        public List<Staff> TGetList()
        {
            return _staffDal.GetList();
        }

        public Staff TGetByID(int id)
        {
            return _staffDal.GetByID(id);
        }
    }
}
