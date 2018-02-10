using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using owdrafter.Models;

namespace owdrafter.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                using (DrafterDbContext db = new DrafterDbContext())
                {
                    db.users.Add(user);
                    db.SaveChanges();
                }
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
            using(DrafterDbContext db = new DrafterDbContext())
            {
                var usr = db.users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if( usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["Username"] = usr.Username.ToString();

                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is wrong.");
                }    
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
                return RedirectToAction("Login");
        }
    }
}