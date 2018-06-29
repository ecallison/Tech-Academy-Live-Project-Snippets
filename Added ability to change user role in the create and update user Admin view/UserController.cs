  // POST: Update/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult EditPost(RegisterViewModel rvm)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var userToUpdate = db.Users.Find(rvm.Id);

            var removeRole = UserManager.RemoveFromRole(userToUpdate.Id, userToUpdate.Roles.ToString());

            var addRole = UserManager.AddToRole(userToUpdate.Id, rvm.UserRoles);


            if (ModelState.IsValid)
            {
                userToUpdate = new ApplicationUser
                {
                    UserName = rvm.UserName,
                    Email = rvm.Email,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    PhoneNumber = rvm.PhoneNumber,
                    Department = rvm.Department,
                    Position = rvm.Position,
                    Address = rvm.Address,
                    HireDate = rvm.HireDate,
                    HourlyPayRate = rvm.HourlyPayRate,
                    Fulltime = rvm.Fulltime
                };
            }