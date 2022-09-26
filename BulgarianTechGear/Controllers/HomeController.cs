using BulgarianTechGear.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianTechGear.Controllers
{
    using BulgarianTechGear.Models;
    using BulgarianTechGear.Models.MobilePhones;
    using BulgarianTechGear.Models.MobilePhones.Home;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly BulgarianTechGearDbContext data;

        public HomeController(BulgarianTechGearDbContext data)
        {
            this.data = data;
        }
        public ActionResult Index()
        {
            var phones = this.data
                .MobilePhones
                .OrderByDescending(x => x.Id)
                .Select(
                    x => new PhoneIndexViewModelcs
                    {
                                 Id = x.Id,
                                 Model = x.Model,
                                 Price = x.Price,
                                 Year = x.Year,
                                 Url = x.Url
                                 
                             })
                .Take(3)
                .ToList();

            return View(phones);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
