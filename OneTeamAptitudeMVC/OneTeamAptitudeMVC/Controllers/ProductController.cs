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
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductHomeMain()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowProduct",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ProductData>>(request);


            return View(dbResponse.Data);
        }
        [HttpGet]
        public ActionResult SearchProduct(string SearchText)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { SearchText }.ToJson(),
                ProcedureName = "spSearchProduct",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ProductData>>(request);


            return View(dbResponse.Data);
        }


        [HttpGet]
        public ActionResult InsertProduct(int Id = 0)
        {
            ProductData ProductDataView = new ProductData();

            setViewBag();
            setViewBag1();
            setViewBag2();
            if (Id > 0)
            {
                DbRequestBase request = new DbRequestBase
                {
                    InputJson = new { Id }.ToJson(),
                    ProcedureName = "spProductDetails",
                    RequestType = DbRequestType.Select
                };
                DbRepository dbRepository = new DbRepository();
                var dbResponse = dbRepository.GetResponse<ProductData>(request);
                ProductDataView = dbResponse.Data;

            }
            return View(ProductDataView);
        }
        [HttpPost]
        public ActionResult Save(ProductDataView ProductData)
        {

            DbRequestBase request = new DbRequestBase
            {
                InputJson = ProductData.ToJson(),
                ProcedureName = "spAddProduct",
                RequestType = DbRequestType.Insert
            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ProductDataView>>(request);
            TempData["Message"] = ProductData.Id > 0 ? "Product updated Successfully" : "new Product saved successfully";
            return RedirectToAction("ProductHomeMain");
        }

        public ActionResult Delete(int Id)
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { Id }.ToJson(),
                ProcedureName = "spDeleteProduct",
                RequestType = DbRequestType.Delete

            };
            DbRepository dbRepository = new DbRepository();
            var dbResponse = dbRepository.GetResponse<List<ProductData>>(request);
            return RedirectToAction("ProductHomeMain");
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
        private void setViewBag1()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowSubCategory",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var SubCategoryList = dbRepository.GetResponse<List<SubcategoryData>>(request);
            SubCategoryList.Data.Insert(0, new SubcategoryData() { Id = 0, SubCategoryName = "--Select--" });


            ViewBag.SubCategoryList = SubCategoryList.Data;
        }
        private void setViewBag2()
        {
            DbRequestBase request = new DbRequestBase
            {
                InputJson = new { }.ToJson(),
                ProcedureName = "spShowBrand",
                RequestType = DbRequestType.Select
            };
            DbRepository dbRepository = new DbRepository();
            var BrandList = dbRepository.GetResponse<List<BrandData>>(request);
            BrandList.Data.Insert(0, new BrandData() { Id = 0, BrandName = "--Select--" });


            ViewBag.BrandList = BrandList.Data;
        }
    }
}

