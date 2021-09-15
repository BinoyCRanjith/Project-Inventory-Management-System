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
    public class SubcategoryController : Controller
    {
        // GET: Subcategory
        public ActionResult SubCategoryHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowSubCategory",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubcategoryData>>(request);


            return View(dbResponse.Data);
        }
        [HttpGet]
        public ActionResult InsertSubCategory(int Id = 0)
        {
            SubcategoryData SubCategoryDataView = new SubcategoryData();

            setViewBag();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spSubCategoryDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<SubcategoryData>(request);
                SubCategoryDataView = dbResponse.Data;
            }
            return View(SubCategoryDataView);
        }
        [HttpPost]
        public ActionResult Save(SubCategoryDataView SubcategoryData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = SubcategoryData.ToJson(),
                ProcedureName = "spAddSubCategory",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubCategoryDataView>>(request);
            TempData["Message"] = SubcategoryData.Id > 0 ? "Category updated Successfully" : "new Category saved successfully";
            return RedirectToAction("SubCategoryHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeleteSubCategory",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<SubcategoryData>>(request);
            return RedirectToAction("SubCategoryHomeMain");
        }
        private void setViewBag()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowCategory",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var CategoryList = dbRepository.GetResponse<List<CategoryData>>(request);
            CategoryList.Data.Insert(0, new CategoryData() { Id = 0, CategoryName = "--Select--" });


            ViewBag.CategoryList = CategoryList.Data;
        }
    }
}
