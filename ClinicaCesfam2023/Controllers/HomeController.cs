using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus;
using ClinicaCesfam2023.Models;


namespace ClinicaCesfam2023.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            
            return View();
        }


        public ActionResult Final()
        {
            ViewBag.Message = "Your application description page.";

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