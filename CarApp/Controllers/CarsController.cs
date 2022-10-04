using Microsoft.AspNetCore.Mvc;
using CarApp.Models;
using System.Diagnostics;

namespace CarApp.Controllers
{
    public class CarsController : Controller
    {

        private static List<CarViewModel> cars = new List<CarViewModel>();
        public IActionResult Index()
        {

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
            cars.Add(carsViewModel);
            return RedirectToAction(nameof(Create));
            //return View("Index");
        }

        public IActionResult BuyCar(int id)
        {
            foreach (var car in cars)
            {
                if (car.Id == id)
                {
                    cars.Remove(car);
                    break;
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
