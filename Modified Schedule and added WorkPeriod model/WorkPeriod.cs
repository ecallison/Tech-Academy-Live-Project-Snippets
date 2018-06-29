using System;
using System.Collections.Generic;
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
        //public string ScheduleId { get; set; }
        ///// <summary>
        ///// What day does this work period begin
        ///// </summary>
        public enum Day { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        /// <summary>
        /// Start time for this work period - 24 hours format
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// End time for this work period - 24 hours format
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// List of possible roles in company
        /// </summary>
        public List<string> WorkType { get; set; }
        /// <summary>
        /// Decimal pay rate for each specific position
        /// </summary>
        public decimal PayRate { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}