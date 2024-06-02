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
    public class ServiceManager:IServiceService
    {
        private readonly IServicesDal _servicesDal;

        public ServiceManager(IServicesDal servicesDal)
        {
            _servicesDal = servicesDal;
        }


        public void TInsert(Service t)
        {
            _servicesDal.Insert(t);
        }

        public void TDelete(Service t)
        {
            _servicesDal.Delete(t);
        }

        public void TUpdate(Service t)
        {
            _servicesDal.Update(t);
        }

        public List<Service> TGetList()
        {
           return _servicesDal.GetList();
        }

        public Service TGetByID(int id)
        {
            return _servicesDal.GetByID(id);
        }
    }
}
