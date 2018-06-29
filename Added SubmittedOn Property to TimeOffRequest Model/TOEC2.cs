  {
                timeOffEvent.EventID = Guid.NewGuid();
                db.TimeOffEvents.Add(timeOffEvent);
                timeOffEvent.SubmittedOn = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
