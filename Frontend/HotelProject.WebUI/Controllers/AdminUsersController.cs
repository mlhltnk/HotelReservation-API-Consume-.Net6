using System.Drawing.Text;
using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUsersController : Controller   //KULLANICILARI İDENTİTY KÜTÜPHANESİNDEN GETİRME İŞLEMİ
    {
        private readonly UserManager<AppUser> _userManager;

        public AdminUsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()    //kullanıcılar listeleme işlemi
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
    }
}
