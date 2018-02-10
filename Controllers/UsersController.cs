using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using owdrafter.Models;

namespace owdrafter.Controllers
{
    public class UsersController : Controller
    {
        private DrafterDbContext _context;

        public UsersController(DrafterDbContext context){
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.users.ToList());
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                _context.users.Add(user);
                _context.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = user.Username + " succesfully registered.";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var account = _context.users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UserID", account.UserId.ToString());
                HttpContext.Session.SetString("Username", account.Username);
                return RedirectToAction("Welcome");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is wrong.");
            }
            return View();
        }

        public ActionResult Welcome()
        {
            if (HttpContext.Session.GetString("UserID") != null)
            {
                ViewBag.Username = HttpContext.Session.GetString("Username");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}