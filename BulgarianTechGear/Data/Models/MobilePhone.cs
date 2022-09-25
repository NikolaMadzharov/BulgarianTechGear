namespace BulgarianTechGear.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MobilePhone
    {
      
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int PixelsFrontCamera { get; set; }

        [Required]
        public int PixelsBackCamera { get; set; }

        [Required]
        public int Memory { get; set; }

        [Required]
        public double DisplaySizeInch { get; set; }

        [Required]
        public double BatteryCapacity { get; set; }

        [Required]
        public string DisplayType { get; set; }

        [Required]
        public int Ram { get; set; }

        [Required]
        public string Resolution { get; set; }

        [Required]
        public string Processor { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        public int MobilePhoneBrandId { get; set; }

        public MobilePhoneBrand MobilePhoneBrand { get; set; }

        
    }
}
