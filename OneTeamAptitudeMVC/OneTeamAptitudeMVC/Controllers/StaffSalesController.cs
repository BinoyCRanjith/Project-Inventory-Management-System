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
    public class StaffSalesController : Controller
    {
        // GET: StaffSales
        public ActionResult SalesHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowSales",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SalesData>>(request);


            return View(dbResponse.Data);
        }

        [HttpGet]
        public ActionResult SearchSales(string SearchText)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { SearchText }.ToJson(),
                ProcedureName = "spSearchSales",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SalesData>>(request);


            return View(dbResponse.Data);
        }


        [HttpGet]
        public ActionResult InsertSales(int Id = 0)
        {
            SalesData SalesDataView = new SalesData();

            setViewBag();
            setViewBag1();
            setViewBag2();
            setViewBag3();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spSalesDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<SalesData>(request);
                SalesDataView = dbResponse.Data;
            }
            return View(SalesDataView);
        }
        [HttpPost]
        public ActionResult Save(SalesDataView SalesData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = SalesData.ToJson(),
                ProcedureName = "spAddSales",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SalesDataView>>(request);
            TempData["Message"] = SalesData.Id > 0 ? "SalesData updated Successfully" : "new Sales saved successfully";
            return RedirectToAction("SalesHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeleteSales",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SalesData>>(request);
            return RedirectToAction("SalesHomeMain");
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
    }
}