using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _OurRoomsComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OurRoomsComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();   //Bir istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5045/api/Room");  //listeleme işlemi olduğundan Getasync
            if (responseMessage.IsSuccessStatusCode)  //200lü kod dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var value = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);  
                return View(value);
            }
            return View();
        }
      
    }
}
