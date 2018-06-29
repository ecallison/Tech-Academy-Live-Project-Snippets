     return RedirectToAction("Index","WorkTimeEvent");
        }
        //Removed code below 
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        //Removed code above
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";