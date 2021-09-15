using OneTeamAptitudeMVC.AptitudeCore;
using OneTeamAptitudeMVC.Models;
using OneTeamAptitudeMVC.Scripts;
using OneTeamAptitudeMVC.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneTeamAptitudeMVC.Controllers
{
    [AptitudeAuthorizeAttributes(Roles = "Student")]

    public class UserController : Controller
    {
        int? UserId;

        public UserController()
        {
            User user = new Models.User();

            if (SessionManager.UserID != null && SessionManager.RollId == 1)
            {
                UserId = SessionManager.UserID;
                user = SessionManager.AuthenticatedUser;
            }


        }


        // GET: User
        public ActionResult Index()
        {
            User user = SessionManager.AuthenticatedUser;

            ExamStats examStats = new ExamStats();
            examStats = UserDTO.GetExamStats();
            SessionManager.ExamDetails = examStats;
            ViewBag.User = user;
            ViewBag.Username = user.Name;
            List<DataPoint> ExamHistory = ExamDTO.ExamHistory();
            ViewBag.ExamHistory = ExamHistory;
            return View(examStats);
        }
        [HttpPost]
        public ActionResult Index(ExamStats examStats)
        {
            ViewBag.message = "";
            //ActionResult action = new ExamController().Index(levelAssign.Category.Id, levelAssign.Level.Id);
            //return action;
            //Boolean b = ExamDTO.GetTodaysExam();
            //if (b)
            //{
                SessionManager.ExamCat = SessionManager.ExamDetails.QuestionCategory.Id;
                SessionManager.NoOfQn = SessionManager.ExamDetails.TotalQuestion;
                //ExamController examController = new ExamController(levelAssign.Level.Id,levelAssign.Passmark);

                return RedirectToAction("Index", "Exam");
            //}
            //else
            //{
            //    ViewBag.message = "You can Re attempt the Exam Tommorrow";
            //    User user = SessionManager.AuthenticatedUser;

            //    ExamStats examStats1 = SessionManager.ExamDetails;
            //    ViewBag.User = user;
            //    ViewBag.Username = user.Name;
            //    List<DataPoint> ExamHistory = ExamDTO.ExamHistory();
            //    ViewBag.ExamHistory = ExamHistory;
            //    return View(examStats1);


            //}
        }
        [HttpGet]
        public ActionResult StudentExamHistory()
        {
            List<ExamResult> ExamHisList = ExamDTO.ExamResultOfStud();
            return View(ExamHisList);
        }
        [HttpGet]
        public ActionResult ExamPractice()
        {
            List<ExamStats> ExStats = ExamDTO.QuickExamForStudent();
            return View(ExStats);
        }
        [HttpPost]
        public ActionResult ExamPractice(int CatId, int NoQn)
        {

            return View();
        }
        
    }
}