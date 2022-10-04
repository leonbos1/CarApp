using Microsoft.AspNetCore.Mvc;
using CarApp.Models;
using System.Diagnostics;

namespace CarApp.Controllers
{
    public class CarsController : Controller
    {

        private static List<CarsViewModel> cars = new List<CarsViewModel>();
        public IActionResult Index()
        {

            return View(cars);
        }

        public IActionResult Create()
        {
            var CarsViewModel = new CarsViewModel();
            return View(CarsViewModel);
        }

        public IActionResult CreateCar(CarsViewModel carsViewModel)
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
