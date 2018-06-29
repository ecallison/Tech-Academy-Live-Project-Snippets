 /// Wage of the user.
        /// </summary>
        [Display(Name = "Hourly Pay Rate")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Please enter valid decimal number with maximum 2 decimal places (example: 25.00 or 25.0 rather than $25).")]
        [Range(0, 9999999999999999.99)]
        public decimal HourlyPayRate { get; set; }
