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
    [AptitudeAuthorizeAttributes(Roles = "Admin,Student")]
    public class StudyMaterialController : Controller
    {
        // GET: StudyMaterial
        [HttpGet]
        public ActionResult Index()
        {
            List<QuestionCategory> QnCatList = LevelQuestionAssignDTO.FillCat();
            ViewBag.QuestionCategory = QnCatList;
            return View();
        }
        [HttpPost]
        public ActionResult Index(StudyMaterials studyMaterials)
        {
            StudyMaterialsDTO.SaveStudyMaterials(studyMaterials);
            List<QuestionCategory> QnCatList = LevelQuestionAssignDTO.FillCat();
            ViewBag.QuestionCategory = QnCatList;
            return View(studyMaterials);
        }
        public string GetStudyMaterials(int id)
        {
            StudyMaterials studyMaterials = StudyMaterialsDTO.GetStudyMaterialData(id);
            return studyMaterials.StudyMaterialsData;
        }
        #region StudyMaterial
        [HttpGet]
        public ActionResult StudyMaterials()
        {
            List<StudyMaterials> studyMaterials = StudyMaterialsDTO.GetStudyMaterialsList();
            return View(studyMaterials);
        }
        #endregion

        public ActionResult ViewImportantFormulas(int CatId)
        {

            StudyMaterials studyMaterials = StudyMaterialsDTO.GetStudyMaterialData(CatId);

            return View(studyMaterials);
        }

    }
}