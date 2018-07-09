  [HttpPost]
        [AllowAnonymous]
        public ActionResult ProcessUserClockIn(LoginViewModel lvm, string updateInfo)
        {
            PasswordHasher ph = new PasswordHasher();
            var dt = DateTime.Now;

            // Checks Db users for email that matches the email user typed in
            ApplicationUser dbUser = db.Users.FirstOrDefault(x => x.Email == lvm.Email);

            //Verify User
            var result = ph.VerifyHashedPassword(dbUser.PasswordHash, lvm.Password);

            //If verification failed
            if (result != PasswordVerificationResult.Success && dbUser != null)
            {
                return Json(new ClockInViewModel());
            }
            //If verification succeeded
            else
            {
                switch (updateInfo)
                {

                    case "Clock In": //When user first clicks clock in button - provide information for modal
                        return Json(new ClockInViewModel(dbUser));

                    case "Clock Out": // User is currently clocked in
                        var finishedEvent = db.WorkTimeEvents.FirstOrDefault(x => x.Id == dbUser.Id && !x.End.HasValue);

                        return Json(new ClockInViewModel(finishedEvent));

                    //User confirms that they want to clock in and has option to enter note
                    case "Confirm Clock In":
                    case "Confirm Clock Out":

                        using (WorkTimeEventController wtc = new WorkTimeEventController())
                        {
                            string confirmedClockIn = wtc.Create(lvm);
                        }
                        return Json(new ClockInViewModel(true));

                    case "Log In":
                        bool? loginResult = LoginUser(lvm);
                        ClockInViewModel cvm = new ClockInViewModel()
                        {
                            LoggingIn = loginResult
                        };

                        return Json(cvm);
                }
            }
            return Json(new ClockInViewModel());
        }
