using CarApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    public class UserController : Controller
    {
        private static List<UserModel> users = new List<UserModel>();
        
        public IActionResult Index()
        {
            
            return View(users);
        }

        public IActionResult Create()
        {
            var userModel = new UserModel();
            return View(userModel);
        }

        public IActionResult CreateUser(UserModel userModel)
        {
            Random random = new Random();
            userModel.Id = random.Next(100000000);
            users.Add(userModel);
            return RedirectToAction(nameof(Create));

        }
    }
}
