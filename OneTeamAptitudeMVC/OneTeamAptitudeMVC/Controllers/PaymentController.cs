using OneTeamAptitudeMVC.AptitudeCore;
using OneTeamAptitudeMVC.Constants;
using OneTeamAptitudeMVC.Helper;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Web.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PaymentMainHome()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowPaymentType",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<PaymentTypeData>>(request);


            return View(dbResponse.Data);
        }
        [HttpGet]
        public ActionResult InsertPayment(int Id = 0)
        {
            PaymentTypeData PaymentTypeDataView = new PaymentTypeData();

            //SetViewBag();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spPaymentDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<PaymentTypeData>(request);
                PaymentTypeDataView = dbResponse.Data;
            }
            return View(PaymentTypeDataView);
        }
        [HttpPost]
        public ActionResult Save(PaymentTypeDataView PaymentTypeData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = PaymentTypeData.ToJson(),
                ProcedureName = "spAddPayment",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<PaymentTypeDataView>>(request);
            TempData["Message"] = PaymentTypeData.Id > 0 ? "PaymentType updated Successfully" : "new PaymentType saved successfully";
            return RedirectToAction("PaymentMainHome");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeletePaymentType",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<PaymentTypeData>>(request);
            return RedirectToAction("PaymentMainHome");
        }
    }
}