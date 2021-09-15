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
    public class StaffCustomerController : Controller
    {
        // GET: StaffCustomer
        public ActionResult CustomerHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowCustomerList",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<CustomerData>>(request);


            return View(dbResponse.Data);
        }

        [HttpGet]
        public ActionResult SearchCustomer(string SearchText)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { SearchText }.ToJson(),
                ProcedureName = "spSearchCustomerList",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<CustomerData>>(request);


            return View(dbResponse.Data);
        }
        [HttpGet]
        public ActionResult InsertCustomer(int Id = 0)
        {
            CustomerData CustomerData = new CustomerData();

            //SetViewBag();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spCustomerDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<CustomerData>(request);
                CustomerData = dbResponse.Data;
            }
            return View(CustomerData);
        }
        [HttpPost]
        public ActionResult Save(CustomData CustomerData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = CustomerData.ToJson(),
                ProcedureName = "spAddCustomerDetails",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<CustomData>>(request);
            TempData["Message"] = CustomerData.Id > 0 ? "User updated Successfully" : "new Customer saved successfully";
            return RedirectToAction("CustomerHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeleteCustomer",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<CustomerData>>(request);
            return RedirectToAction("CustomerHomeMain");
        }
    }
}