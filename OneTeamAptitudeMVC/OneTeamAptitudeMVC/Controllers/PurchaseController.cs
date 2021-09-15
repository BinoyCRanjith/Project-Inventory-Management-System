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
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult PurchaseHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowPurchase",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<PurchaseData>>(request);


            return View(dbResponse.Data);
        }

        [HttpGet]
        public ActionResult SearchPurchase(string SearchText)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { SearchText }.ToJson(),
                ProcedureName = "spSearchPurchase",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<PurchaseData>>(request);


            return View(dbResponse.Data);
        }

        [HttpGet]
        public JsonResult Purchasedetails(int Id = 0)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spPurchaseDetailsCall",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<PurchaseData>(request);
            var PurchaseDataView = dbResponse.Data;

            return Json(PurchaseDataView);
        }
        [HttpGet]
        public ActionResult InsertPurchase(int Id = 0)
        {
            PurchaseData PurchaseDataView = new PurchaseData();

            setViewBag();
            setViewBag1();
            setViewBag2();


            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spPurchaseDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<PurchaseData>(request);
                PurchaseDataView = dbResponse.Data;
            }
            return View(PurchaseDataView);
        }
        [HttpPost]
        public ActionResult Save(PurchaseDataView PurchaseData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = PurchaseData.ToJson(),
                ProcedureName = "spAddPurchase",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<PurchaseDataView>>(request);
            TempData["Message"] = PurchaseData.Id > 0 ? "Purchase updated Successfully" : "new Purchase saved successfully";
            return RedirectToAction("PurchaseHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeletePurchase",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<PurchaseData>>(request);
            return RedirectToAction("PurchaseHomeMain");
        }

        private void setViewBag()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowProduct",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var ProductList = dbRepository.GetResponse<List<ProductData>>(request);
            ProductList.Data.Insert(0, new ProductData() { Id = 0, ProductName = "--Select--" });


            ViewBag.ProductList = ProductList.Data;

        }
        private void setViewBag1()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowPaymentType",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var PaymentList = dbRepository.GetResponse<List<PaymentTypeData>>(request);
            PaymentList.Data.Insert(0, new PaymentTypeData() { Id = 0, PaymentMethod = "--Select--" });
            ViewBag.PaymentList = PaymentList.Data;
        }
        private void setViewBag2()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowStaffList",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var StaffList = dbRepository.GetResponse<List<StaffData>>(request);
            StaffList.Data.Insert(0, new StaffData() { Id = 0, Fullname = "--Select--" });
            ViewBag.StaffList = StaffList.Data;
        }
    }
}