using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Bookings
{
    public class _BookingCoverComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
