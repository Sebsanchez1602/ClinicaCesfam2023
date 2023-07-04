using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transbank.Common;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus;


namespace ClinicaCesfam2023.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            var tx = new Transaction(new Options(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY, WebpayIntegrationType.Test));
            var amount = 2000;
            var buyOrder = new Random().Next(100000, 999999999).ToString();
            var sessionId = "sessionId";
            string finalUrl = "https://localhost:44363/Home/Final";

            var initResult = tx.Create(buyOrder, sessionId, amount, finalUrl);
            var tokenWs = initResult.Token;
            var formAction = initResult.Url;

            ViewBag.Amount = amount;
            ViewBag.BuyOrder = buyOrder;
            ViewBag.TokenWs = tokenWs;
            ViewBag.FormAction = formAction;

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