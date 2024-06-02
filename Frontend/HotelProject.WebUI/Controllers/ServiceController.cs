using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using HotelProject.WebUI.Dtos.ServiceDto;

namespace HotelProject.WebUI.Controllers
{
    public class ServiceController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();   //Bir istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5045/api/Service");  
            if (responseMessage.IsSuccessStatusCode)  //200lü kod dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);  
                return View(value);
            }
            return View();
        }



        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid)  //model geçerli değilse bize view'i dön ama hataları göster
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5045/api/Service", stringContent);  //stringcontent: data,datanın kodlanmış halive türü burada bulunur
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5045/api/Service/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)   //update için verileri getirme işlemi
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5045/api/Service/{id}");
            //güncelleyeceğim verileri getireceğimden Getasync kullandım
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();  //listeleme
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)   //update işlemi
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5045/api/Service/", stringContent);
            //güncelleyeceğim verileri getireceğimden Getasync kullandım
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

