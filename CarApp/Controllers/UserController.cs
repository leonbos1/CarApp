using CarApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    public class UserController : Controller
    {
        private EmpDBContext db = new EmpDBContext();

        public IActionResult Index()
        {
            var users = from user in db.Users
            orderby user.Id
            select user;

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

            try
            {
                db.Users.Add(userModel);
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
