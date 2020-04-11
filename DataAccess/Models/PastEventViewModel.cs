using DataAccess.CustomValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    //[NotMapped]
    public  class PastEventViewModel
    {
        public int Id { get; set; }


        public string Title { get; set; }

        
        [DataType(DataType.Date)]
        [Display(Name = "Date of Event")]
        public DateTime EventDate { get; set; }


        [Display(Name = "Location")]
        public string EventLocation { get; set; }

        [Display(Name = "Start Time(in 24 hr) ")]

        public string StartTime { get; set; }


        [Display(Name = "Type")]
        public string EventType { get; set; }


        [Display(Name = "Duration(in hr)")]
        public int Duration { get; set; }


        [Display(Name = "Description")]
        public string EventDescription { get; set; }


        [Display(Name = "Other Details")]

        public string OtherDetails { get; set; }

        public string Invite { get; set; }


    }
}
