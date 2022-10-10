namespace CarApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CarApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CarApp.Models.EmpDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "CarApp.Models.EmpDBContext";
        }

        protected override void Seed(CarApp.Models.EmpDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            IList<User> users = new List<User>();

            users.Add(new User()
            {
                UserId = 4567456,
                Firstname = "Geert",
                Lastname = "Wilders",
                Age = 60
            });

            users.Add(new User()
            {
                UserId = 4527456,
                Firstname = "Mark",
                Lastname = "Rutte",
                Age = 47
            });

            IList<Car> cars = new List<Car>();

            cars.Add(new Car()
            {
                CarId = 34643,
                Brand = "Mercedes",
                Model = "A45",
                Engine = "2.0L 4cyl",
                BuildYear = 2020,
                bodyType = "Hatchback",
                UserId = 4527456
            });

            IList<Auction> auctions = new List<Auction>();

            auctions.Add(new Auction()
            {
                AuctionId = 346367,
                CarId = 34643,
                Price = 65000

            });



        }


    }
}
