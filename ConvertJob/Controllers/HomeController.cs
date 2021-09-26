using PhilipsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConvertJob.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ConvertProcess process = new ConvertProcess();
            process.Start();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}