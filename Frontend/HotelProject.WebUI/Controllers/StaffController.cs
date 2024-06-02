using System.Text;
using FluentValidation;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    //---------APİ CONSUME İŞLEMİ----------
    public class StaffController : Controller
    {
        private readonly IValidator<AddStaffViewModel> _staffValidator;
        private readonly IHttpClientFactory _httpClientFactory;


        public StaffController(IValidator<AddStaffViewModel> staffValidator, IHttpClientFactory httpClientFactory)
        {
            _staffValidator = staffValidator;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); 
            var responseMessage =
                await client.GetAsync("http://localhost:5045/api/Staff"); 
            if (responseMessage.IsSuccessStatusCode) //200lü kod dönerse
            {
                var jsonData =
                    await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert
                    .DeserializeObject<
                        List<StaffViewModel>>(
                        jsonData); 
                return View(value);
            }

            return View();
        }



        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)  
        {
            var validationresult = _staffValidator.Validate(model);
            if (validationresult.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(model);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage =
                    await client.PostAsync("http://localhost:5045/api/Staff",
                        stringContent); //stringcontent: data,datanın kodlanmış halive türü burada bulunur
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
            else
            {
                foreach (var error in validationresult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }
        }






        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5045/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)   //update için verileri getirme işlemi
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5045/api/Staff/{id}");  
                //güncelleyeceğim verileri getireceğimden Getasync kullandım
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();  //listeleme
                    var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                    return View(values);
                }
                return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)   //update işlemi
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("http://localhost:5045/api/Staff/", stringContent);
            //güncelleyeceğim verileri getireceğimden Getasync kullandım
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
