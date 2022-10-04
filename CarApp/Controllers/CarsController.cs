using Microsoft.AspNetCore.Mvc;
using CarApp.Models;

namespace CarApp.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            CarsViewModel Car = new CarsViewModel()
            {
                Brand = "Porsche",
                Model = "911"
            };
            
            return View(Car);
        }

        public IActionResult Create()
        {
            return View();
        }
    }

}
