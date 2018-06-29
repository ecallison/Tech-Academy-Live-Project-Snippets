                //Adding default user to admin role
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            catch (System.Exception)
            {
                
            }    
                   
            //Creating User Role
            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole
                {
                    Name = "User"
                };
                roleManager.Create(role);
            }
            try //or??
            {
                var user = new ApplicationUser
                {
                    FirstName = "Alex",
                    LastName = "Smith",
                    HireDate = System.DateTime.Today,
                    Department = "Develoment",
                    Position = "Software Development",
                    Address = "3123 Portland Ct",
                    HourlyPayRate = 20,
                    Fulltime = true,
                    Email = "alex@gmail.com",
                    PhoneNumber = "123-231-2255",
                    UserName = "alex@gmail.com"
                };



                string userPassword = "Password1!";
                var chkUser = UserManager.Create(user, userPassword);

                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "User");
                }
            }
            catch (System.Exception)
            {

            }

        }