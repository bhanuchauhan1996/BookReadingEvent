using DataAccess.Models;
using Services.IRepository;
using Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReadingEvent.Controllers
{
    /// <summary>
    /// Perform Registration for users
    /// </summary>
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private DatabaseContext databaseContext = new DatabaseContext();
        IRegistration Iregistration;
        IRole Irole;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registration"></param>
        /// <param name="role"></param>
        public RegistrationController(IRegistration registration, IRole role)
        {
            Iregistration = registration;
            Irole = role;


        }
        /// <summary>
        /// 
        /// </summary>
        public RegistrationController()
        {
            Iregistration = new RegistrationRepo();
            Irole = new RoleRepo();
        }
       /// <summary>
       /// Get the list of all the users
       /// </summary>
       /// <returns></returns>
        public ActionResult Index()
        {
            List<Registration> @registration = databaseContext.Registrations.ToList();

            
            return View(registration);
           
        }

        /// <summary>
        /// get the registration form
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// post the form data into database for registration
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        
         public ActionResult Create(Registration registration)
        {
            var isEmailExist = Iregistration.CheckEmailExists(registration.Email);
            if(isEmailExist)
            {
                ModelState.AddModelError("", errorMessage: "Email Already used!! Try Unique One");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    Iregistration.AddUser(registration);

                    int userid = databaseContext.Registrations.Max(x => x.UserId);
                    Irole.AddRole(userid);

                    return RedirectToAction("Index", "Home");
                    
                }
            }
            
            return View();

        }

        /// <summary>
        /// Get from for editing user information
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            int id =int.Parse( User.Identity.Name);
            Registration @registration = databaseContext.Registrations.Single(userid => userid.UserId ==id );
            return View(registration);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post()
        {
            try
            {
                int id = int.Parse(User.Identity.Name);
                Registration @registration = databaseContext.Registrations.Single(userid => userid.UserId == id);
                UpdateModel(@registration, new string[] { "UserId", "Name", "Email", "Password"});
                Iregistration.UpdateUser(@registration);

                return RedirectToAction("Home","Event");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
