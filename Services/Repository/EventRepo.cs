using DataAccess.Models;
using Services.IRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Services.Repository
{
    /// <summary>
    /// This class implement the Event Interface.
    /// </summary>
    public class EventRepo : IEvent
    {
       private string connectionString =
                   ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;
        private DatabaseContext databaseContext;

        /// <summary>
        /// Parameterized constructor to initialize database
        /// </summary>
        /// <param name="databaseContext"></param>
        public EventRepo(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        /// <summary>
        /// Default constructor to allocate memory to database object.
        /// </summary>
        public EventRepo()
        {
            databaseContext = new DatabaseContext();
            
        }
        /// <summary>
        /// This function is used to add event in the database which accepts two parameter.
        /// </summary>
        /// <param name="events"></param>
        /// <param name="str"></param>
        public void AddEvent(Event events,string str)
        {
           

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEvent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Title";
                paramName.Value = events.Title;
                cmd.Parameters.Add(paramName);

                SqlParameter paramDate = new SqlParameter();
                paramDate.ParameterName = "@Date";
                paramDate.Value = events.EventDate;
                cmd.Parameters.Add(paramDate);

                SqlParameter paramLocation = new SqlParameter();
                paramLocation.ParameterName = "@Location";
                paramLocation.Value = events.EventLocation;
                cmd.Parameters.Add(paramLocation);

                SqlParameter paramStartTime = new SqlParameter();
                paramStartTime.ParameterName = "@Starttime";
                paramStartTime.Value = events.StartTime;
                cmd.Parameters.Add(paramStartTime);

                SqlParameter paramEventType = new SqlParameter();
                paramEventType.ParameterName = "@Type";
                paramEventType.Value = events.EventType;
                cmd.Parameters.Add(paramEventType);

                SqlParameter paramDuration = new SqlParameter();
                paramDuration.ParameterName = "@Duration";
                paramDuration.Value = events.Duration;                      
                cmd.Parameters.Add(paramDuration);

                SqlParameter paramDescription = new SqlParameter();
                paramDescription.ParameterName = "@Description";
                paramDescription.Value = events.EventDescription;
                cmd.Parameters.Add(paramDescription);

                SqlParameter paramOtherdetails = new SqlParameter();
                paramOtherdetails.ParameterName = "@Otherdetails";
                paramOtherdetails.Value = events.OtherDetails;
                cmd.Parameters.Add(paramOtherdetails);

                SqlParameter paramInvite = new SqlParameter();
                paramInvite.ParameterName = "@Invite";
                paramInvite.Value = events.Invite;
                cmd.Parameters.Add(paramInvite);

                SqlParameter paramUserId = new SqlParameter();
                paramUserId.ParameterName = "@UserId";
                paramUserId.Value = str;
                cmd.Parameters.Add(paramUserId);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Used to update the event details given by users.
        /// </summary>
        /// <param name="events"></param>
        public void UpdateEvent(Event events)
        {
            

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEvent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = events.Id;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Title";
                paramName.Value = events.Title;
                cmd.Parameters.Add(paramName);

                SqlParameter paramDate = new SqlParameter();
                paramDate.ParameterName = "@Date";
                paramDate.Value = events.EventDate;
                cmd.Parameters.Add(paramDate);

                SqlParameter paramLocation = new SqlParameter();
                paramLocation.ParameterName = "@Location";
                paramLocation.Value = events.EventLocation;
                cmd.Parameters.Add(paramLocation);

                SqlParameter paramStartTime = new SqlParameter();
                paramStartTime.ParameterName = "@Starttime";
                paramStartTime.Value = events.StartTime;
                cmd.Parameters.Add(paramStartTime);

                SqlParameter paramEventType = new SqlParameter();
                paramEventType.ParameterName = "@Type";
                paramEventType.Value = events.EventType;
                cmd.Parameters.Add(paramEventType);

                SqlParameter paramDuration = new SqlParameter();
                paramDuration.ParameterName = "@Duration";
                paramDuration.Value = events.Duration;
                cmd.Parameters.Add(paramDuration);

                SqlParameter paramDescription = new SqlParameter();
                paramDescription.ParameterName = "@Description";
                paramDescription.Value = events.EventDescription;
                cmd.Parameters.Add(paramDescription);

                SqlParameter paramOtherdetails = new SqlParameter();
                paramOtherdetails.ParameterName = "@Otherdetails";
                paramOtherdetails.Value = events.OtherDetails;
                cmd.Parameters.Add(paramOtherdetails);

                SqlParameter paramInvite = new SqlParameter();
                paramInvite.ParameterName = "@Invite";
                paramInvite.Value = events.Invite;
                cmd.Parameters.Add(paramInvite);


                con.Open();
                cmd.ExecuteNonQuery();
            }
            
        }

        /// <summary>
        /// Used to fetch the completed event
        /// </summary>
        /// <returns></returns>
        public List<Event> GetpastEvent()
        {
            List<Event> events = databaseContext.Events.Where(start => start.EventDate < DateTime.Now).ToList();
            return events;
        }

        /// <summary>
        /// Used to fetch the upcoming events
        /// </summary>
        /// <returns></returns>
        public List<Event> GetfutureEvent()
        {
            List<Event> events = databaseContext.Events.Where(start => start.EventDate > DateTime.Now).ToList();
            return events;
        }

        /// <summary>
        /// Used to fetch the event in which user is invited
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Event> GetEventInvite(int id)
        {
            string email = databaseContext.Registrations.Single(x => x.UserId == id).Email;
            var result = from a in databaseContext.Events select (a.Invite);

            string[] strInvite = databaseContext.Events.AsEnumerable().Select(s => s.Invite).ToArray<string>();
            List<Event> eventinvite=null;
            for (int i = 0; i < strInvite.Length; i++)
            {
                if (strInvite[i] != null)
                {
                    string[] invite = strInvite[i].Split(',');
                    for (int j = 0; j < invite.Length; j++)
                    {
                        if (invite[j] == email)
                        {
                            string check = invite[j];
                          eventinvite = databaseContext.Events.Where(x => x.Invite.Contains(check)).ToList();

                            return eventinvite;
                        }
                    }
                }
            }
            return eventinvite;
        }

    }
}
