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
    public class TypeController : Controller
    {
        // GET: Type
        public ActionResult TypeHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowType",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<TypeData>>(request);


            return View(dbResponse.Data);
        }
        [HttpGet]
        public ActionResult InsertType(int Id = 0)
        {
            TypeData TypeDataView = new TypeData();

            //SetViewBag();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spTypeDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<TypeData>(request);
                TypeDataView = dbResponse.Data;
            }
            return View(TypeDataView);
        }
        [HttpPost]
        public ActionResult Save(TypeDataView TypeData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = TypeData.ToJson(),
                ProcedureName = "spAddType",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<TypeDataView>>(request);
            TempData["Message"] = TypeData.Id > 0 ? "Type updated Successfully" : "new Type saved successfully";
            return RedirectToAction("TypeHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeleteType",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<TypeData>>(request);
            return RedirectToAction("TypeHomeMain");
        }
    }
}