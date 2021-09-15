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
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult StaffHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowStaffList",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<StaffData>>(request);


            return View(dbResponse.Data);
        }

        [HttpGet]
        public ActionResult SearchStaff(string SearchText)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { SearchText }.ToJson(),
                ProcedureName = "spSearchStaffList",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<StaffData>>(request);


            return View(dbResponse.Data);
        }


        [HttpGet]
        public ActionResult InsertStaff(int Id = 0)
        {
            StaffData StaffDataView = new StaffData();

            setViewBag();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spStaffDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<StaffData>(request);
                StaffDataView = dbResponse.Data;
            }
            return View(StaffDataView);
        }
        [HttpPost]
        public ActionResult Save(StaffDataView StaffData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = StaffData.ToJson(),
                ProcedureName = "[spAddStaffDetails]",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<StaffDataView>>(request);
            TempData["Message"] = StaffData.Id > 0 ? "Staff updated Successfully" : "new Staff saved successfully";
            return RedirectToAction("StaffHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "[spDeleteStaff]",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<StaffData>>(request);
            return RedirectToAction("StaffHomeMain");
        }
        private void setViewBag()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowType",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var TypeList = dbRepository.GetResponse<List<TypeData>>(request);
            TypeList.Data.Insert(0, new TypeData() { Id = 0, Type = "--Select--" });


            ViewBag.TypeList = TypeList.Data;
        }
    }
}
