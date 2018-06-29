 				timeOffEvent.User = db.Users.Where(w => w.Id == userid).First();
                timeOffEvent.EventID = Guid.NewGuid();
                db.TimeOffEvents.Add(timeOffEvent);
                timeOffEvent.SubmittedOn = DateTime.Now;
                db.SaveChanges();
                return new EmptyResult();
            }
