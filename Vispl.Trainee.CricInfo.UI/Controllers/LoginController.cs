using System;
using Vispl.Trainee.CricInfo.VO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Vispl.Trainee.CricInfo.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Cls_Login_VO model)
        {
            if(ModelState.IsValid)
            {
                if(model.Username == "admin" && model.Password == "password")
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("LoginDashboard", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}