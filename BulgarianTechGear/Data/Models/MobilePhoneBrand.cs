namespace BulgarianTechGear.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MobilePhoneBrand
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        public IEnumerable<MobilePhone> MobilePhones { get; set; } = new HashSet<MobilePhone>();
    }
}
