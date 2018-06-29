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
        /// What day does this work period begin
        /// </summary>
        enum Day { Sun, Mon, Tue, Wed, Thu, Fri, Sat };
        /// <summary>
        /// Start time for this work period - 24 hours format
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// End time for this work period - 24 hours format
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// List of possible positions in company
        /// </summary>
        public List<string> Roles { get; set; }
        /// <summary>
        /// WorkPeriodId Guid for each work period
        /// </summary>
        public Guid WorkPeriodID { get; set; }
        /// <summary>
        /// Decimal pay rate for each specific position
        /// </summary>
        public decimal PayRate { get; set; }
    }
}