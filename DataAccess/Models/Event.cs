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
    /// <summary>
    /// This class contains Event Related Information.
    /// </summary>
    [Table("Event")]
    public  class Event
    {
        /// <summary>
        /// It represents Event Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// It represents Title of the event.
        /// </summary>
        [Required]
        [RegularExpression("^[a-zA-Z\\s]{3,20}$", ErrorMessage = "Please enter string only.")]
        public string Title { get; set; }

        /// <summary>
        /// It represents Date of Event.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Event")]
        [MaxEventDateValidator]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// It represents Event Location.
        /// </summary>
        [Required]
        [Display(Name = "Location")]
        public string EventLocation { get; set; }

        /// <summary>
        /// It represent Schedule time of event.
        /// </summary>
        [Display(Name = "Start Time(in 24 hr) ")]
        [Required]
        public string StartTime { get; set; }

        /// <summary>
        /// It represents Type of event .
        /// </summary>
        [Required]
        [Display(Name = "Type")]
        public string EventType { get; set; }

        /// <summary>
        /// It represents Event Duration.
        /// </summary>
        [Required]
        [Display(Name ="Duration(in hr)")]
        public int Duration { get; set; }

        /// <summary>
        /// It represents description of event.
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Display(Name = "Description")]
        public string EventDescription { get; set; }

        //[Required]
        /// <summary>
        /// It represents other details of the Invite.
        /// </summary>
        [Display(Name = "Other Details")]
        [MaxLength(500)]
        public string OtherDetails { get; set; }

        /// <summary>
        /// It represents Invited people in the event.
        /// </summary>
        public string Invite { get; set; }

        /// <summary>
        /// It represents user id of user who created that event.
        /// </summary>
        public int UserId { get; set; }


    }
}
