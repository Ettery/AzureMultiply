﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzureMultiply.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Azure Math!";
            ViewBag.HomeClass = "selected";
            ViewBag.PlayClass = "unselected";
            ViewBag.RegisterClass = "unselected";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
