using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Models.Booking;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();   //Bir istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5045/api/Booking");  //listeleme işlemi olduğundan Getasync
            if (responseMessage.IsSuccessStatusCode)  //200lü kod dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var value = JsonConvert.DeserializeObject<List<ResultBookingViewModel>>(jsonData);  
                return View(value);
            }
            return View();
        }




        public async Task<IActionResult> ApprovedReservation(int id)          
                                                                               
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5045/api/Booking/BookingApproved?id={id}");
            //güncelleyeceğim verileri getireceğimden Getasync kullandım
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
