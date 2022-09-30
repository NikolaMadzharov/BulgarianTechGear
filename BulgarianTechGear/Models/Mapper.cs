namespace BulgarianTechGear.Models

{
    using AutoMapper;

    using BulgarianTechGear.Models.MobilePhone;

    public class Mapper:Profile
    {
        public Mapper()
        {

            CreateMap<Data.Models.MobilePhone, AddMobilePhoneFromModel>();

        }
    }
}
