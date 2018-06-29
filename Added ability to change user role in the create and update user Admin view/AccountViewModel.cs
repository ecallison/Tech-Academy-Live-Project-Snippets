public class RegisterViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "User Roles")]
        public string UserRoles { get; set; }