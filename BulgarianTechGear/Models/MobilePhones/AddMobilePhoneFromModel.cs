using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BulgarianTechGear.Models.MobilePhone
{
    using BulgarianTechGear.Models.MobilePhones;

    public class AddMobilePhoneFromModel
    {
        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public int? Year { get; set; }

        [Required]
        public int? PixelsFrontCamera { get; set; }

        [Required]
        public int? PixelsBackCamera { get; set; }

        [Required]
        public int? Memory { get; set; }

        [Required]
        public double? DisplaySizeInch { get; set; }

        [Required]
        public double? BatteryCapacity { get; set; }

        [Required]
        public string? DisplayType { get; set; }

        [Required]
        public int? Ram { get; set; }

        [Required]
        public string Resolution { get; set; }

        [Required]
        public string Processor { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        public string Url { get; set; }

        [Display(Name = "Brands")]
        public int BrandId { get; set; }

        public IEnumerable<MobilePhoneBrandViewCategory> Brands { get; set; }
    }
}
