using HotelProject.WebUI.Models.Booking;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class BookingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingViewModel _createBookingViewModel)
        {
            _createBookingViewModel.Status = "Onay Bekliyor";
            _createBookingViewModel.Description = "deneme";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(_createBookingViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5045/api/Booking", stringContent);  //stringcontent: data,datanın kodlanmış halive türü burada bulunur
            return RedirectToAction("Index", "Default");
        }

    }
}
