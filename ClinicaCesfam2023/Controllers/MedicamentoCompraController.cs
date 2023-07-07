    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Transbank.Common;
    using Transbank.Webpay.Common;
    using Transbank.Webpay.WebpayPlus;
    using ClinicaCesfam2023.Models;



    namespace ClinicaCesfam2023.Controllers
    {
        public class MedicamentoCompraController : Controller
        {
            public ActionResult Index(int? medicamentoId, string token_ws, int? cantidad)
            {


            var tx = new Transaction(new Options(IntegrationCommerceCodes.WEBPAY_PLUS, IntegrationApiKeys.WEBPAY, WebpayIntegrationType.Test));
            using (var db = new CesfamClinicaEntities())
            {
                var medicamento = db.medicamento.ToList();
                ViewBag.Medicamentos = new SelectList(medicamento, "id_med", "nombre");

                if (medicamentoId != null)
                {

                    var medicamentoSeleccionado = db.medicamento.FirstOrDefault(m => m.id_med == medicamentoId);

                    if (medicamentoSeleccionado != null)
                    {


                        if (medicamentoSeleccionado.cantidad >= cantidad)

                        {


                            medicamentoSeleccionado.cantidad -= cantidad.Value;
                            db.SaveChanges();


              
                            var amount = cantidad.Value * medicamentoSeleccionado.precio;
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
                        }

                        else
                        {
                            // Mostrar mensaje de error si no hay suficientes medicamentos disponibles
                            ViewBag.ErrorMessage = "No hay suficientes medicamentos disponibles.";
                        }




                    }


                }

            }


            return View();
        }









       
        
    }
}
