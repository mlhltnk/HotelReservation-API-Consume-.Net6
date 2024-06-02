using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;

namespace HotelProject.DataAccessLayer.Repositories
{
    public class GenericRespository<T>:IGenericDal<T> where T : class
    {
        private readonly HotelContext _hotelContext;

        public GenericRespository(HotelContext hotelContext)
        {
            _hotelContext = hotelContext;
        }


        public void Insert(T t)
        {
            _hotelContext.Add(t);
            _hotelContext.SaveChanges();
        }

        public void Delete(T t)
        {
            _hotelContext.Remove(t);
            _hotelContext.SaveChanges();
        }

        public void Update(T t)
        {
            _hotelContext.Update(t);
            _hotelContext.SaveChanges();
        }

        public List<T> GetList()
        {
            return _hotelContext.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return _hotelContext.Set<T>().Find(id);
        }
    }
}
