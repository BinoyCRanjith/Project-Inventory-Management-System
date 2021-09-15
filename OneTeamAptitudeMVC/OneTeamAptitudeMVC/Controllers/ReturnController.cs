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
    public class ReturnController : Controller
    {
        // GET: Return
        public ActionResult ReturnHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowReturn",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ReturnData>>(request);


            return View(dbResponse.Data);
        }

        [HttpGet]
        public ActionResult SearchReturn(string SearchText)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { SearchText }.ToJson(),
                ProcedureName = "spSearchReturn",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ReturnData>>(request);


            return View(dbResponse.Data);
        }


        [HttpGet]
        public ActionResult InsertReturn(int Id = 0)
        {
            ReturnData ReturnDataView = new ReturnData();

            setViewBag();
            setViewBag1();
            setViewBag2();
            setViewBag3();
            setViewBag4();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spReturnDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<ReturnData>(request);
                ReturnDataView = dbResponse.Data;
            }
            return View(ReturnDataView);
        }
        [HttpPost]
        public ActionResult Save(ReturnDataView ReturnData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = ReturnData.ToJson(),
                ProcedureName = "spAddReturn",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ReturnDataView>>(request);
            TempData["Message"] = ReturnData.Id > 0 ? "Return Data updated Successfully" : "new Return Data saved successfully";
            return RedirectToAction("ReturnHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeletereturn",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ReturnData>>(request);
            return RedirectToAction("ReturnHomeMain");
        }

        public void setViewBag()
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
        public void setViewBag1()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowCustomerList",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var CustomerList = dbRepository.GetResponse<List<CustomerData>>(request);
            CustomerList.Data.Insert(0, new CustomerData() { Id = 0, Name = "--Select--" });


            ViewBag.CustomerList = CustomerList.Data;
        }

        private void setViewBag2()
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

        private void setViewBag3()
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
        private void setViewBag4()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowSales",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var SalesList = dbRepository.GetResponse<List<SalesData>>(request);
            SalesList.Data.Insert(0, new SalesData() { Id = 0, CustomerId = "--Select--" });
            ViewBag.SalesList = SalesList.Data;
        }
    }
}
    