        public ActionResult ViewUserDetails(string id)
        {
            var userId = id;
            var user = db.Users.Where(w => w.Id == userId).First();
            UserDetailsViewModel userDetails = new UserDetailsViewModel(user.FirstName, user.LastName, user.Address, user.HireDate.ToShortDateString(), user.Department, user.Position, user.HourlyPayRate, user.Fulltime);
            return PartialView("_ViewUserDetails", userDetails);
        }
        // GET: /Employer/User/Register
        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
            ViewBag.Name = new SelectList(db.Roles.ToList(), "", "Name");

            return View();
        }

        // POST: /Employer/User/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Department = model.Department,
                    Position = model.Position,
                    Address = model.Address,
                    HireDate = model.HireDate,
                    HourlyPayRate = model.HourlyPayRate,
                    Fulltime = model.Fulltime
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var addRole = UserManager.AddToRole(user.Id, model.UserRoles);
                    //load index of users after user is registered.
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }
            // If we got this far, something failed, redisplay form
            return View();
        }

        [HttpGet]
        public ActionResult Edit(string Id)
        {
            ViewBag.Name = new SelectList(db.Roles.ToList(), "", "Name");

            //switched these for testing purposes.
            ApplicationUser dataUser = new ApplicationUser();
            dataUser = db.Users.Where(x => x.Id == Id).First();
            //this is just pulling the first user from the database. This is a dummy account.
            RegisterViewModel rv = new RegisterViewModel();
            rv.PhoneNumber = dataUser.PhoneNumber;
            rv.FirstName = dataUser.FirstName;
            rv.LastName = dataUser.LastName;
            rv.UserName = dataUser.UserName;
            rv.Department = dataUser.Department;
            rv.Position = dataUser.Position;
            rv.Address = dataUser.Address;
            rv.HourlyPayRate = dataUser.HourlyPayRate;
            rv.HireDate = dataUser.HireDate;
            rv.Email = dataUser.Email;
            if (dataUser == null)
            {
                return HttpNotFound();
            }

            return View("Edit", rv);

        }

        // POST: Update/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult EditPost(RegisterViewModel model, string Id)
        {
            var userToUpdate = db.Users.Where(x => x.Id == Id).First();

            if (TryUpdateModel(userToUpdate, "", new string[] { "FirstName", "LastName", "UserName", "PhoneNumber", "Department", "Position", "Address", "HourlyPayRate", "Email", "HireDate", "Fulltime" }))
            {
                ApplicationDbContext db = new ApplicationDbContext();

                try
                {
                    var removeRole = UserManager.RemoveFromRole(userToUpdate.Id, model.UserRoles);
                    var addRole = UserManager.AddToRole(userToUpdate.Id, model.UserRoles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {

                    ModelState.AddModelError("", "Unable to save changes");
                }
            }
            return View(userToUpdate);
        }
