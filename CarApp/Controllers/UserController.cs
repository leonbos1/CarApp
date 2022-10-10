using CarApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    public class UserController : Controller
    {
        private EmpDBContext db = new EmpDBContext();

        public IActionResult Index()
        {
            var users = from user in db.User
            orderby user.UserId
            select user;

            return View(users);
        }

        public IActionResult Create()
        {
            var userModel = new User();
            return View(userModel);
        }

        public IActionResult CreateUser(User userModel)
        {
            Random random = new Random();
            userModel.UserId = random.Next(100000000);

            try
            {
                db.User.Add(userModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}
