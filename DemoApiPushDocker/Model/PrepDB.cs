using Microsoft.AspNetCore.Builder;

namespace DemoApiPushDocker.Model
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            SeedData(serviceScope.ServiceProvider.GetService<ColourContext>());
        }

        public static void SeedData(ColourContext context)
        {
            Console.WriteLine("Appling Migrations...");
            context.Database.Migrate();

            if (!context.ColourItems.Any())
            {
                Console.WriteLine("Adding data - seeding...");
                context.ColourItems.AddRange(
                    new Colour { ColourName = "red" },
                    new Colour { ColourName = "yellow" },
                    new Colour { ColourName = "green" }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data - not seeding");
            }
        }

    }
}
