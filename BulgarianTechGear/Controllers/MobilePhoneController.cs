using BulgarianTechGear.Models.MobilePhone;
using Microsoft.AspNetCore.Mvc;
namespace BulgarianTechGear.Controllers
{
    using BulgarianTechGear.Data;
    using BulgarianTechGear.Data.Models;
    using BulgarianTechGear.Models.MobilePhones;

    public class MobilePhoneController : Controller
    {
        private readonly BulgarianTechGearDbContext data;

        public MobilePhoneController(BulgarianTechGearDbContext data)
        {
            this.data = data;
        }

        public IActionResult Add() => View(new AddMobilePhoneFromModel
        {
            Brands = this.GetPhoneBrands()
        });

      
        public IActionResult All(string searchTerm)
        {

            var phoneQuery = this.data.MobilePhones.AsQueryable();

            //if (!string.IsNullOrWhiteSpace(searchTerm))
            //{
            //    phoneQuery = phoneQuery.Where(
            //        p => p.Model.ToLower().Contains(searchTerm.ToLower())
            //              || p.Description.ToLower().Contains(searchTerm.ToLower()));
            //}

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
                }).ToList();

            return View(new AllPhonesQueryModel
                            {
                                Phones = phones,
                                SearchTerm = searchTerm
                            });
        }


        [HttpPost]
        public IActionResult Add(AddMobilePhoneFromModel phone)
        {
            if (!this.data.MobilePhoneBrands.Any(m => m.Id == phone.BrandId))
            {
                this.ModelState.AddModelError(nameof(phone.BrandId), "The brand does not exist!");
            }


            var phoneData = new Data.Models.MobilePhone
            {
                Model = phone.Model,
                Price = (decimal)phone.Price,
                DisplaySizeInch = (double)phone.DisplaySizeInch,
                DisplayType = phone.DisplayType,
                Ram = (int)phone.Ram,
                Resolution = phone.Resolution,
                Processor = phone.Processor,
                Description = phone.Description,
                Url = phone.Url,
                PixelsFrontCamera = (int)phone.PixelsFrontCamera,
                PixelsBackCamera = (int)phone.PixelsBackCamera,
                Year = (int)phone.Year,
                BatteryCapacity = (double)phone.BatteryCapacity,
                Memory = (int)phone.Memory,
                MobilePhoneBrandId = phone.BrandId
            };
            this.data.Add(phoneData);
            this.data.SaveChanges();

            return this.RedirectToAction(nameof(All));
        }

        public IEnumerable<MobilePhoneBrandViewCategory> GetPhoneBrands() =>
            this.data.MobilePhoneBrands.Select(
                m => new MobilePhoneBrandViewCategory
                {
                    Id = m.Id,
                    Brand = m.Brand
                }).ToList();

    }
}
