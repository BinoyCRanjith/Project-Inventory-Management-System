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
    public class BrandController : Controller
    {
        // GET: Brand
        public ActionResult BrandHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowBrand",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<BrandData>>(request);


            return View(dbResponse.Data);
        }
        [HttpGet]
        public ActionResult InsertBrand(int Id = 0)
        {
            BrandData BrandDataView = new BrandData();

            //SetViewBag();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spBrandDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<BrandData>(request);
                BrandDataView = dbResponse.Data;
            }
            return View(BrandDataView);
        }
        [HttpPost]
        public ActionResult Save(BrandDataView BrandData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = BrandData.ToJson(),
                ProcedureName = "spAddBrand",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<BrandDataView>>(request);
            TempData["Message"] = BrandData.Id > 0 ? "Brand updated Successfully" : "new Brand saved successfully";
            return RedirectToAction("BrandHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeleteBrand",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<BrandData>>(request);
            return RedirectToAction("BrandHomeMain");
        }
    }
}