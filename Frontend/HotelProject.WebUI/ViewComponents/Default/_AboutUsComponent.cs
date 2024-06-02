using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutUsComponent:ViewComponent    
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //VİEVCOMPONENT İÇİNDE APİ CONSUME İŞLEMİ
        public async Task <IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();   //Bir istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5045/api/About");  //listeleme işlemi olduğundan Getasync
            if (responseMessage.IsSuccessStatusCode)  //200lü kod dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();  
                var value = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);  
                return View(value);
            }
            return View();
        }
    }
}
