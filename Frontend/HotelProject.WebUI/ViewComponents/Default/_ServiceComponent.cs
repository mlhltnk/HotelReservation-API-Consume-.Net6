using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _ServiceComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();   //Bir istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5045/api/Service");  //listeleme işlemi olduğundan Getasync
            if (responseMessage.IsSuccessStatusCode)  //200lü kod dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   //gelen veriyi jsonData diye bir değişkene atadım
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);  //jsonData verisi json türünde olduğundan deserialize ederek normal tablomda gösterecek şekilde çevirdim.
                return View(value);
            }
            return View();
        }

    }
}
