﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace grupoesparza.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
 
    }
}