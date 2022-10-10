using Microsoft.AspNetCore.Mvc;
using CarApp.Models;
using System.Diagnostics;

namespace CarApp.Controllers
{
    public class CarsController : Controller
    {

        private static List<Car> cars = new List<Car>();
        private EmpDBContext db = new EmpDBContext();
     
        public IActionResult Index()
        {

            var auctions = (from a in db.Auction

                            join c in db.Car on a.CarId equals c.CarId
                            join u in db.User on c.UserId equals u.UserId

                           select new CarAuction
                           {
                               Auction = a,
                               Car = c,
                               User = u
                           }).ToList();


            return View(auctions);
        }

        public IActionResult Create()
        {
            var CarsViewModel = new Car();
            return View(CarsViewModel);
        }

        public IActionResult CreateCar(Auction auction)
        {
            Random random = new Random();
            auction.AuctionId = random.Next(100000000);

            try
            {
                db.Auction.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

   
        }

        public IActionResult BuyCar(int id)
        {
            Car car = db.Car.Where(d => d.CarId == id).First();
            db.Car.Remove(car);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}
