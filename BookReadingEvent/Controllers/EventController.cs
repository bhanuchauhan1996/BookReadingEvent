using DataAccess.Models;
using Services.IRepository;
using Services.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace BookReadingEvent.Controllers
{
    /// <summary>
    /// This controller deals with event operations
    /// </summary>
    public class EventController : Controller
    {
      
        private DatabaseContext databaseContext = new DatabaseContext();
        private IEvent Ievent;
        
        /// <summary>
        /// Constructor used to initialize Interface
        /// </summary>
        /// <param name="event"></param>
        public EventController(IEvent @event)
        {
            Ievent = @event;
           
        }

        /// <summary>
        /// Allocate memory to the Repository
        /// </summary>
        public EventController()
        {
            Ievent = new EventRepo();
           
        }

        /// <summary>
        /// Get the List of all events
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                
                    List<Event> @event = databaseContext.Events.ToList();
                    return View(@event);
               
            }
            catch(NullReferenceException )
            {
                return null;  
            }
            
          
        }
        
        /// <summary>
        /// GET: list of all the event which can be edited by the current logged in user.No user can edit any event
        /// </summary>
        /// <returns></returns>
        public ActionResult EditIndex()
        {
            List<Event> @futureevent = databaseContext.Events.Where(start => start.EventDate > DateTime.Now && start.UserId.ToString()== HttpContext.User.Identity.Name).ToList();

            return View(futureevent);
        }

        /// <summary>
        /// Get: List of event which can be edit by the admin. Admin can edit event of any user.
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminEdit()
        {
            List<Event> @event = databaseContext.Events.Where(start => start.EventDate > DateTime.Now).ToList();

            return View("EditIndex",@event);

        }

        /// <summary>
        /// Get: list of event created by the logged in user.
        /// </summary>
        /// <returns></returns>
        public ActionResult MyEvent()
        {
            List<Event> myevent = databaseContext.Events.Where(x => x.UserId.ToString()== HttpContext.User.Identity.Name).ToList();

            return View(myevent);

        }

        /// <summary>
        /// GET:list of events all the upcoming and past event dynamically.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Home()
        {
            dynamic dynamic = new ExpandoObject();
            dynamic.PastEventViewModel = Ievent.GetpastEvent();
            dynamic.FutureEventViewModel = Ievent.GetfutureEvent();
           
            return View(dynamic);
        }
       
        /// <summary>
        /// GET: Details of the event whose id is given
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            Event @event = databaseContext.Events.Single(eventid => eventid.Id == id);
            return View(@event);
        }

        /// <summary>
        /// Get: create view to create the new event
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Post: the details to the database
        /// </summary>
        /// <param name="event"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event @event,string str)
        {
           
            if (ModelState.IsValid)
                {
                Ievent.AddEvent(@event,HttpContext.User.Identity.Name);
               
                return RedirectToAction("Home", "Event");
                }
                return View();
            
            }
        /// <summary>
        /// get the event to be edited
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
                // GET: Event/Edit/5
                public ActionResult Edit(int id)
                {
                Event @event = databaseContext.Events.Single(eventid => eventid.Id == id);
                return View(@event);
            
                 }

        /// <summary>
        /// Post: the event details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int id)
        {
            try
            {
                Event @event = databaseContext.Events.Single(eventid => eventid.Id == id);
                UpdateModel(@event, new string[] { "Id", "Title", "EventDate", "EventLocation", "StartTime", "EventType", "Duration", "EventDescription", "OtherDetails", "Invite" });
                Ievent.UpdateEvent(@event);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// get the event invite for logged in user
        /// </summary>
        /// <returns></returns>
        public ActionResult EventInvite()
        {
            string userid = HttpContext.User.Identity.Name;
            int id = int.Parse(userid);
         List <Event> @event =  Ievent.GetEventInvite(id);
            return View(@event);

        }

    }
}
