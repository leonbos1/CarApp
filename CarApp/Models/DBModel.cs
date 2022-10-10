using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarApp.Models
{
    public class DBModel
    {

    }

    public class EmpDBContext : DbContext
    {
        public EmpDBContext()
        {

        }
        public DbSet<Car> Car { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<Auction> Auction { get; set; }


    }


    public class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
    }

    public class Car
    {
        
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string LincensePlate { get; set; }
        public string Engine { get; set; }
        public int BuildYear { get; set; }
        public string bodyType { get; set; }
        
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

    }

    public class Auction
    { 
        public int AuctionId { get; set; }

        
        public Car Car { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public int Price { get; set; }
    }

    public class CarAuction
    {
        public Car Car { get; set; }
        public Auction Auction { get; set; }
        public User User { get; set; }
    }


}
