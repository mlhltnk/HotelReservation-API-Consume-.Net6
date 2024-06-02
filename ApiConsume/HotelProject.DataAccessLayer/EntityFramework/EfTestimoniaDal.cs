using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.Entity.Concrete;
using HotelProject.DataAccessLayer.Concrete;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfTestimoniaDal:GenericRespository<Testimonial>,ITestimonialDal
    {
        public EfTestimoniaDal(HotelContext hotelContext): base(hotelContext)
        {
            
        }
    }
}
