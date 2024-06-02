using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AdminImageFileController : Controller
    //FİLE YÜKLEME İŞLEMİ APİCONSUME EDİLMESİ
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent,"file",file.Name);
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.PostAsync("http://localhost:5045/api/FileImage",multipartFormDataContent);

            return View();
        }
    }
}
