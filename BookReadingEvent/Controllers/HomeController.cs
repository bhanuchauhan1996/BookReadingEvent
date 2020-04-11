using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReadingEvent.Controllers
{/// <summary>
/// 
/// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Holds information for organization
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Book Reading Event .";

            return View();
        }

        /// <summary>
        /// contact related information
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "For any suport or query contact us.";

            return View();
        }
    }
}