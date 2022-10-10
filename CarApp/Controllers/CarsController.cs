using Microsoft.AspNetCore.Mvc;
using CarApp.Models;
using System.Diagnostics;

namespace CarApp.Controllers
{
    public class CarsController : Controller
    {

        private static List<CarViewModel> cars = new List<CarViewModel>();
        private EmpDBContext db = new EmpDBContext();
     
        public IActionResult Index()
        {

            var cars = from car in db.Cars
                        orderby car.Id
                        select car;

            return View(cars);
        }

        public IActionResult Create()
        {
            var CarsViewModel = new CarViewModel();
            return View(CarsViewModel);
        }

        public IActionResult CreateCar(CarViewModel carsViewModel)
        {
            Random random = new Random();
            carsViewModel.Id = random.Next(100000000);

            try
            {
                db.Cars.Add(carsViewModel);
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
            CarViewModel car = db.Cars.Where(d => d.Id == id).First();
            db.Cars.Remove(car);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}
