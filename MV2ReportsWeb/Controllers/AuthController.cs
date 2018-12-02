using MV2ReportsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using MV2ReportsWeb.CustomLibraries;

namespace MV2ReportsWeb.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
       public ActionResult Login(Users model)
        {
            if (!ModelState.IsValid) //Checks if input fields have the correct format
            {
                return View(model); //Returns the view with the input values so that the user doesn't have to retype again
            }
            using (var db = new MV2ReportsWebContext())
            {
                var getEmail = db.Users.Where(u => u.Email == model.Email).Select(u => u.Email);
                if (getEmail.FirstOrDefault() != null)
                {
                    var getPassword = db.Users.Where(u => u.Email == model.Email).Select(u => u.Password);
                    var materializePassword = getPassword.ToList();
                    var password = materializePassword[0];
                    var decryptedPassword = CustomDecrypt.Decrypt(password);
                    if (model.Email != null && model.Password == decryptedPassword)
                    {
                        var getName = db.Users.Where(u => u.Email == model.Email).Select(u => u.Name);
                        var materializeName = getName.ToList();
                        var name = materializeName[0];
                        var getCompany = db.Users.Where(u => u.Email == model.Email).Select(u => u.Company);
                        var materializeCompany = getCompany.ToList();
                        var company = materializeCompany[0];
                        var materializeEmail = getEmail.ToList();
                        var email = materializeEmail[0];
                        var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Email, email),
                    }, "ApplicationCookie");
                        var ctx = Request.GetOwinContext();
                        var authManager = ctx.Authentication;
                        authManager.SignIn(identity);
                        return RedirectToAction("Index", "MyReports");
                    }
                }
                else
                    return RedirectToAction("Registration", "auth");
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(model);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(Users model)
        {
            if (ModelState.IsValid)
                using (var db = new MV2ReportsWebContext())
                {
                    var queryUser = db.Users.FirstOrDefault(u => u.Email == model.Email);
                    if (queryUser == null)
                    {
                        var encryptedPassword = CustomEncrypt.Encrypt(model.Password);
                        var user = db.Users.Create();
                        user.Email = model.Email;
                        user.Password = encryptedPassword;
                        user.Name = model.Name;
                        user.Company = model.Company;
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        return RedirectToAction("Registration");
                    }
                }
            else
            {
                ModelState.AddModelError("", "Invalid registration");
            }
            return View(model);
        }
    }
}