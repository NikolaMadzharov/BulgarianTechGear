namespace BulgarianTechGear.Models.MobilePhones
{
    public class AllPhonesQueryModel
    {
        public IEnumerable<MobilePhoneListingViewModel> Phones { get; set; }

        public IEnumerable<string> Brands { get; set; }

        public IEnumerable<string> SearchTerm { get; set; }

        public PhoneSorting Sorting { get; set; }
    }
}
