namespace BulgarianTechGear.Infrastructure
{
    using BulgarianTechGear.Data;
    using BulgarianTechGear.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {

            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<BulgarianTechGearDbContext>();

            data.Database.Migrate();

            SeedModels(data);

            return app;
            // app.ApplicationServices.GetService<ApplicationDbContext>()



        }

        private static void SeedModels(BulgarianTechGearDbContext data)
        {
            if (data.MobilePhoneBrands.Any())
            {
                return;
            }
            data.MobilePhoneBrands.AddRange(new[]
                                          {
                                              new MobilePhoneBrand{Brand = "Apple"},
                                              new MobilePhoneBrand{Brand = "Samsung"},
                                              new MobilePhoneBrand{Brand = "Huawei"},

                                          });
            data.SaveChanges();
        }
    }
}
