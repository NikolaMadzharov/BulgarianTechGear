using BulgarianTechGear.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulgarianTechGear.Controllers
{
    using BulgarianTechGear.Models.MobilePhones;

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
                    x => new MobilePhoneListingViewModel
                             {
                                 Id = x.Id,
                                 Model = x.Model,
                                 Price = x.Price,
                                 Year = x.Year,
                                 Url = x.Url,
                                 MobilePhoneBrands = x.MobilePhoneBrand.Brand
                             })
                .Take(3)
                .ToList();
            return View(phones);
        }

    }
}
