using ScheduleUsers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleUsers.Models
{
    /// <summary>
    /// Individual schedules for employees
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Identify each employee schedule using a unique Schedule Id
        /// </summary>
        public string Id { get; set; }
        //public string ApplicationUserId { get; set; }
        /// <summary>
        /// Notes for pertinent information regarding employee schedules
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Specify day the work period starts
        /// </summary>
        public DateTime ScheduleStartDay { get; set; }
        /// <summary>
        /// List of individual work periods for employee
        /// </summary>
        public virtual List<WorkPeriod> workPeriods { get; set; }
        /// <summary>
        /// Registered employee user account
        /// </summary>
        public virtual ApplicationUser User { get; set; }
    }
}