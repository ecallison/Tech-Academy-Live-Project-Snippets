namespace ScheduleUsers.Models
{
    /// <summary>
    /// Individual schedules for employees
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Identify each employee schedule using a unique ScheduleID
        /// </summary>
        [Key]
        public Guid ScheduleID { get; set; }
        /// <summary>
        /// Notes for pertinent information regarding employee schedules
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Timestamp the day the work period starts
        /// </summary>
        public DateTime ScheduleStartDay { get; set; }
        /// <summary>
        /// List of individual work periods for employee
        /// </summary>
        public List<WorkPeriod> workPeriods { get; set; }
        /// <summary>
        /// Registered employee user account
        /// </summary>
        public virtual ApplicationUser User { get; set; }
    }
}