using BookReadingEvent.Library;
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
    /// <summary>
    /// This Controller will handle login related operation
    /// </summary>
    [AllowAnonymous]
    public class LoginController : Controller
    {
       
        private DatabaseContext databaseContext = new DatabaseContext();
        IEvent Ievent;
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        public LoginController(IEvent @event)
        {
            Ievent = @event;
            

        }
        /// <summary>
        /// 
        /// </summary>
        public LoginController()
        {
            Ievent = new EventRepo();
            

        }

        /// <summary>
        /// get login form
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// post login data
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
           // try
            //{

                using (var context = new DatabaseContext())
                {

                    bool isValid = context.Registrations.Any(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);
                    if (isValid)
                    {
                        Registration registrations = context.Registrations.Single(x => x.Email == loginViewModel.Email);

                        FormsAuthentication.SetAuthCookie(registrations.UserId.ToString(), false);
                        return RedirectToAction("Home", "Event");
                    }

                    ModelState.AddModelError("", "Invalid username and password");
                    return View();
                }
            //}
            //catch(InvalidOperationException)
            //{
            //    return View();
            //}
        }
        /// <summary>
        /// logout from application
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        

    }
}