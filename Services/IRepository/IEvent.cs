using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IRepository
{
    /// <summary>
    /// This Interface is contains event related method
    /// </summary>
   public interface IEvent
    {
        /// <summary>
        /// This function is used to add event in the database which accepts two parameter.
        /// </summary>
        /// <param name="events"></param>
        /// <param name="str"></param>
        void AddEvent(Event events,string str);

        /// <summary>
        /// Used to update the event details given by users.
        /// </summary>
        /// <param name="events"></param>
         void UpdateEvent(Event events);

        /// <summary>
        /// Used to fetch the completed event
        /// </summary>
        /// <returns></returns>
        List<Event> GetpastEvent();

        /// <summary>
        /// Used to fetch the upcoming events
        /// </summary>
        /// <returns></returns>
         List<Event> GetfutureEvent();

        /// <summary>
        /// Used to fetch the event in which user is invited
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Event> GetEventInvite(int id);
         

    }
}
