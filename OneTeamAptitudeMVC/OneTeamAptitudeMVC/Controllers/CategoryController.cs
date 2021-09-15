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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowCategory",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<CategoryData>>(request);


            return View(dbResponse.Data);
        }
        [HttpGet]
        public ActionResult InsertCategory(int Id = 0)
        {
            CategoryData CategoryDataView = new CategoryData();

            //SetViewBag();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spCategoryDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<CategoryData>(request);
                CategoryDataView = dbResponse.Data;
            }
            return View(CategoryDataView);
        }
        [HttpPost]
        public ActionResult Save(CategoryDataView CategoryData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = CategoryData.ToJson(),
                ProcedureName = "spAddCategory",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<CategoryDataView>>(request);
            TempData["Message"] = CategoryData.Id > 0 ? "Category updated Successfully" : "new Category saved successfully";
            return RedirectToAction("CategoryHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeleteCategory",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<BrandData>>(request);
            return RedirectToAction("CategoryHomeMain");
        }
    }
}
