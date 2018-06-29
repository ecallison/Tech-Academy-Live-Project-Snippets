using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScheduleUsers.Models
{
    /// <summary>
    /// Individual periods of time within a schedule
    /// </summary>
    public class WorkPeriod
    {
        /// <summary>
        /// WorkPeriod Id Guid for each work period
        /// </summary>

        public string Id { get; set; }
        ///// <summary>
        ///// What day does this work period begin
        ///// </summary>
        public enum Day { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        /// <summary>
        /// Start time for this work period - 24 hours format
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public string StartTime { get; set; }
        /// <summary>
        /// End time for this work period - 24 hours format
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public string EndTime { get; set; }
        /// <summary>
        /// List of possible roles in company
        /// </summary>
        public List<string> WorkType { get; set; }
        /// <summary>
        /// Decimal pay rate for each specific position
        /// </summary>
        /// 
        public string ScheduleId { get; set; }
        public decimal PayRate { get; set; }
        public virtual Schedule Schedule { get; set; }

        public WorkPeriod()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}