    /// Identify each employee schedule using a unique Schedule Id
        /// </summary>
        public string Id { get; set; }
        [Display(Name = "Notes")]
        //public string ApplicationUserId { get; set; }
        /// <summary>
        /// Notes for pertinent information regarding employee schedules
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Specify day the work period starts
        /// </summary>
        [Display(Name = "Schedule Start Day")]
        //[DisplayFormat(DataFormatString = "{dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ScheduleStartDay { get; set; }
        /// <summary>
        /// List of individual work periods for employee
        /// </summary>
        [Display(Name = "Work Periods")]
        public virtual ICollection<WorkPeriod> workPeriods { get; set; }
        /// <summary>
        /// Registered employee user account
        /// </summary>
