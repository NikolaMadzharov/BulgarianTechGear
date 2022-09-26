namespace BulgarianTechGear.Models.MobilePhones
{
    using System.ComponentModel.DataAnnotations;

    public class AllPhonesQueryModel
    {
        public List<MobilePhoneListingViewModel> Phones { get; set; }

        public IEnumerable<string> Brands { get; set; }
        [Display(Name = "Search")]
        public string SearchTerm { get; set; }

        public PhoneSorting Sorting { get; set; }
    }
}
