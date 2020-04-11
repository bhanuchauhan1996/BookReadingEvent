using DataAccess.Models;
using Services.IRepository;
using Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookReadingEvent.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private DatabaseContext databaseContext = new DatabaseContext();
        IEvent Ievent;
        public LoginController(IEvent @event)
        {
            Ievent = @event;


        }
        public LoginController()
        {
            Ievent = new EventRepo();


        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            bool isValid = databaseContext.Registrations.Any(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);
            if (isValid)
            {
                Registration registrations = databaseContext.Registrations.Single(x => x.Email == loginViewModel.Email);

                FormsAuthentication.SetAuthCookie(registrations.UserId.ToString(), true);
                return RedirectToAction("Home", "Event");
            }

            ModelState.AddModelError("", "Invalid username and password");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}