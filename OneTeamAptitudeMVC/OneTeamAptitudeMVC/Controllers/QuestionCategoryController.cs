using OneTeamAptitudeMVC.AptitudeCore;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Controllers
{
    [AptitudeAuthorizeAttributes(Roles = "Admin,Staff,Student")]

    public class QuestionCategoryController : Controller
    {
        // GET: QuestionCategory
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SaveCategory(string Category)
        {

           List<QuestionCategory> QuestionCategoryList= QuestioncategoryDTO.SaveQuestionCategory(Category);
            return Json(new { success = true, data = QuestionCategoryList }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategory(int id, string Cat)
        {

            List<QuestionCategory> QuestionCategoryList = QuestioncategoryDTO.UpdateCategory(id, Cat);
            return Json(new { success = true, data = QuestionCategoryList }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory(int id)
        {

            List<QuestionCategory> QuestionCategoryList = QuestioncategoryDTO.DeleteQnCategory(id);
            return Json(new { success = true, data = QuestionCategoryList }, JsonRequestBehavior.AllowGet);
        }


    }
}