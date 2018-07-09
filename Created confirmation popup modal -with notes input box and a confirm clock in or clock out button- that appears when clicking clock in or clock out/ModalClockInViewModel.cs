using Microsoft.AspNet.Identity.Owin;
using ScheduleUsers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScheduleUsers.ViewModels
{
    public class ClockInViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Check if username and password are valid.
        /// </summary>
        public bool ValidCredentials { get; set; }

        /// <summary>
        /// Determines whether the user is clocking in or out.
        /// </summary>
        public bool? ClockingIn { get; set; }

        /// <summary>
        /// Determines whether the user is clicking the log in button or not.
        /// </summary>
        public bool? LoggingIn { get; set; }

        /// <summary>
        /// Allows user to enter a message
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Check if username and password are valid.
        /// </summary>
        public string InfoError { get; set; }

        //On initial clock in click and on log in click
        public ClockInViewModel(ApplicationUser applicationUser)
        {
            this.FirstName = applicationUser.FirstName;
            this.LastName =  applicationUser.LastName;
            this.Note = "";
            this.ClockingIn = true;
            this.ValidCredentials = true;
        }
        //On intial clock out
        public ClockInViewModel(WorkTimeEvent workTimeEvent)
        {
            this.LoggingIn = null;
            this.ClockingIn = false;
            this.FirstName = workTimeEvent.User.FirstName;
            this.LastName = workTimeEvent.User.LastName;
            this.ValidCredentials = true;
            this.Note = workTimeEvent.Note;
        }

        //On confirm clock in
        public ClockInViewModel(bool verified)
        {
            this.ClockingIn = null;
            this.LoggingIn = null;
            this.ValidCredentials = true;
        }

        //Verification Failed
        public ClockInViewModel()
        {
            this.LoggingIn = false;
            this.ValidCredentials = false;
            this.InfoError = "There was a problem with the password or username, please try again or contact you system administrator if the problem continues.";
        }
    }
}